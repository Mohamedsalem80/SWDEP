using System.Windows.Forms;

namespace WindowsFormsApp8
{
    partial class TodoForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TodoForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btmHam = new System.Windows.Forms.PictureBox();
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.pntasks = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pncompletedtasks = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.pnupcomtasks = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pnupcomingtasks = new System.Windows.Forms.Button();
            this.sidebartransition = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btmHam)).BeginInit();
            this.sidebar.SuspendLayout();
            this.pntasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pncompletedtasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.pnupcomtasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btmHam);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1042, 34);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(52, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "TODO-LIST ";
            // 
            // btmHam
            // 
            this.btmHam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btmHam.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btmHam.ErrorImage")));
            this.btmHam.Image = ((System.Drawing.Image)(resources.GetObject("btmHam.Image")));
            this.btmHam.Location = new System.Drawing.Point(10, 2);
            this.btmHam.Name = "btmHam";
            this.btmHam.Size = new System.Drawing.Size(29, 29);
            this.btmHam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btmHam.TabIndex = 1;
            this.btmHam.TabStop = false;
            this.btmHam.Click += new System.EventHandler(this.btmHam_Click);
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.Black;
            this.sidebar.Controls.Add(this.pntasks);
            this.sidebar.Controls.Add(this.pncompletedtasks);
            this.sidebar.Controls.Add(this.pnupcomtasks);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.sidebar.Location = new System.Drawing.Point(0, 34);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(198, 604);
            this.sidebar.TabIndex = 1;
            this.sidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.sidebar_Paint);
            // 
            // pntasks
            // 
            this.pntasks.Controls.Add(this.pictureBox3);
            this.pntasks.Controls.Add(this.button2);
            this.pntasks.Location = new System.Drawing.Point(3, 3);
            this.pntasks.Name = "pntasks";
            this.pntasks.Padding = new System.Windows.Forms.Padding(0, 26, 0, 0);
            this.pntasks.Size = new System.Drawing.Size(209, 59);
            this.pntasks.TabIndex = 3;
            // 
            // pictureBox3
            // 
            this.pictureBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(9, 13);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 29);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // button2
            // 
            this.button2.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(-9, -16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(228, 90);
            this.button2.TabIndex = 0;
            this.button2.Text = "TASKS";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // pncompletedtasks
            // 
            this.pncompletedtasks.Controls.Add(this.pictureBox4);
            this.pncompletedtasks.Controls.Add(this.button3);
            this.pncompletedtasks.Location = new System.Drawing.Point(3, 68);
            this.pncompletedtasks.Name = "pncompletedtasks";
            this.pncompletedtasks.Padding = new System.Windows.Forms.Padding(0, 26, 0, 0);
            this.pncompletedtasks.Size = new System.Drawing.Size(209, 59);
            this.pncompletedtasks.TabIndex = 4;
            // 
            // pictureBox4
            // 
            this.pictureBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(9, 15);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(29, 29);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // button3
            // 
            this.button3.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.button3.BackColor = System.Drawing.Color.Black;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(-9, -5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(256, 78);
            this.button3.TabIndex = 0;
            this.button3.Text = "COMPLETED TASKS";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pnupcomtasks
            // 
            this.pnupcomtasks.Controls.Add(this.pictureBox5);
            this.pnupcomtasks.Controls.Add(this.pnupcomingtasks);
            this.pnupcomtasks.Location = new System.Drawing.Point(3, 133);
            this.pnupcomtasks.Name = "pnupcomtasks";
            this.pnupcomtasks.Padding = new System.Windows.Forms.Padding(0, 26, 0, 0);
            this.pnupcomtasks.Size = new System.Drawing.Size(209, 59);
            this.pnupcomtasks.TabIndex = 5;
            // 
            // pictureBox5
            // 
            this.pictureBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(9, 14);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(29, 29);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 3;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pnupcomingtasks
            // 
            this.pnupcomingtasks.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonMenu;
            this.pnupcomingtasks.BackColor = System.Drawing.Color.Black;
            this.pnupcomingtasks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnupcomingtasks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnupcomingtasks.ForeColor = System.Drawing.SystemColors.Control;
            this.pnupcomingtasks.Location = new System.Drawing.Point(-9, -15);
            this.pnupcomingtasks.Name = "pnupcomingtasks";
            this.pnupcomingtasks.Size = new System.Drawing.Size(256, 88);
            this.pnupcomingtasks.TabIndex = 0;
            this.pnupcomingtasks.Text = "UPCOMING TASKS";
            this.pnupcomingtasks.UseVisualStyleBackColor = false;
            this.pnupcomingtasks.Click += new System.EventHandler(this.pnupcomingtasks_Click_1);
            // 
            // sidebartransition
            // 
            this.sidebartransition.Interval = 10;
            this.sidebartransition.Tick += new System.EventHandler(this.sidebartransition_Tick_1);
            // 
            // TodoForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1042, 638);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel1);
            this.IsMdiContainer = true;
            this.Name = "TodoForm";
            this.Text = "TODO LIST";
            this.Load += new System.EventHandler(this.TodoForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btmHam)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.pntasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pncompletedtasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.pnupcomtasks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private PictureBox btmHam;
        private Label label1;
        private FlowLayoutPanel sidebar;
        private Panel pntasks;
        private Button button2;
        private Panel pncompletedtasks;
        private Button button3;
        private Panel pnupcomtasks;
        private Button pnupcomingtasks;
        private System.Windows.Forms.Timer sidebartransition;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
    }
}
