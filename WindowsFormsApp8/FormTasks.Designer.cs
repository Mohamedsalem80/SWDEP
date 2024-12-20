using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApp8
{
    partial class FormTasks
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.taskoptn = new System.Windows.Forms.Panel();
            this.addMainTaskButton = new System.Windows.Forms.Button();
            this.mainflowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.taskoptn.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskoptn
            // 
            this.taskoptn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.taskoptn.Controls.Add(this.addMainTaskButton);
            this.taskoptn.Dock = System.Windows.Forms.DockStyle.Top;
            this.taskoptn.Location = new System.Drawing.Point(0, 0);
            this.taskoptn.Name = "taskoptn";
            this.taskoptn.Size = new System.Drawing.Size(953, 49);
            this.taskoptn.TabIndex = 0;
            // 
            // addMainTaskButton
            // 
            this.addMainTaskButton.AutoSize = true;
            this.addMainTaskButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.addMainTaskButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addMainTaskButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addMainTaskButton.Location = new System.Drawing.Point(0, 0);
            this.addMainTaskButton.Name = "addMainTaskButton";
            this.addMainTaskButton.Size = new System.Drawing.Size(953, 29);
            this.addMainTaskButton.TabIndex = 0;
            this.addMainTaskButton.Text = "Add Main Task";
            this.addMainTaskButton.UseVisualStyleBackColor = false;
            // 
            // mainflowLayoutPanel
            // 
            this.mainflowLayoutPanel.AutoScroll = true;
            this.mainflowLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainflowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainflowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.mainflowLayoutPanel.Location = new System.Drawing.Point(0, 49);
            this.mainflowLayoutPanel.Name = "mainflowLayoutPanel";
            this.mainflowLayoutPanel.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.mainflowLayoutPanel.Size = new System.Drawing.Size(953, 523);
            this.mainflowLayoutPanel.TabIndex = 1;
            this.mainflowLayoutPanel.WrapContents = false;
            this.mainflowLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainflowLayoutPanel_Paint_1);
            // 
            // FormTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(953, 572);
            this.Controls.Add(this.mainflowLayoutPanel);
            this.Controls.Add(this.taskoptn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTasks";
            this.Text = "FormTasks";
            this.taskoptn.ResumeLayout(false);
            this.taskoptn.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel taskoptn;
        private Button addMainTaskButton;
        private FlowLayoutPanel mainflowLayoutPanel;
    }
}