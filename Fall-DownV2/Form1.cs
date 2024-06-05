using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fall_DownV2
{
    public partial class Game : Form
    {
        //declare bools for movement, gravity etc.
        bool left = false, right = false, isFalling = false, isJumping = false, onPlatform = false;
        int force;
        int G = 10;
        const int PLATS_SET = 1;
        int plats;

        public Game()
        {
            InitializeComponent();
            floor.Width = screen.Width;
            floor.Left = 0;
            floor.Top = screen.Height - floor.Height;
            force = G;
        }

        private void Game_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
        }

        private void gravityTimer_Tick(object sender, EventArgs e)
        {
            if (isFalling)
            {
                player.Top += 5;
                player.BringToFront();
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if(e.KeyCode == Keys.Up && onPlatform == true)
            {
                isJumping = true;
                force = G;
            }
        }
        private void gameTick_Tick(object sender, EventArgs e)
        {
            if (left == true)
            {
                player.Left -= 5;
            }
            if (right == true)
            {
                player.Left += 5;
            }
            if (isJumping)
            {
                if (force > 0 && isFalling == false)
                {
                    player.Top -= force;
                    force = -2;
                }
            }
            if(onPlatform == true)
            {
                isFalling = false;
                isJumping = false;
            }

            foreach (Control x in this.Controls)
            {
                plats = 0;
                if (x is PictureBox)
                {
                    if ((string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            onPlatform = true;
                            isFalling = false;
                            isJumping = false;
                        }
                        else
                        {
                            plats += 1;
                        }
                    }
                }
            }
        }
    }
}
