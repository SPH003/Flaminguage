using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Flaminguage
{
    public partial class Home : Form
    {
        private Naudiohandler x = new Naudiohandler();

        public string TextForExit, resetquestion, resettitle,
            themechangetitle, themechangetext, purposestext, purposestitle,
            dictionarytext, testtext, flmtext;

        public int songstate = 1;
        public int learningpathstate = 0;
        public int Xo, Yo, buttonclick, user_index;
        public Random rnd = new Random();

        public Home()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.CenterToScreen();
            this.Icon = Flaminguage.Properties.Resources.appicon;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (Flaminguage.Properties.Settings.Default.FirstRun == true)
            {
                Flaminguage.Properties.Settings.Default.FirstRun = false;
                Flaminguage.Properties.Settings.Default.Save();
            }

            label12.Text = DateTime.Now.ToShortTimeString();
            pictures();
            texts();
            sizing();
            locations();
            colors();
            MakeVisibleMenu();

            switch (int.Parse(DateTime.Now.Second.ToString()) % 2)
            {
                case 0:
                    user_index = rnd.Next(12);
                    break;

                default:
                    user_index = rnd.Next(3);
                    break;
            }
            PlayMusicAndMessage();
        }

        private void MakeUnVisibleMenu()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label12.Visible = false;
            pictureBox1.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;

            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            pictureBox1.Enabled = false;
            pictureBox6.Enabled = false;
            pictureBox7.Enabled = false;
        }

        private void MakeVisibleMenu()
        {
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label12.Visible = true;
            pictureBox1.Visible = true;
            pictureBox6.Visible = true;
            pictureBox7.Visible = true;

            label1.Enabled = true;
            label2.Enabled = true;
            label3.Enabled = true;
            pictureBox1.Enabled = true;
            pictureBox6.Enabled = true;
            pictureBox7.Enabled = true;
        }

        private void MakeUnVisibleSongMenu()
        {
            label5.Visible = false;

            pictureBox8.Visible = false;
            pictureBox9.Visible = false;
            pictureBox10.Visible = false;

            pictureBox8.Enabled = false;
            pictureBox9.Enabled = false;
            pictureBox10.Enabled = false;
        }

        private void MakeVisibleSongMenu()
        {
            label5.Visible = true;

            pictureBox8.Visible = true;
            pictureBox9.Visible = true;
            pictureBox10.Visible = true;

            pictureBox8.Enabled = true;
            pictureBox9.Enabled = true;
            pictureBox10.Enabled = true;
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
                pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox13.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox15.SizeMode = PictureBoxSizeMode.StretchImage;

                pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "pictureBox1"));
                pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "pictureBox2"));
                pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "pictureBox3"));
                pictureBox4.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "pictureBox4"));
                pictureBox5.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "pictureBox5"));
                pictureBox6.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "pictureBox6"));
                pictureBox7.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "pictureBox7"));
                pictureBox8.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "pictureBox8"));
                pictureBox9.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "pictureBox9"));
                pictureBox10.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "pictureBox10"));

                pictureBox11.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "1"));

                pictureBox14.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "comicbook-learningpath"));

                pictureBox15.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "aboutus"));
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
            button4.FlatStyle = FlatStyle.Flat;
            button5.FlatStyle = FlatStyle.Flat;
            button6.FlatStyle = FlatStyle.Flat;
            button7.FlatStyle = FlatStyle.Flat;
            button8.FlatStyle = FlatStyle.Flat;

            button1.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);
            button2.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);
            button3.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);
            button4.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);
            button5.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);
            button6.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);
            button7.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);
            button8.FlatAppearance.BorderColor = Color.FromArgb(249, 219, 189);

            this.BackColor = Color.FromArgb(69, 9, 32);

            label1.BackColor = Color.FromArgb(255, 205, 178);
            label2.BackColor = Color.FromArgb(255, 205, 178);
            label3.BackColor = Color.FromArgb(255, 205, 178);
            label12.BackColor = Color.FromArgb(255, 205, 178);
            pictureBox1.BackColor = Color.FromArgb(255, 205, 178);
            pictureBox6.BackColor = Color.FromArgb(255, 205, 178);
            pictureBox7.BackColor = Color.FromArgb(255, 205, 178);

            pictureBox8.BackColor = Color.Transparent;
            pictureBox9.BackColor = Color.Transparent;
            pictureBox10.BackColor = Color.Transparent;

            label2.ForeColor = Color.FromArgb(69, 9, 32);
            label3.ForeColor = Color.FromArgb(69, 9, 32);
            label12.ForeColor = Color.FromArgb(69, 9, 32);

            label13.BackColor = Color.Transparent;
            label14.BackColor = Color.Transparent;
            label15.BackColor = Color.Transparent;
            label16.BackColor = Color.Transparent;
            label13.ForeColor = Color.Black;
            label14.ForeColor = Color.Black;
            label15.ForeColor = Color.Black;
            label16.ForeColor = Color.Black;

            label5.BackColor = Color.FromArgb(118, 116, 183);
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            pictureBox4.BackColor = Color.Transparent;
            pictureBox5.BackColor = Color.Transparent;
            label4.ForeColor = Color.FromArgb(69, 9, 32);
            label6.ForeColor = Color.FromArgb(69, 9, 32);

            label6.BackColor = Color.FromArgb(181, 131, 141);
            pictureBox12.BackColor = Color.FromArgb(109, 104, 117);
            pictureBox13.BackColor = Color.FromArgb(255, 200, 221);
            label4.BackColor = Color.FromArgb(255, 205, 178);
            button1.BackColor = Color.FromArgb(109, 104, 117);

            button1.ForeColor = Color.FromArgb(249, 219, 189);

            //settings color
            label7.BackColor = Color.FromArgb(255, 205, 178);
            label8.BackColor = Color.FromArgb(255, 205, 178);
            label9.BackColor = Color.FromArgb(255, 205, 178);
            label10.BackColor = Color.FromArgb(255, 205, 178);
            label11.BackColor = Color.FromArgb(255, 205, 178);

            label8.ForeColor = Color.FromArgb(69, 9, 32);
            label9.ForeColor = Color.FromArgb(69, 9, 32);
            label10.ForeColor = Color.FromArgb(69, 9, 32);
            label11.ForeColor = Color.FromArgb(69, 9, 32);
            button2.ForeColor = Color.FromArgb(249, 219, 189);
            button3.ForeColor = Color.FromArgb(249, 219, 189);
            button4.ForeColor = Color.FromArgb(249, 219, 189);
            button5.ForeColor = Color.FromArgb(249, 219, 189);
            button6.ForeColor = Color.FromArgb(249, 219, 189);
            button7.ForeColor = Color.FromArgb(249, 219, 189);
            button8.ForeColor = Color.FromArgb(249, 219, 189);

            button2.BackColor = Color.FromArgb(69, 9, 32);
            button3.BackColor = Color.FromArgb(69, 9, 32);
            button4.BackColor = Color.FromArgb(69, 9, 32);
            button5.BackColor = Color.FromArgb(69, 9, 32);
            button6.BackColor = Color.FromArgb(69, 9, 32);
            button7.BackColor = Color.FromArgb(69, 9, 32);
            button8.BackColor = Color.FromArgb(69, 9, 32);
        }

        private void texts()
        {
            try
            {
                button1.AutoSize = false;
                button2.AutoSize = false;
                button3.AutoSize = false;
                button4.AutoSize = false;
                button5.AutoSize = false;
                button6.AutoSize = false;
                button7.AutoSize = false;
                button8.AutoSize = false;

                button1.Width = 1;
                button1.Height = 1;
                button2.Width = 1;
                button2.Height = 1;
                button3.Width = 1;
                button3.Height = 1;
                button4.Width = 1;
                button4.Height = 1;
                button5.Width = 1;
                button5.Height = 1;
                button6.Width = 1;
                button6.Height = 1;
                button7.Width = 1;
                button7.Height = 1;
                button8.Width = 1;
                button8.Height = 1;

                button4.Text = "Réinitialiser l'application";

                label2.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label3.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label12.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label4.Font = new Font("NunitoExtraLight", 15, FontStyle.Regular);
                label6.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label8.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label9.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label10.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label11.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label13.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label14.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label15.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                label16.Font = new Font("FredokaLight", 15, FontStyle.Regular);

                button1.Font = new Font("FredokaLight", 15, FontStyle.Regular);
                button2.Font = new Font("FredokaLight", 13, FontStyle.Regular);
                button3.Font = new Font("FredokaLight", 13, FontStyle.Regular);
                button4.Font = new Font("FredokaLight", 13, FontStyle.Regular);
                button5.Font = new Font("FredokaLight", 13, FontStyle.Regular);
                button6.Font = new Font("FredokaLight", 13, FontStyle.Regular);
                button7.Font = new Font("FredokaLight", 13, FontStyle.Regular);
                button8.Font = new Font("FredokaLight", 13, FontStyle.Regular);

                switch (Flaminguage.Properties.Settings.Default.Languageapp)
                {
                    case "eng":

                        label1.Text = "";
                        label5.Text = "";
                        label6.Text = "Menu";

                        label2.Text = "Flaminguage";
                        label3.Text = "LearningPath";
                        button1.Text = "Start";

                        label7.Text = "";
                        label8.Text = "Language";
                        label9.Text = "Reset";
                        label10.Text = "Theme";
                        label11.Text = "Shutdown";
                        button2.Text = "Eng";
                        button3.Text = "Fre";
                        button4.Text = "Reset App";
                        button5.Text = "Pink";
                        button6.Text = "Yellow";
                        button7.Text = "Back";
                        button8.Text = "Turn off";

                        TextForExit = "Do you want to exit the program?";
                        resetquestion = "Do you want to reset your progress?";
                        resettitle = "Reset Data";
                        themechangetext = "The Bee theme will be added in a future update.";
                        themechangetitle = "In Progress";
                        purposestext = "Developed an educational application designed to demonstrate to students that app and game development is an achievable skill through consistent learning and practice. The project aims to encourage beginners to start building and continuously improve their abilities. Acknowledged contributions from junior students A. Saleh Jalali and M. Nayer Abadi, along with all students who remained persistent and committed throughout the learning process.";
                        purposestitle = "Flaminguage Purposes";
                        dictionarytext = "Dictionary Section\nThe place for all vocabs. You can look for your word here.\nTake your time.";
                        testtext = "Test Section\nTest your knowledge with our typing speed test or quiz game.\nHave fun.";
                        flmtext = "Flaminguage\nStart your journey in the learning world of words.\nStart your journey into the world of learning words. Learn with our method, where vocabulary is organized by usage. You won’t get confused here.\nbe confident.";

                        break;

                    case "fr":

                        label1.Text = "";
                        label5.Text = "";
                        label6.Text = "Menu";
                        label2.Text = "Flaminguage";
                        label3.Text = "Parcours d'apprentissage";
                        button1.Text = "Commencer";

                        label7.Text = "";
                        label8.Text = "Langue";
                        label9.Text = "Réinitialiser";
                        label10.Text = "Thème";
                        label11.Text = "Fermer";
                        button2.Text = "Eng";
                        button3.Text = "Fre";
                        button4.Text = "Réinitialiser l'application";
                        button5.Text = "Rose";
                        button6.Text = "Jaune";
                        button7.Text = "dos";
                        button8.Text = "Éteindre";

                        resetquestion = "Voulez-vous réinitialiser votre progression ?";
                        resettitle = "Réinitialiser les données";
                        TextForExit = "Voulez-vous quitter le programme ?";
                        themechangetext = "Le thème des abeilles sera disponible prochainement.";
                        themechangetitle = "En cours";
                        purposestext = "Développement d’une application éducative visant à montrer aux étudiants que la création d’applications et de jeux est une compétence accessible grâce à un apprentissage régulier et à la pratique. Ce projet a pour objectif d’encourager les débutants à commencer à créer et à améliorer continuellement leurs compétences. Remerciements aux étudiants juniors A. Saleh Jalali et M. Nayer Abadi, ainsi qu’à tous les étudiants qui sont restés persévérants et engagés tout au long du processus d’apprentissage.";
                        purposestitle = "Objectifs de Flaminguage";
                        dictionarytext = "Section Dictionnaire\nL'endroit idéal pour trouver du vocabulaire. Vous pouvez chercher votre mot ici.\nPrenez votre temps.";
                        flmtext = "Flaminguage\nCommencez votre voyage dans le monde de l'apprentissage des mots.\nApprenez avec notre méthode : le vocabulaire est classé ici selon son usage.\nVous ne serez pas confus ici, soyez-en sûr.";
                        testtext = "Section d'essais\nTestez vos connaissances en participant à notre jeu de rapidité ou à notre quiz.\nAmusez-vous.";

                        break;
                }

                button1.AutoSize = true;
                button2.AutoSize = true;
                button3.AutoSize = true;
                button4.AutoSize = true;
                button5.AutoSize = true;
                button6.AutoSize = true;
                button7.AutoSize = true;
                button8.AutoSize = true;
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void sizing()
        {
            pictureBox1.Height = 2 * label2.ClientSize.Height;
            pictureBox1.Width = pictureBox1.ClientSize.Height;

            pictureBox6.Height = pictureBox1.ClientSize.Height;
            pictureBox6.Width = pictureBox1.ClientSize.Width;

            pictureBox7.Height = pictureBox1.ClientSize.Height;
            pictureBox7.Width = pictureBox1.ClientSize.Width;

            label1.Width = this.ClientSize.Width;
            label1.Height = 2 * label2.ClientSize.Height;

            pictureBox2.Width = this.ClientSize.Width / 15;
            pictureBox2.Height = this.ClientSize.Width / 15;

            pictureBox3.Width = pictureBox2.Width;
            pictureBox3.Height = pictureBox2.Height;

            pictureBox4.Width = pictureBox2.Width;
            pictureBox4.Height = pictureBox2.Height;

            pictureBox5.Width = pictureBox2.Width;
            pictureBox5.Height = pictureBox2.Height;

            pictureBox8.Height = 4 * label2.ClientSize.Height / 2;
            pictureBox8.Width = 4 * label2.ClientSize.Height / 2;

            pictureBox9.Height = pictureBox8.ClientSize.Height;
            pictureBox9.Width = pictureBox8.ClientSize.Width;

            pictureBox10.Height = pictureBox8.ClientSize.Height;
            pictureBox10.Width = pictureBox8.ClientSize.Width;

            label5.Width = 3 * pictureBox10.ClientSize.Width;
            label5.Height = pictureBox10.ClientSize.Height + 5;

            label4.Width = this.ClientSize.Width / 2;
            label4.Height = this.ClientSize.Height / 3;

            label6.Width = label4.ClientSize.Width;
            label6.Height = label4.ClientSize.Height / 10;

            pictureBox12.Width = pictureBox1.ClientSize.Height / 2 - 5;
            pictureBox12.Height = pictureBox1.ClientSize.Height / 2 - 5;

            pictureBox13.Width = pictureBox12.ClientSize.Width;
            pictureBox13.Height = pictureBox12.ClientSize.Height;

            pictureBox11.Height = this.ClientSize.Height;
            pictureBox11.Width = this.ClientSize.Width;

            pictureBox14.Width = 4 * this.ClientSize.Width / 10;
            pictureBox14.Height = this.ClientSize.Height - label1.ClientSize.Height - 10;

            pictureBox15.Width = 32 * this.ClientSize.Width / 100;
            pictureBox15.Height = 8 * (this.ClientSize.Height - label1.ClientSize.Height) / 10 - 10;
        }

        private void locations()
        {
            label13.Parent = pictureBox11;
            label14.Parent = pictureBox11;
            label15.Parent = pictureBox11;
            label16.Parent = pictureBox11;
            pictureBox2.Parent = pictureBox11;
            pictureBox3.Parent = pictureBox11;
            pictureBox4.Parent = pictureBox11;
            pictureBox5.Parent = pictureBox11;
            pictureBox8.Parent = label5;
            pictureBox9.Parent = label5;
            pictureBox10.Parent = label5;

            pictureBox11.Location = new Point(0, 0);

            label1.Location = new Point(0, this.ClientSize.Height - label1.ClientSize.Height);

            pictureBox6.Location = new Point(1,
                label1.Location.Y + label1.ClientSize.Height / 2 - pictureBox6.ClientSize.Height / 2);

            label2.Location = new Point(5 + pictureBox6.Location.X + pictureBox6.ClientSize.Width,
                label1.Location.Y + label1.ClientSize.Height / 2 - label2.ClientSize.Height / 2);

            pictureBox7.Location = new Point(5 + label2.Location.X + label2.ClientSize.Width
                , label1.Location.Y + label1.ClientSize.Height / 2 - pictureBox7.ClientSize.Height / 2);

            label3.Location = new Point(pictureBox7.Location.X + pictureBox7.ClientSize.Width + 5,
                label1.Location.Y + label1.ClientSize.Height / 2 - label3.ClientSize.Height / 2);

            pictureBox1.Location = new Point(label1.ClientSize.Width - pictureBox1.ClientSize.Width - 5,
                label1.Location.Y + label1.ClientSize.Height / 2 - pictureBox1.ClientSize.Height / 2);

            label12.Location = new Point(pictureBox1.Location.X - label12.ClientSize.Width,
               label1.Location.Y + label1.ClientSize.Height / 2 - label12.ClientSize.Height / 2);

            label5.Location = new Point(this.ClientSize.Width / 2 - label5.ClientSize.Width / 2,
                0);

            pictureBox8.Location = new Point(label5.ClientSize.Width / 2 - pictureBox8.ClientSize.Width / 2,
               label5.ClientSize.Height / 2 - pictureBox8.ClientSize.Height / 2);

            pictureBox10.Location = new Point(label5.ClientSize.Width / 2 - pictureBox8.ClientSize.Width / 2 - pictureBox10.ClientSize.Width - (label5.ClientSize.Width - 3 * pictureBox8.ClientSize.Width) / 4,
            label5.ClientSize.Height / 2 - pictureBox10.ClientSize.Height / 2);

            pictureBox9.Location = new Point(label5.ClientSize.Width / 2 + pictureBox9.ClientSize.Width / 2 + (label5.ClientSize.Width - 3 * pictureBox8.ClientSize.Width) / 4,
            label5.ClientSize.Height / 2 - pictureBox9.ClientSize.Height / 2);

            pictureBox2.Location = new Point(10,
                pictureBox2.ClientSize.Height / 2);

            label13.Location = new Point(pictureBox2.Location.X + pictureBox2.ClientSize.Width / 2 - label13.ClientSize.Width / 2,
                pictureBox2.Location.Y + pictureBox2.ClientSize.Height);

            pictureBox3.Location = new Point(pictureBox2.Location.X,
                pictureBox2.Location.Y + 2 + pictureBox2.ClientSize.Height + label13.ClientSize.Height);

            label14.Location = new Point(pictureBox3.Location.X + pictureBox3.ClientSize.Width / 2 - label14.ClientSize.Width / 2,
                pictureBox3.Location.Y + pictureBox3.ClientSize.Height);

            pictureBox4.Location = new Point(pictureBox2.Location.X,
                pictureBox3.Location.Y + 2 + pictureBox3.ClientSize.Height + label14.ClientSize.Height);

            label15.Location = new Point(pictureBox4.Location.X + pictureBox4.ClientSize.Width / 2 - label15.ClientSize.Width / 2,
                pictureBox4.Location.Y + pictureBox4.ClientSize.Height);

            pictureBox5.Location = new Point(pictureBox2.Location.X,
                pictureBox4.Location.Y + 2 + pictureBox4.ClientSize.Height + label15.ClientSize.Height);

            label16.Location = new Point(pictureBox5.Location.X + pictureBox5.ClientSize.Width / 2 - label16.ClientSize.Width / 2,
                pictureBox5.Location.Y + pictureBox5.ClientSize.Height);

            label4.Location = new Point(this.ClientSize.Width / 2 - label4.ClientSize.Width / 2,
                this.ClientSize.Height / 2 - label4.ClientSize.Height / 2);

            button1.Location = new Point(label4.Location.X + label4.ClientSize.Width - button1.ClientSize.Width - 10,
                label4.Location.Y + label4.ClientSize.Height - button1.ClientSize.Height - 10);

            pictureBox12.Location = new Point(label4.Location.X + label4.ClientSize.Width - pictureBox12.ClientSize.Width - 5,
              label4.Location.Y + label4.ClientSize.Height / 20 - pictureBox12.ClientSize.Height / 2);

            pictureBox13.Location = new Point(pictureBox12.Location.X - pictureBox13.ClientSize.Width - 5,
              label4.Location.Y + label4.ClientSize.Height / 20 - pictureBox13.ClientSize.Height / 2);

            label6.Location = new Point(label4.Location.X,
                label4.Location.Y);

            //settingsBox location

            label7.Width = this.ClientSize.Width / 3;
            label7.Height = this.ClientSize.Height / 3;
            label7.Location = new Point(this.ClientSize.Width / 2 - label7.ClientSize.Width / 2, this.ClientSize.Height / 2 - label7.ClientSize.Height / 2);

            label8.Location = new Point(label7.Location.X + button8.ClientSize.Width / 2,
                label7.Location.Y + label7.ClientSize.Height / 8 - label8.ClientSize.Height / 2);

            label9.Location = new Point(label8.Location.X,
                label7.Location.Y + 3 * label7.ClientSize.Height / 8 - label9.ClientSize.Height / 2);

            label10.Location = new Point(label8.Location.X,
                label7.Location.Y + 5 * label7.ClientSize.Height / 8 - label10.ClientSize.Height / 2);

            label11.Location = new Point(label8.Location.X,
                label7.Location.Y + 7 * label7.ClientSize.Height / 8 - label11.ClientSize.Height / 2);

            button2.Location = new Point(label7.Location.X + label7.ClientSize.Width - button2.ClientSize.Width - button8.ClientSize.Width / 2,
                label8.Location.Y + label8.ClientSize.Height / 2 - button2.ClientSize.Height / 2);

            button3.Location = new Point(button2.Location.X - button3.ClientSize.Width - button8.ClientSize.Width / 3, button2.Location.Y);

            button4.Location = new Point(label7.Location.X + label7.ClientSize.Width - button4.ClientSize.Width - button8.ClientSize.Width / 2,
                label9.Location.Y + label9.ClientSize.Height / 2 - button4.ClientSize.Height / 2);

            button5.Location = new Point(label7.Location.X + label7.ClientSize.Width - button5.ClientSize.Width - button8.ClientSize.Width / 2,
                label10.Location.Y + label10.ClientSize.Height / 2 - button5.ClientSize.Height / 2);

            button6.Location = new Point(button5.Location.X - button6.ClientSize.Width - button8.ClientSize.Width / 3, button5.Location.Y);

            button8.Location = new Point(label7.Location.X + label7.ClientSize.Width - button8.ClientSize.Width - button8.ClientSize.Width / 2,
                label11.Location.Y + label11.ClientSize.Height / 2 - button8.ClientSize.Height / 2);

            button7.Location = new Point(button8.Location.X - button7.ClientSize.Width - button8.ClientSize.Width / 3, button8.Location.Y);

            pictureBox14.Location = new Point(this.ClientSize.Width / 2 - pictureBox14.ClientSize.Width / 2,
          (this.ClientSize.Height - label1.ClientSize.Height) / 2 - pictureBox14.ClientSize.Height / 2);

            pictureBox15.Location = new Point(0,
                this.ClientSize.Height - label1.ClientSize.Height - pictureBox15.ClientSize.Height);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label4.Visible = false;

            label6.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            button1.Visible = false;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;

            label7.Enabled = true;
            label8.Enabled = true;
            label9.Enabled = true;
            label10.Enabled = true;
            label11.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;

            label2.Enabled = false;
            label3.Enabled = false;
            label6.Enabled = false;

            label6.Enabled = false;
            pictureBox8.Enabled = false;
            pictureBox12.Enabled = false;
            pictureBox13.Enabled = false;

            button1.Enabled = false;
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            pictureBox5.Enabled = false;

            texts();

            locations();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Flaminguage.Properties.Settings.Default.Languageapp = "eng";
            Flaminguage.Properties.Settings.Default.Save();
            texts();

            locations();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Flaminguage.Properties.Settings.Default.Languageapp = "fr";
            Flaminguage.Properties.Settings.Default.Save();
            texts();
            sizing();
            locations();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult userchoose = MessageBox.Show(resetquestion, resettitle, MessageBoxButtons.YesNo);
            if (userchoose == DialogResult.Yes)
            {
                Flaminguage.Properties.Settings.Default.Languageapp = "eng";
                Flaminguage.Properties.Settings.Default.Score1 = 0;
                Flaminguage.Properties.Settings.Default.Score2 = 0;
                Flaminguage.Properties.Settings.Default.Score3 = 0;
                Flaminguage.Properties.Settings.Default.Score4 = 0;
                Flaminguage.Properties.Settings.Default.Score5 = 0;
                Flaminguage.Properties.Settings.Default.Score6 = 0;
                Flaminguage.Properties.Settings.Default.level = 1;
                Flaminguage.Properties.Settings.Default.Save();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(themechangetext, themechangetitle);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Flaminguage.Properties.Settings.Default.Theme = "pink";
            Flaminguage.Properties.Settings.Default.Save();
            colors();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show(TextForExit, "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.Yes)
            {
                x.Stop();
                x.Dispose();
                Application.Exit();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;

            label7.Enabled = false;
            label8.Enabled = false;
            label9.Enabled = false;
            label10.Enabled = false;
            label11.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            label2.Enabled = true;
            label3.Enabled = true;
            pictureBox8.Enabled = true;
            pictureBox12.Enabled = true;

            button1.Enabled = false;
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox12.Visible = true;
            pictureBox13.Visible = true;
            label4.Text = flmtext;
            label6.Visible = true;
            label4.Visible = true;

            button1.Visible = true;
            button1.Enabled = true;
            buttonclick = 2;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox12.Visible = true;
            pictureBox13.Visible = true;
            label4.Text = testtext;
            label4.Visible = true;
            label6.Visible = true;

            button1.Visible = true;
            button1.Enabled = true;
            buttonclick = 3;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox12.Visible = true;
            pictureBox13.Visible = true;
            label4.Text = dictionarytext;
            label4.Visible = true;
            label6.Visible = true;

            button1.Visible = true;
            button1.Enabled = true;
            buttonclick = 4;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label6.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            button1.Visible = false;
            button1.Enabled = false;
            MessageBox.Show(purposestext, purposestitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Picturebox_MouseEnter(object sender, EventArgs e)
        {
            //      ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.jpg", ((PictureBox)sender).Name));

            Xo = ((PictureBox)sender).Location.X;
            Yo = ((PictureBox)sender).Location.Y;

            ((PictureBox)sender).Width = 11 * ((PictureBox)sender).Width / 10;
            ((PictureBox)sender).Height = 11 * ((PictureBox)sender).Height / 10;

            ((PictureBox)sender).Location = new Point(Xo - ((PictureBox)sender).Width / 22, Yo);
            ((PictureBox)sender).BringToFront();
        }

        private void Picturebox_MouseLeave(object sender, EventArgs e)
        {
            //     ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\leave-{0}.jpg", ((PictureBox)sender).Name));

            Xo = ((PictureBox)sender).Location.X;
            Yo = ((PictureBox)sender).Location.Y;

            ((PictureBox)sender).Width = this.ClientSize.Width / 15;
            ((PictureBox)sender).Height = this.ClientSize.Width / 15;

            ((PictureBox)sender).Location = new Point(Xo + ((PictureBox)sender).Width / 20, Yo);
        }

        private void formdisposing()
        {
            button1.Font.Dispose();
            button2.Font.Dispose();
            label2.Font.Dispose();

            //       pictureBox1.Image.Dispose();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            if (label6.Visible == true)
            {
                label4.Visible = false;
                label6.Visible = false;
                pictureBox12.Visible = false;
                pictureBox13.Visible = false;
                button1.Visible = false;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x.Stop();
            x.Dispose();

            switch (buttonclick)
            {
                case 2:
                    Category ca = new Category();
                    ca.Show();
                    this.Close();

                    break;

                case 3:
                    Test te = new Test();
                    te.Show();
                    this.Close();
                    break;

                case 4:
                    Dictionary dc = new Dictionary();
                    dc.Show();
                    this.Close();
                    break;
            }
        }

        private void Home_MouseMove(object sender, MouseEventArgs e)
        {
            //   if (e.Y >label1 .Location .Y-20 ){
            //        MakeVisibleMenu();

            //    }
            //     else {
            //         MakeUnVisibleMenu();
            //     }

            if (e.Y < label5.Location.Y + label5.ClientSize.Height + 20)
            {
                MakeVisibleSongMenu();
            }
            else
            {
                MakeUnVisibleSongMenu();
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            label4.Visible = false;
            label6.Visible = false;
            pictureBox12.Visible = false;
            pictureBox13.Visible = false;
            button1.Visible = false;
            button1.Enabled = false;
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

        private void PlayMusicAndMessage()
        {
            try
            {
                x.SetPlaylist(new List<string>
                {
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "0")),
                     Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "1")),
                     Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "2")),
                     Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "3")),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "4")),
                     Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "5")),
                   Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "6")),
                   Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "7")),
                     Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "8")),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "9")),
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "10")),
                     Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Music\\{0}.mp3", "11"))
            }, user_index);

                x.Play();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            switch (songstate)
            {
                case 0:

                    x.Resume();
                    songstate = 1;

                    break;

                case 1:

                    x.Pause();
                    songstate = 0;
                    break;
            }
        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            x.Next();
            songstate = 1;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            x.Previous();
            songstate = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label12.Text = DateTime.Now.ToShortTimeString();

            label12.Location = new Point(pictureBox1.Location.X - label12.ClientSize.Width,
              label1.Location.Y + label1.ClientSize.Height / 2 - label12.ClientSize.Height / 2);
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}d.png", ((PictureBox)sender).Name));
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            ((PictureBox)sender).ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", ((PictureBox)sender).Name));
        }

        private void label3_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox11.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "1b"));

                switch (learningpathstate)
                {
                    case 0:

                        pictureBox14.Visible = true;
                        pictureBox1.Enabled = false;
                        pictureBox2.Enabled = false;
                        pictureBox3.Enabled = false;
                        pictureBox4.Enabled = false;
                        pictureBox5.Enabled = false;

                        learningpathstate = 1;

                        break;

                    case 1:
                        pictureBox14.Visible = false; ;
                        pictureBox1.Enabled = true;
                        pictureBox2.Enabled = true;
                        pictureBox3.Enabled = true;
                        pictureBox4.Enabled = true;
                        pictureBox5.Enabled = true;

                        pictureBox11.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Home\\{0}.png", "1"));

                        learningpathstate = 0;

                        break;
                }
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            switch (learningpathstate)
            {
                case 0:

                    pictureBox15.Visible = true;
                    pictureBox1.Enabled = false;
                    pictureBox2.Enabled = false;
                    pictureBox3.Enabled = false;
                    pictureBox4.Enabled = false;
                    pictureBox5.Enabled = false;
                    pictureBox7.Enabled = false;
                    label3.Enabled = false;

                    learningpathstate = 1;

                    break;

                case 1:
                    pictureBox15.Visible = false; ;
                    pictureBox1.Enabled = true;
                    pictureBox2.Enabled = true;
                    pictureBox3.Enabled = true;
                    pictureBox4.Enabled = true;
                    pictureBox5.Enabled = true;
                    pictureBox7.Enabled = true;
                    label3.Enabled = true;

                    learningpathstate = 0;

                    break;
            }
        }
    }
}