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
    public partial class FormLogin : Form
    {

        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            MySqlConnection connection = new MySqlConnection(connectionString);
            string query = "select id from staff where User = @user and Password = @pass";

            using(MySqlCommand cmd = new MySqlCommand(query, connection)) 
            {
                connection.Open();

                string users = user.Text;
                string passz = pass.Text;

                cmd.Parameters.AddWithValue("@user", users);
                cmd.Parameters.AddWithValue("@pass", passz);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                FormMain forms = new FormMain();
                                forms.username = user.Text;
                                forms.passwords = pass.Text;
                                forms.ShowDialog();

                                MessageBox.Show("Berhasil Login");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Gagal Login");
                            }
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
