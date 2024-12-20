using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    internal class Prompt
    {
        public static string ShowDialog(string title, string label, string defaultText = "")
        {
            Form prompt = new Form
            {
                Width = 400,
                Height = 200,
                Text = title,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label textLabel = new Label() { Left = 10, Top = 20, Width = 360, Text = label };
            TextBox inputBox = new TextBox() { Left = 10, Top = 50, Width = 360, Text = defaultText };
            Button confirmation = new Button() { Text = "OK", Left = 260, Top = 100, Width = 100 };

            confirmation.DialogResult = DialogResult.OK;
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);

            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : defaultText;
        }
    }
}
