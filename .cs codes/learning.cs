using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace Flaminguage
{
    public partial class learning : Form
    {
        private SoundPlayer player = new SoundPlayer();

        public string pathbaselevelpics;
        public string guidecattext, guidecattitle;
        public int xpic, ypic;

        private static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Flaminguagedata.mdb");

        private static string connectionString = string.Format(
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Jet OLEDB:Database Password=;",
            dbPath
        );

        private int currentIndex = 0;
        private int currentQuestion = 0;
        private int totalQuestions = 5;
        private int score = 0;
        private string correctAnswer = "";
        private string TextForExit;
        private DataTable wordsTable = new DataTable();
        private Random rnd = new Random();

        public learning()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.CenterToScreen();
            this.Icon = Flaminguage.Properties.Resources.appicon;
        }

        private void learning_Load(object sender, EventArgs e)
        {
            levelchanger();
            pictures();
            texts();
            sizing();
            locations();
            colors();

            ShowWord(0);
            picchanger(pathbaselevelpics, label6.Text);
        }

        private void levelchanger()
        {
            switch (Flaminguage.Properties.Settings.Default.level)
            {
                case 1:
                    LoadData("Residence");
                    pathbaselevelpics = "Residence";
                    break;

                case 2:
                    LoadData("DailySeviccesProviderPlaces");
                    pathbaselevelpics = "DailySeviccesProviderPlaces";

                    break;

                case 3:
                    LoadData("EducationalPlaces");
                    pathbaselevelpics = "EducationalPlaces";

                    break;

                case 4:
                    LoadData("Places");
                    pathbaselevelpics = "Places";

                    break;

                case 5:
                    LoadData("GovernmentPlaces");
                    pathbaselevelpics = "GovernmentPlaces";

                    break;

                case 6:
                    LoadData("EconomicSevices");
                    pathbaselevelpics = "EconomicSevices";

                    break;
            }
        }

        private void pictures()
        {
            try
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

                pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Category\\{0}.png", "next"));
                pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Category\\{0}.png", "back"));
                pictureBox4.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Category\\{0}.png", "parrotspeaking2"));
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void colors()
        {
            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatStyle = FlatStyle.Flat;
            button3.FlatStyle = FlatStyle.Flat;

            button1.FlatAppearance.BorderColor = Color.FromArgb(255, 205, 178);
            button2.FlatAppearance.BorderColor = Color.FromArgb(255, 205, 178);
            button3.FlatAppearance.BorderColor = Color.FromArgb(255, 205, 178);

            this.BackColor = Color.FromArgb(69, 9, 32);
            pictureBox2.BackColor = Color.FromArgb(249, 107, 154);
            pictureBox3.BackColor = Color.FromArgb(249, 107, 154);

            label1.BackColor = Color.FromArgb(255, 205, 178);
            label2.BackColor = Color.FromArgb(255, 205, 178);
            label3.BackColor = Color.FromArgb(255, 205, 178);
            label4.BackColor = Color.FromArgb(255, 205, 178);
            label2.ForeColor = Color.FromArgb(69, 9, 32);
            label3.ForeColor = Color.FromArgb(69, 9, 32);
            label4.ForeColor = Color.FromArgb(69, 9, 32);

            label5.BackColor = Color.FromArgb(140, 41, 75);
            pictureBox1.BackColor = Color.FromArgb(140, 41, 75);
            pictureBox4.BackColor = Color.FromArgb(249, 107, 154);
            roundedPanel1.BackColor = Color.FromArgb(249, 107, 154);

            label6.BackColor = Color.FromArgb(249, 107, 154);
            label8.BackColor = Color.FromArgb(140, 41, 75);
            label7.BackColor = Color.FromArgb(249, 107, 154);

            label6.ForeColor = Color.FromArgb(255, 205, 178);
            label7.ForeColor = Color.FromArgb(255, 205, 178);
            label8.ForeColor = Color.FromArgb(255, 205, 178);

            button1.ForeColor = Color.FromArgb(140, 41, 75);
            button2.ForeColor = Color.FromArgb(140, 41, 75);
            button3.ForeColor = Color.FromArgb(140, 41, 75);
            button1.BackColor = Color.FromArgb(255, 205, 178);
            button2.BackColor = Color.FromArgb(255, 205, 178);
            button3.BackColor = Color.FromArgb(255, 205, 178);
        }

        private void sizing()
        {
            label1.Width = this.ClientSize.Width;
            label1.Height = label2.ClientSize.Height + 5;

            label5.Width = 6 * this.ClientSize.Width / 7;
            label5.Height = this.ClientSize.Height - 3 * label1.ClientSize.Height;

            pictureBox1.Width = 2 * label5.ClientSize.Width / 3;
            pictureBox1.Height = label5.ClientSize.Height;

            roundedPanel1.Size = new Size(9 * (label5.ClientSize.Width / 3) / 10, 9 * label5.ClientSize.Height / 10);
            roundedPanel1.CornerRadius = 25;

            pictureBox2.Width = 3 * (roundedPanel1.ClientSize.Width) / 10;
            pictureBox2.Height = pictureBox2.ClientSize.Width;

            pictureBox3.Width = pictureBox2.ClientSize.Width;
            pictureBox3.Height = pictureBox2.ClientSize.Height;

            pictureBox4.Width = 6 * roundedPanel1.ClientSize.Width / 10;
            pictureBox4.Height = pictureBox4.ClientSize.Width;
        }

        private void locations()
        {
            label1.Location = new Point(0, 0);
            label2.Location = new Point(5, label1.Location.Y + label1.ClientSize.Height / 2 - label2.ClientSize.Height / 2);
            label3.Location = new Point(label2.Location.X + label2.ClientSize.Width + 5, label1.Location.Y + label1.ClientSize.Height / 2 - label3.ClientSize.Height / 2);
            label4.Location = new Point(label3.Location.X + label3.ClientSize.Width + 5, label1.Location.Y + label1.ClientSize.Height / 2 - label4.ClientSize.Height / 2);

            label5.Location = new Point(this.ClientSize.Width / 2 - label5.ClientSize.Width / 2,
                (this.ClientSize.Height) / 2 - label5.ClientSize.Height / 2 + label1.ClientSize.Height / 2);

            pictureBox1.Location = new Point(label5.Location.X,
                label5.Location.Y);

            roundedPanel1.Location = new Point(label5.Location.X + pictureBox1.ClientSize.Width + (label5.ClientSize.Width / 6) - roundedPanel1.ClientSize.Width / 2,
                label5.Location.Y + label5.ClientSize.Height / 2 - roundedPanel1.ClientSize.Height / 2);

            label6.Location = new Point(roundedPanel1.Location.X + roundedPanel1.ClientSize.Width / 2 - label6.ClientSize.Width / 2,
                 roundedPanel1.Location.Y + roundedPanel1.ClientSize.Height / 2 - 8 * label6.ClientSize.Height / 10);

            pictureBox4.Location = new Point(roundedPanel1.Location.X + roundedPanel1.ClientSize.Width / 2 - pictureBox4.ClientSize.Width / 2,
                roundedPanel1.Location.Y);

            label7.Location = new Point(roundedPanel1.Location.X + roundedPanel1.ClientSize.Width / 2 - label7.ClientSize.Width / 2,
              label6.Location.Y + 2 * label6.ClientSize.Height);

            pictureBox2.Location = new Point(roundedPanel1.Location.X + roundedPanel1.ClientSize.Width - 11 * pictureBox2.ClientSize.Width / 10,
              roundedPanel1.Location.Y + roundedPanel1.ClientSize.Height - 3 * pictureBox2.ClientSize.Height / 2);

            pictureBox3.Location = new Point(roundedPanel1.Location.X + 1 * pictureBox2.ClientSize.Width / 10,
                    pictureBox2.Location.Y);

            label8.Location = new Point(this.ClientSize.Width / 2 - label8.ClientSize.Width / 2,
               label5.Location.Y + (label5.ClientSize.Height - (3 * button1.ClientSize.Height) - label8.ClientSize.Height) / 5);

            button2.Location = new Point(this.ClientSize.Width / 2 - button2.ClientSize.Width / 2,
                  label8.Location.Y + label8.ClientSize.Height + (label5.ClientSize.Height - (3 * button1.ClientSize.Height) - label8.ClientSize.Height) / 5);

            button1.Location = new Point(this.ClientSize.Width / 2 - button1.ClientSize.Width / 2,
                button2.Location.Y + button2.ClientSize.Height + (label5.ClientSize.Height - (3 * button1.ClientSize.Height) - label8.ClientSize.Height) / 5);

            button3.Location = new Point(this.ClientSize.Width / 2 - button3.ClientSize.Width / 2,
                button1.Location.Y + button1.ClientSize.Height + (label5.ClientSize.Height - (3 * button1.ClientSize.Height) - label8.ClientSize.Height) / 5);
        }

        private void texts()
        {
            try
            {
                label2.Font = new Font("FredokaLight", 16, FontStyle.Regular);
                label3.Font = new Font("FredokaLight", 16, FontStyle.Regular);
                label4.Font = new Font("FredokaLight", 16, FontStyle.Regular);
                label6.Font = new Font("FredokaLight", 32, FontStyle.Regular);
                label7.Font = new Font("NunitoExtraLight", 26, FontStyle.Regular);
                label8.Font = new Font("NunitoExtraLight", 32, FontStyle.Regular);

                button1.Font = new Font("FredokaLight", 24, FontStyle.Bold);
                button2.Font = new Font("FredokaLight", 24, FontStyle.Bold);
                button3.Font = new Font("FredokaLight", 24, FontStyle.Bold);

                switch (Flaminguage.Properties.Settings.Default.Languageapp)
                {
                    case "eng":

                        label1.Text = "";
                        label5.Text = "";
                        label2.Text = "Flaminguage";
                        label4.Text = "Back";
                        TextForExit = "Congratulations! You’ve unlocked the highest level.";
                        label3.Text = "Level: " + Flaminguage.Properties.Settings.Default.level;
                        guidecattitle = "How to use";
                        guidecattext = "On this page, learners will be presented with a set of vocabulary items along with their meanings and pronunciation. Upon completion, a test must be successfully completed in order to progress to the next level.";

                        break;

                    case "fr":

                        label1.Text = "";
                        label5.Text = "";
                        label2.Text = "Flaminguage";
                        label3.Text = "Niveau: " + Flaminguage.Properties.Settings.Default.level;
                        label4.Text = "Dos";
                        TextForExit = "Vous avez atteint le niveau maximum";
                        guidecattitle = "Comment utiliser";
                        guidecattext = "Sur cette page, les apprenants découvriront un ensemble de mots de vocabulaire accompagnés de leurs significations et de leur prononciation. À la fin, un test devra être complété avec succès afin de passer au niveau suivant.";

                        break;
                }
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void LoadData(string Tablename)
        {
            try
            {
                string sqlcode = string.Format("SELECT * FROM {0}", Tablename);
                OleDbDataAdapter da = new OleDbDataAdapter(sqlcode, connectionString);
                da.Fill(wordsTable);
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void ShowWord(int index)
        {
            try
            {
                label6.AutoSize = false;
                label7.AutoSize = false;

                label6.Width = 1;
                label6.Height = 1;
                label7.Width = 1;
                label7.Height = 1;

                label6.Text = wordsTable.Rows[index]["Word"].ToString();
                label7.Text = wordsTable.Rows[index]["Meaning"].ToString();

                label6.AutoSize = true;
                label7.AutoSize = true;

                roundedPanel1.Location = new Point(label5.Location.X + pictureBox1.ClientSize.Width + (label5.ClientSize.Width / 6) - roundedPanel1.ClientSize.Width / 2,
                    label5.Location.Y + label5.ClientSize.Height / 2 - roundedPanel1.ClientSize.Height / 2);

                label6.Location = new Point(roundedPanel1.Location.X + roundedPanel1.ClientSize.Width / 2 - label6.ClientSize.Width / 2,
                     roundedPanel1.Location.Y + roundedPanel1.ClientSize.Height / 2 - 8 * label6.ClientSize.Height / 10);

                pictureBox4.Location = new Point(roundedPanel1.Location.X + roundedPanel1.ClientSize.Width / 2 - pictureBox4.ClientSize.Width / 2,
                    roundedPanel1.Location.Y);

                label7.Location = new Point(roundedPanel1.Location.X + roundedPanel1.ClientSize.Width / 2 - label7.ClientSize.Width / 2,
                  label6.Location.Y + 2 * label6.ClientSize.Height);

                pictureBox2.Location = new Point(roundedPanel1.Location.X + roundedPanel1.ClientSize.Width - 11 * pictureBox2.ClientSize.Width / 10,
                  roundedPanel1.Location.Y + roundedPanel1.ClientSize.Height - 3 * pictureBox2.ClientSize.Height / 2);

                pictureBox3.Location = new Point(roundedPanel1.Location.X + 1 * pictureBox2.ClientSize.Width / 10,
                        pictureBox2.Location.Y);
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
                    switch (Flaminguage.Properties.Settings.Default.level)
                    {
                        case 1:
                            Flaminguage.Properties.Settings.Default.Score1 = score;
                            break;

                        case 2:
                            Flaminguage.Properties.Settings.Default.Score2 = score;
                            break;

                        case 3:
                            Flaminguage.Properties.Settings.Default.Score3 = score;
                            break;

                        case 4:
                            Flaminguage.Properties.Settings.Default.Score4 = score;
                            break;

                        case 5:
                            Flaminguage.Properties.Settings.Default.Score5 = score;
                            break;

                        case 6:
                            Flaminguage.Properties.Settings.Default.Score6 = score;
                            break;
                    }
                    if (Flaminguage.Properties.Settings.Default.level < 6)
                    {
                        Flaminguage.Properties.Settings.Default.level = Flaminguage.Properties.Settings.Default.level + 1;
                    }
                    else
                    {
                        MessageBox.Show(TextForExit);
                    }

                    Flaminguage.Properties.Settings.Default.Save();

                    MessageBox.Show("Test Result!\nTotal number of questions: " + totalQuestions + "\nYour score: " + score);
                    Category c = new Category();
                    player.Stop();
                    player.Dispose();
                    c.Show();

                    formdisposing(); this.Close(); this.Dispose();
                    return;
                }

                //choosing random word

                string word = wordsTable.Rows[currentIndex]["Word"].ToString();
                correctAnswer = wordsTable.Rows[currentIndex]["Meaning"].ToString();

                label8.AutoSize = false;

                label8.Width = 1;

                label8.Text = "What is the meaning of " + word + "?";

                label8.AutoSize = true;

                // label5.Width = label8.ClientSize .Width+button2 .ClientSize .Width + button3 .ClientSize .Width ;

                // Adding two other options for test
                List<string> options = wordsTable.AsEnumerable()
                    .Select(r => r["Meaning"].ToString())
                    .Where(m => m != correctAnswer)
                    .OrderBy(x => rnd.Next())
                    .Take(2)
                    .ToList();

                // Adding correct answer
                options.Add(correctAnswer);

                // Shffeling options
                options = options.OrderBy(x => rnd.Next()).ToList();

                // Putting words in buttons text
                button1.AutoSize = false;
                button2.AutoSize = false;
                button3.AutoSize = false;

                button1.Width = 1;
                button1.Height = 1;
                button2.Width = 1;
                button2.Height = 1;
                button3.Width = 1;
                button3.Height = 1;

                button1.Text = options[0];
                button2.Text = options[1];
                button3.Text = options[2];

                button1.AutoSize = true;
                button2.AutoSize = true;
                button3.AutoSize = true;

                //        label5.Location = new Point(this.ClientSize.Width / 2 - label5.ClientSize.Width / 2,
                //          this.ClientSize.Height / 2 - label5.ClientSize.Height / 2);

                label8.Location = new Point(this.ClientSize.Width / 2 - label8.ClientSize.Width / 2,
                label5.Location.Y + (label5.ClientSize.Height - (3 * button1.ClientSize.Height) - label8.ClientSize.Height) / 5);

                button2.Location = new Point(this.ClientSize.Width / 2 - button2.ClientSize.Width / 2,
                      label8.Location.Y + label8.ClientSize.Height + (label5.ClientSize.Height - (3 * button1.ClientSize.Height) - label8.ClientSize.Height) / 5);

                button1.Location = new Point(this.ClientSize.Width / 2 - button1.ClientSize.Width / 2,
                    button2.Location.Y + button2.ClientSize.Height + (label5.ClientSize.Height - (3 * button1.ClientSize.Height) - label8.ClientSize.Height) / 5);

                button3.Location = new Point(this.ClientSize.Width / 2 - button3.ClientSize.Width / 2,
                    button1.Location.Y + button1.ClientSize.Height + (label5.ClientSize.Height - (3 * button1.ClientSize.Height) - label8.ClientSize.Height) / 5);

                currentIndex++;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (wordsTable == null || wordsTable.Rows.Count == 0)
            {
                return;
            }

            currentIndex++;

            if (currentIndex >= wordsTable.Rows.Count)
            {
                label8.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;

                roundedPanel1.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                pictureBox3.Enabled = false;
                pictureBox3.Visible = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox2.Enabled = false;
                pictureBox4.Visible = false;
                pictureBox4.Enabled = false;

                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;

                totalQuestions = wordsTable.Rows.Count;
                currentIndex = 0;
                LoadQuestion();
            }
            else
            {
                ShowWord(currentIndex);
                picchanger(pathbaselevelpics, label6.Text);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (wordsTable == null || wordsTable.Rows.Count == 0)
            {
                return;
            }

            currentIndex--;

            if (currentIndex < 0)
            {
                currentIndex = 0;
                ShowWord(currentIndex);
                picchanger(pathbaselevelpics, label6.Text);
            }
            else
            {
                ShowWord(currentIndex);
                picchanger(pathbaselevelpics, label6.Text);
            }
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

        private void label4_Click(object sender, EventArgs e)
        {
            player.Stop();
            player.Dispose();
            Category c = new Category();
            c.Show();
            formdisposing();
            this.Close();
        }

        private void formdisposing()
        {
            label8.Font.Dispose();
            label7.Font.Dispose();
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

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(guidecattext, guidecattitle);
        }

        private void PlayMusicAndMessage(string index)
        {
            try
            {
                var musicPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("WordsPronunciation\\{0}.wav", index));

                if (File.Exists(musicPath))
                {
                    player.Stop();
                    player.SoundLocation = musicPath;
                    player.Play();
                }
                else
                {
                    var musicPath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("WordsPronunciation\\{0}.wav", "narration"));

                    player.Stop();
                    player.SoundLocation = musicPath2;
                    player.Play();
                }
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PlayMusicAndMessage(label6.Text);
        }

        private void picchanger(string pathlevel, string w)
        {
            try
            {
                pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                string.Format("Pictures\\Category\\{0}\\{1}.png", pathlevel, w));
            }
            catch (Exception ww)
            {
                MessageBox.Show(ww.Message);
            }
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            switch (((PictureBox)sender).Name)
            {
                case "pictureBox2":
                    pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Category\\{0}.png", "next2"));

                    break;

                case "pictureBox3":
                    pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Category\\{0}.png", "back2"));

                    break;

                case "pictureBox4":
                    pictureBox4.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Category\\{0}.png", "parrotspeaking"));

                    break;
            }
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            switch (((PictureBox)sender).Name)
            {
                case "pictureBox2":
                    pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Category\\{0}.png", "next"));

                    break;

                case "pictureBox3":
                    pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Category\\{0}.png", "back"));

                    break;

                case "pictureBox4":
                    pictureBox4.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Category\\{0}.png", "parrotspeaking2"));

                    break;
            }
        }
    }
}