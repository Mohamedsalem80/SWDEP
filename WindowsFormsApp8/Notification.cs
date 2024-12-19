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
    public partial class Notification : Form
    {
        
        private string connectionString = "Server=127.0.0.1;Port=3306;Database=notifications;Uid=root;Pwd=;";
        public Notification()
        {
            InitializeComponent();
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            LoadNotifications();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void CreateNotificationUI(string notificationType,string descripton, int notificationId)
        {
            var notficationPanel = new FlowLayoutPanel
            {
                BorderStyle = BorderStyle.FixedSingle,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(10),
                Width = 427
            };
            var notificationTitle = new Label { Text = notificationType, AutoSize = true };
            var notificationDiscription = new Label { Text = descripton, AutoSize = true };
            var deleteTaskButton = new Button { Text = "Delete notification", AutoSize = true };

            NotificationInfo notificationInfo = new NotificationInfo { NotificationId = notificationId};
            notficationPanel.Tag = notificationInfo;
            deleteTaskButton.Click += (s, eArgs) => DeleteNotfication(notficationPanel, notificationId);

            notficationPanel.Controls.Add(notificationTitle);
            notficationPanel.Controls.Add(notificationDiscription);
            notficationPanel.Controls.Add(deleteTaskButton);

            flowLayoutPanel1.Controls.Add(notficationPanel);

            //return notficationPanel;
        }
        private void DeleteNotfication(FlowLayoutPanel notficationPanel, int notficationId)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string deletenotificationQuery = "DELETE FROM Subtasks WHERE notification_ID = " + Convert.ToString(notficationId);

                    MySqlCommand cmd = new MySqlCommand(deletenotificationQuery, connection);
                    cmd.ExecuteNonQuery();

                    flowLayoutPanel1.Controls.Remove(notficationPanel);
                    notficationPanel.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting notification: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadNotifications()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM notifications_data";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int notificationId = reader.GetInt32("notification_ID");
                            string notificationType = reader.GetString("notification_Type");
                            string notificationDescription = reader.GetString("notification_Description");

                            CreateNotificationUI(notificationDescription, notificationType, notificationId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading tasks from database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }      
    }
}
//using System;
//using System.Linq;
//using System.Windows.Forms;
//using MySql.Data.MySqlClient;

//namespace project
//{
//    public partial class FormTasks : Form
//    {
//        // MySQL connection string (adjust based on your XAMPP MySQL setup)
//        private string connectionString = "Server=127.0.0.1;Port=3306;Database=todolist;Uid=root;Pwd=;";

//        public FormTasks()
//        {
//            InitializeComponent();
//            LoadMainTasks();
//        }

//        // Handler for Add Main Task Button
//        // In your addMainTaskButton_Click method

//        private void addMainTaskButton_Click(object sender, EventArgs e)
//        {
//            string taskName = Microsoft.VisualBasic.Interaction.InputBox("Enter main task name:", "Add Main Task", "Main Task");
//            string dueDateString = Microsoft.VisualBasic.Interaction.InputBox("Enter the due date (YYYY-MM-DD):", "Add Main Task", DateTime.Now.ToString("yyyy-MM-dd"));

//            if (string.IsNullOrWhiteSpace(taskName))
//            {
//                MessageBox.Show("Task name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (!DateTime.TryParse(dueDateString, out DateTime dueDate))
//            {
//                MessageBox.Show("Invalid date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            int taskId = InsertMainTaskToDatabase(taskName, dueDate);
//            if (taskId == -1) return;

//            CreateTaskUI(taskName, dueDate, taskId, 0);
//        }


//        private int InsertMainTaskToDatabase(string taskName, DateTime dueDate)
//        {
//            using (MySqlConnection connection = new MySqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();
//                    string query = "INSERT INTO MainTasks (TaskName, DueDate, Progress) VALUES (@TaskName, @DueDate, @Progress); SELECT LAST_INSERT_ID();";
//                    MySqlCommand cmd = new MySqlCommand(query, connection);
//                    cmd.Parameters.AddWithValue("@TaskName", taskName);
//                    cmd.Parameters.AddWithValue("@DueDate", dueDate);
//                    cmd.Parameters.AddWithValue("@Progress", 0);

//                    return Convert.ToInt32(cmd.ExecuteScalar());
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Error inserting task into database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return -1;
//                }
//            }
//        }
//        


//        private void DeleteMainTask(FlowLayoutPanel taskPanel, int taskId)
//        {
//            if (MessageBox.Show("Are you sure you want to delete this task and all its subtasks?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
//            {
//                using (MySqlConnection connection = new MySqlConnection(connectionString))
//                {
//                    try
//                    {
//                        connection.Open();
//                        string deleteSubtasksQuery = "DELETE FROM Subtasks WHERE MainTaskID = @TaskId";
//                        string deleteMainTaskQuery = "DELETE FROM MainTasks WHERE TaskId = @TaskId";

//                        MySqlCommand cmd = new MySqlCommand(deleteSubtasksQuery, connection);
//                        cmd.Parameters.AddWithValue("@TaskId", taskId);
//                        cmd.ExecuteNonQuery();

//                        cmd.CommandText = deleteMainTaskQuery;
//                        cmd.ExecuteNonQuery();

//                        mainflowLayoutPanel.Controls.Remove(taskPanel);
//                        taskPanel.Dispose();
//                    }
//                    catch (Exception ex)
//                    {
//                        MessageBox.Show($"Error deleting task: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    }
//                }
//            }
//        }


//        // Edit Main Task
//        private void EditMainTask(FlowLayoutPanel taskPanel, Label taskLabel)
//        {
//            string newTaskName = Microsoft.VisualBasic.Interaction.InputBox("Edit task name:", "Edit Main Task", taskLabel.Text.Split('(')[0].Trim());
//            string newDueDateString = Microsoft.VisualBasic.Interaction.InputBox("Edit the due date (YYYY-MM-DD):", "Edit Main Task", taskLabel.Text.Split(':')[1].Trim());

//            if (string.IsNullOrWhiteSpace(newTaskName))
//            {
//                MessageBox.Show("Task name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (!DateTime.TryParse(newDueDateString, out DateTime newDueDate))
//            {
//                MessageBox.Show("Invalid date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            taskLabel.Text = $"{newTaskName} (Due: {newDueDate:yyyy-MM-dd})";
//            TaskInfo taskInfo = (TaskInfo)taskPanel.Tag;
//            taskInfo.DueDate = newDueDate;
//        }
//        // Add Subtask
//        // Add Subtask
//        private void AddSubtask(FlowLayoutPanel taskPanel, ProgressBar progressBar)
//        {
//            if (taskPanel.Tag is TaskInfo taskInfo)
//            {
//                string subtaskName = Microsoft.VisualBasic.Interaction.InputBox("Enter subtask name:", "Add Subtask", "Subtask");
//                string subDueDateString = Microsoft.VisualBasic.Interaction.InputBox("Enter the subtask due date (YYYY-MM-DD):", "Add Subtask", DateTime.Now.ToString("yyyy-MM-dd"));

//                if (string.IsNullOrWhiteSpace(subtaskName))
//                {
//                    MessageBox.Show("Subtask name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                if (!DateTime.TryParse(subDueDateString, out DateTime subDueDate))
//                {
//                    MessageBox.Show("Invalid date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return;
//                }

//                if (subDueDate > taskInfo.DueDate)
//                {
//                    MessageBox.Show("Subtask due date cannot be later than the main task's due date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                int subtaskId = InsertSubtaskToDatabase(subtaskName, subDueDate, taskInfo.TaskId);
//                if (subtaskId == -1) return;

//                CreateSubtaskUI(subtaskName, subDueDate, subtaskId, taskPanel, progressBar);
//            }
//            else
//            {
//                MessageBox.Show("Failed to load task information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }
//        private void UpdateSubtaskCompletionStatus(int subtaskId, bool isCompleted)
//        {
//            using (MySqlConnection connection = new MySqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();
//                    string query = "UPDATE Subtasks SET IsCompleted = @IsCompleted WHERE SubtaskId = @SubtaskId";
//                    MySqlCommand cmd = new MySqlCommand(query, connection);
//                    cmd.Parameters.AddWithValue("@IsCompleted", isCompleted);
//                    cmd.Parameters.AddWithValue("@SubtaskId", subtaskId);

//                    cmd.ExecuteNonQuery();
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Error updating subtask completion status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//        }



//        // Insert Subtask into the MySQL database
//        // Insert Subtask into the MySQL database
//        private int InsertSubtaskToDatabase(string subtaskName, DateTime subDueDate, int mainTaskId)
//        {
//            using (MySqlConnection connection = new MySqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();
//                    string query = "INSERT INTO Subtasks (SubtaskName, SubtaskDueDate, IsCompleted, MainTaskID) VALUES (@SubtaskName, @SubtaskDueDate, @IsCompleted, @MainTaskID); SELECT LAST_INSERT_ID();";
//                    MySqlCommand cmd = new MySqlCommand(query, connection);
//                    cmd.Parameters.AddWithValue("@SubtaskName", subtaskName);
//                    cmd.Parameters.AddWithValue("@SubtaskDueDate", subDueDate);
//                    cmd.Parameters.AddWithValue("@IsCompleted", false);
//                    cmd.Parameters.AddWithValue("@MainTaskID", mainTaskId);

//                    return Convert.ToInt32(cmd.ExecuteScalar());
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Error inserting subtask into database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return -1;
//                }
//            }
//        }
//        private void CreateSubtaskUI(string subtaskName, DateTime subDueDate, int subtaskId, FlowLayoutPanel taskPanel, ProgressBar progressBar)
//        {
//            var subtaskCheckbox = new CheckBox
//            {
//                Text = $"{subtaskName} (Due: {subDueDate:yyyy-MM-dd})",
//                AutoSize = true,
//                Tag = subtaskId
//            };

//            var deleteSubtaskButton = new Button
//            {
//                Text = "Delete Subtask",
//                AutoSize = true,
//                Tag = subtaskId
//            };

//            subtaskCheckbox.CheckedChanged += (s, eArgs) =>
//            {
//                UpdateSubtaskCompletionStatus(subtaskId, subtaskCheckbox.Checked);
//                UpdateProgress(taskPanel, progressBar);
//            };

//            deleteSubtaskButton.Click += (s, eArgs) => DeleteSubtask(subtaskCheckbox, deleteSubtaskButton, taskPanel, progressBar);

//            taskPanel.Controls.Add(subtaskCheckbox);
//            taskPanel.Controls.Add(deleteSubtaskButton);
//        }

//        private void DeleteSubtask(CheckBox subtaskCheckbox, Button deleteButton, FlowLayoutPanel taskPanel, ProgressBar progressBar)
//        {
//            int subtaskId = (int)subtaskCheckbox.Tag;

//            if (MessageBox.Show("Are you sure you want to delete this subtask?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
//            {
//                using (MySqlConnection connection = new MySqlConnection(connectionString))
//                {
//                    try
//                    {
//                        connection.Open();
//                        string query = "DELETE FROM Subtasks WHERE SubtaskId = @SubtaskId";
//                        MySqlCommand cmd = new MySqlCommand(query, connection);
//                        cmd.Parameters.AddWithValue("@SubtaskId", subtaskId);
//                        cmd.ExecuteNonQuery();

//                        taskPanel.Controls.Remove(subtaskCheckbox);
//                        taskPanel.Controls.Remove(deleteButton);
//                        UpdateProgress(taskPanel, progressBar);
//                    }
//                    catch (Exception ex)
//                    {
//                        MessageBox.Show($"Error deleting subtask: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    }
//                }
//            }
//        }

//        // Edit Subtask
//        private void EditSubtask(CheckBox subtaskCheckbox, string currentSubtaskName, DateTime currentSubDueDate)
//        {
//            // Prompt user for new subtask details
//            string newSubtaskName = Microsoft.VisualBasic.Interaction.InputBox("Edit subtask name:", "Edit Subtask", currentSubtaskName);
//            string newSubDueDateString = Microsoft.VisualBasic.Interaction.InputBox("Edit subtask due date (YYYY-MM-DD):", "Edit Subtask", currentSubDueDate.ToString("yyyy-MM-dd"));

//            if (string.IsNullOrWhiteSpace(newSubtaskName))
//            {
//                MessageBox.Show("Subtask name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (!DateTime.TryParse(newSubDueDateString, out DateTime newSubDueDate))
//            {
//                MessageBox.Show("Invalid date format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // Update subtask label and due date
//            subtaskCheckbox.Text = $"{newSubtaskName} (Due: {newSubDueDate:yyyy-MM-dd})";
//        }

//        // TaskInfo class to hold TaskId and DueDate
public class NotificationInfo
{
    public int NotificationId { get; set; }
    //public DateTime DueDate { get; set; }
}


//        // Load Main Tasks from the database
//        private void LoadMainTasks()
//        {
//            using (MySqlConnection connection = new MySqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();
//                    string query = "SELECT * FROM MainTasks";
//                    MySqlCommand cmd = new MySqlCommand(query, connection);
//                    using (MySqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            int taskId = reader.GetInt32("TaskId");
//                            string taskName = reader.GetString("TaskName");
//                            DateTime dueDate = reader.GetDateTime("DueDate");
//                            int progress = reader.GetInt32("Progress");

//                            // Create the UI for the main task
//                            var taskPanel = CreateTaskUI(taskName, dueDate, taskId, progress);

//                            // Load the subtasks for this main task
//                            LoadSubtasks(taskId, taskPanel, taskPanel.Controls.OfType<ProgressBar>().First());
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Error loading tasks from database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//        }
//        private void LoadSubtasks(int mainTaskId, FlowLayoutPanel taskPanel, ProgressBar progressBar)
//        {
//            using (MySqlConnection connection = new MySqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();
//                    string query = "SELECT SubtaskId, SubtaskName, SubtaskDueDate, IsCompleted FROM Subtasks WHERE MainTaskID = @MainTaskID";
//                    MySqlCommand cmd = new MySqlCommand(query, connection);
//                    cmd.Parameters.AddWithValue("@MainTaskID", mainTaskId);
//                    MySqlDataReader reader = cmd.ExecuteReader();

//                    int completedSubtasks = 0;
//                    int totalSubtasks = 0;

//                    while (reader.Read())
//                    {
//                        int subtaskId = reader.GetInt32("SubtaskId");
//                        string subtaskName = reader.GetString("SubtaskName");
//                        DateTime subtaskDueDate = reader.GetDateTime("SubtaskDueDate");
//                        bool isCompleted = reader.GetBoolean("IsCompleted");

//                        var subtaskCheckbox = new CheckBox
//                        {
//                            Text = $"{subtaskName} (Due: {subtaskDueDate:yyyy-MM-dd})",
//                            AutoSize = true,
//                            Checked = isCompleted,
//                            Tag = subtaskId // Store the SubtaskId in the Tag property
//                        };

//                        subtaskCheckbox.CheckedChanged += (s, eArgs) =>
//                        {
//                            UpdateSubtaskCompletionStatus(subtaskId, subtaskCheckbox.Checked);
//                            UpdateProgress(taskPanel, progressBar);
//                        };

//                        taskPanel.Controls.Add(subtaskCheckbox);

//                        totalSubtasks++;
//                        if (isCompleted) completedSubtasks++;
//                    }

//                    progressBar.Value = totalSubtasks > 0 ? (completedSubtasks * 100) / totalSubtasks : 0;
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Error loading subtasks from database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//        }

//        private void UpdateProgress(FlowLayoutPanel taskPanel, ProgressBar progressBar)
//        {
//            int totalSubtasks = 0;
//            int completedSubtasks = 0;

//            foreach (Control control in taskPanel.Controls.OfType<CheckBox>())
//            {
//                totalSubtasks++;
//                if (((CheckBox)control).Checked) completedSubtasks++;
//            }

//            progressBar.Value = totalSubtasks > 0 ? (completedSubtasks * 100 / totalSubtasks) : 0;
//            UpdateProgressInDatabase((taskPanel.Tag as TaskInfo).TaskId, progressBar.Value);
//        }

//        private void UpdateProgressInDatabase(int taskId, int progress)
//        {
//            using (MySqlConnection connection = new MySqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();
//                    string query = "UPDATE MainTasks SET Progress = @Progress WHERE TaskId = @TaskId";
//                    MySqlCommand cmd = new MySqlCommand(query, connection);
//                    cmd.Parameters.AddWithValue("@Progress", progress);
//                    cmd.Parameters.AddWithValue("@TaskId", taskId);
//                    cmd.ExecuteNonQuery();
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show($"Error updating task progress: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//        }
//    }
//}