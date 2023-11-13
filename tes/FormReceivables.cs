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
    public partial class FormReceivables : Form
    {
        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";

        public FormReceivables()
        {
            InitializeComponent();
        }

        private void GetDataByDate()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT no_faktur, MAX(tgl) as tgl, MAX(id) as id, MAX(namaPelanggan) as nama, SUM(qty) as total_barang, SUM(subtotal) as total_harga FROM transaction WHERE DATE(tgl) = DATE(@tgl) AND payment = 'kredit' GROUP BY no_faktur; ";

            DateTime tgl = STARTDATE.Value;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Mengatur parameter tanggal
                    cmd.Parameters.Add("@tgl", MySqlDbType.DateTime).Value = tgl;

                    Console.WriteLine(tgl);
                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Mengecek apakah ada data yang bisa dibaca
                            dgv.Rows.Clear();
                            if (reader.HasRows)
                            {
                                // Bersihkan DataGridView jika sudah ada data sebelumnya

                                // Loop melalui hasil pembacaan
                                while (reader.Read())
                                {
                                    // Mengambil nilai dari hasil pembacaan
                                    string noFaktur = reader["no_faktur"].ToString();
                                    DateTime tanggal = Convert.ToDateTime(reader["tgl"]);
                                    string nama = reader["nama"].ToString();
                                    int qty = Convert.ToInt32(reader["total_barang"]);
                                    string id = reader["id"].ToString();
                                    decimal harga = Convert.ToDecimal(reader["total_harga"]);
                                    string strharga = harga.ToString("N0", new CultureInfo("ID-id"));
                                    string tanggalFormatted = tanggal.ToString("yyyy-MM-dd");

                                    Image editIcon = Properties.Resources.icons8_info_24px_1;
                                    // Tambahkan data ke DataGridView
                                    dgv.Rows.Add(id, noFaktur, tanggalFormatted, nama, qty, strharga, editIcon);

                                }

                                decimal total = 0;
                                int qtys = 0;

                                for (int i = 0; i < dgv.Rows.Count;) 
                                {
                                    total += decimal.Parse(dgv.Rows[i].Cells[5].Value.ToString());
                                    qtys += int.Parse(dgv.Rows[i].Cells[4].Value.ToString());
                                    i++;
                                }

                                string totalText = total.ToString();
                                Image emptyIcon = Properties.Resources.emptyIcon;

                                // Tambahkan baris TOTAL ke DataGridView
                                dgv.Rows.Add("", "", "", "TOTAL :", qtys, totalText, emptyIcon);
                            }
                            else
                            {
                                Console.WriteLine("A");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan: " + ex.Message);
                    }
                }
            }
        }

        private void FormReceivables_Load(object sender, EventArgs e)
        {
            STARTDATE.Value = DateTime.Now;
        }
        private void STARTDATE_ValueChanged(object sender, EventArgs e)
        {
            GetDataByDate();
            DateTime tgl = STARTDATE.Value;
        }

        private void FormReceivablesDetails_FormClosing(object sender, FormClosedEventArgs e)
        {
            GetDataByDate();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv.Columns["column4"].Index && e.RowIndex >= 0)
            {
                string nofaktur = dgv.Rows[e.RowIndex].Cells["column1"].Value.ToString();

                if(nofaktur != "")
                {
                    string rawTgl = dgv.Rows[e.RowIndex].Cells["column2"].Value.ToString();
                    string faktur = dgv.Rows[e.RowIndex].Cells["column1"].Value.ToString();
                    DateTime tgl = DateTime.Parse(rawTgl);
                    // Mengambil nilai tanggal dari sel dan memformatnya
                    string formattedTgl = tgl.ToString("yyyy-MM-dd");
                    /*FormCetakFaktur frmCetak = new FormCetakFaktur();
                    frmCetak.no_faktur = nofaktur;
                    frmCetak.tgl = formattedTgl;
                    frmCetak.ShowDialog();*/
                    FormReceivablesDetails formPiutang = new FormReceivablesDetails();
                    formPiutang.SelectedKode = faktur;
                    formPiutang.tgl = formattedTgl;
                    formPiutang.FormClosed += new FormClosedEventHandler(FormReceivablesDetails_FormClosing);
                    formPiutang.ShowDialog();

                }

            }
        }
    }
}
