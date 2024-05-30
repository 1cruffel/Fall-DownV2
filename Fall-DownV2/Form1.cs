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
        bool left = false, right = false, falling = false;

        public Game()
        {
            InitializeComponent();
        }

        private void objectsUpdater_Tick(object sender, EventArgs e)
        {
            floor.Width = screen.Width;
            floor.Left = 0;
            floor.Top = screen.Height - floor.Height;
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
        }
    }
}
