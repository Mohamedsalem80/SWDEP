using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class TodoForm : Form
    {
        // Forms for different task views
        private FormTasks tasks;
        private FormCompletedTask completedTask;
        private FormUpcomingTasks upcomingTasks;

        // Sidebar state
        private bool sidebarExpand = true;

        public TodoForm()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form load logic can be implemented here
        }

        private void Tasks_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Clear reference to the Tasks form when closed
            tasks = null;
        }

        private void CompletedTasks_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Clear reference to the Completed Tasks form when closed
            completedTask = null;
        }

        private void UpcomingTasks_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Clear reference to the Upcoming Tasks form when closed
            upcomingTasks = null;
        }




        private void button2_Click_1(object sender, EventArgs e)
        {

            // Open or activate the Tasks form
            if (tasks == null)
            {
                tasks = new FormTasks();
                tasks.FormClosed += Tasks_FormClosed;
                tasks.MdiParent = this;
                tasks.Dock = DockStyle.Fill;
                tasks.Show();
            }
            else
            {
                tasks.Activate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            // Open or activate the Completed Tasks form
            if (completedTask == null)
            {
                completedTask = new FormCompletedTask();
                completedTask.FormClosed += CompletedTasks_FormClosed;
                completedTask.MdiParent = this;
                completedTask.Dock = DockStyle.Fill;
                completedTask.Show();
            }
            else
            {
                completedTask.Activate();
            }

            // Refresh the list of completed tasks
            completedTask.RefreshTasks();
        }

        private void pnupcomingtasks_Click_1(object sender, EventArgs e)
        {
          
            // Open or activate the Upcoming Tasks form
            if (upcomingTasks == null)
            {
                upcomingTasks = new FormUpcomingTasks();
                upcomingTasks.FormClosed += UpcomingTasks_FormClosed;
                upcomingTasks.MdiParent = this;
                upcomingTasks.Dock = DockStyle.Fill;
                upcomingTasks.Show();
            }
            else
            {
                upcomingTasks.Activate();
            }

            // Refresh the list of upcoming tasks
            upcomingTasks.RefreshTasks();
        }

        private void btmHam_Click(object sender, EventArgs e)
        {     // Animate sidebar expansion or collapse
            sidebartransition.Start();

        }

        private void sidebartransition_Tick_1(object sender, EventArgs e)
        {
            // Animate sidebar expansion or collapse
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 55)
                {
                    sidebarExpand = false;
                    sidebartransition.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width > 180)
                {
                    sidebarExpand = true;
                    sidebartransition.Stop();

                    // Adjust the widths of related panels
                    pntasks.Width = sidebar.Width;
                    pncompletedtasks.Width = sidebar.Width;
                    pnupcomtasks.Width = sidebar.Width;
                }
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            button2_Click_1(sender, e);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pnupcomingtasks_Click_1(sender, e);
        }

        private void p1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TodoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
