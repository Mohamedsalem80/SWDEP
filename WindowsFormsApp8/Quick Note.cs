using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp8
{
    public partial class Quick_Note : Form
    {
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        MySqlCommand cmd;
        MySqlDataAdapter adapt;
        int selectedNoteID = 0;

        public Quick_Note()
        {
            InitializeComponent();
            DisplayData();
        }

        private void bttnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "" && txtContent.Text != "")
            {
                try
                {
                    cmd = new MySqlCommand("INSERT INTO db.notes(title, content) VALUES(@title, @content)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@content", txtContent.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DisplayData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill out all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayData()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                adapt = new MySqlDataAdapter("SELECT id, title, content FROM db.notes", con);
                adapt.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();

                if (dataGridView2.Columns["id"] != null)
                {
                    dataGridView2.Columns["id"].Visible = false;
                }

                if (dataGridView2.Columns["title"] != null)
                {
                    dataGridView2.Columns["title"].Width = (int)(dataGridView2.Width * 0.3); 
                }

                if (dataGridView2.Columns["content"] != null)
                {
                    dataGridView2.Columns["content"].Width = (int)(dataGridView2.Width * 0.7); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearData()
        {
            txtTitle.Text = "";
            txtContent.Text = "";
            selectedNoteID = 0;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedNoteID > 0)
            {
                if (txtTitle.Text != "" && txtContent.Text != "")
                {
                    try
                    {
                        cmd = new MySqlCommand("UPDATE db.notes SET title=@title, content=@content WHERE id=@id", con);
                        con.Open();
                        cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                        cmd.Parameters.AddWithValue("@content", txtContent.Text);
                        cmd.Parameters.AddWithValue("@id", selectedNoteID);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        DisplayData();
                        ClearData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Fill out all fields to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Select a note to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedNoteID > 0)
            {
                try
                {
                    cmd = new MySqlCommand("DELETE FROM db.notes WHERE id=@id", con);
                    cmd.Parameters.AddWithValue("@id", selectedNoteID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DisplayData();
                    ClearData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Select a note to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                selectedNoteID = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["id"].Value);
                txtTitle.Text = dataGridView2.Rows[e.RowIndex].Cells["title"].Value.ToString();
                txtContent.Text = dataGridView2.Rows[e.RowIndex].Cells["content"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            Drawing drawingAppForm = new Drawing();
            drawingAppForm.Show();
        }
    }
}
