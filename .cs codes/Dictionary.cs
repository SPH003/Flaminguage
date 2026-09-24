using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Flaminguage
{
    public partial class Dictionary : Form
    {
        public Dictionary()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.CenterToScreen();
            this.Icon = Flaminguage.Properties.Resources.appicon;
        }

        private void Dictionary_Load(object sender, EventArgs e)
        {
            texts();
            ConnectToDatabase();
            LoadDataToGrid();
            sizing();
            locations();
            colors();
        }

        private void colors()
        {
            this.BackColor = Color.FromArgb(69, 9, 32);
            label1.BackColor = Color.FromArgb(255, 205, 178);
            label2.BackColor = Color.FromArgb(255, 205, 178);
            dataGridView1.BackColor = Color.FromArgb(255, 205, 178);
            dataGridView1.GridColor = Color.FromArgb(255, 205, 178);
            dataGridView1.ForeColor = Color.FromArgb(69, 9, 32);
            label2.ForeColor = Color.FromArgb(69, 9, 32);
        }

        private void texts()
        {
            try
            {
                label2.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                dataGridView1.Font = new Font("NunitoExtraLight", 15, FontStyle.Regular);

                switch (Flaminguage.Properties.Settings.Default.Languageapp)
                {
                    case "eng":

                        label1.Text = "";
                        label2.Text = "Home Menu";
                        break;

                    case "fr":

                        label1.Text = "";
                        label2.Text = "Menu d'accueil";
                        break;
                }
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void sizing()
        {
            label1.Width = this.ClientSize.Width;
            label1.Height = label2.ClientSize.Height + 5;
            dataGridView1.Width = this.ClientSize.Width;
            dataGridView1.Height = this.ClientSize.Height - label1.ClientSize.Height;
        }

        private void locations()
        {
            label1.Location = new Point(0, 0);
            label2.Location = new Point(5, label1.Location.Y + label1.ClientSize.Height / 2 - label2.ClientSize.Height / 2);
            dataGridView1.Location = new Point(0, label1.Location.Y + label1.ClientSize.Height);
        }

        private void ConnectToDatabase()
        {
            string databaselocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Flaminguagedata.mdb");
            string connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0}; Jet OLEDB:Database Password=;", databaselocation);

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Connection Successful ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Please check your DataBase, Connection is lost " + ex.Message);
                }
            }
        }

        private void LoadDataToGrid()
        {
            // Defining the path .
            string databaselocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Flaminguagedata.mdb");

            // Building connection string of database with the password.
            string connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Jet OLEDB:Database Password=;", databaselocation);

            // SQL query to select all records from database table.
            string query = "SELECT * FROM Dictionary";

            // Using a DataTable to store the results
            DataTable dt = new DataTable();

            // Wraping the connection in a using block.
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    // Creating an adapter for the SELECT query.
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);

                    // Filling the DataTable.
                    adapter.Fill(dt);

                    // Assigning the DataTable as the data source for the DataGridView.
                    dataGridView1.DataSource = dt;

                    int totalRowHeight = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        totalRowHeight += row.Height;
                    }

                    // Adding the height of the column headers
                    //totalRowHeight += dataGridView1.ColumnHeadersHeight;

                    // Adding a little padding
                    //totalRowHeight += 2;

                    // Setting the height of the DataGridView
                    //dataGridView1.Height = totalRowHeight;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            formdisposing();
            this.Close();
        }

        private void formdisposing()
        {
            label2.Font.Dispose();
            dataGridView1.Dispose();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.FromArgb(69, 9, 32);
            ((Label)sender).ForeColor = Color.FromArgb(255, 205, 178);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).BackColor = Color.FromArgb(255, 205, 178);
            ((Label)sender).ForeColor = Color.FromArgb(69, 9, 32);
        }
    }
}