namespace WindowsFormsApp8
{
    partial class Drawing
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
            this.TopPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.eraser_btn = new System.Windows.Forms.Button();
            this.paintbrush_btn = new System.Windows.Forms.Button();
            this.paintbrush_size = new System.Windows.Forms.NumericUpDown();
            this.colorbox = new System.Windows.Forms.Button();
            this.canvasPannel = new System.Windows.Forms.Panel();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paintbrush_size)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.TopPanel.Controls.Add(this.colorbox);
            this.TopPanel.Controls.Add(this.paintbrush_size);
            this.TopPanel.Controls.Add(this.eraser_btn);
            this.TopPanel.Controls.Add(this.paintbrush_btn);
            this.TopPanel.Controls.Add(this.btnSave);
            this.TopPanel.Controls.Add(this.btnClear);
            this.TopPanel.Controls.Add(this.panel2);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1174, 72);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            this.TopPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1154, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 72);
            this.panel2.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1060, 10);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 54);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Tai Le", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(934, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 54);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // eraser_btn
            // 
            this.eraser_btn.BackgroundImage = global::WindowsFormsApp8.Properties.Resources.ph11;
            this.eraser_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.eraser_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eraser_btn.FlatAppearance.BorderSize = 0;
            this.eraser_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eraser_btn.Location = new System.Drawing.Point(436, 16);
            this.eraser_btn.Name = "eraser_btn";
            this.eraser_btn.Size = new System.Drawing.Size(49, 46);
            this.eraser_btn.TabIndex = 1;
            this.eraser_btn.UseVisualStyleBackColor = true;
            this.eraser_btn.Click += new System.EventHandler(this.eraser_btn_Click);
            // 
            // paintbrush_btn
            // 
            this.paintbrush_btn.BackgroundImage = global::WindowsFormsApp8.Properties.Resources.ph101;
            this.paintbrush_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.paintbrush_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.paintbrush_btn.FlatAppearance.BorderSize = 0;
            this.paintbrush_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paintbrush_btn.Location = new System.Drawing.Point(630, 10);
            this.paintbrush_btn.Name = "paintbrush_btn";
            this.paintbrush_btn.Size = new System.Drawing.Size(34, 59);
            this.paintbrush_btn.TabIndex = 1;
            this.paintbrush_btn.UseVisualStyleBackColor = true;
            this.paintbrush_btn.Click += new System.EventHandler(this.paintbrush_btn_Click);
            // 
            // paintbrush_size
            // 
            this.paintbrush_size.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.paintbrush_size.ForeColor = System.Drawing.Color.White;
            this.paintbrush_size.Location = new System.Drawing.Point(694, 29);
            this.paintbrush_size.Name = "paintbrush_size";
            this.paintbrush_size.Size = new System.Drawing.Size(63, 22);
            this.paintbrush_size.TabIndex = 1;
            this.paintbrush_size.ValueChanged += new System.EventHandler(this.paintbrushsize_changed);
            // 
            // colorbox
            // 
            this.colorbox.BackColor = System.Drawing.Color.Black;
            this.colorbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorbox.FlatAppearance.BorderSize = 0;
            this.colorbox.Location = new System.Drawing.Point(524, 10);
            this.colorbox.Name = "colorbox";
            this.colorbox.Size = new System.Drawing.Size(64, 59);
            this.colorbox.TabIndex = 1;
            this.colorbox.UseVisualStyleBackColor = false;
            this.colorbox.Click += new System.EventHandler(this.colorbox_Click);
            // 
            // canvasPannel
            // 
            this.canvasPannel.BackColor = System.Drawing.Color.White;
            this.canvasPannel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPannel.Location = new System.Drawing.Point(0, 72);
            this.canvasPannel.Name = "canvasPannel";
            this.canvasPannel.Size = new System.Drawing.Size(1174, 676);
            this.canvasPannel.TabIndex = 1;
            this.canvasPannel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvasPannel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            // 
            // Drawing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 748);
            this.Controls.Add(this.canvasPannel);
            this.Controls.Add(this.TopPanel);
            this.Name = "Drawing";
            this.Text = "Drawing";
            this.Load += new System.EventHandler(this.Drawing_Load);
            this.TopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paintbrush_size)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button paintbrush_btn;
        private System.Windows.Forms.Button eraser_btn;
        private System.Windows.Forms.NumericUpDown paintbrush_size;
        private System.Windows.Forms.Button colorbox;
        private System.Windows.Forms.Panel canvasPannel;
    }
}