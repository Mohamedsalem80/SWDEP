using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Timers;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp8
{
    public partial class ChatForm : Form
    {
        private string connectionString = "Server=127.0.0.1;Port=3306;Database=swde;Uid=root;Pwd=;";
        
        
        private int userId = 1;

        private static System.Timers.Timer pollingTimer;
        DateTime lastCheckTime;

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

        public ChatForm()
        {
            InitializeComponent();

            //ConnectionString = connectionstring;
            //UserId = userid;


            flowLayoutPanelMessages.Visible = false;
            labelChatName.Visible = false;
            buttonChangeName.Visible = false;
            textBoxMessage.Visible = false;
            ButtonSend.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadChats();
            pollingTimer = new System.Timers.Timer(2000);
            pollingTimer.Elapsed += CheckForNew;
            pollingTimer.AutoReset = true;
            pollingTimer.Start();
            lastCheckTime = DateTime.Now;
        }

        private void CheckForNew(object sender, ElapsedEventArgs e)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("GetNews", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@inputlastCheckTime", lastCheckTime);

                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            int messageID = Convert.ToInt32(row["messageID"]);

                            string notificationType = row["notificationType"].ToString();
                            if (notificationType == "I")
                            {
                                OnInsertMessage(messageID);
                            }
                            else if (notificationType == "U")
                            {
                                OnUpdateMessage(messageID);
                            }
                            else if (notificationType == "D")
                            {
                                
                                OnDeleteMessage(messageID);
                            }

                            lastCheckTime = DateTime.Now;                          
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnInsertMessage(int messageID)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("GetMessage", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@inputMessageID", messageID);


                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            string message = row["message"].ToString();
                            string senderID = row["senderName"].ToString();
                            int userid = Convert.ToInt32(row["userID"]);
                            if (flowLayoutPanelMessages.InvokeRequired && userid != userId)
                            {
                                flowLayoutPanelMessages.Invoke(new Action(() =>
                                {
                                    UserControlMessage messageControl = new UserControlMessage
                                    {
                                        MessageId = messageID,
                                        Message = message,
                                        senderName = senderID,
                                        Dock = DockStyle.Top,
                                        Margin = new Padding(0, 0, 5, 10)
                                    };

                                    messageControl.AddHeighttext();
                                    flowLayoutPanelMessages.Controls.Add(messageControl);

                                }));
                                if (flowLayoutPanelMessages.VerticalScroll.Visible)
                                {
                                    flowLayoutPanelMessages.VerticalScroll.Value = flowLayoutPanelMessages.VerticalScroll.Maximum;
                                    flowLayoutPanelMessages.PerformLayout();
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void OnUpdateMessage(int messageID)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("GetMessage", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@inputMessageID", messageID);


                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            string message = row["message"].ToString();
                            foreach (Control control in flowLayoutPanelMessages.Controls)
                            {
                                if ((control is UserControlMessage MessageControl) && (MessageControl.MessageId == messageID))
                                {
                                    MessageControl.Message = message;
                                    MessageControl.AddHeighttext();
                                    break;
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnDeleteMessage(int messageID)
        {
            foreach (Control control in flowLayoutPanelMessages.Controls)
            {
                if ((control is UserControlMessage MessageControl) && (MessageControl.MessageId == messageID))
                {
                    flowLayoutPanelMessages.Controls.Remove(MessageControl);
                    break;
                }
            }
        }

        private void LoadChats()
        {
            flowLayoutPanelChat.Controls.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("GetUserChats", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@userId", userId);


                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        foreach (DataRow row in dt.Rows)
                        {

                            UserControl1 userControl = new UserControl1
                            {
                                ChatId = Convert.ToInt32(row["chatID"]),
                                ChatName = row["chatName"].ToString()
                            };

                            userControl.ChatClicked += UserControl_ChatClicked;

                            flowLayoutPanelChat.Controls.Add(userControl);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (flowLayoutPanelChat.VerticalScroll.Visible)
            {
                foreach (Control control in flowLayoutPanelChat.Controls)
                {
                    if (control is UserControl1 chatControl)
                    {
                        chatControl.Width = 163;
                    }
                }
                flowLayoutPanelChat.PerformLayout();
            }
        }

        private int currentChatId;
        private string currentChatName;

        private void UserControl_ChatClicked(object sender, EventArgs e)
        {
            if ( (sender is UserControl1 clickedControl) && (clickedControl.ChatId != currentChatId))
            {
                currentChatId = clickedControl.ChatId;
                currentChatName = clickedControl.ChatName;
                LoadChatMessages();

            }
        }

        private void LoadChatMessages()
        {

            if (flowLayoutPanelMessages.Visible == false)
            {
                flowLayoutPanelMessages.Visible = true;
                labelChatName.Visible = true;
                buttonChangeName.Visible = true;
                textBoxMessage.Visible = true;
                ButtonSend.Visible = true;
            }

            

            flowLayoutPanelMessages.PerformLayout();
            flowLayoutPanelMessages.Controls.Clear();

            labelChatName.Text = currentChatName;



            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("GetChatMessages", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@inputChatID", currentChatId);

                        DataTable dt = new DataTable();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }

                        foreach (DataRow row in dt.Rows)
                        {
                            int senderId = Convert.ToInt32(row["senderID"]);
                            string messageText = row["message"].ToString();
                            int messageId = Convert.ToInt32(row["messageID"]);

                            if (senderId == userId)
                            {
                                UserControlUserMessage userMessageControl = new UserControlUserMessage
                                {
                                    MessageId = messageId,
                                    Message = messageText,
                                    Dock = DockStyle.None,
                                    Anchor = AnchorStyles.Left,
                                    Margin = new Padding(0, 0, 145, 10)
                                };

                                userMessageControl.OnUpdateMessage += UserMessageControl_OnUpdateMessage;
                                userMessageControl.OnDeleteMessage += UserMessageControl_OnDeleteMessage;

                                userMessageControl.AddHeighttext();

                                flowLayoutPanelMessages.Controls.Add(userMessageControl);
                            }
                            else
                            {
                                UserControlMessage messageControl = new UserControlMessage
                                {
                                    MessageId = messageId,
                                    Message = messageText,
                                    senderName = row["senderName"].ToString(),
                                    Dock = DockStyle.Top,
                                    Margin = new Padding(0, 0, 5, 10)
                                };

                                messageControl.AddHeighttext();

                                flowLayoutPanelMessages.Controls.Add(messageControl);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



            if (flowLayoutPanelMessages.VerticalScroll.Visible)
            {
                foreach (Control control in flowLayoutPanelMessages.Controls)
                {
                    if (control is UserControlUserMessage userMessageControl)
                    {
                        userMessageControl.Margin = Margin = new Padding(0, 0, 128, 10);
                    }
                }
                flowLayoutPanelMessages.VerticalScroll.Value = flowLayoutPanelMessages.VerticalScroll.Maximum;
                flowLayoutPanelMessages.PerformLayout();
            }
            
        }


        private void UserMessageControl_OnUpdateMessage(object sender, EventArgs e)
        {
            if (sender is UserControlUserMessage messageControl)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        using (MySqlCommand cmd = new MySqlCommand("UpdateMessage", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@inputMessageID", messageControl.MessageId);
                            cmd.Parameters.AddWithValue("@inputMessage", messageControl.Message);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                LoadChatMessages();
                            }
                            else
                            {
                                MessageBox.Show("Failed to update message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void UserMessageControl_OnDeleteMessage(object sender, EventArgs e)
        {
            if (sender is UserControlUserMessage messageControl)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        using (MySqlCommand cmd = new MySqlCommand("DeleteMessage", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@inputMessageID", messageControl.MessageId);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                MessageBox.Show("Failed to delete message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void flowLayoutPanelMessages_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonSend_Click_1(object sender, EventArgs e)
        {

            string messageText = textBoxMessage.Text.Trim();
            if (string.IsNullOrEmpty(messageText))
            {
                MessageBox.Show("Message cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentChatId <= 0)
            {
                MessageBox.Show("No chat selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("AddMessages", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@inputChatID", currentChatId); 
                        cmd.Parameters.AddWithValue("@inputSenderID", userId);      // The sender is the current user
                        cmd.Parameters.AddWithValue("@inputMessage", messageText);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            LoadChatMessages();
                            textBoxMessage.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Failed to send message.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flowLayoutPanelChat_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonAddChat_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.UserId = this.UserId;
            f2.ConnectionString = this.ConnectionString;
            DialogResult result = f2.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadChats();
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string newChatName = Prompt.ShowDialog("Change Chat Name", "Enter the new chat name:", currentChatName);

            if (!string.IsNullOrEmpty(newChatName))
            {
                currentChatName = newChatName;
                labelChatName.Text = newChatName;

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        using (MySqlCommand cmd = new MySqlCommand("ChangeChatName", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@inputChatID", currentChatId);
                            cmd.Parameters.AddWithValue("@inputChatName", newChatName);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                LoadChats();
                            }
                            else
                            {
                                MessageBox.Show("Failed to change chat name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Chatname cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
