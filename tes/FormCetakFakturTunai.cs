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
using Microsoft.Reporting.WinForms;

namespace tes
{
    public partial class FormCetakFakturTunai : Form
    {
        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";

        DataSet1 dataSet1 = new DataSet1();

        public string no_faktur { get; set; }
        public string tgl { get; set; }
        public FormCetakFakturTunai()
        {
            InitializeComponent();
        }

        private void FormCetakFakturTunai_Load(object sender, EventArgs e)
        {

            Console.WriteLine(tgl);
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "select no_faktur, tgl, nama, kode, harga, qty, subtotal, Tunai from transaction where no_faktur = '" + no_faktur + "' AND Date(tgl) = '" + tgl + "' ;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(dataSet1, "DataSourceProduk");
                }
            }

            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dataSet1.Tables["DataSourceProduk"]);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            reportViewer1.LocalReport.ReportPath = $"{Application.StartupPath}/Report2.rdlc";

            reportViewer1.SetPageSettings(new System.Drawing.Printing.PageSettings
            {
                Landscape = false,
                Margins = new System.Drawing.Printing.Margins(30, 0, 0, 0)
            });
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.ZoomPercent = 75;

            this.reportViewer1.RefreshReport();
        }
    }
}
