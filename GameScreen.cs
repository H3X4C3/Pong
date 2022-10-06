using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Pong
{
    public partial class GameScreen : Form
    {
        // GAME VARS
        private bool moveUp;
        private bool moveDown;
        private int p1Score = 0;
        private int p2Score = 0;
        private int speedX = 4;
        private int speedY = 4;
        private int cpuSpeed = 5;

        // BALL POSITION
        private int ballStartingPosX;
        private int ballStartingPosY;

        public GameScreen()
        {
            InitializeComponent();

            ballStartingPosX = ball.Location.X;
            ballStartingPosY = ball.Location.Y;
            timer.Start();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile(Application.StartupPath + @"..\..\..\resources\fonts\ThaleahFat.ttf");
            foreach (Control c in this.Controls)
            {
                c.Font = new Font(fontCollection.Families[0], c.Font.Size, c.Font.Style);
            }
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    moveUp = true;
                    break;
                case Keys.S:
                    moveDown = true;
                    break;
                case Keys.Up:
                    moveUp = true;
                    break;
                case Keys.Down:
                    moveDown = true;
                    break;
            }
        }

        private void KeyReleased(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    moveUp = false;
                    break;
                case Keys.S:
                    moveDown = false;
                    break;
                case Keys.Up:
                    moveUp = false;
                    break;
                case Keys.Down:
                    moveDown = false;
                    break;
            }
        }

        private void movePlayer(object sender, EventArgs e)
        {
            player1Score.Text = "" + p1Score;
            player2Score.Text = "" + p2Score;

            // CPU MOVEMENT
            player2.Top += cpuSpeed;
            if (!player2.Bounds.IntersectsWith(barrier.Bounds) || player2.Top + player2.Height < 600) cpuSpeed = -cpuSpeed;

            //Check who wins
            if (p1Score == 10)
            {
                timer.Stop();
                MessageBox.Show("Player 1 Wins!");
            }
            if(p2Score == 10)
            {
                timer.Stop();
                MessageBox.Show("Player 2 Wins!");
            }

            // UPDATE BALL MOVEMENT
            ball.Left += speedX;
            ball.Top += speedY;

            // CHECK WHERE BALL CROSSES
            if(ball.Left < 0)
            {
                p2Score++;
                ball.Left = ballStartingPosX;
                ball.Top = ballStartingPosY;
                speedX = -speedX;
            }
            if(ball.Left + ball.Width > this.ClientSize.Width)
            {
                p1Score++;
                ball.Left = ballStartingPosX;
                ball.Top = ballStartingPosY;
                speedX = -speedX;
            }

            // BALL MOVEMENT
            if (ball.Bounds.IntersectsWith(barrier.Bounds) || ball.Top + ball.Height > this.ClientSize.Height) speedY = -speedY;
            if (ball.Bounds.IntersectsWith(player1.Bounds) || ball.Bounds.IntersectsWith(player2.Bounds)) speedX = -speedX;

            // PLAYER MOVEMENT
            if (moveUp == true && !player1.Bounds.IntersectsWith(barrier.Bounds)) player1.Top -= 5;
            if (moveDown == true && player1.Top + player1.Height < this.ClientSize.Height) player1.Top += 5;
        }
    }
}
