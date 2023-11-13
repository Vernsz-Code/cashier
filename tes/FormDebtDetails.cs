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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tes
{
    public partial class FormDebtDetails : Form
    {
        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";
        decimal TotalHutang = 0;
        string Status = "";
        private string SelectedID;
        private string SelectedKodeBarang;

        public string tgl {  get; set; }
        public string faktur { get; set; }

        public FormDebtDetails()
        {
            InitializeComponent();
        }
        private void getDataPembayaran()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT tgl_pembayaran, tunai FROM pembayaran WHERE faktur = @faktur and tgl_pembelian = @tgl and jenis = 'hutang'";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@faktur", faktur);
                    cmd.Parameters.AddWithValue("@tgl", tgl);
                    try
                    {

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dgvPembayaran.Rows.Clear();
                                while (reader.Read())
                                {
                                    DateTime tgl = Convert.ToDateTime(reader["tgl_pembayaran"]);
                                    string strTgl = tgl.ToString("yyyy-MM-dd");
                                    decimal tunai = decimal.Parse(reader["tunai"].ToString());
                                    string strTunai = tunai.ToString("N0");

                                    dgvPembayaran.Rows.Add(strTgl, strTunai);
                                }

                                decimal total = 0;

                                for (int i = 0; i < dgvPembayaran.Rows.Count; i++)
                                {
                                    total += decimal.Parse(dgvPembayaran.Rows[i].Cells[1].Value.ToString().Replace(".", ""), CultureInfo.InvariantCulture);
                                }
                                TotalHutang = TotalHutang - total;
                                string totalText = total.ToString("N0", new CultureInfo("id-ID"));

                                string StrTotalHutang = TotalHutang.ToString("N0");

                                lbl_Sisa_Hutang.Text = StrTotalHutang;
                                dgvPembayaran.Rows.Add("TOTAL :", totalText);
                            }
                            else
                            {
                                Console.WriteLine("A");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi Kesalahan : 2 " + ex.Message);
                    }
                }
                conn.Close();
            }
        }
        private void refreshCart()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT * FROM transaction_in where no_faktur = @faktur and tgl = @tgl";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@faktur", faktur);
                cmd.Parameters.AddWithValue("@tgl", tgl);

                try
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgv.Rows.Clear();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["id"]);
                                string noFaktur = reader["no_faktur"].ToString();
                                DateTime tanggal = Convert.ToDateTime(reader["tgl"]);
                                string kode = reader["kode"].ToString();
                                string nama = reader["nama"].ToString();
                                string namaPelanggan = reader["suplier"].ToString();
                                int qty = Convert.ToInt32(reader["qty"]);
                                int retur = Convert.ToInt32(reader["retur"]);
                                decimal harga = Convert.ToDecimal(reader["harga"]);
                                string strharga = harga.ToString("N0", new CultureInfo("ID-id"));
                                lbl_NOFAKTUR.Text = noFaktur;
                                lbl_NAMA.Text = namaPelanggan;
                                decimal subtotal = qty * harga;
                                string strsubtotal = subtotal.ToString("N0", new CultureInfo("ID-id"));
                                string tanggalFormatted = tanggal.ToString("yyyy-MM-dd");
                                Image deleteIcon = Properties.Resources.icons8_delete_24px_1;
                                
                                dgv.Rows.Add(id, kode, nama, strharga, qty, retur, strsubtotal, subtotal, deleteIcon);
                            }
                            decimal total = 0;
                            int qtys = 0;
                            int returs = 0;
                            for (int i = 0; i < dgv.Rows.Count;)
                            {
                                total += decimal.Parse(dgv.Rows[i].Cells[7].Value.ToString());
                                qtys += int.Parse(dgv.Rows[i].Cells[4].Value.ToString());
                                returs += int.Parse(dgv.Rows[i].Cells[5].Value.ToString());
                                i++;
                            }
                            string totalText = total.ToString("N0", new CultureInfo("id-ID"));
                            Image emptyIcon = Properties.Resources.emptyIcon;

                            TotalHutang = total;

                            dgv.Rows.Add("", "", "TOTAL :", "", qtys, returs, totalText, "", emptyIcon);
                            lbl_Sisa_Hutang.Text = totalText;
                            getDataPembayaran();
                        }
                    }
                }
                catch(Exception ex)
                { MessageBox.Show("Terjadi kesalahan : ", ex.Message); }
            }
            connection.Close();
        }

        private void addPembayaran()
        {
            try
            {
                string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
                string query = "INSERT INTO pembayaran (tgl_pembelian, tunai, tgl_pembayaran, faktur, jenis) values (@tgl, @tunai, @tgl_p, @faktur, 'hutang')";

                string tgl_p = DateTime.Now.ToString("yyyy-MM-dd");

                decimal tunai = decimal.Parse(inputBayar.Text);



                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@tgl", tgl);
                        cmd.Parameters.AddWithValue("@tgl_p", tgl_p);
                        cmd.Parameters.AddWithValue("@tunai", tunai);
                        cmd.Parameters.AddWithValue("@faktur", faktur);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                MessageBox.Show("Data Berhasil Ditambahkan!");
                inputBayar.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi Kesalahan Saat Insert Data Pembayaran:", ex.Message);
            }
        }

        private void updateStatus()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "update transaction_in set payment = 'tunai' WHERE no_faktur = @faktur and DATE(tgl) = @tgl";
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@faktur", faktur);
                cmd.Parameters.AddWithValue("@tgl", tgl);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void bannerStatus()
        {
            decimal hutang = decimal.Parse(lbl_Sisa_Hutang.Text.Replace(".", ""));
            if (hutang > 0)
            {
                guna2CustomGradientPanel1.FillColor = Color.Orange;
                guna2CustomGradientPanel1.FillColor2 = Color.Orange;
                guna2CustomGradientPanel1.FillColor3 = Color.Orange;
                guna2CustomGradientPanel1.FillColor4 = Color.Orange;
                pictureBox2.Image = Properties.Resources.icons8_cancel_2_filled_48px;
                label6.Text = "Tidak Lunas";
            }
            else
            {
                guna2CustomGradientPanel1.FillColor = System.Drawing.SystemColors.Highlight;
                guna2CustomGradientPanel1.FillColor2 = System.Drawing.SystemColors.Highlight;
                guna2CustomGradientPanel1.FillColor3 = System.Drawing.SystemColors.Highlight;
                guna2CustomGradientPanel1.FillColor4 = System.Drawing.SystemColors.Highlight;
                pictureBox2.Image = Properties.Resources.icons8_ok_48px;
                label6.Text = "Lunas";
                updateStatus();
            }
        }

        private void updateStock(int qty, string kode)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "UPDATE product set masuk = masuk - @qty where kode_brg = @kode";

            MySqlConnection conn = new MySqlConnection(connectionString);

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                conn.Open();
                try
                {
                    cmd.Parameters.AddWithValue("@qty", qty);
                    cmd.Parameters.AddWithValue("@kode", kode);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan", ex.Message);
                }
                conn.Close();
            }
        }

        private void DeleteDataProduk(int id)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "DELETE FROM transaction_in where id = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                        MessageBox.Show("Data berhasil dihapus dan stok sudah di Pulihkan, Tidak Perlu tekan tombol Save! Langsung Close saja", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refreshCart();
                    }
                    else
                    {
                        MessageBox.Show("Data tidak ditemukan atau gagal dihapus");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi Kesalahan ketika menghapus data!", ex.Message);
                }
            }

        }

        private void updateRetur(int qty, string id)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "UPDATE transaction_in set retur = retur +  @qty where id = @id";
            int idc = int.Parse(id);
            if (DIRETUR.Value != DIRETUR.Maximum)
            {
                MySqlConnection conn = new MySqlConnection(connectionString);

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {

                    conn.Open();
                    try
                    {
                        cmd.Parameters.AddWithValue("@qty", qty);
                        cmd.Parameters.AddWithValue("@id", idc);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Barang Berhasil Diretur!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan", ex.Message);
                    }
                    conn.Close();
                }
            }
            else
            {
                DeleteDataProduk(idc);
            }
        }

        private void clearPanel()
        {
            SelectedKodeBarang = "";
            KodeBarang.Text = "";
            NAMABARANG.Text = "";
            HARGA.Text = "";
            DIBELI.Value = 0;
            SUBTOTAL.Text = "";
            DIRETUR.Value = 0;
        }

        private void FormDebtDetails_Load(object sender, EventArgs e)
        {
            refreshCart();
            lbl_Tanggal.Text = tgl;
            bannerStatus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            addPembayaran();
            refreshCart();
            bannerStatus();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv.Rows[e.RowIndex];
                SelectedID = row.Cells["ID"].Value.ToString();
                SelectedKodeBarang = row.Cells["Column1"].Value.ToString();
                KodeBarang.Text = row.Cells["Column1"].Value.ToString();
                NAMABARANG.Text = row.Cells["Column2"].Value.ToString();
                HARGA.Text = row.Cells["Column3"].Value.ToString();
                DIBELI.Text = row.Cells["Column4"].Value.ToString();
                SUBTOTAL.Text = row.Cells["Column5"].Value.ToString();
                //decimal diRetur = Convert.ToDecimal(row.Cells["Column7"].Value);
                DIRETUR.Value = 0;
                DIRETUR.Maximum = DIBELI.Value;
                DIRETUR.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv.Columns["DeleteIcon"].Index && e.RowIndex >= 0)
            {
                int IDToDelete = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["ID"].Value);
                int retur = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Column4"].Value);
                string kodeBarang = dgv.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                updateStock(retur, kodeBarang);
                DeleteDataProduk(IDToDelete);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string kode = KodeBarang.Text;
            int retur = Convert.ToInt32(DIRETUR.Text);
            updateStock(retur, kode);
            updateRetur(retur, SelectedID);
            refreshCart();
            clearPanel();
        }
    }
}
