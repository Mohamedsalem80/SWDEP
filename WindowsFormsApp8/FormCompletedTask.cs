using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace WindowsFormsApp8
{
    public partial class FormCompletedTask : Form
    {
        // MySQL connection string
        private readonly string connectionString = "Server=127.0.0.1;Port=3306;Database=application_db;Uid=root;Pwd=;";

        // List to store references to task panels
        private readonly List<Panel> taskPanels = new List<Panel>();

        public FormCompletedTask()
        {
            InitializeComponent();
            LoadCompletedTasks(); // Load tasks when the form initializes
        }

        public void RefreshTasks()
        {
            // Refresh the task list
            LoadCompletedTasks();
        }

        // Load completed tasks from the database
        private void LoadCompletedTasks()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TaskId, TaskName, DueDate FROM MainTasks WHERE Progress = 100";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    int yPosition = 20; // Initial Y position for task panels

                    // Loop through each task retrieved from the database
                    while (reader.Read())
                    {
                        int taskId = reader.GetInt32("TaskId");
                        string taskName = reader.GetString("TaskName");
                        DateTime dueDate = reader.GetDateTime("DueDate");

                        // Create a new panel for the task
                        Panel taskPanel = new Panel
                        {
                            Size = new Size(760, 60),
                            Location = new Point(20, yPosition),
                            BorderStyle = BorderStyle.FixedSingle,
                            BackColor = Color.LightGreen
                        };

                        // Add a label to display task details
                        Label taskLabel = new Label
                        {
                            Text = $"{taskName} (Due: {dueDate:yyyy-MM-dd})",
                            AutoSize = true,
                            Font = new Font("Arial", 12, FontStyle.Bold),
                            Location = new Point(10, 10)
                        };

                        taskPanel.Controls.Add(taskLabel); // Add the label to the panel
                        Controls.Add(taskPanel); // Add the panel to the form
                        taskPanels.Add(taskPanel); // Store reference to the panel

                        yPosition += 70; // Increment Y position for the next panel
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading completed tasks: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Refresh completed tasks by clearing old panels and reloading
        public void RefreshCompletedTasks()
        {
            // Remove and dispose of existing task panels
            foreach (var panel in taskPanels)
            {
                Controls.Remove(panel);
                panel.Dispose();
            }
            taskPanels.Clear(); // Clear the list

            // Reload tasks
            LoadCompletedTasks();
        }

        // Button click event to manually refresh tasks
        private void button3_Click_1(object sender, EventArgs e)
        {
            RefreshCompletedTasks();
        }

        private void FormCompletedTask_Load(object sender, EventArgs e)
        {

        }
    }
}
