namespace WindowsFormsApp8
{
    partial class UserControlUserMessage
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
            this.labelUserMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUserMessage
            // 
            this.labelUserMessage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelUserMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserMessage.ForeColor = System.Drawing.Color.Gold;
            this.labelUserMessage.Location = new System.Drawing.Point(5, 5);
            this.labelUserMessage.Name = "labelUserMessage";
            this.labelUserMessage.Size = new System.Drawing.Size(340, 40);
            this.labelUserMessage.TabIndex = 0;
            this.labelUserMessage.Text = "label1";
            // 
            // UserControlUserMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.labelUserMessage);
            this.Name = "UserControlUserMessage";
            this.Size = new System.Drawing.Size(350, 50);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUserMessage;
    }
}
