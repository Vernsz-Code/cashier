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
    public partial class frmPilihBarang : Form
    {
        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";

        public string SelectedKodeBarang { get; private set; }
        public event Action<BarangInfo> OnBarangInfoSelected;

        public frmPilihBarang()
        {
            InitializeComponent();
        }

        private void search()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT kode_brg, nama_brg, sisaBox, sisaPcs, hargaPcs, hargaBeli FROM tb_stok where kode_brg LIKE '%" + SEARCH.Text + "%' OR nama_brg LIKE '%" + SEARCH.Text + "%'"; // Ganti dengan nama tabel dan query Anda

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Mengecek apakah ada data yang bisa dibaca
                            if (reader.HasRows)
                            {
                                // Bersihkan DataGridView jika sudah ada data sebelumnya
                                dgv.Rows.Clear();

                                // Loop melalui hasil pembacaan
                                while (reader.Read())
                                {
                                    // Membaca nilai dari kolom-kolom yang sesuai
                                    int kodeBarang = reader.GetInt32(0);
                                    string namaBarang = reader.GetString(1);
                                    int sisaBox = reader.GetInt32(2);
                                    int sisaPcs = reader.GetInt32(3);
                                    decimal hargaJual = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);
                                    decimal modal = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5);

                                    string hargaRupiah = hargaJual.ToString("N0", new CultureInfo("id-ID"));
                                    string modalRupiah = modal.ToString("N0", new CultureInfo("id-ID"));

                                    // Menambahkan data ke DataGridView
                                    dgv.Rows.Add(kodeBarang, namaBarang, sisaBox, sisaPcs, hargaRupiah, modalRupiah);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Tidak ada data yang ditemukan.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan (qtbk): " + ex.Message);
                    }
                }
            }
        }

        private void LoadData()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT kode_brg, nama_brg, sisaBox, sisaPcs, hargaPcs, hargaBeli FROM tb_stok"; // Ganti dengan nama tabel dan query Anda

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Mengecek apakah ada data yang bisa dibaca
                            if (reader.HasRows)
                            {
                                // Bersihkan DataGridView jika sudah ada data sebelumnya
                                dgv.Rows.Clear();

                                // Loop melalui hasil pembacaan
                                while (reader.Read())
                                {
                                    // Membaca nilai dari kolom-kolom yang sesuai
                                    string kodeBarang = reader.GetString(0);
                                    string namaBarang = reader.GetString(1);
                                    int sisaBox = reader.GetInt32(2);
                                    int sisaPcs = reader.GetInt32(3);
                                    decimal hargaJual = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);
                                    decimal modal = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5);

                                    string hargaRupiah = hargaJual.ToString("N0", new CultureInfo("id-ID"));
                                    string modalRupiah = modal.ToString("N0", new CultureInfo("id-ID"));

                                    // Menambahkan data ke DataGridView
                                    dgv.Rows.Add(kodeBarang, namaBarang, sisaBox, sisaPcs, hargaRupiah, modalRupiah);

                                }
                            }
                            else
                            {
                                MessageBox.Show("Tidak ada data yang ditemukan.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan (qtbk): " + ex.Message);
                    }
                }
            }
        }

        private void SEARCH_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void frmPilihBarang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BarangInfo barangInfo = new BarangInfo
            {
                KodeBarang = KODEBRG.Text
            };

            OnBarangInfoSelected?.Invoke(barangInfo);

            this.Close();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv.Rows[e.RowIndex];
                KODEBARANG.Text = row.Cells["column2"].Value.ToString();
                KODEBRG.Text = row.Cells["column1"].Value.ToString();
                btnSave.Enabled = true;
            }
        }
    }
}
