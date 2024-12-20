namespace WindowsFormsApp8
{
    partial class UserControl1
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
            this.labelChatName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelChatName
            // 
            this.labelChatName.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelChatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChatName.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelChatName.Location = new System.Drawing.Point(3, 3);
            this.labelChatName.Name = "labelChatName";
            this.labelChatName.Size = new System.Drawing.Size(233, 40);
            this.labelChatName.TabIndex = 0;
            this.labelChatName.Text = "Chat";
            this.labelChatName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.labelChatName);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(239, 46);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelChatName;
    }
}
