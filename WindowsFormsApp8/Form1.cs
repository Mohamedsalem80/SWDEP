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
    
    public partial class Form1 : Form
    {
        TodoForm todo;
        private string connectionString = "Server=127.0.0.1;Port=3306;Database=application_db;Uid=root;Pwd=;";
        public Form1()
        {
            InitializeComponent();
           //loadform(new TodoForm());
            p1.Visible = true;
            notifyIcon1.Icon = SystemIcons.Application;
        }
        bool sidebarExpand = true;

        public void loadform(object Form)
        {
            if (this.mainPannel.Controls.Count > 0)
                this.mainPannel.Controls.RemoveAt(0);
            Form f = Form as Form;
           f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPannel.Controls.Add(f);
            this.mainPannel.Tag = f;
            f.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 61)
                {
                    sidebar.Width = 61;
                    sidebarExpand = false;
                    timer1.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 152)
                {
                    sidebar.Width = 152;
                    sidebarExpand = true;
                    timer1.Stop();
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            if (todo == null)
            {
                todo = new TodoForm();
                todo.FormClosed += todo_FormClosed;
               // todo.MdiParent = this;
                todo.Dock = DockStyle.Fill;
                todo.Show();
            }
            else
            {
                todo.Activate();
            }

           
        }
        private void todo_FormClosed(object sender, FormClosedEventArgs e)
        {
            todo = null;
        }
        private void btnChat_Click(object sender, EventArgs e)
        {
            loadform(new ChatForm());
            position(btnChat);
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            loadform(new Quick_Note());
            position(btnNotes);
        }

        private void btnAI_Click(object sender, EventArgs e)
        {
            loadform(new ChatBot());
            position(btnAI);
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            loadform(new Notification());
            position(btnNotification);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            position(btnTodo);
        }
        private void position(Button b)
        {
            int newX = b.Location.X - p1.Width;
            int newY = b.Location.Y;
            if (newX < 0) newX = 0;
            if (newY < 0) newY = 0;

            p1.Location = new Point(newX, newY);
        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnNotepad_Click(object sender, EventArgs e)
        {
            loadform(new Notepad());
            position(btnNotepad);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Log_GitHub newForm = new Log_GitHub();
            newForm.Show();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int x = 1;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    x:
                    string query = "SELECT * FROM notifications_data WHERE OS_Push = 0 ";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int notificationId = reader.GetInt32("notification_ID");
                            string notificationType = reader.GetString("notification_Type");
                            string notificationDescription = reader.GetString("notification_Description");
                            notifyIcon1.BalloonTipText = notificationDescription;
                            notifyIcon1.BalloonTipTitle = notificationType;
                            notifyIcon1.ShowBalloonTip(2000);
                            string z = "UPDATE notifications_data SET OS_Push = 1 WHERE notification_ID=" + Convert.ToString(notificationId) + ";";
                            reader.Close();
                            cmd.CommandText = z;
                            cmd.ExecuteNonQuery();
                            goto x;
                            //reader = cmd.ExecuteReader();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading tasks from database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mainPannel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM subtasks WHERE IsCompleted = 0 and notification_push = 0 ";
                    string z;
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                x:
                    query = "SELECT * FROM subtasks WHERE IsCompleted = 0 and notification_push = 0 ";
                    cmd.CommandText = query;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int SubtaskID = reader.GetInt32("SubtaskID");
                            DateTime SubtaskDueDate = reader.GetDateTime("SubtaskDueDate");
                            string SubtaskName = reader.GetString("SubtaskName");
                            z = "UPDATE subtasks SET notification_push = 1 WHERE SubtaskID=" + Convert.ToString(SubtaskID) + ";";
                            if (SubtaskDueDate != DateTime.Now.Date)
                                continue;
                            reader.Close();
                            cmd.CommandText = z;
                            cmd.ExecuteNonQuery();
                            z = "INSERT INTO notifications_data (notification_Type, notification_Description, OS_Push) VALUES ('duedate of subtask is today','" + SubtaskName + " duedate is today',0);";
                            cmd.CommandText = z;
                            cmd.ExecuteNonQuery();
                            goto x;
                        }
                    }
                y:
                    query = "SELECT * FROM maintasks WHERE progress < 100 and notification_push = 0 ";
                    cmd.CommandText = query;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int taskID = reader.GetInt32("taskID");
                            DateTime Duedate = reader.GetDateTime("DueDate");
                            string taskName = reader.GetString("taskName");
                            z = "UPDATE maintasks SET notification_push = 1 WHERE taskID=" + Convert.ToString(taskID) + ";";
                            if (Duedate != DateTime.Now.Date)
                                continue;
                            reader.Close();
                            cmd.CommandText = z;
                            cmd.ExecuteNonQuery();
                            z = "INSERT INTO notifications_data (notification_Type, notification_Description, OS_Push) VALUES (" + "'duedate of maintask is today'" + ",'" + taskName + " duedate is today',0);";
                            cmd.CommandText = z;
                            cmd.ExecuteNonQuery();
                            goto y;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading tasks from database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
