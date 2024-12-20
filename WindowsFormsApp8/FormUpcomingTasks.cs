using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class FormUpcomingTasks : Form
    {
        private string connectionString = "Server=127.0.0.1;Port=3306;Database=application_db;Uid=root;Pwd=;"; // actual DB connection string

        public FormUpcomingTasks()
        {
            InitializeComponent();
            LoadMainTasks(); // Initial load
        }

        // This event is triggered whenever the form is activated
        private void FormUpcomingTasks_Activated(object sender, EventArgs e)
        {
            LoadMainTasks(); // Reload tasks every time the form is activated (brought to the foreground)
        }

        // Method to manually refresh tasks when called from other forms or button click
        public void RefreshTasks()
        {
            LoadMainTasks();  // Reload tasks when called explicitly
        }

        // Load only the main tasks that have incomplete subtasks
        private void LoadMainTasks()
        {
            flowLayoutPanel1.Controls.Clear(); // Clear the current controls before reloading tasks

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM MainTasks";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int taskId = reader.GetInt32("TaskId");
                            string taskName = reader.GetString("TaskName");
                            DateTime dueDate = reader.GetDateTime("DueDate");
                            int progress = reader.GetInt32("Progress");

                            // Only load the task if there are incomplete subtasks
                            bool hasIncompleteSubtasks = CheckForIncompleteSubtasks(taskId);
                            if (hasIncompleteSubtasks)
                            {
                                // Create the UI for the main task
                                var taskPanel = CreateTaskUI(taskName, dueDate, taskId, progress);

                                // Load the subtasks for this main task (only incomplete ones)
                                LoadSubtasks(taskId, taskPanel);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading tasks from database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Helper method to check if the main task has any incomplete subtasks
        private bool CheckForIncompleteSubtasks(int mainTaskId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Subtasks WHERE MainTaskID = @MainTaskID AND IsCompleted = 0";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MainTaskID", mainTaskId);
                    int incompleteSubtasks = Convert.ToInt32(cmd.ExecuteScalar());
                    return incompleteSubtasks > 0; // Return true if there are incomplete subtasks
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error checking subtasks: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        // Create a panel to display the main task information
        private FlowLayoutPanel CreateTaskUI(string taskName, DateTime dueDate, int taskId, int progress)
        {
            var taskPanel = new FlowLayoutPanel
            {
                AutoSize = true,
                BorderStyle = BorderStyle.FixedSingle,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(10)
            };

            var taskLabel = new Label { Text = $"{taskName} (Due: {dueDate:yyyy-MM-dd})", AutoSize = true };
            var progressBar = new ProgressBar { Minimum = 0, Maximum = 100, Value = progress, Width = 300 };

            taskPanel.Controls.Add(taskLabel);
            taskPanel.Controls.Add(progressBar);

            flowLayoutPanel1.Controls.Add(taskPanel); // Add the task panel to the flowLayoutPanel1

            return taskPanel;
        }

        // Load and display only incomplete subtasks
        private void LoadSubtasks(int mainTaskId, FlowLayoutPanel taskPanel)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT SubtaskId, SubtaskName, SubtaskDueDate FROM Subtasks WHERE MainTaskID = @MainTaskID AND IsCompleted = 0";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MainTaskID", mainTaskId);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string subtaskName = reader.GetString("SubtaskName");
                        DateTime subtaskDueDate = reader.GetDateTime("SubtaskDueDate");

                        var subtaskLabel = new Label
                        {
                            Text = $"{subtaskName} (Due: {subtaskDueDate:yyyy-MM-dd})",
                            AutoSize = true
                        };

                        taskPanel.Controls.Add(subtaskLabel); // Display the subtask info under the main task
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading subtasks from database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
