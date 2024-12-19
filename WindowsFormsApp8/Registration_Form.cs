using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp8
{
    public partial class Registration_Form : Form
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;database=userdb;uid=root;pwd=;");
        public Registration_Form()
        {
            InitializeComponent();
        }

        private bool isPasswordVisible = false;

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (username == "" || email == "" || password == "")
            {
                MessageBox.Show("Please enter your username, email, and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email. Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                connection.Open();

                string checkQuery = "SELECT * FROM users WHERE email = @email";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@email", email);
                MySqlDataReader reader = checkCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    MessageBox.Show("This email is already registered. Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reader.Close();
                    return;
                }
                reader.Close();

                string query = "INSERT INTO users (username, email, password) VALUES (@username, @email, @password)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Registration successful!");

                this.Close();
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
            Log_GitHub newform = new Log_GitHub();
            newform.Show();

            this.Close();
        }
    }
}
