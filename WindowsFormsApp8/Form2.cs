using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private string connectionString;


        private int userId = 4;


        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            membersload();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxMembersSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxChatName_TextChanged(object sender, EventArgs e)
        {

        }

        private void membersload()
        {
            groupBox1.Controls.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    DataTable dt = new DataTable();

                    string membersSearch = textBoxMembersSearch.Text.Trim();
                    if (string.IsNullOrEmpty(membersSearch))
                    {
                        using (MySqlCommand cmd = new MySqlCommand("GetMembers", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@inputUserID", userId);

                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                    else
                    {
                        using (MySqlCommand cmd = new MySqlCommand("GetSpecificMember", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@inputUserID", userId);
                            cmd.Parameters.AddWithValue("@inputMemberName", membersSearch);


                            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                            {
                                adapter.Fill(dt);
                            }


                        }
                    }

                    // Dynamic checkbox creation
                    int yOffset = 20; // Vertical offset for placing checkboxes

                    foreach (DataRow row in dt.Rows)
                    {
                        int memberID = Convert.ToInt32(row["memberID"]);
                        string memberName = row["memberName"].ToString();


                        CheckBox checkBox = new CheckBox
                        {
                            Text = memberName,
                            Name = "chk_" + memberID,
                            Tag = memberID,
                            Location = new System.Drawing.Point(10, yOffset),
                            AutoSize = true
                        };


                        groupBox1.Controls.Add(checkBox);


                        yOffset += 25;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreateChat_Click(object sender, EventArgs e)
        {

            string chatName = textBoxChatName.Text.Trim();
            if (string.IsNullOrEmpty(chatName))
            {
                MessageBox.Show("Chat name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int checkboxCount = 0;

            foreach (Control control in groupBox1.Controls)
            {
                if (control is CheckBox checkBox && checkBox.Checked)
                {
                    checkboxCount++;
                }
            }

            if (checkboxCount == 0)
            {
                MessageBox.Show("Chat cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    int newChatId;

                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("CreateChat", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@inputChatName", chatName);

                        MySqlParameter outputParam = new MySqlParameter("@outputChatID", MySqlDbType.Int32)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParam);

                        // Execute the procedure
                        cmd.ExecuteNonQuery();

                        // Get the output value
                        newChatId = Convert.ToInt32(outputParam.Value);
                    }

                    foreach (Control control in groupBox1.Controls)
                    {
                        if (control is CheckBox checkBox && checkBox.Checked)
                        {
                            int memberID = Convert.ToInt32(checkBox.Tag);

                            using (MySqlCommand cmd = new MySqlCommand("AddMemberToChat", conn))
                            {
                                cmd.CommandType= CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@inputChatID", newChatId);
                                cmd.Parameters.AddWithValue("@inputUserID", memberID);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }

                    using (MySqlCommand cmd = new MySqlCommand("AddMemberToChat", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@inputChatID", newChatId);
                        cmd.Parameters.AddWithValue("@inputUserID", userId);

                        cmd.ExecuteNonQuery();
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            membersload();
        }
    }
}
