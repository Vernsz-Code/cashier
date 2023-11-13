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
using System.Runtime.InteropServices.ComTypes;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System.IO;

namespace tes
{
    public partial class frmReport : Form
    {
        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";

        public frmReport()
        {
            InitializeComponent();
        }

        private void ExportToExcel(DataGridView dgv, string filePath)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            FileInfo excelFile = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(excelFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");

                int colIndex = 1;

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible)
                    {
                        worksheet.Cells[1, colIndex].Value = dgv.Columns[i].HeaderText;
                        colIndex++;
                    }
                }

                for (int row = 0; row < dgv.Rows.Count; row++)
                {
                    colIndex = 1;

                    for (int col = 0; col < dgv.Columns.Count; col++)
                    {
                        if (dgv.Columns[col].Visible)
                        {
                            worksheet.Cells[row + 2, colIndex].Value = dgv.Rows[row].Cells[col].Value;
                            colIndex++;
                        }
                    }
                }

                worksheet.Column(1).Width = 5;
                worksheet.Column(2).Width = 10;
                worksheet.Column(3).Width = 14;
                worksheet.Column(4).Width = 35;
                worksheet.Column(5).Width = 5;
                worksheet.Column(6).Width = 12;
                worksheet.Column(7).Width = 13;

                // Membuat tabel dan menerapkan gaya tabel
                var dataRange = worksheet.Cells["A1:" + worksheet.Cells[worksheet.Dimension.End.Row, worksheet.Dimension.End.Column].Address];
                var tbl = worksheet.Tables.Add(dataRange, "MyTable");
                tbl.TableStyle = TableStyles.Medium2;

                package.Save();
            }
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save as Excel File";
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.DefaultExt = "xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                ExportToExcel(dgv, filePath);
                MessageBox.Show("Data berhasil diekspor ke Excel.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetDataByDate()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT id, no_faktur, tgl, kode, nama, qty, harga, laba FROM transaction WHERE DATE(tgl) = DATE(@tgl) and payment = 'tunai'";

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
                                    int id = Convert.ToInt32(reader["id"]);
                                    string noFaktur = reader["no_faktur"].ToString();
                                    DateTime tanggal = Convert.ToDateTime(reader["tgl"]);
                                    string kode = reader["kode"].ToString();
                                    string nama = reader["nama"].ToString();
                                    int qty = Convert.ToInt32(reader["qty"]);
                                    decimal harga = Convert.ToDecimal(reader["harga"]);
                                    string strharga = harga.ToString("N0", new CultureInfo("ID-id"));
                                    decimal laba = Convert.ToDecimal(reader["laba"]);
                                    string strlaba = laba.ToString("N0", new CultureInfo("ID-id"));

                                    decimal subtotal = qty * harga;

                                    string strsubtotal = subtotal.ToString("N0", new CultureInfo("ID-id"));
                                    string tanggalFormatted = tanggal.ToString("yyyy-MM-dd");
                                    Image deleteIcon = Properties.Resources.icons8_delete_24px_1;

                                    // Tambahkan data ke DataGridView
                                    dgv.Rows.Add(id, noFaktur, tanggalFormatted, kode, nama, strharga, qty, strsubtotal, strlaba, laba, subtotal, deleteIcon);

                                }
                                
                                decimal total = 0;
                                decimal labas = 0;
                                int qtys = 0;
                                
                                for (int i = 0; i < dgv.Rows.Count;)
                                {
                                    total += decimal.Parse(dgv.Rows[i].Cells[10].Value.ToString());
                                    labas += decimal.Parse(dgv.Rows[i].Cells[9].Value.ToString());
                                    qtys += int.Parse(dgv.Rows[i].Cells[6].Value.ToString());
                                    i++;
                                }
                                Image emptyIcon = Properties.Resources.emptyIcon;
                                string totalText = total.ToString("N0", new CultureInfo("id-ID"));
                                string labaText = labas.ToString("N0", new CultureInfo("id-ID"));
                                dgv.Rows.Add("", "", "", "", "TOTAL :", "", qtys, totalText, labaText, "", "", emptyIcon);
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

        private void updateStock(int qty, string kode)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "UPDATE product set keluar = keluar - @qty where kode_brg = @kode";

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
            string query = "DELETE FROM transaction where id = @id";
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
                        MessageBox.Show("Data berhasil dihapus dan stok sudah di Pulihkan", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        GetDataByDate();
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

        private void frmReport_Load(object sender, EventArgs e)
        {
            STARTDATE.Value = DateTime.Now;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Apakah Anda Yakin Ingin Menghapus?", "Hapus", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (e.ColumnIndex == dgv.Columns["DeleteIcon"].Index && e.RowIndex >= 0)
                {
                    int IDToDelete = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["ID"].Value);
                    int retur = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Column5"].Value);
                    string kodeBarang = dgv.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
                    updateStock(retur, kodeBarang);
                    DeleteDataProduk(IDToDelete);
                }
            }
        }

        private void STARTDATE_ValueChanged(object sender, EventArgs e)
        {
            GetDataByDate();
            DateTime tgl = STARTDATE.Value;
        }

        

        private void PRINTALL_Click(object sender, EventArgs e)
        {

        }
        public static void exportExcel(string file, string formattedDate)
        {
            var customerList = new List<dataPenjualan>();

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            //ExcelPackage.LicenseContext = LicenseContext.Equals;
            using (ExcelPackage pck = new ExcelPackage())
            {
                pck.Workbook.Worksheets.Add("DataPenjualan" + formattedDate).Cells[1, 1].LoadFromCollection(customerList, true);
                pck.SaveAs(new FileInfo(file));
            }

        }

        public class dataPenjualan
        {
            public int faktur { get; set; }
            public string tanggal { get; set; }
            public string kode { get; set; }
            public string namaBarang { get; set; }
            public int QTY { get; set; }
            public decimal harga { get; set; }
            public decimal laba { get; set; }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
