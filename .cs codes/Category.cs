using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Flaminguage
{
    public partial class Category : Form
    {
        public int Xo, Yo;

        public string guidecattitle, guidecattext;

        public Category()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.CenterToScreen();
            this.Icon = Flaminguage.Properties.Resources.appicon;
        }

        private void Category_Load(object sender, EventArgs e)
        {
            pictures();
            levelchanger();
            texts();
            sizing();
            locations();
            colors();
        }

        private void levelchanger()
        {
            try
            {
                switch (Flaminguage.Properties.Settings.Default.level)
                {
                    case 1:

                        pictureBox1.Enabled = true;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;

                        label1.Enabled = true;

                        pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox1d"));
                        pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox2d"));
                        pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox3d"));
                        pictureBox4.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox4d"));
                        pictureBox5.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox5d"));
                        pictureBox6.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox6d"));

                        break;

                    case 2:

                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = true;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;

                        label1.Enabled = false;

                        pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox1f"));
                        pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox2d"));
                        pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox3d"));
                        pictureBox4.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox4d"));
                        pictureBox5.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox5d"));
                        pictureBox6.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox6d"));

                        break;

                    case 3:

                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = true;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;

                        label1.Enabled = false;

                        pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox1f"));
                        pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox2f"));
                        pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox3d"));
                        pictureBox4.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox4d"));
                        pictureBox5.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox5d"));
                        pictureBox6.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox6d"));

                        break;

                    case 4:

                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = true;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = false;

                        label1.Enabled = false;

                        pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox1f"));
                        pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox2f"));
                        pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox3f"));
                        pictureBox4.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox4d"));
                        pictureBox5.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox5d"));
                        pictureBox6.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox6d"));

                        break;

                    case 5:

                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = true;
                        pictureBox6.Enabled = false;

                        label1.Enabled = false;

                        pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox1f"));
                        pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox2f"));
                        pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox3f"));
                        pictureBox4.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox4f"));
                        pictureBox5.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox5d"));
                        pictureBox6.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox6d"));

                        break;

                    case 6:

                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;
                        pictureBox6.Enabled = true;

                        label1.Enabled = false;

                        pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox1f"));
                        pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox2f"));
                        pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox3f"));
                        pictureBox4.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox4f"));
                        pictureBox5.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox5f"));
                        pictureBox6.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "pictureBox6d"));

                        break;
                }
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
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
                pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;

                pictureBox7.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", "backgr"));
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void colors()
        {
            this.BackColor = Color.FromArgb(244, 131, 124);

            label1.BackColor = Color.FromArgb(255, 205, 178);
            label2.BackColor = Color.FromArgb(255, 205, 178);
            label3.BackColor = Color.FromArgb(255, 205, 178);
            label10.BackColor = Color.FromArgb(255, 205, 178);
            label2.ForeColor = Color.FromArgb(69, 9, 32);
            label3.ForeColor = Color.FromArgb(69, 9, 32);
            label10.ForeColor = Color.FromArgb(69, 9, 32);

            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            pictureBox6.BackColor = Color.Transparent;

            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;

            label4.ForeColor = Color.DarkRed;
            label5.ForeColor = Color.DarkRed;
            label6.ForeColor = Color.DarkRed;
            label7.ForeColor = Color.DarkRed;
            label8.ForeColor = Color.DarkRed;
            label9.ForeColor = Color.DarkRed;
        }

        private void texts()
        {
            try
            {
                label2.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label3.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label4.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label5.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label6.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label7.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label8.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label9.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label10.Font = new Font("FredokaLight", 15, FontStyle.Regular);

                switch (Flaminguage.Properties.Settings.Default.Languageapp)
                {
                    case "eng":

                        label1.Text = "";
                        label2.Text = "Flaminguage";
                        label3.Text = "Level: " + Flaminguage.Properties.Settings.Default.level;
                        label4.Text = "Score: " + Flaminguage.Properties.Settings.Default.Score1;
                        label5.Text = "Score: " + Flaminguage.Properties.Settings.Default.Score2;
                        label6.Text = "Score: " + Flaminguage.Properties.Settings.Default.Score3;
                        label7.Text = "Score: " + Flaminguage.Properties.Settings.Default.Score4;
                        label8.Text = "Score: " + Flaminguage.Properties.Settings.Default.Score5;
                        label9.Text = "Score: " + Flaminguage.Properties.Settings.Default.Score6;
                        label10.Text = "Home Menu";
                        guidecattext = "On this page, you can practice vocabulary by repeating each word. Audio pronunciations and images are provided to help you learn and remember the words more effectively.";
                        guidecattitle = "How to use";

                        break;

                    case "fr":

                        label1.Text = "";
                        label2.Text = "Flaminguage";
                        label3.Text = "Niveau: " + Flaminguage.Properties.Settings.Default.level;
                        label4.Text = "Score: " + Flaminguage.Properties.Settings.Default.Score1;
                        label5.Text = "Score: " + Flaminguage.Properties.Settings.Default.Score2;
                        label6.Text = "Score: " + Flaminguage.Properties.Settings.Default.Score3;
                        label7.Text = "Score: " + Flaminguage.Properties.Settings.Default.Score4;
                        label8.Text = "Score: " + Flaminguage.Properties.Settings.Default.Score5;
                        label9.Text = "Score: " + Flaminguage.Properties.Settings.Default.Score6;
                        label10.Text = "Menu d'accueil";
                        guidecattext = "Sur cette page, vous pouvez vous entraîner à mémoriser les mots en les répétant. Vous trouverez également des enregistrements audio et des photos pour vous aider à les retenir.";
                        guidecattitle = "Comment utiliser";

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

            pictureBox1.Width = this.ClientSize.Width / 3;
            pictureBox1.Height = (this.ClientSize.Height - label1.ClientSize.Height) / 2;

            pictureBox2.Width = pictureBox1.Width;
            pictureBox2.Height = pictureBox1.Height;

            pictureBox3.Width = pictureBox1.Width;
            pictureBox3.Height = pictureBox1.Height;

            pictureBox4.Width = pictureBox1.Width;
            pictureBox4.Height = pictureBox1.Height;

            pictureBox5.Width = pictureBox1.Width;
            pictureBox5.Height = pictureBox1.Height;

            pictureBox6.Width = pictureBox1.Width;
            pictureBox6.Height = pictureBox1.Height;

            pictureBox7.Width = this.ClientSize.Width;
            pictureBox7.Height = this.ClientSize.Height;
        }

        private void locations()
        {
            label4.Parent = pictureBox1;
            label5.Parent = pictureBox2;
            label6.Parent = pictureBox3;
            label7.Parent = pictureBox4;
            label8.Parent = pictureBox5;
            label9.Parent = pictureBox6;

            pictureBox1.Parent = pictureBox7;
            pictureBox2.Parent = pictureBox7;
            pictureBox3.Parent = pictureBox7;
            pictureBox4.Parent = pictureBox7;
            pictureBox5.Parent = pictureBox7;
            pictureBox6.Parent = pictureBox7;

            label1.Location = new Point(0, 0);
            pictureBox7.Location = new Point(0, 0);
            label2.Location = new Point(5, label1.Location.Y + label1.ClientSize.Height / 2 - label2.ClientSize.Height / 2);
            label3.Location = new Point(label2.Location.X + label2.ClientSize.Width + 5, label1.Location.Y + label1.ClientSize.Height / 2 - label3.ClientSize.Height / 2);
            label10.Location = new Point(label3.Location.X + label3.ClientSize.Width + 5, label1.Location.Y + label1.ClientSize.Height / 2 - label10.ClientSize.Height / 2);

            pictureBox1.Location = new Point(0, label1.ClientSize.Height);
            pictureBox2.Location = new Point(pictureBox1.ClientSize.Width, label1.ClientSize.Height);
            pictureBox3.Location = new Point(2 * pictureBox1.ClientSize.Width, label1.ClientSize.Height);
            pictureBox4.Location = new Point(0, pictureBox1.ClientSize.Height + label1.ClientSize.Height);
            pictureBox5.Location = new Point(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height + label1.ClientSize.Height);
            pictureBox6.Location = new Point(2 * pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height + label1.ClientSize.Height);

            label4.Location = new Point(pictureBox1.ClientSize.Width / 2 - label4.ClientSize.Width / 2,
                pictureBox1.ClientSize.Height - 2 * label4.ClientSize.Height);
            label5.Location = new Point(pictureBox2.ClientSize.Width / 2 - label5.ClientSize.Width / 2,
                    pictureBox2.ClientSize.Height - 2 * label5.ClientSize.Height);
            label6.Location = new Point(pictureBox3.ClientSize.Width / 2 - label6.ClientSize.Width / 2,
                pictureBox3.ClientSize.Height - 2 * label6.ClientSize.Height);

            label7.Location = new Point(pictureBox4.ClientSize.Width / 2 - label7.ClientSize.Width / 2,
                pictureBox4.ClientSize.Height - 2 * label7.ClientSize.Height);
            label8.Location = new Point(pictureBox5.ClientSize.Width / 2 - label8.ClientSize.Width / 2,
                pictureBox5.ClientSize.Height - 2 * label8.ClientSize.Height);
            label9.Location = new Point(pictureBox6.ClientSize.Width / 2 - label9.ClientSize.Width / 2,
                pictureBox6.ClientSize.Height - 2 * label9.ClientSize.Height);
        }

        private void Picturebox_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                switch (Flaminguage.Properties.Settings.Default.level)
                {
                    case 1:

                        if (((PictureBox)sender).Name == "pictureBox1")
                        {
                            ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", ((PictureBox)sender).Name));
                        }

                        break;

                    case 2:

                        if (((PictureBox)sender).Name == "pictureBox2")
                        {
                            ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", ((PictureBox)sender).Name));
                        }
                        break;

                    case 3:
                        if (((PictureBox)sender).Name == "pictureBox3")
                        {
                            ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", ((PictureBox)sender).Name));
                        }

                        break;

                    case 4:

                        if (((PictureBox)sender).Name == "pictureBox4")
                        {
                            ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", ((PictureBox)sender).Name));
                        }
                        break;

                    case 5:

                        if (((PictureBox)sender).Name == "pictureBox5")
                        {
                            ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", ((PictureBox)sender).Name));
                        }
                        break;

                    case 6:

                        if (((PictureBox)sender).Name == "pictureBox6")
                        {
                            ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}.png", ((PictureBox)sender).Name));
                        }
                        break;
                }
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void Picturebox_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                switch (Flaminguage.Properties.Settings.Default.level)
                {
                    case 1:

                        if (((PictureBox)sender).Name == "pictureBox1")
                        {
                            ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}d.png", ((PictureBox)sender).Name));
                        }

                        break;

                    case 2:

                        if (((PictureBox)sender).Name == "pictureBox2")
                        {
                            ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}d.png", ((PictureBox)sender).Name));
                        }
                        break;

                    case 3:
                        if (((PictureBox)sender).Name == "pictureBox3")
                        {
                            ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}d.png", ((PictureBox)sender).Name));
                        }

                        break;

                    case 4:

                        if (((PictureBox)sender).Name == "pictureBox4")
                        {
                            ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}d.png", ((PictureBox)sender).Name));
                        }
                        break;

                    case 5:

                        if (((PictureBox)sender).Name == "pictureBox5")
                        {
                            ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}d.png", ((PictureBox)sender).Name));
                        }
                        break;

                    case 6:

                        if (((PictureBox)sender).Name == "pictureBox6")
                        {
                            ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Levels\\{0}d.png", ((PictureBox)sender).Name));
                        }
                        break;
                }
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(guidecattext, guidecattitle);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            formdisposing();
            this.Close();
        }

        private void Picturebox_Click(object sender, EventArgs e)
        {
            learning L = new learning();
            L.Show();
            formdisposing();
            this.Close();
        }

        private void Label_Click(object sender, EventArgs e)
        {
            learning L = new learning();
            L.Show();
            formdisposing();
            this.Close();
        }

        private void formdisposing()
        {
            label2.Font.Dispose();

            //       pictureBox1.Image.Dispose();
            //       pictureBox2.Image.Dispose();
            //       pictureBox3.Image.Dispose();
            //       pictureBox4.Image.Dispose();
            //       pictureBox5.Image.Dispose();
            //       pictureBox6.Image.Dispose();
            //       pictureBox7.Image.Dispose();
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