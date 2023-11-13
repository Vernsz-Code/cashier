using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;
using MySql.Data.MySqlClient;

namespace tes
{
    public partial class FormUserSettings : Form
    {
        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";

        public FormUserSettings()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FormAddStaff frmAddStaff = new FormAddStaff();
            frmAddStaff.ShowDialog();
        }

        private void loadData()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "select id, User, jabatan from staff";

            MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();
            using(MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    dgv.Rows.Clear();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string id = reader["id"].ToString();
                                string Users = reader["User"].ToString();
                                string jabatan = reader["jabatan"].ToString();
                                Image editIcon = Properties.Resources.icons8_info_24px_1;
                                Image deleteIcon = Properties.Resources.icons8_delete_24px_1;

                                dgv.Rows.Add(id, Users, jabatan, deleteIcon, editIcon);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            conn.Close();
        }

        private void FormUserSettings_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void FormAddStaff_FormClosing(object sender, FormClosedEventArgs e)
        {
            loadData();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dgv.Columns["editIcon"].Index && e.RowIndex >= 0)
            {
                int id = int.Parse(dgv.Rows[e.RowIndex].Cells["Column1"].Value.ToString());

                if(id !=  0)
                {
                    FormAddStaff form = new FormAddStaff();
                    form.id = id;
                    form.condition = "edit";
                    form.FormClosed += new FormClosedEventHandler(FormAddStaff_FormClosing);
                    form.ShowDialog();
                }
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "select id, User, jabatan from staff where id LIKE '%" + guna2TextBox1.Text + "%' OR User LIKE '%" + guna2TextBox1.Text + "%'";

            MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                try
                {
                    dgv.Rows.Clear();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string id = reader["id"].ToString();
                                string Users = reader["User"].ToString();
                                string jabatan = reader["jabatan"].ToString();
                                Image editIcon = Properties.Resources.icons8_info_24px_1;
                                Image deleteIcon = Properties.Resources.icons8_delete_24px_1;

                                dgv.Rows.Add(id, Users, jabatan, deleteIcon, editIcon);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            conn.Close();
        }
    }
}
