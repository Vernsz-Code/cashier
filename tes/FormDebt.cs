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
    public partial class FormDebt : Form
    {
        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";

        public FormDebt()
        {
            InitializeComponent();
        }

        private void LoadLaporan()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT no_faktur, MAX(id) as id, MAX(tgl) as tgl, MAX(suplier) as suplier, SUM(qty) as qty, SUM(subtotal) as subtotal FROM transaction_in WHERE payment = 'kredit' and DATE(tgl) = @tgl GROUP BY no_faktur; ";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    string tglv = STARTDATE.Value.ToString("yyyy-MM-dd");
                    cmd.Parameters.AddWithValue("@tgl", tglv);
                    try
                    {
                        connection.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            dgv.Rows.Clear();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string ID = reader["id"].ToString();
                                    string No_faktur = reader["no_faktur"].ToString();
                                    DateTime Tgls = Convert.ToDateTime(reader["tgl"]);
                                    int Qty = Convert.ToInt32(reader["qty"]);
                                    string Supplier = reader["suplier"].ToString();
                                    decimal harga = Convert.ToDecimal(reader["subtotal"]);
                                    string Tgl = Tgls.ToString("yyyy-MM-dd");
                                    string hargaStr = harga.ToString("N0");
                                    Image editIcon = Properties.Resources.icons8_info_24px_1;

                                    dgv.Rows.Add(ID, No_faktur, Tgl, Supplier, Qty, hargaStr, editIcon);
                                }

                                decimal total = 0;
                                int qtys = 0;

                                for (int i = 0; i < dgv.Rows.Count;)
                                {
                                    total += decimal.Parse(dgv.Rows[i].Cells[5].Value.ToString());
                                    qtys += int.Parse(dgv.Rows[i].Cells[4].Value.ToString());
                                    i++;
                                }

                                string totalText = total.ToString("N0");
                                Image emptyIcon = Properties.Resources.emptyIcon;

                                // Tambahkan baris TOTAL ke DataGridView
                                dgv.Rows.Add("", "", "", "TOTAL :", qtys, totalText, emptyIcon);
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

        private void FormDebt_Load(object sender, EventArgs e)
        {
            STARTDATE.Value = DateTime.Now;
        }

        private void STARTDATE_ValueChanged(object sender, EventArgs e)
        {
            LoadLaporan();
        }
        private void FormDebtDetails_FormClosing(object sender, FormClosedEventArgs e)
        {
            LoadLaporan();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv.Columns["Icon"].Index && e.RowIndex >= 0)
            {
                string nofaktur = dgv.Rows[e.RowIndex].Cells["column1"].Value.ToString();

                if (nofaktur != "")
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
                    FormDebtDetails formHutang = new FormDebtDetails();
                    formHutang.faktur = faktur;
                    formHutang.tgl = formattedTgl;
                    formHutang.FormClosed += new FormClosedEventHandler(FormDebtDetails_FormClosing);
                    formHutang.ShowDialog();

                }

            }
        }
    }
}
