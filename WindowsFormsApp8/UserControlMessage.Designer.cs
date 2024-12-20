namespace WindowsFormsApp8
{
    partial class UserControlMessage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSenderName = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSenderName
            // 
            this.labelSenderName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelSenderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSenderName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelSenderName.Location = new System.Drawing.Point(5, 5);
            this.labelSenderName.Name = "labelSenderName";
            this.labelSenderName.Size = new System.Drawing.Size(340, 20);
            this.labelSenderName.TabIndex = 0;
            this.labelSenderName.Text = "SenderName";
            // 
            // labelMessage
            // 
            this.labelMessage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.ForeColor = System.Drawing.Color.Gold;
            this.labelMessage.Location = new System.Drawing.Point(5, 30);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(340, 45);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.Text = "label1";
            this.labelMessage.Click += new System.EventHandler(this.labelMessage_Click);
            // 
            // UserControlMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.labelSenderName);
            this.Name = "UserControlMessage";
            this.Size = new System.Drawing.Size(350, 80);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelSenderName;
        private System.Windows.Forms.Label labelMessage;
    }
}
