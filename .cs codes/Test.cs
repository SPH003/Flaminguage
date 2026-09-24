using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Flaminguage
{
    public partial class Test : Form
    {
        public string guidecattext, guidecattitle;

        public Test()
        {
            InitializeComponent();

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            this.CenterToScreen();
            this.Icon = Flaminguage.Properties.Resources.appicon;
        }

        private void Test_Load(object sender, EventArgs e)
        {
            pictures();
            texts();
            sizing();
            locations();
            colors();
            Cursor.Position = new Point(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
        }

        private void pictures()
        {
            try
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

                pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Test\\{0}.png", "type"));
                pictureBox2.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Test\\{0}.png", "vocabtest"));
                pictureBox3.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Test\\{0}.png", "backgr"));
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }
        }

        private void colors()
        {
            this.BackColor = Color.FromArgb(69, 9, 32);

            label1.BackColor = Color.FromArgb(255, 205, 178);

            label2.BackColor = Color.FromArgb(255, 205, 178);
            label5.BackColor = Color.FromArgb(255, 205, 178);

            label2.ForeColor = Color.FromArgb(69, 9, 32);
            label5.ForeColor = Color.FromArgb(69, 9, 32);

            pictureBox1.BackColor = Color.FromArgb(69, 9, 32);
            pictureBox2.BackColor = Color.FromArgb(69, 9, 32);

            label4.BackColor = Color.FromArgb(255, 205, 178);
            label3.BackColor = Color.FromArgb(255, 205, 178);

            label3.ForeColor = Color.FromArgb(69, 9, 32);
            label4.ForeColor = Color.FromArgb(69, 9, 32);

            label6.BackColor = Color.FromArgb(255, 205, 178);
            label7.BackColor = Color.FromArgb(255, 205, 178);

            label6.ForeColor = Color.FromArgb(69, 9, 32);
            label7.ForeColor = Color.FromArgb(69, 9, 32);
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

                switch (Flaminguage.Properties.Settings.Default.Languageapp)
                {
                    case "eng":

                        label1.Text = "";
                        label2.Text = "Flaminguage";
                        label3.Text = "Type Test";
                        label4.Text = "Vocab Test";
                        label5.Text = "Home Menu";
                        label6.Text = "Type Test \n In this section, you can evaluate your \n typing speed and accuracy. \n Prepare yourself for the challenge";
                        label7.Text = "Vocab Test \n This section allows you to assess your knowledge through \n a series of exercises and quizzes. \n Good luck.";
                        guidecattitle = "How to use";
                        guidecattext = "In this section, you can assess your typing speed and evaluate your vocabulary knowledge.";

                        break;

                    case "fr":

                        label1.Text = "";
                        label2.Text = "Flaminguage";
                        label3.Text = "Essai de type";
                        label4.Text = "Test de vocabulaire";
                        label5.Text = "Menu d'accueil";
                        label6.Text = "Essai de type \n Vous pouvez tester votre vitesse \n de frappe dans cette section. \n Préparez-vous";
                        label7.Text = "Test de vocabulaire \n Vous pouvez tester vos connaissances \n en participant à cette section. \n Bonne chance";
                        guidecattitle = "  Comment utiliser";
                        guidecattext = "Dans cette section, vous pouvez tester votre vitesse de frappe ou votre vocabulaire.";

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

            pictureBox1.Width = 1 * this.ClientSize.Width / 4;
            pictureBox1.Height = 8 * (this.ClientSize.Height - label1.ClientSize.Height) / 10;

            pictureBox2.Width = pictureBox1.Width;
            pictureBox2.Height = pictureBox1.Height;

            label6.Width = pictureBox1.ClientSize.Width;
            label6.Height = pictureBox1.ClientSize.Height;

            label7.Width = label6.ClientSize.Width;
            label7.Height = label6.ClientSize.Height;

            label3.Width = pictureBox1.ClientSize.Width;
            label3.Height = label2.ClientSize.Height + 10;

            label4.Width = pictureBox2.ClientSize.Width;
            label4.Height = label2.ClientSize.Height + 10;

            pictureBox3.Width = this.ClientSize.Width;
            pictureBox3.Height = this.ClientSize.Height;
        }

        private void locations()
        {
            //label6.Parent = pictureBox1;
            // label7.Parent = pictureBox2;

            label1.Location = new Point(0, 0);
            pictureBox3.Location = new Point(0, 0);
            label2.Location = new Point(5, label1.Location.Y + label1.ClientSize.Height / 2 - label2.ClientSize.Height / 2);
            label5.Location = new Point(label2.Location.X + label2.ClientSize.Width + 5, label1.Location.Y + label1.ClientSize.Height / 2 - label5.ClientSize.Height / 2);

            pictureBox1.Location = new Point((this.ClientSize.Width - pictureBox1.ClientSize.Width * 2) / 3,
                (this.ClientSize.Height) / 2 - pictureBox1.ClientSize.Height / 2);

            pictureBox2.Location = new Point(pictureBox1.Location.X + pictureBox1.ClientSize.Width + (this.ClientSize.Width - pictureBox1.ClientSize.Width * 2) / 3,
                pictureBox1.Location.Y);

            label6.Location = new Point(pictureBox1.Location.X,
                 pictureBox1.Location.Y);

            label7.Location = new Point(pictureBox2.Location.X,
                 pictureBox2.Location.Y);

            label3.Location = new Point(pictureBox1.Location.X + pictureBox1.ClientSize.Width / 2 - label3.ClientSize.Width / 2,
                pictureBox1.Location.Y + pictureBox1.ClientSize.Height);

            label4.Location = new Point(pictureBox2.Location.X + pictureBox2.ClientSize.Width / 2 - label4.ClientSize.Width / 2,
                pictureBox2.Location.Y + pictureBox2.ClientSize.Height);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TypeSpeed tp = new TypeSpeed();
            tp.Show();
            formdisposing();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            TypeSpeed tp = new TypeSpeed();
            tp.Show();
            formdisposing();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            VocabTest vt = new VocabTest();
            vt.Show();
            formdisposing();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            VocabTest vt = new VocabTest();
            vt.Show();
            formdisposing();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            formdisposing();
            this.Close();
        }

        private void formdisposing()
        {
            label2.Font.Dispose();

            //       pictureBox1.Image.Dispose();
            //       pictureBox2.Image.Dispose();
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

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            label6.BringToFront();
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.SendToBack();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            label7.BringToFront();
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.SendToBack();
        }
    }
}