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
    public partial class FormRetur : Form
    {
        public string NoFaktur { get; set; }
        private string SelectedID;
        private string SelectedKode;

        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";
        public FormRetur()
        {
            InitializeComponent();
        }

        private void RefreshCart()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT kode_barang, nama_barang, nama_pelanggan, alamat, harga, subtotal, qty, id,total_harga, retur, Tunai, qtyawal FROM tb_transaksi WHERE no_faktur = @noFaktur";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@noFaktur", NoFaktur);

                        decimal totalHarga = 0;
                        int totalBarang = 0;

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dgv.Rows.Clear();

                                while (reader.Read())
                                {
                                    string namaBarang = reader.GetString(1);
                                    string levelHarga = reader.GetString(2);
                                    decimal subtotal = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5);
                                    int id = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
                                    decimal harga = reader.GetDecimal(4);
                                    int qty = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
                                    int qtyawal = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
                                    string nama = reader.GetString(2);
                                    string alamat = reader.GetString(3);
                                    int kode_barang = reader.GetInt32(0);
                                    int retur = reader.GetInt32(9);
                                    decimal Tunai = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10);
                                    decimal total = reader.IsDBNull(8) ? 0 : reader.GetDecimal(8);
                                    lbl_NAMA.Text = nama;
                                    lbl_NOFAKTUR.Text = NoFaktur;
                                    lbl_ALAMAT.Text = alamat;
                                    lbl_Tunai.Text = Tunai.ToString();

                                    string hargaBrg = harga.ToString("N0", new CultureInfo("id-ID"));
                                    string subTotal = subtotal.ToString("N0", new CultureInfo("id-ID"));

                                    Image editIcon = Properties.Resources.icons8_delete_24px_1;

                                    dgv.Rows.Add(id, kode_barang, namaBarang, qty, retur, hargaBrg, subTotal, editIcon, qtyawal);

                                    totalHarga += subtotal;
                                    totalBarang += qty;
                                }

                                lbl_TOTAL.Text = totalHarga.ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan oiioii 2: " + ex.Message);
                    }
                }
            }
        }

        private void FormRetur_Load(object sender, EventArgs e)
        {
            RefreshCart();
        }

        private void HapusDataBarangKeluar(int kodeBarangToDelete)
        {
            try
            {
                string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string deleteQuery = "DELETE FROM tb_transaksi WHERE id = @kodeBarangToDelete";

                MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection);
                deleteCmd.Parameters.AddWithValue("@kodeBarangToDelete", kodeBarangToDelete);

                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                    MessageBox.Show("Data berhasil dihapus dan stok sudah di Pulihkan, Tidak Perlu tekan tombol Save! Langsung Close saja", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCart();
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan atau gagal dihapus");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan 5: " + ex.Message);
            }
        }

        private void updateData()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            string harga = this.HARGA.Text;
            harga = harga.Replace(".", "");

            string subTotal = this.SUBTOTAL.Text;
            subTotal = subTotal.Replace(".", "");

            string subRetur = this.SUBRETUR.Text;
            subRetur = subRetur.Replace(".", "");

            string query = "UPDATE `tb_transaksi` SET " +
                    "`harga` = '" + harga + "', " +
                    "`subtotal` = '" + subTotal + "', " + "`QTY` = `QTY` - '" + this.DIRETUR.Text + "', " + 
                    "`retur` = '" + this.DIRETUR.Text + "', " +
                    "`subretur` = `subretur` + '" + subRetur + "' " +
                    "WHERE `id` = '" + SelectedID + "'";

            if (DIRETUR.Value != DIRETUR.Maximum)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        try
                        {
                            connection.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Berhasil Retur barang dengan Kode : " + SelectedID);
                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                HapusDataBarangKeluar(Convert.ToInt32(SelectedID));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateStok(SelectedKode);
            updateData();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv.Rows[e.RowIndex];
                SelectedID = row.Cells["ID"].Value.ToString();
                SelectedKode = row.Cells["column1"].Value.ToString();
                NAMABARANG.Text = row.Cells["column2"].Value.ToString();
                HARGA.Text = row.Cells["column4"].Value.ToString();
                DIBELI.Text = row.Cells["column3"].Value.ToString();
                SUBTOTAL.Text = row.Cells["column5"].Value.ToString();
                decimal diRetur = Convert.ToDecimal(row.Cells["column7"].Value);
                DIRETUR.Value = diRetur;
                sum.Text = row.Cells["column8"].Value.ToString(); ;
                DIRETUR.Maximum = DIBELI.Value;
                DIRETUR.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;
                //MessageBox.Show()
            }
        }

        private void DIRETUR_ValueChanged(object sender, EventArgs e)
        {
            string hargaText = HARGA.Text;

            int jumlahBarangRetur = Convert.ToInt32(DIRETUR.Value);

            int jumlahBarang = Convert.ToInt32(DIBELI.Value);

            decimal totalHargaRetur = 0;

            decimal totalHarga = 0;

            if (decimal.TryParse(hargaText, out decimal harga))
            {
                totalHargaRetur = harga * jumlahBarangRetur;
            }
            
            if (decimal.TryParse(hargaText, out decimal hargaa))
            {
                totalHarga = hargaa * jumlahBarang;
            }

            SUBRETUR.Text = totalHargaRetur.ToString();

            SUBTOTAL.Text = totalHarga.ToString();

            int sumValue = Convert.ToInt32(sum.Value);
            int direturValue = Convert.ToInt32(DIRETUR.Value);

            DIBELI.Value = sumValue - direturValue;
        }

        public void TambahStok(string kodeBarang, int jumlahDikurangkan)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "UPDATE tb_stok SET sisaPcs = sisaPcs + @jumlahDikurangkan WHERE kode_brg = @kodeBarang";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@kodeBarang", kodeBarang);
                    cmd.Parameters.AddWithValue("@jumlahDikurangkan", jumlahDikurangkan);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan 1.3: " + ex.Message);
                    }
                }
            }
        }

        private void UpdateStok(string kodeBarang)
        {
            int sisaBox = GetStokSatuan(kodeBarang);

            int retur = int.Parse(DIRETUR.Text);

            TambahStok(kodeBarang, retur);
        }

        public int GetStokSatuan(string kodeBarang)
        {
            int jumlahBarangAwal = 0;

            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT sisaPcs FROM tb_stok WHERE kode_brg = @kodeBarang";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@kodeBarang", kodeBarang);

                    try
                    {
                        connection.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        jumlahBarangAwal = Convert.ToInt32(result);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan 1.1: " + ex.Message);
                    }
                }
            }

            return jumlahBarangAwal;
        }

        private void UpdateStokDeleted(string kodeBarang, int retur)
        {
            int sisaBox = GetStokSatuan(kodeBarang);

            //Console.WriteLine("Var: " + kodeBarang + " | " + retur + " | " + lempengPerBox);

            TambahStok(kodeBarang, retur);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv.Columns["Column6"].Index && e.RowIndex >= 0)
            {
                int kodeBarangToDelete = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["ID"].Value);
                int retur = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Column7"].Value);
                string kodeBarang = dgv.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                HapusDataBarangKeluar(kodeBarangToDelete);
                UpdateStokDeleted(kodeBarang, retur);
            }
        }
    }
}
