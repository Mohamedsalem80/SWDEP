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
    public partial class UserControlMessage : UserControl
    {
        private int _messageId;
        private string _message;
        private string _senderName;
        public UserControlMessage()
        {
            InitializeComponent();
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
                labelMessage.Text = value;
            }
        }

        public string senderName
        {
            get
            {
                return _senderName;
            }
            set
            {
                _senderName = value;
                labelSenderName.Text = value;
            }
        }

        public void AddHeighttext()
        {
            UserControlMessage message = new UserControlMessage();
            message.BringToFront();
            labelMessage.Height = Class1.GetTextHeight(labelMessage);
            message.Height = labelMessage.Top + labelMessage.Height + labelSenderName.Top;
            this.Height = message.Bottom;
        }

        private void labelMessage_Click(object sender, EventArgs e)
        {

        }
    }
}
