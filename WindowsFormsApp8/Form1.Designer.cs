namespace WindowsFormsApp8
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.sidebar = new System.Windows.Forms.Panel();
            this.p1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mainPannel = new System.Windows.Forms.Panel();
            this.btnNotepad = new System.Windows.Forms.Button();
            this.btnNotification = new System.Windows.Forms.Button();
            this.btnAI = new System.Windows.Forms.Button();
            this.btnNotes = new System.Windows.Forms.Button();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnTodo = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1206, 43);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(1059, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "GitHub";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1195, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(11, 43);
            this.panel3.TabIndex = 3;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.Black;
            this.sidebar.Controls.Add(this.btnNotepad);
            this.sidebar.Controls.Add(this.p1);
            this.sidebar.Controls.Add(this.btnNotification);
            this.sidebar.Controls.Add(this.btnAI);
            this.sidebar.Controls.Add(this.btnNotes);
            this.sidebar.Controls.Add(this.btnChat);
            this.sidebar.Controls.Add(this.btnTodo);
            this.sidebar.Controls.Add(this.pictureBox2);
            this.sidebar.Controls.Add(this.label1);
            this.sidebar.Cursor = System.Windows.Forms.Cursors.Default;
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 43);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(153, 739);
            this.sidebar.TabIndex = 1;
            this.sidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.sidebar_Paint);
            // 
            // p1
            // 
            this.p1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.p1.Location = new System.Drawing.Point(12, 66);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(10, 40);
            this.p1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(79, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dashboard";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mainPannel
            // 
            this.mainPannel.Cursor = System.Windows.Forms.Cursors.Default;
            this.mainPannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPannel.Location = new System.Drawing.Point(153, 43);
            this.mainPannel.Name = "mainPannel";
            this.mainPannel.Size = new System.Drawing.Size(1053, 739);
            this.mainPannel.TabIndex = 2;
            // 
            // btnNotepad
            // 
            this.btnNotepad.BackColor = System.Drawing.Color.Black;
            this.btnNotepad.BackgroundImage = global::WindowsFormsApp8.Properties.Resources.ph17;
            this.btnNotepad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNotepad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotepad.FlatAppearance.BorderSize = 0;
            this.btnNotepad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotepad.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotepad.ForeColor = System.Drawing.Color.White;
            this.btnNotepad.Location = new System.Drawing.Point(-87, 275);
            this.btnNotepad.Name = "btnNotepad";
            this.btnNotepad.Size = new System.Drawing.Size(252, 31);
            this.btnNotepad.TabIndex = 6;
            this.btnNotepad.Text = "                            Notepad\r\n";
            this.btnNotepad.UseVisualStyleBackColor = false;
            this.btnNotepad.Click += new System.EventHandler(this.btnNotepad_Click);
            // 
            // btnNotification
            // 
            this.btnNotification.BackColor = System.Drawing.Color.Black;
            this.btnNotification.BackgroundImage = global::WindowsFormsApp8.Properties.Resources.ph7;
            this.btnNotification.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNotification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotification.FlatAppearance.BorderSize = 0;
            this.btnNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotification.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotification.ForeColor = System.Drawing.Color.White;
            this.btnNotification.Location = new System.Drawing.Point(-101, 396);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(279, 34);
            this.btnNotification.TabIndex = 6;
            this.btnNotification.Text = "                              Notifications\r\n";
            this.btnNotification.UseVisualStyleBackColor = false;
            this.btnNotification.Click += new System.EventHandler(this.btnNotification_Click);
            // 
            // btnAI
            // 
            this.btnAI.BackColor = System.Drawing.Color.Black;
            this.btnAI.BackgroundImage = global::WindowsFormsApp8.Properties.Resources.ph6;
            this.btnAI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAI.FlatAppearance.BorderSize = 0;
            this.btnAI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAI.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAI.ForeColor = System.Drawing.Color.White;
            this.btnAI.Location = new System.Drawing.Point(-101, 336);
            this.btnAI.Name = "btnAI";
            this.btnAI.Size = new System.Drawing.Size(279, 29);
            this.btnAI.TabIndex = 6;
            this.btnAI.Text = "                               AI Assistant\r\n";
            this.btnAI.UseVisualStyleBackColor = false;
            this.btnAI.Click += new System.EventHandler(this.btnAI_Click);
            // 
            // btnNotes
            // 
            this.btnNotes.BackColor = System.Drawing.Color.Black;
            this.btnNotes.BackgroundImage = global::WindowsFormsApp8.Properties.Resources.ph5;
            this.btnNotes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNotes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotes.FlatAppearance.BorderSize = 0;
            this.btnNotes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotes.ForeColor = System.Drawing.Color.White;
            this.btnNotes.Location = new System.Drawing.Point(-101, 205);
            this.btnNotes.Name = "btnNotes";
            this.btnNotes.Size = new System.Drawing.Size(279, 43);
            this.btnNotes.TabIndex = 5;
            this.btnNotes.Text = "                              Quick Notes\r\n";
            this.btnNotes.UseVisualStyleBackColor = false;
            this.btnNotes.Click += new System.EventHandler(this.btnNotes_Click);
            // 
            // btnChat
            // 
            this.btnChat.BackColor = System.Drawing.Color.Black;
            this.btnChat.BackgroundImage = global::WindowsFormsApp8.Properties.Resources.ph3;
            this.btnChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChat.FlatAppearance.BorderSize = 0;
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChat.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChat.ForeColor = System.Drawing.Color.White;
            this.btnChat.Location = new System.Drawing.Point(-53, 137);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(191, 29);
            this.btnChat.TabIndex = 4;
            this.btnChat.Text = "                        Chat";
            this.btnChat.UseVisualStyleBackColor = false;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // btnTodo
            // 
            this.btnTodo.BackColor = System.Drawing.Color.Black;
            this.btnTodo.BackgroundImage = global::WindowsFormsApp8.Properties.Resources.ph2;
            this.btnTodo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTodo.FlatAppearance.BorderSize = 0;
            this.btnTodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodo.ForeColor = System.Drawing.Color.White;
            this.btnTodo.Location = new System.Drawing.Point(-53, 66);
            this.btnTodo.Name = "btnTodo";
            this.btnTodo.Size = new System.Drawing.Size(191, 43);
            this.btnTodo.TabIndex = 3;
            this.btnTodo.Text = "                        Todo";
            this.btnTodo.UseVisualStyleBackColor = false;
            this.btnTodo.Click += new System.EventHandler(this.btnTodo_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Image = global::WindowsFormsApp8.Properties.Resources.ph8;
            this.pictureBox2.Location = new System.Drawing.Point(21, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox3.Image = global::WindowsFormsApp8.Properties.Resources.ph1;
            this.pictureBox3.Location = new System.Drawing.Point(1154, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(41, 43);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1206, 782);
            this.Controls.Add(this.mainPannel);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Programmer Environment";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.sidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnTodo;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnNotes;
        private System.Windows.Forms.Button btnAI;
        private System.Windows.Forms.Button btnNotification;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel mainPannel;
        private System.Windows.Forms.Panel p1;
        private System.Windows.Forms.Button btnNotepad;
        private System.Windows.Forms.Label label2;
    }
}

