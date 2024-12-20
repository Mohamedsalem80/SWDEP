using System;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class UserControlUserMessage : UserControl
    {
        private int _messageId;
        private string _message;
        private ContextMenuStrip contextMenu;

        public UserControlUserMessage()
        {
            InitializeComponent();

            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Update", null, UpdateMessage);
            contextMenu.Items.Add("Delete", null, DeleteMessage);

            this.ContextMenuStrip = contextMenu;

            labelUserMessage.MouseDown += LabelUserMessage_MouseDown;
        }

        public int MessageId
        {
            get
            {
                return _messageId;
            }

            set
            {
                _messageId = value;
            }
        }

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                labelUserMessage.Text = value;
            }
        }

        public void AddHeighttext()
        {
            UserControlUserMessage userMessage = new UserControlUserMessage();
            userMessage.BringToFront();
            labelUserMessage.Height = Class1.GetTextHeight(labelUserMessage);
            userMessage.Height = labelUserMessage.Top + labelUserMessage.Height;
            this.Height = userMessage.Bottom + 5;
        }

        private void LabelUserMessage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show(this, e.Location);
            }
        }

        private void UpdateMessage(object sender, EventArgs e)
        {
            string newMessage = Prompt.ShowDialog("Update Message", "Enter the new message:", _message);

            if (!string.IsNullOrEmpty(newMessage))
            {
                _message = newMessage;
                labelUserMessage.Text = newMessage;

                OnUpdateMessage?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Message cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DeleteMessage(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this message?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                OnDeleteMessage?.Invoke(this, EventArgs.Empty);

                this.Parent.Controls.Remove(this);
            }
        }

        public event EventHandler OnUpdateMessage;
        public event EventHandler OnDeleteMessage;
    }


}

