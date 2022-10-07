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
using System.Media;

namespace Pong
{
    public partial class GameScreen : Form
    {
        // DIRECTION
        private bool moveUp;
        private bool moveDown;

        // SCORE
        private int p1Score = 0;
        private int p2Score = 0;

        // VELOCITY
        private int speedX = 8;
        private int speedY = 8;
        private int cpuSpeed = 6;

        // DEAFULT POSITIONS
        private int ballStartingPosX;
        private int ballStartingPosY;

        // AI RANDOMIZATION
        Random rand = new Random();

        // MUSIC
        SoundPlayer player;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public GameScreen()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();

            ballStartingPosX = ball.Left + ball.Width;
            ballStartingPosY = ball.Top + ball.Height;

            timer.Start();
        }

        PrivateFontCollection fontCollection = new PrivateFontCollection(); // CUSTOM FONT
        private void GameScreen_Load(object sender, EventArgs e)
        {
            fontCollection.AddFontFile(Application.StartupPath + @"..\..\..\resources\fonts\ThaleahFat.ttf");
            foreach (Control c in this.Controls)
            {
                c.Font = new Font(fontCollection.Families[0], c.Font.Size, c.Font.Style);
            }

            lblWinner.Font = new Font(fontCollection.Families[0], lblWinner.Font.Size, lblWinner.Font.Style);
            btnRestart.Font = new Font(fontCollection.Families[0], btnRestart.Font.Size, btnRestart.Font.Style);
            btnQuit.Font = new Font(fontCollection.Families[0], btnQuit.Font.Size, btnQuit.Font.Style);
        }

        private void restartGame(object sender, EventArgs e)
        {
            timer.Start();

            // HIDE WIN MENU
            player.Stop();
            winMenu.Enabled = false;
            winMenu.Hide();

            // RESET SCORE
            p1Score = 0;
            p2Score = 0;

            // RESET BALL POSITION
            ball.Left = ballStartingPosX;
            ball.Top = ballStartingPosY;

            // RESET PLAYER POSITION
            player1.Location = new Point(12, 275);
            player2.Location = new Point(994, 275);
        }

        private void quitGame(object sender, EventArgs e)
        {
            this.Close();
        }

        // CHECK SCORE
        private void checkScore()
        {
            // Check who wins
            if (p1Score == 10)
            {
                timer.Stop();
                winMenu.Enabled = true;
                winMenu.Show();
                lblWinner.Text = "Player 1 Wins!";
                player = new SoundPlayer(@"..\..\..\resources\audio\Game Won.wav");
                player.Play();
            }
            if (p2Score == 10)
            {
                timer.Stop();
                winMenu.Enabled = true;
                winMenu.Show();
                lblWinner.Text = "Player 2 Wins!";
                player = new SoundPlayer(@"..\..\..\resources\audio\Game Lost.wav");
                player.Play();
            }
        }

        // PLAYER MOVEMENTS
        private void movePlayer1()
        {
            // PLAYER MOVEMENT
            if (moveUp == true && player1.Top > 130) player1.Top -= 10;
            if (moveDown == true && player1.Top + player1.Height < this.ClientSize.Height) player1.Top += 10;
        }

        private void movePlayer2()
        {
            // CPU MOVEMENT
            player2.Top += cpuSpeed;
            if (player2.Top < 130 || player2.Top + player2.Height > this.ClientSize.Height)
            {
                cpuSpeed = -cpuSpeed;
            }
        }

        // BALL MOVEMENT
        private void ballMovement()
        {
            
            // BALL MOVEMENT
            ball.Left += speedX;
            ball.Top += speedY;
            if (ball.Bounds.IntersectsWith(barrier.Bounds) || ball.Top + ball.Height > this.ClientSize.Height) speedY = -speedY;
            if (ball.Bounds.IntersectsWith(player1.Bounds) || ball.Bounds.IntersectsWith(player2.Bounds)) speedX = -speedX;
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    moveUp = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.S:
                    moveDown = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Up:
                    moveUp = true;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Down:
                    moveDown = true;
                    e.SuppressKeyPress = true;
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

        private void handleGame(object sender, EventArgs e)
        {
            player1Score.Text = "" + p1Score;
            player2Score.Text = "" + p2Score;

            checkScore();

            // CHECK WHERE BALL CROSSES
            if (ball.Left < 0)
            {
                p2Score++;
                ball.Left = ballStartingPosX;
                ball.Top = ballStartingPosY;
                speedX = -speedX;
            }
            if (ball.Left + ball.Width > this.ClientSize.Width)
            {
                p1Score++;
                ball.Left = ballStartingPosX;
                ball.Top = ballStartingPosY;
                speedX = -speedX;
            }

            movePlayer1();
            movePlayer2();
            ballMovement();
        }
    }
}
