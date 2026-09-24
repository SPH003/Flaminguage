using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Flaminguage
{
    public partial class Logo : Form
    {
        public int i = 0;

        public Logo()
        {
            InitializeComponent();
            this.Icon = Flaminguage.Properties.Resources.appicon;
        }

        private void Logo_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Width = 50 * Screen.PrimaryScreen.Bounds.Width / 100;
            this.Height = 50 * Screen.PrimaryScreen.Bounds.Height / 100;
            this.CenterToScreen();

            label1.Parent = pictureBox1;
            label1.ForeColor = Color.Black;
            label1.BackColor = Color.Transparent;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            try
            {
                pictureBox1.ImageLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("Pictures\\Loading\\{0}.png", "loadingscreen"));
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message);
            }

            pictureBox1.Width = this.ClientSize.Width;
            pictureBox1.Height = this.ClientSize.Height;
            pictureBox1.Location = new Point(this.ClientSize.Width / 2 - pictureBox1.ClientSize.Width / 2
                , this.ClientSize.Height / 2 - pictureBox1.ClientSize.Height / 2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i < 10)
            {
                label1.Text = "Loading assets";
                label1.Location = new Point(pictureBox1.ClientSize.Width - label1.ClientSize.Width - 10, pictureBox1.ClientSize.Height - label1.ClientSize.Height - 10);
                i++;
            }
            else if (i >= 10 & i < 50)
            {
                label1.Text = "Subscribe our page to support us";
                label1.Location = new Point(pictureBox1.ClientSize.Width - label1.ClientSize.Width - 10, pictureBox1.ClientSize.Height - label1.ClientSize.Height - 10);
                i++;
            }
            else if (i >= 50 & i < 100)
            {
                label1.Text = "Just few seconds...";
                label1.Location = new Point(pictureBox1.ClientSize.Width - label1.ClientSize.Width - 10, pictureBox1.ClientSize.Height - label1.ClientSize.Height - 10);
                i++;
            }
            else if (i == 100)
            {
                label1.Text = "Let's go";
                label1.Location = new Point(pictureBox1.ClientSize.Width - label1.ClientSize.Width - 10, pictureBox1.ClientSize.Height - label1.ClientSize.Height - 10);
                Home h = new Home();
                h.Show();

                timer1.Stop(); timer1.Enabled = false; timer1.Dispose();
                this.Close(); this.Dispose();
            }
        }
    }
}