using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace tes
{
    public partial class FormKasir : Form
    {
        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";

        public FormKasir()
        {
            InitializeComponent();
        }
        void LoadNoFaktur()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT MAX(no_faktur) FROM transaction WHERE DATE(tgl) = DATE(@tgl)";
            DateTime waktu = new DateTime();
            waktu = DateTime.Now;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@tgl", waktu);
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        int highestFaktur = Convert.ToInt32(result);
                        int nextFaktur = highestFaktur + 1;
                        lbl_NOFAKTUR.Text = nextFaktur.ToString();
                    }
                    else
                    {
                        lbl_NOFAKTUR.Text = "1";
                    }
                }
            }
        }
        private void ClearAll()
        {
            txtBayar.Text = "";

            dgv.Rows.Clear();

            lbl_TotalBarang.Text = "0";
            lbl_TotalHarga.Text = "Rp0,00";
            lbl_TotalDiskon.Text = "Rp0,00";
            lbl_TotalBayar.Text = "Rp0,00";
            lbl_Kembalian.Text = "Rp0,00";
            LoadNoFaktur();
        }

        private void FormKasir_Load(object sender, EventArgs e)
        {
            txtScan.Focus();
            LoadNoFaktur();
        }
        private void LoadData(string kode_brg)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();

                string query = "SELECT * FROM product WHERE kode_brg = @kode_brg and stok_akhir > 0;";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@kode_brg", kode_brg);

                    bool found = false;

                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Cells["KodeBarang"].Value != null && row.Cells["KodeBarang"].Value.ToString() == kode_brg.ToUpper())
                        {
                            int rowIndex = row.Index;
                            int qty = Convert.ToInt32(dgv.Rows[rowIndex].Cells["Qty"].Value) + 1;
                            int stok = Convert.ToInt32(dgv.Rows[rowIndex].Cells["Stok"].Value);

                            if (stok < qty)
                            {
                                MessageBox.Show("Stok tidak mencukupi untuk menambahkan barang.");
                                txtScan.Text = "";
                                found = true;
                            }
                            else
                            {
                                dgv.Rows[rowIndex].Cells["Qty"].Value = qty;

                                decimal hargaJual = Convert.ToDecimal(row.Cells["HargaJual"].Value);
                                decimal subtotal = qty * hargaJual;
                                dgv.Rows[rowIndex].Cells["Subtotal"].Value = subtotal;

                                txtScan.Text = "";
                                UpdateTotalLabels();
                                found = true;
                            }

                        }
                    }

                    if (!found)
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string kodeBarang = reader["kode_brg"].ToString();
                                string namaBarang = reader["nama_brg"].ToString();
                                string stok = reader["stok_akhir"].ToString();
                                decimal hargaJual = Convert.ToDecimal(reader["jual"]);
                                decimal markUp = Convert.ToDecimal(reader["mark_up"]);

                                int qty = 1;
                                decimal subtotal = qty * hargaJual;

                                Image deleteIcon = Properties.Resources.icons8_delete_24px_1;

                                dgv.Rows.Add(kodeBarang, namaBarang, hargaJual, qty, "0", "0", subtotal, stok, markUp, markUp, deleteIcon);
                                txtScan.Text = "";
                            }
                            else
                            {
                                //MessageBox.Show("Data Tidak Di Temukan Atau Stok Habis!!!");
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void txtScan_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtScan.Text);
        }
        private void UpdateTotalLabels()
        {
            decimal totalQty = 0;
            decimal totalHargaJual = 0;
            decimal totalDiskon = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Qty"].Value != null)
                {
                    totalQty += Convert.ToDecimal(row.Cells["Qty"].Value);
                }

                if (row.Cells["Subtotal"].Value != null)
                {
                    totalHargaJual += Convert.ToDecimal(row.Cells["Subtotal"].Value);
                }

                if (row.Cells["Disc"].Value != null)
                {
                    totalDiskon += Convert.ToDecimal(row.Cells["Disc"].Value);
                }
            }

            decimal totalBayar = totalHargaJual - totalDiskon;

            lbl_TotalBarang.Text = totalQty.ToString();
            lbl_TotalHarga.Text = totalHargaJual.ToString("N0", new CultureInfo("id-ID"));
            lbl_TotalDiskon.Text = totalDiskon.ToString("N0", new CultureInfo("id-ID"));
            lbl_TotalBayar.Text = totalBayar.ToString("N0", new CultureInfo("id-ID"));
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTotalLabels();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                if (e.ColumnIndex == dgv.Columns["Qty"].Index)
                {
                    int newQty = Convert.ToInt32(row.Cells["Qty"].Value);
                    decimal hargaJual = Convert.ToDecimal(row.Cells["HargaJual"].Value);

                    decimal subtotal = newQty * hargaJual;
                    row.Cells["Subtotal"].Value = subtotal;

                    //Laba
                    decimal markUp = Convert.ToDecimal(row.Cells["MarkUp"].Value);

                    decimal laba = markUp * newQty;
                    row.Cells["Laba"].Value = laba;
                }
                else if (e.ColumnIndex == dgv.Columns["HargaJual"].Index)
                {
                    int qty = Convert.ToInt32(row.Cells["Qty"].Value);
                    decimal newHargaJual = Convert.ToDecimal(row.Cells["HargaJual"].Value);

                    decimal subtotal = qty * newHargaJual;
                    row.Cells["Subtotal"].Value = subtotal;
                }
                else if (e.ColumnIndex == dgv.Columns["DiscPercent"].Index)
                {
                    int qty = Convert.ToInt32(row.Cells["Qty"].Value);
                    decimal hargaJual = Convert.ToDecimal(row.Cells["HargaJual"].Value);
                    decimal discPercent = Convert.ToDecimal(row.Cells["DiscPercent"].Value);

                    decimal diskon = (hargaJual * discPercent / 100) * qty;
                    row.Cells["Disc"].Value = diskon;
                }
                else if (e.ColumnIndex == dgv.Columns["Disc"].Index)
                {
                    int qty = Convert.ToInt32(row.Cells["Qty"].Value);
                    decimal disc = Convert.ToDecimal(row.Cells["Disc"].Value);

                    decimal hargaJual = Convert.ToDecimal(row.Cells["HargaJual"].Value);
                    decimal discPercent = (disc / (hargaJual * qty)) * 100;
                    row.Cells["DiscPercent"].Value = discPercent;
                }
            }
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                if (e.ColumnIndex == dgv.Columns["HargaJual"].Index || e.ColumnIndex == dgv.Columns["Subtotal"].Index || e.ColumnIndex == dgv.Columns["Disc"].Index)
                {
                    if (e.Value is decimal)
                    {
                        e.Value = ((decimal)e.Value).ToString("N0", new CultureInfo("id-ID"));
                    }
                }
            }
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateTotalLabels();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv.Columns["btnDelete"].Index && e.RowIndex >= 0)
            {
                dgv.Rows.RemoveAt(e.RowIndex);

                UpdateTotalLabels();
            }
        }

        private void kurangStok()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    string kodeBarang = row.Cells["KodeBarang"].Value.ToString();
                    int qty = Convert.ToInt32(row.Cells["Qty"].Value);

                    string kueri = "update product set keluar = keluar + @qty where kode_brg = @kode";

                    MySqlCommand cmd = new MySqlCommand(kueri, conn);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("kode", kodeBarang);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                decimal totalBayar = decimal.Parse(lbl_TotalBayar.Text, NumberStyles.Currency, new CultureInfo("id-ID"));

                decimal jumlahBayar = decimal.Parse(txtBayar.Text, NumberStyles.Currency, new CultureInfo("id-ID"));

                decimal sisa = totalBayar - jumlahBayar;

                lbl_Kembalian.Text = sisa.ToString("N0", new CultureInfo("id-ID"));
                MessageBox.Show($"Sisa Hutang: {sisa.ToString("N0", new CultureInfo("id-ID"))}", "Hutang" , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                decimal totalBayar = decimal.Parse(lbl_TotalBayar.Text, NumberStyles.Currency, new CultureInfo("id-ID"));

                decimal jumlahBayar = decimal.Parse(txtBayar.Text, NumberStyles.Currency, new CultureInfo("id-ID"));

                if (jumlahBayar < totalBayar)
                {
                    MessageBox.Show("Jumlah bayar kurang dari total bayar.\nHarap periksa kembali jumlah bayar.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    decimal kembalian = jumlahBayar - totalBayar;
                    lbl_Kembalian.Text = kembalian.ToString("N0", new CultureInfo("id-ID"));

                    MessageBox.Show($"Kembalian: {kembalian.ToString("N0", new CultureInfo("id-ID"))}", "Kembalian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void insertToKas(string kode)
        {
            try
            {
                string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
                string query = "INSERT INTO pembayaran (tgl_pembelian, tunai, tgl_pembayaran, faktur, jenis) values (@tgl, @tunai, @tgl_p, @faktur, 'piutang')";

                string tgl_p = DateTime.Now.ToString("yyyy-MM-dd");

                decimal tunai = decimal.Parse(txtBayar.Text);



                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@tgl", tgl_p);
                        cmd.Parameters.AddWithValue("@tgl_p", tgl_p);
                        cmd.Parameters.AddWithValue("@tunai", tunai);
                        cmd.Parameters.AddWithValue("@faktur", kode);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show("Data Berhasil Ditambahkan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan Saat Insert Data Pembayaran:", ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                label5.Visible = true;
                label7.Text = "Sisa :";
                label6.Text = "Dp : Rp";
                namaTextBox.Visible = true;
            }
            else
            {
                label5.Visible = false;
                label6.Text = "Bayar : Rp";
                label7.Text = "Kembalian :";
                namaTextBox.Visible = false;
            }
        }

        private void insert()
        {
            string noFaktur = lbl_NOFAKTUR.Text;
            kurangStok();
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    string kodeBarang = row.Cells["KodeBarang"].Value.ToString();
                    string nama = row.Cells["NamaBarang"].Value.ToString();
                    int qty = Convert.ToInt32(row.Cells["Qty"].Value);
                    decimal hargaJual = Convert.ToDecimal(row.Cells["HargaJual"].Value);
                    decimal subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value);
                    decimal markUp = Convert.ToDecimal(row.Cells["MarkUp"].Value);
                    decimal laba = Convert.ToDecimal(row.Cells["Laba"].Value);
                    string namaPelanggan;
                    string payment;
                    decimal Tunai = decimal.Parse(txtBayar.Text.ToString().Replace(".", ""));

                    if (checkBox1.Checked)
                    {
                        payment = "kredit";
                        namaPelanggan = namaTextBox.Text;
                    }
                    else
                    {
                        payment = "tunai";
                        namaPelanggan = "-";
                    }

                    string insertQuery = "INSERT INTO transaction (no_faktur, kode, nama, qty, harga, subtotal, mark_up, laba, payment, namaPelanggan, Tunai, retur) " +
                                            "VALUES (@no_faktur, @kode_barang, @nama_barang, @qty, @harga_jual, @subtotal, @mark_up, @laba, @payment, @namaP, @Tunai, 0)";

                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@no_faktur", noFaktur);
                    command.Parameters.AddWithValue("@kode_barang", kodeBarang);
                    command.Parameters.AddWithValue("@nama_barang", nama);
                    command.Parameters.AddWithValue("@qty", qty);
                    command.Parameters.AddWithValue("@harga_jual", hargaJual);
                    command.Parameters.AddWithValue("@subtotal", subtotal);
                    command.Parameters.AddWithValue("@mark_up", markUp);
                    command.Parameters.AddWithValue("@laba", laba);
                    command.Parameters.AddWithValue("@payment", payment);
                    command.Parameters.AddWithValue("@namaP", namaPelanggan);
                    command.Parameters.AddWithValue("@Tunai", Tunai);

                    command.ExecuteNonQuery();

                }
                insertToKas(noFaktur);
                connection.Close();
                DateTime tgl = DateTime.Now;
                if(checkBox1.Checked == true) {
                FormCetakFaktur frmCetak = new FormCetakFaktur();
                frmCetak.no_faktur = noFaktur;
                frmCetak.tgl = tgl.ToString("yyyy-MM-dd");
                frmCetak.ShowDialog();
                }
                else
                {
                    FormCetakFakturTunai frmCetak = new FormCetakFakturTunai();
                    frmCetak.no_faktur = noFaktur;
                    frmCetak.tgl = tgl.ToString("yyyy-MM-dd");
                    frmCetak.ShowDialog();
                }
                ClearAll();
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtBayar.Text != "")
            {
                insert();
            }
            else
            {
                MessageBox.Show("Tunai Harus Di Isi");
            }
        }
    }
}
