﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadform(new TodoForm());
            p1.Visible = true;
        }
        bool sidebarExpand = true;

        public void loadform(object Form)
        {
            if (this.mainPannel.Controls.Count > 0)
                this.mainPannel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainPannel.Controls.Add(f);
            this.mainPannel.Tag = f;
            f.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 61)
                {
                    sidebar.Width = 61;
                    sidebarExpand = false;
                    timer1.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 152)
                {
                    sidebar.Width = 152;
                    sidebarExpand = true;
                    timer1.Stop();
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnTodo_Click(object sender, EventArgs e)
        {
            loadform(new TodoForm());
            position(btnTodo);
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            loadform(new ChatForm());
            position(btnChat);
        }

        private void btnNotes_Click(object sender, EventArgs e)
        {
            loadform(new Quick_Note());
            position(btnNotes);
        }

        private void btnAI_Click(object sender, EventArgs e)
        {
            loadform(new AIForm());
            position(btnAI);
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            loadform(new Notification());
            position(btnNotification);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            position(btnTodo);
        }
        private void position(Button b)
        {
            int newX = b.Location.X - p1.Width;
            int newY = b.Location.Y;
            if (newX < 0) newX = 0;
            if (newY < 0) newY = 0;

            p1.Location = new Point(newX, newY);
        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnNotepad_Click(object sender, EventArgs e)
        {
            loadform(new Notepad());
            position(btnNotepad);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Log_GitHub newForm = new Log_GitHub();
            newForm.Show();
        }
    }
}