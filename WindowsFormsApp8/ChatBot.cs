using WindowsFormsApp8.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class ChatBot : Form
    {
        public RunModel MODEL;

        public ChatBot()
        {
            InitializeComponent();
            MODEL = new RunModel();

            // Configure the FlowLayoutPanel
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.AutoScroll = true;
        }

        // Event handler for label1 click
        private void label1_Click(object sender, EventArgs e)
        {
            // You can add functionality here if you need the label to do something when clicked
        }

        private void ChatBot_Load(object sender, EventArgs e)
        {
            // Any code to initialize when the form loads
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userInput = textBox1.Text;
            if (!string.IsNullOrWhiteSpace(userInput))
            {
                AddMessage("You", userInput, Color.LightBlue, ContentAlignment.MiddleRight);

                try
                {
                    string botOutput = MODEL.askRunModel(userInput);
                    AddMessage("ChatBot", botOutput, Color.LightGray, ContentAlignment.MiddleLeft);

                    textBox1.Clear(); // Clear the input box
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a message before clicking Ask.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AddMessage(string sender, string message, Color backgroundColor, ContentAlignment alignment)
        {
            // Create a panel for the message
            var messagePanel = new Panel
            {
                AutoSize = true,
                BackColor = backgroundColor,
                Margin = new Padding(5, 5, 5, 5),
                Dock = DockStyle.Top, // Ensures it spans the width of the FlowLayoutPanel
                Padding = new Padding(10)
            };

            // Create a label for the message
            var messageLabel = new Label
            {
                Text = $"{sender}: {message}",
                AutoSize = true,
                ForeColor = Color.Black,
                TextAlign = alignment,
                MaximumSize = new Size(flowLayoutPanel1.Width - 30, 0) // Wraps text within the panel
            };

            messagePanel.Controls.Add(messageLabel);
            flowLayoutPanel1.Controls.Add(messagePanel);

            // Scroll to the bottom to show the latest message
            flowLayoutPanel1.ScrollControlIntoView(messagePanel);
        }
    }
}