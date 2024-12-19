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
    public partial class Log_GitHub : Form
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;database=userdb;uid=root;pwd=;");

        private bool isPasswordVisible = false;

        public Log_GitHub()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = txtUserName.Text;
            string password = txtPassword.Text;

            if (input == "" || password == "")
            {
                MessageBox.Show("Please enter your username or email and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();
                string query = "SELECT * FROM users WHERE (username = @input OR email = @input) AND password = @password";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@input", input);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read(); 
                    string username = reader["username"].ToString(); 

                    
                    GitHub newform = new GitHub(username);
                    newform.Show();
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Incorrect username/email or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            if (isPasswordVisible)
            {
                txtPassword.PasswordChar = '*';
                btnTogglePassword.Text = "Show";
                isPasswordVisible = false;
            }
            else
            {
                txtPassword.PasswordChar = '\0';
                btnTogglePassword.Text = "Hide";
                isPasswordVisible = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Registration_Form newform = new Registration_Form();
            newform.Show();

            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
