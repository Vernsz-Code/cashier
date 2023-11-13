using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace tes
{
    public partial class FormMain : Form
    {
        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";
        int lbm = 0;
        int lbk = 0;
        int lh = 0;
        int lp = 0;
        public string username { get; set; }
        public string passwords { get; set; }

        Button currentButton;
        public FormMain()
        {
            InitializeComponent(); 
        }
        bool laporan = false;

        private void loadData()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "SELECT * FROM staff where User = @username and Password = @password;";
            connection.ConnectionString = connectionString;
            connection.Open();
            using(MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", passwords);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int md = int.Parse(reader["md"].ToString());
                        int mp = int.Parse(reader["mp"].ToString());
                        int mbm = int.Parse(reader["mbm"].ToString());
                        int mbk = int.Parse(reader["mbk"].ToString());
                        int mk = int.Parse(reader["mk"].ToString());
                        lbm = int.Parse(reader["lbm"].ToString());
                        lbk = int.Parse(reader["lbk"].ToString());
                        lh = int.Parse(reader["lh"].ToString());
                        lp = int.Parse(reader["lp"].ToString());
                        int llss = int.Parse(reader["llss"].ToString());

                        btnDashboard.Visible = md == 1;
                        btnMaster.Visible = mp == 1;
                        button3.Visible = mbm == 1;
                        btnFaktur.Visible = mbk == 1;
                        btnKas.Visible = mk == 1;
                        button2.Visible = lbm == 1 || lbk == 1 || lh == 1 || lp == 1;
                        /*btnBarangMasuk.Visible = lbm == 1;
                        btnlaporan.Visible = lbk == 1;
                        btnDebt.Visible = lh == 1;
                        btnClientDebt.Visible = lp == 1;*/
                        btnStaff.Visible = llss == 1;

                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Di Temukan!!!");
                    }
                }
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            activebutton(sender);
            laporan = !laporan;

            if (lp == 1)
            {
                btnClientDebt.Visible = laporan;
            }
            else
            {
                btnClientDebt.Visible = false;
            }
            if (lh == 1)
            {
                btnDebt.Visible = laporan;
            }
            else
            {
                btnDebt.Visible = false;
            }
            if (lbk == 1)
            {
                btnlaporan.Visible = laporan;
            }
            else
            {
                btnlaporan.Visible = false;
            }
            if (lbm == 1)
            {
                btnBarangMasuk.Visible = laporan;
            }
            else
            {
                btnBarangMasuk.Visible = false;
            }

        }

        public void LoadForm(object Form)
        {
            Form previousForm = mainPanel.Controls.OfType<Form>().FirstOrDefault();
            if (previousForm != null)
            {
                previousForm.Dispose();
                mainPanel.Controls.Remove(previousForm);
            }

            mainPanel.Visible = true;
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(f);

            f.Show();
        }
        void activebutton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    resetbutton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(18, 25, 48);
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        void resetbutton()
        {
            btnDashboard.BackColor = Color.FromArgb(27, 37, 71);
            btnDashboard.ForeColor = Color.Gainsboro;
            btnDashboard.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnMaster.BackColor = Color.FromArgb(27, 37, 71);
            btnMaster.ForeColor = Color.Gainsboro;
            btnMaster.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnlaporan.BackColor = Color.FromArgb(27, 37, 71);
            btnlaporan.ForeColor = Color.Gainsboro;
            btnlaporan.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnClientDebt.BackColor = Color.FromArgb(27, 37, 71);
            btnClientDebt.ForeColor = Color.Gainsboro;
            btnClientDebt.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnDebt.BackColor = Color.FromArgb(27, 37, 71);
            btnDebt.ForeColor = Color.Gainsboro;
            btnDebt.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnFaktur.BackColor = Color.FromArgb(27, 37, 71);
            btnFaktur.ForeColor = Color.Gainsboro;
            btnFaktur.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnBarangMasuk.BackColor = Color.FromArgb(27, 37, 71);
            btnBarangMasuk.ForeColor = Color.Gainsboro;
            btnBarangMasuk.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            button2.BackColor = Color.FromArgb(27, 37, 71);
            button2.ForeColor = Color.Gainsboro;
            button2.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            button3.BackColor = Color.FromArgb(27, 37, 71);
            button3.ForeColor = Color.Gainsboro;
            button3.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnKas.BackColor = Color.FromArgb(27, 37, 71);
            btnKas.ForeColor = Color.Gainsboro;
            btnKas.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            btnStaff.BackColor = Color.FromArgb(27, 37, 71);
            btnStaff.ForeColor = Color.Gainsboro;
            btnStaff.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadForm(new FormDashboard());
            activebutton(sender);
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            LoadForm(new FrmStok());
            activebutton(sender);
        }

        private void guna2ImageButton2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2ImageButton1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah kamu yakin ingin keluar dari app?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void guna2ImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            System.Diagnostics.Process.Start("https://wa.link/utc65e");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadForm(new FormDashboard());
            loadData();
        }

        private void btnUserSettings_Click(object sender, EventArgs e)
        {
            activebutton(sender);
        }


        private void btnFaktur_Click(object sender, EventArgs e)
        {
            LoadForm(new FormKasir());
            activebutton(sender);
        }
        private void btnKas_Click(object sender, EventArgs e)
        {
            LoadForm(new FormKas());
            activebutton(sender);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            LoadForm(new FormBarangMasuk());
            activebutton(sender);
        }

        private void btnBarangMasuk_Click(object sender, EventArgs e)
        {
            LoadForm(new BarangMasuk());
            activebutton(sender);
        }

        private void btnlaporan_Click_1(object sender, EventArgs e)
        {
            LoadForm(new frmReport());
            activebutton(sender);
        }
        private void btnDebt_Click(object sender, EventArgs e)
        {
            LoadForm(new FormDebt());
            activebutton(sender);
        }

        private void btnClientDebt_Click(object sender, EventArgs e)
        {
            LoadForm(new FormReceivables());
            activebutton(sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadForm(new FormUserSettings());
            activebutton(sender);
        }
    }
}
