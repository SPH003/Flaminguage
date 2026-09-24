using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Flaminguage
{
    public partial class VocabTest : Form
    {
        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Flaminguagedata.mdb");

        private static string connectionString = string.Format(
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Jet OLEDB:Database Password=;",
            dbPath
        );

        private int currentQuestion = 0;
        private int totalQuestions = 5; // Total number of questions
        private int score = 0;
        private string correctAnswer = "";
        private string TextForExit, texterror, textsubject;

        private Random rnd = new Random();
        private DataTable wordsTable = new DataTable();

        public VocabTest()
        {
            InitializeComponent();

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.CenterToScreen();
            this.Icon = Flaminguage.Properties.Resources.appicon;
        }

        private void VocabTest_Load(object sender, EventArgs e)
        {
            texts();
            sizing();
            LoadData();
            LoadQuestion();
            locations();
            colors();
        }

        private void texts()
        {
            try
            {
                label2.Font = new Font("BebasNeue", 16, FontStyle.Regular);
                label3.Font = new Font("BebasNeue", 20, FontStyle.Regular);
                label4.Font = new Font("BebasNeue", 16, FontStyle.Regular);
                label6.Font = new Font("BebasNeue", 16, FontStyle.Regular);

                button1.Font = new Font("BebasNeue", 14, FontStyle.Bold);
                button2.Font = new Font("BebasNeue", 14, FontStyle.Bold);
                button3.Font = new Font("BebasNeue", 14, FontStyle.Bold);
                button4.Font = new Font("BebasNeue", 14, FontStyle.Bold);
                button5.Font = new Font("BebasNeue", 14, FontStyle.Bold);
                button6.Font = new Font("BebasNeue", 14, FontStyle.Bold);

                switch (Flaminguage.Properties.Settings.Default.Languageapp)
                {
                    case "eng":

                        label1.Text = "";
                        label5.Text = "";
                        label2.Text = "Flaminguage";
                        label4.Text = "Home Menu";
                        label6.Text = "How many questions do you want to answer (1-1170)?";
                        TextForExit = "Are you sure?";
                        button6.Text = "Run";
                        texterror = "Input the right question total number between 1-1170";
                        textsubject = "Wrong input";
                        break;

                    case "fr":

                        label1.Text = "";
                        label5.Text = "";
                        label2.Text = "Flaminguage";
                        label4.Text = "Menu d'accueil";
                        label6.Text = "À combien de questions souhaitez-vous répondre (1-1170)?";
                        TextForExit = "Es-tu sûr?";
                        button6.Text = "Courir";
                        texterror = "Saisissez le numéro total de la question correcte, compris entre 1 et 1170.";
                        textsubject = "Mauvaise saisie";
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
            label1.Height = label2.ClientSize.Height + 2;

            label5.Width = 2 * this.ClientSize.Width / 3;
            label5.Height = this.ClientSize.Height / 2;
        }

        private void locations()
        {
            label1.Location = new Point(0, 0);
            label2.Location = new Point(20, label1.Location.Y + label1.ClientSize.Height / 2 - label2.ClientSize.Height / 2);
            label4.Location = new Point(label2.Location.X + label2.ClientSize.Width + 5, label1.Location.Y + label1.ClientSize.Height / 2 - label4.ClientSize.Height / 2);

            label5.Location = new Point(this.ClientSize.Width / 2 - label5.ClientSize.Width / 2,
                this.ClientSize.Height / 2 - label5.ClientSize.Height / 2);
            label3.Location = new Point(label5.Location.X + label5.ClientSize.Width / 2 - label3.ClientSize.Width / 2,
                label5.Location.Y + label3.ClientSize.Height);

            button3.Location = new Point(label5.Location.X + label5.ClientSize.Width / 2 - button3.ClientSize.Width / 2,
               label5.Location.Y + label5.ClientSize.Height / 2 - button3.ClientSize.Height / 2);

            button4.Location = new Point(label5.Location.X + label5.ClientSize.Width / 2 - button4.ClientSize.Width / 2,
               button3.Location.Y + button3.ClientSize.Height + 5);

            button5.Location = new Point(label5.Location.X + label5.ClientSize.Width / 2 - button5.ClientSize.Width / 2,
            button4.Location.Y + button4.ClientSize.Height + 5);

            button2.Location = new Point(label5.Location.X + label5.ClientSize.Width / 2 - button2.ClientSize.Width / 2,
               button3.Location.Y - button2.ClientSize.Height - 5);

            button1.Location = new Point(label5.Location.X + label5.ClientSize.Width / 2 - button1.ClientSize.Width / 2,
               button2.Location.Y - button1.ClientSize.Height - 5);

            label6.Location = new Point(label5.Location.X + label5.ClientSize.Width / 2 - label6.ClientSize.Width / 2,
                           label5.Location.Y + label6.ClientSize.Height);

            textBox1.Location = new Point(label5.Location.X + label5.ClientSize.Width / 2 - textBox1.ClientSize.Width / 2,
                label5.Location.Y + label5.ClientSize.Height / 2 - textBox1.ClientSize.Height / 2);

            button6.Location = new Point(this.ClientSize.Width / 2 - button6.ClientSize.Width / 2,
                textBox1.Location.Y + textBox1.ClientSize.Height + button6.ClientSize.Height);
        }

        private void colors()
        {
            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatStyle = FlatStyle.Flat;
            button3.FlatStyle = FlatStyle.Flat;
            button4.FlatStyle = FlatStyle.Flat;
            button5.FlatStyle = FlatStyle.Flat;
            button6.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);
            button2.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);
            button3.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);
            button4.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);
            button5.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);
            button6.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);

            this.BackColor = Color.FromArgb(69, 9, 32);
            label1.BackColor = Color.FromArgb(255, 205, 178);
            label2.BackColor = Color.FromArgb(255, 205, 178);
            label4.BackColor = Color.FromArgb(255, 205, 178);
            label2.ForeColor = Color.FromArgb(69, 9, 32);
            label4.ForeColor = Color.FromArgb(69, 9, 32);

            label5.BackColor = Color.FromArgb(255, 205, 178);
            label3.BackColor = Color.FromArgb(255, 205, 178);
            label6.BackColor = Color.FromArgb(255, 205, 178);
            label3.ForeColor = Color.FromArgb(69, 9, 32);
            label6.ForeColor = Color.FromArgb(69, 9, 32);
            button1.BackColor = Color.FromArgb(109, 104, 117);
            button2.BackColor = Color.FromArgb(109, 104, 117);
            button3.BackColor = Color.FromArgb(109, 104, 117);
            button4.BackColor = Color.FromArgb(109, 104, 117);
            button5.BackColor = Color.FromArgb(109, 104, 117);
            button6.BackColor = Color.FromArgb(109, 104, 117);
            button1.ForeColor = Color.FromArgb(249, 219, 189);
            button2.ForeColor = Color.FromArgb(249, 219, 189);
            button3.ForeColor = Color.FromArgb(249, 219, 189);
            button4.ForeColor = Color.FromArgb(249, 219, 189);
            button5.ForeColor = Color.FromArgb(249, 219, 189);
            button6.ForeColor = Color.FromArgb(249, 219, 189);
        }

        private void LoadData()
        {
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Dictionary", connectionString);
                da.Fill(wordsTable);
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void LoadQuestion()
        {
            try
            {
                if (currentQuestion >= totalQuestions)
                {
                    MessageBox.Show("Test Result!\nTotal number of questions: " + totalQuestions + "\nYour score: " + score);
                    Home h = new Home();
                    h.Show();

                    formdisposing(); this.Close(); this.Dispose();
                    return;
                }

                // Choosing randmomly a word for test
                int randIndex = rnd.Next(wordsTable.Rows.Count);
                string word = wordsTable.Rows[randIndex]["Word"].ToString();
                correctAnswer = wordsTable.Rows[randIndex]["Meaning"].ToString();

                label3.Text = "What is the meaning of " + word + "?";
                label3.Location = new Point(label5.Location.X + label5.ClientSize.Width / 2 - label3.ClientSize.Width / 2,
                 label5.Location.Y + label3.ClientSize.Height);

                // Choosing wrong answers
                List<string> options = wordsTable.AsEnumerable()
                    .Select(r => r["Meaning"].ToString())
                    .Where(m => m != correctAnswer)
                    .OrderBy(x => rnd.Next())
                    .Take(4)
                    .ToList();

                // Adding the correct option
                options.Add(correctAnswer);

                // Shuffling
                options = options.OrderBy(x => rnd.Next()).ToList();

                // Putting words into buttons
                button1.Text = options[0];
                button2.Text = options[1];
                button3.Text = options[2];
                button4.Text = options[3];
                button5.Text = options[4];

                button3.Location = new Point(label5.Location.X + label5.ClientSize.Width / 2 - button3.ClientSize.Width / 2,
                     label5.Location.Y + label5.ClientSize.Height / 2 - button3.ClientSize.Height / 2);

                button4.Location = new Point(label5.Location.X + label5.ClientSize.Width / 2 - button4.ClientSize.Width / 2,
                   button3.Location.Y + button3.ClientSize.Height + 5);

                button5.Location = new Point(label5.Location.X + label5.ClientSize.Width / 2 - button5.ClientSize.Width / 2,
                button4.Location.Y + button4.ClientSize.Height + 5);

                button2.Location = new Point(label5.Location.X + label5.ClientSize.Width / 2 - button2.ClientSize.Width / 2,
                   button3.Location.Y - button2.ClientSize.Height - 5);

                button1.Location = new Point(label5.Location.X + label5.ClientSize.Width / 2 - button1.ClientSize.Width / 2,
                   button2.Location.Y - button1.ClientSize.Height - 5);

                currentQuestion++;
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void CheckAnswer(Button btn)
        {
            if (btn.Text == correctAnswer)
            {
                score++;
                MessageBox.Show("✅ Correct!");
            }
            else
            {
                MessageBox.Show("❌ Wrong!");
            }

            LoadQuestion();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAnswer(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckAnswer(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CheckAnswer(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CheckAnswer(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CheckAnswer(button5);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show(TextForExit, "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                Home h = new Home();
                h.Show();

                formdisposing(); this.Close(); this.Dispose();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null | textBox1.Text == "")
            {
                MessageBox.Show(texterror, textsubject, MessageBoxButtons.OK);
            }
            else
            {
                if (int.Parse(textBox1.Text) > 0 & int.Parse(textBox1.Text) < 1171)
                {
                    totalQuestions = int.Parse(textBox1.Text);
                    textBox1.Clear();
                    textBox1.Enabled = false;
                    textBox1.Visible = false;
                    button6.Enabled = false;
                    button6.Visible = false;
                    label6.Visible = false;

                    label3.Visible = true;
                    button1.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button5.Visible = true;

                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                }
                else
                {
                    MessageBox.Show(texterror, textsubject, MessageBoxButtons.OK);
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(char.IsNumber((char)e.KeyCode) | e.KeyCode == Keys.Back))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void formdisposing()
        {
            label3.Font.Dispose();

            label2.Font.Dispose();
            button1.Font.Dispose();
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