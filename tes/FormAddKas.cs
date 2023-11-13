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
    public partial class FormAddKas : Form
    {
        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";
        public string NoFaktur { get; set; }
        public string condition { get; set; }
        public FormAddKas()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};AllowUserVariables=true;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                if (condition == "insert")
                {
                    string kueri = "INSERT INTO `tb_kas` (`no`, `faktur`, `tgl`, `jenis`, `kategori`, `pemasukan`, `pengeluaran`, `keterangan`, `operator`) VALUES (NULL, @faktur, @tgl, @jenis, @kategori, @pemasukan, @pengeluaran, @ket, @op);";
                    string noFaktur = faktur.Text;
                    string tgl = DATE.Value.ToString("yyyy/MM/dd");
                    string jenis = guna2ComboBox1.Text;
                    string kategori = guna2ComboBox2.Text;
                    string pemasukan = guna2TextBox3.Text;
                    decimal pbl = decimal.Parse(pemasukan);
                    string pengeluaran = guna2TextBox4.Text;
                    decimal pgl = decimal.Parse(pengeluaran);
                    string keterangans = keterangan.Text;
                    string op = "Manager";

                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(kueri, connection))
                    {
                        cmd.Parameters.AddWithValue("@faktur", noFaktur);
                        cmd.Parameters.AddWithValue("@tgl", tgl);
                        cmd.Parameters.AddWithValue("@jenis", jenis);
                        cmd.Parameters.AddWithValue("@kategori", kategori);
                        cmd.Parameters.AddWithValue("@pemasukan", pbl);
                        cmd.Parameters.AddWithValue("@pengeluaran", pgl);
                        cmd.Parameters.AddWithValue("@ket", keterangans);
                        cmd.Parameters.AddWithValue("@op", op);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                else if (condition == "update")
                {

                }
                else
                {

                }

            }

        }

        private void FormAddKas_Load(object sender, EventArgs e)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT no, faktur, DATE(tgl) as tgl, jenis, kategori, pemasukan, pengeluaran, keterangan, operator from tb_kas where no = @faktur";
            MySqlConnection connection = new MySqlConnection(connectionString);

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@faktur", NoFaktur);
                connection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string nofaktur = reader.GetString(1);
                        faktur.Text = nofaktur;
                        DateTime tanggalDariDatabase = reader.GetDateTime(2);
                        string formattedDate = tanggalDariDatabase.ToString("yyyy MMM dd");
                        DATE.Value = tanggalDariDatabase;
                        DATE.Text = formattedDate;
                        guna2ComboBox1.Text = reader.GetString(3);
                        guna2ComboBox2.Text = reader.GetString(4);
                        guna2TextBox3.Text = reader.GetDecimal(5).ToString("N0", new CultureInfo("id-ID"));
                        guna2TextBox4.Text = reader.GetDecimal(6).ToString("N0", new CultureInfo("id-ID"));
                        keterangan.Text = reader.GetString(7);
                    }
                }
            }
            connection.Close();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(guna2ComboBox1.Text == "Pengeluaran")
            {
                guna2ComboBox2.Items.Clear();
                guna2ComboBox2.Items.Add("Pembelian");
                guna2TextBox3.Enabled = false;
                guna2TextBox4.Enabled = true;
            }
            else
            {
                guna2ComboBox2.Items.Clear();
                guna2ComboBox2.Items.Add("Penjualan");
                guna2TextBox3.Enabled = true;
                guna2TextBox4.Enabled = false;
            }
        }
    }
}
