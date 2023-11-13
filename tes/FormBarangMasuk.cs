using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace tes
{
    public partial class FormBarangMasuk : Form
    {
        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";

        public FormBarangMasuk()
        {
            InitializeComponent();
        }

        private void ClearString()
        {
            guna2TextBox3.Text = "";
            guna2TextBox4.Text = "";
            MODAL.Text = "";
            S_AWAL.Value = 0;
            S_AKHIR.Value = 0;
            B_MASUK.Value = 0;
            B_KELUAR.Value = 0;
            PENDAPATAN.Text = "";
            Harta.Text = "";
            HARGAJUAL1.Text = "";
            DISTRIBUTOR.Text = "";
            PERCENTASE.Text = "0";
            Harta.Text = "";
        }

        private void InsertData()
        {
            try
            {
                string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};AllowUserVariables=true;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                string kueri = "INSERT INTO product(kode_brg, nama_brg, stok_awal, suplier, beli, jual, mark_up, persentase, masuk, keluar, stok_akhir, pendapatan, laba, harta) values(@kode_brg, @nama_brg, @stok_awal, @suplier, @beli, @jual, @mark_up, @persentase, @masuk, @keluar, @stok_akhir, @pendapatan, @laba, @harta);";

                //data
                string kode_brg = guna2TextBox3.Text;
                string nama_brg = guna2TextBox4.Text;
                int stok_awal = int.Parse(S_AWAL.Value.ToString());
                int masuk = int.Parse(B_MASUK.Value.ToString());
                int keluar = int.Parse(B_KELUAR.Value.ToString());
                int stok_akhir = int.Parse(S_AKHIR.Value.ToString());
                string sup = DISTRIBUTOR.Text;

                if (sup == "")
                {
                    sup = "-";
                }

                decimal beli = decimal.Parse(MODAL.Text);
                decimal jual = decimal.Parse(HARGAJUAL1.Text);
                decimal markup = decimal.Parse(guna2TextBox2.Text);
                string pendapatan = PENDAPATAN.Text;

                //decimal result = hargaJual - hargaBeli;

                //string laba = result.ToString();
                string harta = Harta.Text;
                string percen = PERCENTASE.Text;
                //data

                using (MySqlCommand cmd = new MySqlCommand(kueri, connection))
                {
                    cmd.Parameters.AddWithValue("@kode_brg", kode_brg);
                    cmd.Parameters.AddWithValue("@nama_brg", nama_brg);
                    cmd.Parameters.AddWithValue("@stok_awal", stok_awal);
                    cmd.Parameters.AddWithValue("@masuk", 0);
                    cmd.Parameters.AddWithValue("@keluar", 0);
                    cmd.Parameters.AddWithValue("@stok_akhir", stok_awal);
                    cmd.Parameters.AddWithValue("@suplier", sup);
                    cmd.Parameters.AddWithValue("@beli", beli);
                    cmd.Parameters.AddWithValue("@jual", jual);
                    cmd.Parameters.AddWithValue("@mark_up", markup);
                    cmd.Parameters.AddWithValue("@pendapatan", 0);
                    cmd.Parameters.AddWithValue("@laba", 0);
                    cmd.Parameters.AddWithValue("@harta", 0);
                    cmd.Parameters.AddWithValue("@persentase", percen);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Data berhasil Ditambahkan!");
                }
            }
            catch (Exception ex)
            {
                // Tangani kesalahan dengan pesan yang lebih deskriptif
                MessageBox.Show("Terjadi kesalahan saat menambahkan data: " + ex.Message);
            }
        }

        void LoadNoFaktur()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT MAX(no_faktur) FROM transaction_in WHERE DATE(tgl) = DATE(@tgl)";
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

        private void LoadData(string kode_brg)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                string kode = kode_brg.ToUpper();
                string query = "SELECT * FROM product WHERE kode_brg = @kode_brg";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@kode_brg", kode);

                bool found = false;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells["KodeBarang"].Value != null && row.Cells["KodeBarang"].Value.ToString() == kode)
                    {
                        int rowIndex = row.Index;
                        int qty = Convert.ToInt32(dgv.Rows[rowIndex].Cells["Qty"].Value) + 1;

                        dgv.Rows[rowIndex].Cells["Qty"].Value = qty;

                        decimal hargaJual = Convert.ToDecimal(row.Cells["HargaJual"].Value);
                        decimal subtotal = qty * hargaJual;
                        dgv.Rows[rowIndex].Cells["Subtotal"].Value = subtotal;

                        txtScan.Text = "";
                        found = true;

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
                            string suplier = reader["suplier"].ToString();
                            decimal hargaJual = Convert.ToDecimal(reader["beli"]);

                            int qty = 1;
                            decimal subtotal = qty * hargaJual;

                            Image deleteIcon = Properties.Resources.icons8_delete_24px_1;

                            string hargaStr = hargaJual.ToString("N0");
                            string subtotalStr = subtotal.ToString("N0");

                            dgv.Rows.Add(kodeBarang, namaBarang, hargaStr, qty, subtotalStr, deleteIcon);
                            txtScan.Text = "";
                        }
                        else
                        {

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

        private void ClearAll()
        {
            txtScan.Text = "";

            dgv.Rows.Clear();

            namaTextBox.Text = "";
            checkBox1.Checked = false;
            LoadNoFaktur();
        }

        private void tambahStok()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    string kodeBarang = row.Cells["KodeBarang"].Value.ToString();
                    int qty = Convert.ToInt32(row.Cells["Qty"].Value);

                    string kueri = "update product set masuk = masuk + @qty, stok_akhir = stok_akhir + @qty where kode_brg = @kode";

                    MySqlCommand cmd = new MySqlCommand(kueri, conn);
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@kode", kodeBarang);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void insertToKas(string kode)
        {
            try
            {
                string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
                string query = "INSERT INTO pembayaran (tgl_pembelian, tunai, tgl_pembayaran, faktur, jenis) values (@tgl, @tunai, @tgl_p, @faktur, 'hutang')";

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

        private void InsertDatas()
        {

            string noFaktur = lbl_NOFAKTUR.Text;
            tambahStok();
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    string kodeBarang = row.Cells["KodeBarang"].Value.ToString();
                    string nama = row.Cells["NamaBarang"].Value.ToString();
                    int qty = Convert.ToInt32(row.Cells["Qty"].Value);
                    decimal hargaBeli = Convert.ToDecimal(row.Cells["HargaJual"].Value);
                    decimal subtotal = Convert.ToDecimal(row.Cells["Subtotal"].Value);
                    string namaSuplier;
                    string payment;

                    DateTime tgls = new DateTime();
                    tgls = DateTime.Now;

                    string tgl = tgls.ToString("yyyy-MM-dd");

                    if (checkBox1.Checked)
                    {
                        payment = "kredit";
                        namaSuplier = namaTextBox.Text;
                    }
                    else
                    {
                        payment = "tunai";
                        namaSuplier = "-";
                    }

                    string insertQuery = "INSERT INTO transaction_in (tgl, no_faktur, kode, nama, qty, suplier, payment, harga, subtotal, retur) " +
                                            "VALUES (@tgl, @no_faktur, @kode, @nama, @qty, @suplier, @payment, @harga, @subtotal, 0)";

                    MySqlCommand command = new MySqlCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@tgl", tgl);
                    command.Parameters.AddWithValue("@no_faktur", noFaktur);
                    command.Parameters.AddWithValue("@kode", kodeBarang);
                    command.Parameters.AddWithValue("@nama", nama);
                    command.Parameters.AddWithValue("@qty", qty);
                    command.Parameters.AddWithValue("@suplier", namaSuplier);
                    command.Parameters.AddWithValue("@payment", payment);
                    command.Parameters.AddWithValue("@harga", hargaBeli);
                    command.Parameters.AddWithValue("@subtotal", subtotal);

                    command.ExecuteNonQuery();
                    Console.WriteLine("a");
                }
                insertToKas(noFaktur);
                ClearAll();
            }
        }

        private void FormBarangMasuk_Load(object sender, EventArgs e)
        {
            txtScan.Focus();
            LoadNoFaktur();
        }

        private void txtScan_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtScan.Text);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            InsertData();
            LoadData(guna2TextBox3.Text);
            ClearString();
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv.Rows[e.RowIndex];

                if (e.ColumnIndex == dgv.Columns["Qty"].Index)
                {
                    int newQty = Convert.ToInt32(row.Cells["Qty"].Value);
                    decimal hargaJual = Convert.ToDecimal(row.Cells["HargaJual"].Value);

                    decimal subtotal = newQty * hargaJual;
                    row.Cells["Subtotal"].Value = subtotal;
                }
                else if (e.ColumnIndex == dgv.Columns["HargaJual"].Index)
                {
                    int qty = Convert.ToInt32(row.Cells["Qty"].Value);
                    decimal newHargaJual = Convert.ToDecimal(row.Cells["HargaJual"].Value);

                    decimal subtotal = qty * newHargaJual;
                    row.Cells["Subtotal"].Value = subtotal;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(namaTextBox.Text == "")
            {
                MessageBox.Show("Masukan Nama Supplier Terlebih Dahulu");
            }
            else
            {
                InsertDatas();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label16.Text = "Dp : Rp";
            }
            else
            {
                label16.Text = "Bayar : Rp";
            }
        }
    }
}
