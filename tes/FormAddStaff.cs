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

namespace tes
{
    public partial class FormAddStaff : Form
    {
        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";

        public int id {  get; set; }
        public string condition { get; set; }

        public FormAddStaff()
        {
            InitializeComponent();
        }

        private void loadData()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "select * from staff where id = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            using(MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) 
                    {
                        string user = reader["User"].ToString();
                        string Pass = reader["Password"].ToString();
                        string jabatan = reader["jabatan"].ToString();
                        int imd = int.Parse(reader["md"].ToString());
                        int imp = int.Parse(reader["mp"].ToString());
                        int imbm = int.Parse(reader["mbm"].ToString());
                        int imbk = int.Parse(reader["mbk"].ToString());
                        int imk = int.Parse(reader["mk"].ToString());
                        int ilbm = int.Parse(reader["lbm"].ToString());
                        int ilbk = int.Parse(reader["lbk"].ToString());
                        int ilh = int.Parse(reader["lh"].ToString());
                        int ilp = int.Parse(reader["lp"].ToString());
                        int illss = int.Parse(reader["llss"].ToString());

                        userTextBox.Text = user;
                        passTextBox.Text = Pass;
                        jabatanTextBox.Text = jabatan;

                        md.Checked = imd == 1;
                        mp.Checked = imp == 1;
                        mbm.Checked = imbm == 1;
                        mbk.Checked = imbk == 1;
                        mk.Checked = imk == 1;
                        lbm.Checked = ilbm == 1;
                        lbk.Checked = ilbk == 1;
                        lh.Checked = ilh == 1;
                        lp.Checked = ilp == 1;
                        llss.Checked = illss == 1;
                    }
                    else
                    {
                        MessageBox.Show("Data Tidak Ditemukan!!!");
                    }
                }
            }

            conn.Close();
        }

        private void insertData()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string insertQuery = "INSERT INTO staff (User, Password, jabatan, md, mp, mbm, mbk, mk, lbm, lbk, lh, lp, llss) VALUES (@User, @Password, @jabatan, @md, @mp, @mbm, @mbk, @mk, @lbm, @lbk, @lh, @lp, @llss)";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            using (MySqlCommand cmd = new MySqlCommand(insertQuery, conn))
            {
                cmd.Parameters.AddWithValue("@User", userTextBox.Text);
                cmd.Parameters.AddWithValue("@Password", passTextBox.Text);
                cmd.Parameters.AddWithValue("@jabatan", jabatanTextBox.Text);
                cmd.Parameters.AddWithValue("@md", md.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@mp", mp.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@mbm", mbm.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@mbk", mbk.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@mk", mk.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@lbm", lbm.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@lbk", lbk.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@lh", lh.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@lp", lp.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@llss", llss.Checked ? 1 : 0);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data berhasil disimpan!");
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan data!");
                }
            }

            conn.Close();
        }

        private void updateData()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string updateQuery = "UPDATE staff SET User = @User, Password = @Password, jabatan = @jabatan, md = @md, mp = @mp, mbm = @mbm, mbk = @mbk, mk = @mk, lbm = @lbm, lbk = @lbk, lh = @lh, lp = @lp, llss = @llss WHERE id = @id";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            using (MySqlCommand cmd = new MySqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@User", userTextBox.Text);
                cmd.Parameters.AddWithValue("@Password", passTextBox.Text);
                cmd.Parameters.AddWithValue("@jabatan", jabatanTextBox.Text);
                cmd.Parameters.AddWithValue("@md", md.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@mp", mp.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@mbm", mbm.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@mbk", mbk.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@mk", mk.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@lbm", lbm.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@lbk", lbk.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@lh", lh.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@lp", lp.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@llss", llss.Checked ? 1 : 0);
                cmd.Parameters.AddWithValue("@id", id); // Sesuaikan dengan kolom kunci utama tabel

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data berhasil diupdate!");
                }
                else
                {
                    MessageBox.Show("Gagal mengupdate data!");
                }
            }

            conn.Close();
        }


        private void FormAddStaff_Load(object sender, EventArgs e)
        {
            if(condition == "edit")
            {
                loadData();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (condition == "edit")
            {
                updateData();
            }
            else
            {
                insertData();
            }
        }
    }
}
