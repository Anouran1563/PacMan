using System.Windows.Forms;
using System;

namespace Test1
{
    public partial class Form1 : Form
    {
        bool up;
        bool down;
        bool left;
        bool right;

        int speed = 8;
        int ghost1 = 8;
        int ghost2 = 8;
        int ghost3x = 8;
        int ghost3y = 8;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
            lblOver.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void KeyisDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                left = true;
                pbPlayer.Image = Properties.Resources.left;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                right = true;
                pbPlayer.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                up = true;
                pbPlayer.Image = Properties.Resources.Up;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                down = true;
                pbPlayer.Image = Properties.Resources.down;
            }
        }

        private void KeyisUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
            {
                up = false;
            }
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
            {
                down = false;
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = "Score: " + score;
            if (left)
            {
                pbPlayer.Left -= speed;
            }
            if (right)
            {
                pbPlayer.Left += speed;
            }
            if (up)
            {
                pbPlayer.Top -= speed;
            }
            if (down)
            {
                pbPlayer.Top += speed;
            }
            pbRed.Left += ghost1;
            pbYellow.Left += ghost2;
            if (pbRed.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                ghost1 = -ghost1;
            }
            else if (pbRed.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                ghost1 = -ghost1;
            }
            if (pbYellow.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                ghost2 = -ghost2;
            }
            else if (pbYellow.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                ghost2 = -ghost2;
            }
            foreach (Control x in pbPlayer.Controls)
            {
                if (x is PictureBox && x.Tag == "wall" || x.Tag == "ghost")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pbPlayer.Bounds) || score == 30)
                    {
                        pbPlayer.Left = 0;
                        pbPlayer.Top = 25;
                        lblOver.Text = "Game Over";
                        lblOver.Visible = true;
                        GameTimer.Stop();
                    }
                }
                if (x is PictureBox && x.Tag == "coin")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(pbPlayer.Bounds))
                    {
                        this.Controls.Remove(x);
                        score++;
                    }
                }
            }
            pbPink.Left += ghost3x;
            pbPink.Top += ghost3y;
            if (pbPink.Left < 1 ||
                pbPink.Left + pbPink.Width > ClientSize.Width - 2 ||
                (pbPink.Bounds.IntersectsWith(pictureBox4.Bounds)) ||
                (pbPink.Bounds.IntersectsWith(pictureBox3.Bounds)) ||
                (pbPink.Bounds.IntersectsWith(pictureBox1.Bounds)) ||
                (pbPink.Bounds.IntersectsWith(pictureBox2.Bounds)))
            {
                ghost3x = -ghost3x;
            }
            if (pbPink.Top < 1 || pbPink.Top + pbPink.Height > ClientSize.Height - 2)
            {
                ghost3y = -ghost3y;
            }
        }
    }
}