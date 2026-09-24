using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Flaminguage
{
    public partial class TypeSpeed : Form
    {
        private Naudiohandler x = new Naudiohandler();

        public int songstate = 0;
        private int currentWordIndex = 0;
        private List<string> levelWords;
        private static readonly Random rnd = new Random();
        public int xlabel, ylabel;
        public int movementspeed = 5;
        public int lifeofgame = 10;
        public int numberforlife = 10;
        public int databasewordscount;
        public int userscore = 0;
        public int i = 0;
        public int j = 2;
        public string userword, TableName;
        public string TextForExit, GameOver;

        public TypeSpeed()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.CenterToScreen();
            this.Icon = Flaminguage.Properties.Resources.appicon;

            databasewordscount = 100;
            TableName = "Dictionary";
            try
            {
                // Getting random words directly from DB
                levelWords = WordManager.LoadAllWords(TableName);

                // Shuffling by Fisher-Yates
                for (int z = levelWords.Count - 1; z > 0; z--)
                {
                    int w = rnd.Next(z + 1);
                    w = rnd.Next(z + 1);
                    var temp = levelWords[z];
                    levelWords[z] = levelWords[w];
                    levelWords[w] = temp;
                }
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void TypeSpeed_Load(object sender, EventArgs e)
        {
            texts();
            sizing();
            locations();
            colors();

            locationLabel1(1);
            locationLabel1(2);
            locationLabel1(3);

            timer1.Enabled = true;

            PlayMusicAndMessage();
        }

        private void PlayMusicAndMessage()
        {
            try
            {
                x.SetPlaylist(new List<string>
                {
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "12")),
                     Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "13")),
                     Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "11")),
                     Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "10")),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "4")),
            }, 0);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        private void texts()
        {
            try
            {
                label1.Text = levelWords[0];
                label2.Text = levelWords[1];
                label3.Text = levelWords[2];
                currentWordIndex = 3; // I already used first 3

                label1.Font = new Font("BebasNeue", 16, FontStyle.Regular);
                label2.Font = new Font("BebasNeue", 16, FontStyle.Regular);
                label3.Font = new Font("BebasNeue", 16, FontStyle.Regular);

                label5.Font = new Font("BebasNeue", 14, FontStyle.Bold);
                label6.Font = new Font("BebasNeue", 14, FontStyle.Bold);
                button1.Font = new Font("BebasNeue", 16, FontStyle.Bold);
                button2.Font = new Font("BebasNeue", 16, FontStyle.Bold);
                textBox1.Font = new Font("BebasNeue", 14, FontStyle.Bold);

                switch (Flaminguage.Properties.Settings.Default.Languageapp)
                {
                    case "eng":

                        label4.Text = "";

                        label5.Text = "Life: ";
                        label6.Text = "Score:";
                        label7.Text = "";
                        TextForExit = "Are you sure?";
                        GameOver = "GameOver";

                        break;

                    case "fr":

                        label4.Text = "";

                        label5.Text = "Vie: ";
                        label6.Text = "Score:";
                        label7.Text = "";
                        TextForExit = "Es-tu sûr?";
                        GameOver = "Jeu terminé";

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
            label4.Width = this.ClientSize.Width;
            label4.Height = label5.ClientSize.Height + 2;

            label7.Width = this.ClientSize.Width;
            label7.Height = this.ClientSize.Height / 4;

            textBox1.Width = this.ClientSize.Width / 3;
            textBox1.Height = 2 * button1.ClientSize.Height + 5;
        }

        private void locations()
        {
            label4.Location = new Point(0, 0);
            label6.Location = new Point(this.ClientSize.Width / 2 - label6.ClientSize.Width / 2
                , label4.ClientSize.Height / 2 - label6.ClientSize.Height / 2);

            label7.Location = new Point(0, this.ClientSize.Height - label7.ClientSize.Height);

            button1.Location = new Point(this.ClientSize.Width - 2 * button1.ClientSize.Width,
                label7.Location.Y + label7.ClientSize.Height / 2 - 3 * button1.ClientSize.Height / 2);

            button2.Location = new Point(button1.Location.X,
                label7.Location.Y + label7.ClientSize.Height / 2 + button2.ClientSize.Height / 2);

            textBox1.Location = new Point(label7.ClientSize.Width / 2 - textBox1.ClientSize.Width / 2,
          label7.Location.Y + label7.ClientSize.Height / 2 - textBox1.ClientSize.Height / 2);

            label5.Location = new Point(button1.ClientSize.Width
                , textBox1.Location.Y + textBox1.ClientSize.Height / 2 - label5.ClientSize.Height / 2);
        }

        private void colors()
        {
            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);
            button2.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);
            textBox1.BorderStyle = BorderStyle.FixedSingle;

            this.BackColor = Color.FromArgb(69, 9, 32);

            label1.BackColor = Color.FromArgb(69, 9, 32);
            label2.BackColor = Color.FromArgb(69, 9, 32);
            label3.BackColor = Color.FromArgb(69, 9, 32);
            label1.ForeColor = Color.FromArgb(255, 205, 178);
            label2.ForeColor = Color.FromArgb(255, 205, 178);
            label3.ForeColor = Color.FromArgb(255, 205, 178);

            label4.BackColor = Color.FromArgb(255, 205, 178);
            label6.BackColor = Color.FromArgb(255, 205, 178);
            label6.ForeColor = Color.FromArgb(69, 9, 32);

            label7.BackColor = Color.FromArgb(181, 131, 141);
            label5.BackColor = Color.FromArgb(181, 131, 141);
            label5.ForeColor = Color.FromArgb(69, 9, 32);
            button1.ForeColor = Color.FromArgb(69, 9, 32);
            button2.ForeColor = Color.FromArgb(69, 9, 32);
            button1.BackColor = Color.FromArgb(181, 131, 141);
            button2.BackColor = Color.FromArgb(181, 131, 141);
            textBox1.BackColor = Color.White;
            textBox1.ForeColor = Color.FromArgb(69, 9, 32);
        }

        public void locationLabel1(int labelnumber)
        {
            switch (labelnumber)
            {
                case 1:

                    //Label 1 Locating

                    xlabel = rnd.Next(0, Math.Max(1, this.ClientSize.Width / 3 - label1.ClientSize.Width));
                    ylabel = rnd.Next(-label1.ClientSize.Height, 0);
                    label1.Location = new Point(xlabel, ylabel);

                    break;

                case 2:
                    //Label 2 Locating

                    xlabel = rnd.Next(
           this.ClientSize.Width / 3,
           Math.Max(this.ClientSize.Width / 3 + 1, 2 * this.ClientSize.Width / 3 - label2.ClientSize.Width));
                    ylabel = rnd.Next(-3 * label2.ClientSize.Height, 0);
                    label2.Location = new Point(xlabel, ylabel);
                    break;

                case 3:
                    //Label 3 Locating

                    xlabel = rnd.Next(
            2 * this.ClientSize.Width / 3,
            Math.Max(2 * this.ClientSize.Width / 3 + 1, this.ClientSize.Width - label3.ClientSize.Width)
        );
                    ylabel = rnd.Next(-5 * label3.ClientSize.Height, 0);
                    label3.Location = new Point(xlabel, ylabel);
                    break;
            }
        }

        private void ShowNextWord(Label lbl)
        {
            try
            {
                if (currentWordIndex < levelWords.Count)
                {
                    lbl.Text = levelWords[currentWordIndex];
                    currentWordIndex++;
                }
                else
                {
                    //infinity shuffling list
                    // no more words, leave blank

                    currentWordIndex = 0;
                    // Shuffling by Fisher-Yates
                    for (int z = levelWords.Count - 1; z > 0; z--)
                    {
                        int w = rnd.Next(z + 1);
                        var temp = levelWords[z];
                        levelWords[z] = levelWords[w];
                        levelWords[w] = temp;
                    }

                    lbl.Text = levelWords[currentWordIndex].Trim().Normalize(NormalizationForm.FormC).Replace("’", "'").Replace("–", "-").Replace("—", "-");
                    //      lbl.Visible = false;
                }
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label1.Location.Y > label7.Location.Y - 20)
            {
                lifeofgame = lifeofgame - 1;

                if (lifeofgame == 0)
                {
                    timer1.Stop(); timer1.Enabled = false; timer1.Dispose();

                    i = 0;
                    lifeofgame = numberforlife;
                    userscore = 0;
                    MessageBox.Show(GameOver);

                    Home h = new Home();
                    h.Show();
                    x.Dispose();
                    formdisposing(); this.Close(); this.Dispose();
                }

                locationLabel1(1);
            }
            else
            {
                label1.Top += j;
            }

            if (label2.Location.Y > label7.Location.Y - 20)
            {
                lifeofgame = lifeofgame - 1;
                if (lifeofgame == 0)
                {
                    timer1.Stop(); timer1.Enabled = false; timer1.Dispose();
                    i = 0;

                    lifeofgame = numberforlife;
                    userscore = 0;

                    MessageBox.Show(GameOver);

                    Home h = new Home();
                    h.Show();
                    x.Dispose();
                    formdisposing(); this.Close(); this.Dispose();
                }

                locationLabel1(2);
            }
            else
            {
                label2.Top += j;
            }

            if (label3.Location.Y > label7.Location.Y - 20)
            {
                lifeofgame = lifeofgame - 1;
                if (lifeofgame == 0)
                {
                    timer1.Stop(); timer1.Enabled = false; timer1.Dispose();

                    i = 0;

                    lifeofgame = numberforlife;
                    userscore = 0;

                    MessageBox.Show(GameOver);

                    Home h = new Home();
                    h.Show();
                    x.Dispose();
                    formdisposing(); this.Close(); this.Dispose();
                }

                locationLabel1(3);
            }
            else
            {
                label3.Top += j;
            }

            switch (Flaminguage.Properties.Settings.Default.Languageapp)
            {
                case "eng":
                    label5.Text = "Life: " + lifeofgame;

                    break;

                case "fr":
                    label5.Text = "Vie: " + lifeofgame;

                    break;
            }

            label5.Location = new Point(button1.ClientSize.Width
              , textBox1.Location.Y + textBox1.ClientSize.Height / 2 - label5.ClientSize.Height / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (songstate)
                {
                    case 0:

                        x.Play();
                        songstate = 1;
                        break;
                }

                if (textBox1.Text != "")
                {
                    if (textBox1.Text.Trim().Equals(label1.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        userscore = userscore + 1;
                        label6.Text = "Score: " + userscore;
                        label6.Location = new Point(this.ClientSize.Width / 2 - label6.ClientSize.Width / 2
                                        , label4.ClientSize.Height / 2 - label6.ClientSize.Height / 2);
                        i++;
                        if (i == databasewordscount)
                        {
                            timer1.Stop(); timer1.Enabled = false; timer1.Dispose();

                            userscore = 0;

                            MessageBox.Show("Victory");
                            Home h = new Home();
                            h.Show();

                            x.Dispose();
                            formdisposing(); this.Close(); this.Dispose();
                        }
                        else
                        {
                            locationLabel1(1);

                            ShowNextWord(label1);
                            locationLabel1(1);
                        }
                    }
                    else if (textBox1.Text.Trim().Equals(label2.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        userscore = userscore + 1;
                        label6.Text = "Score: " + userscore;
                        label6.Location = new Point(this.ClientSize.Width / 2 - label6.ClientSize.Width / 2
                                        , label4.ClientSize.Height / 2 - label6.ClientSize.Height / 2);
                        i++;

                        if (i == databasewordscount)
                        {
                            timer1.Stop(); timer1.Enabled = false; timer1.Dispose();

                            userscore = 0;

                            MessageBox.Show("Victory");
                            Home h = new Home();
                            h.Show();
                            x.Dispose();
                            formdisposing(); this.Close(); this.Dispose();
                        }
                        else
                        {
                            locationLabel1(2);

                            ShowNextWord(label2);
                            locationLabel1(2);
                        }
                    }
                    else if (textBox1.Text.Trim().Equals(label3.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        userscore = userscore + 1;
                        label6.Text = "Score: " + userscore;
                        label6.Location = new Point(this.ClientSize.Width / 2 - label6.ClientSize.Width / 2
                                        , label4.ClientSize.Height / 2 - label6.ClientSize.Height / 2);
                        i++;

                        if (i == databasewordscount)
                        {
                            timer1.Stop(); timer1.Enabled = false; timer1.Dispose();
                            userscore = 0;

                            MessageBox.Show("Victory");
                            Home h = new Home();
                            h.Show();
                            x.Dispose();
                            formdisposing(); this.Close(); this.Dispose();
                        }
                        else
                        {
                            locationLabel1(3);

                            ShowNextWord(label3);
                            locationLabel1(3);
                        }
                    }
                    else
                    {
                        userscore = userscore - 1;
                        label6.Text = "Score: " + userscore;
                        label6.Location = new Point(this.ClientSize.Width / 2 - label6.ClientSize.Width / 2
                                        , label4.ClientSize.Height / 2 - label6.ClientSize.Height / 2);
                    }
                }

                textBox1.Clear();
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (songstate)
                {
                    case 0:

                        x.Play();
                        songstate = 1;
                        break;
                }

                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    if (textBox1.Text != "")
                    {
                        if (textBox1.Text.Trim().Equals(label1.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            userscore = userscore + 1;
                            label6.Text = "Score: " + userscore;
                            label6.Location = new Point(this.ClientSize.Width / 2 - label6.ClientSize.Width / 2
                                            , label4.ClientSize.Height / 2 - label6.ClientSize.Height / 2);
                            i++;

                            if (i == databasewordscount)
                            {
                                timer1.Stop(); timer1.Enabled = false; timer1.Dispose();

                                userscore = 0;

                                MessageBox.Show("Victory");
                                Home h = new Home();
                                h.Show();
                                x.Dispose();
                                formdisposing(); this.Close(); this.Dispose();
                            }
                            else
                            {
                                locationLabel1(1);

                                ShowNextWord(label1);
                                locationLabel1(1);
                            }
                        }
                        else if (textBox1.Text.Trim().Equals(label2.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            userscore = userscore + 1;
                            label6.Text = "Score: " + userscore;
                            label6.Location = new Point(this.ClientSize.Width / 2 - label6.ClientSize.Width / 2
                                            , label4.ClientSize.Height / 2 - label6.ClientSize.Height / 2);
                            i++;

                            if (i == databasewordscount)
                            {
                                timer1.Stop(); timer1.Enabled = false; timer1.Dispose();

                                userscore = 0;

                                MessageBox.Show("Victory");
                                Home h = new Home();
                                h.Show();
                                x.Dispose();
                                formdisposing(); this.Close(); this.Dispose();
                            }
                            else
                            {
                                locationLabel1(2);

                                ShowNextWord(label2);
                                locationLabel1(2);
                            }
                        }
                        else if (textBox1.Text.Trim().Equals(label3.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            userscore = userscore + 1;
                            label6.Text = "Score: " + userscore;
                            label6.Location = new Point(this.ClientSize.Width / 2 - label6.ClientSize.Width / 2
                                            , label4.ClientSize.Height / 2 - label6.ClientSize.Height / 2);
                            i++;

                            if (i == databasewordscount)
                            {
                                timer1.Stop(); timer1.Enabled = false; timer1.Dispose();

                                userscore = 0;

                                MessageBox.Show("Victory");
                                Home h = new Home();
                                h.Show();
                                x.Dispose();
                                formdisposing(); this.Close(); this.Dispose();
                            }
                            else
                            {
                                locationLabel1(3);

                                ShowNextWord(label3);
                                locationLabel1(3);
                            }
                        }
                        else
                        {
                            userscore = userscore - 1;
                            label6.Text = "Score: " + userscore;
                            label6.Location = new Point(this.ClientSize.Width / 2 - label6.ClientSize.Width / 2
                                            , label4.ClientSize.Height / 2 - label6.ClientSize.Height / 2);
                        }
                    }

                    textBox1.Clear();
                }
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show(TextForExit, "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                x.Stop();
                x.Dispose();
                Home h = new Home();
                h.Show();

                formdisposing(); this.Close(); this.Dispose();
            }
        }

        private void formdisposing()
        {
            label1.Font.Dispose();
            label5.Font.Dispose();
            button1.Font.Dispose();
            textBox1.Font.Dispose();
        }

        private void TypeSpeed_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:

                    x.Next();

                    break;

                case MouseButtons.Middle:

                    x.Stop();
                    songstate = 0;

                    break;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            j++;
        }
    }
}