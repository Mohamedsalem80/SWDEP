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
    public partial class UserControl1 : UserControl
    {

        private int _chatId;
        private string _chatName;
        public UserControl1()
        {
            InitializeComponent();
            // Attach click event handlers for the control and its children
            this.Click += UserControl_Click;
            foreach (Control control in this.Controls)
            {
                control.Click += UserControl_Click;

            }
        }

        public int ChatId
        {
            get
            {
                return _chatId;
            }
            set
            {
                _chatId = value;
            }
        }

        public string ChatName
        {
            get
            {
                return _chatName;
            }
            set
            {
                _chatName = value;
                labelChatName.Text = value;
            }
        }

        // Event to notify when the control is clicked
        public event EventHandler ChatClicked;

        private void UserControl_Click(object sender, EventArgs e)
        {
            ChatClicked?.Invoke(this, EventArgs.Empty);
        }


    }
}
