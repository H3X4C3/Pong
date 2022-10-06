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
        private int speedX = 10;
        private int speedY = 10;
        private int cpuSpeed = 10;

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

            //Check who wins
            if (p1Score == 10)
            {
                timer.Stop();
                lblWinner.Enabled = true;
                lblWinner.Text = "Player 1 Wins!";
            }
            if(p2Score == 10)
            {
                timer.Stop();
                lblWinner.Enabled = true;
                lblWinner.Text = "Player 2 Wins!";
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

            // CPU MOVEMENT
            player2.Top += cpuSpeed;
            if (player2.Top < 130 || player2.Top + player2.Height > this.ClientSize.Height)
            {
                cpuSpeed = -cpuSpeed;
            }

            // PLAYER MOVEMENT
            if (moveUp == true && player1.Top > 130) player1.Top -= 10;
            if (moveDown == true && player1.Top + player1.Height < this.ClientSize.Height) player1.Top += 10;

            // BALL MOVEMENT
            if (ball.Bounds.IntersectsWith(barrier.Bounds) || ball.Top + ball.Height > this.ClientSize.Height) speedY = -speedY;
            if (ball.Bounds.IntersectsWith(player1.Bounds) || ball.Bounds.IntersectsWith(player2.Bounds)) speedX = -speedX;
        }
    }
}
