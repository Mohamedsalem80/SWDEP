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

namespace WindowsFormsApp8
{
    public partial class GitHub : Form
    {
        private string username; 

        public GitHub(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void GitHub_Load(object sender, EventArgs e)
        {
            label2.Text =  username; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return; 
            }

            try
            {
                using (MySqlConnection connection = new MySqlConnection("server=localhost;database=userdb;uid=root;pwd=;"))
                {
                    connection.Open();

                    string query = "DELETE FROM users WHERE username = @username";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("You have logged out successfully.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Log_GitHub loginForm = new Log_GitHub();
                    loginForm.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
