namespace Pong
{
    partial class GameScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameScreen));
            this.ball = new System.Windows.Forms.PictureBox();
            this.barrier = new System.Windows.Forms.PictureBox();
            this.player2Score = new System.Windows.Forms.Label();
            this.player1Score = new System.Windows.Forms.Label();
            this.player2 = new System.Windows.Forms.PictureBox();
            this.player1 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblWinner = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).BeginInit();
            this.SuspendLayout();
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.Transparent;
            this.ball.Image = ((System.Drawing.Image)(resources.GetObject("ball.Image")));
            this.ball.Location = new System.Drawing.Point(554, 367);
            this.ball.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(46, 53);
            this.ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ball.TabIndex = 5;
            this.ball.TabStop = false;
            // 
            // barrier
            // 
            this.barrier.BackColor = System.Drawing.Color.Aqua;
            this.barrier.Location = new System.Drawing.Point(0, 119);
            this.barrier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barrier.Name = "barrier";
            this.barrier.Size = new System.Drawing.Size(1167, 7);
            this.barrier.TabIndex = 6;
            this.barrier.TabStop = false;
            // 
            // player2Score
            // 
            this.player2Score.AutoSize = true;
            this.player2Score.BackColor = System.Drawing.Color.Transparent;
            this.player2Score.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.player2Score.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.player2Score.ForeColor = System.Drawing.Color.Aqua;
            this.player2Score.Location = new System.Drawing.Point(586, 19);
            this.player2Score.Name = "player2Score";
            this.player2Score.Size = new System.Drawing.Size(88, 106);
            this.player2Score.TabIndex = 7;
            this.player2Score.Text = "0";
            // 
            // player1Score
            // 
            this.player1Score.AutoSize = true;
            this.player1Score.BackColor = System.Drawing.Color.Transparent;
            this.player1Score.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.player1Score.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.player1Score.ForeColor = System.Drawing.Color.Aqua;
            this.player1Score.Location = new System.Drawing.Point(497, 19);
            this.player1Score.Name = "player1Score";
            this.player1Score.Size = new System.Drawing.Size(88, 106);
            this.player1Score.TabIndex = 8;
            this.player1Score.Text = "0";
            // 
            // player2
            // 
            this.player2.BackColor = System.Drawing.Color.Red;
            this.player2.Location = new System.Drawing.Point(1136, 367);
            this.player2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(17, 96);
            this.player2.TabIndex = 9;
            this.player2.TabStop = false;
            // 
            // player1
            // 
            this.player1.BackColor = System.Drawing.Color.Gold;
            this.player1.Location = new System.Drawing.Point(14, 367);
            this.player1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(17, 96);
            this.player1.TabIndex = 10;
            this.player1.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.movePlayer);
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.BackColor = System.Drawing.Color.Transparent;
            this.lblWinner.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWinner.Enabled = false;
            this.lblWinner.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblWinner.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWinner.ForeColor = System.Drawing.Color.Red;
            this.lblWinner.Location = new System.Drawing.Point(0, 0);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(0, 159);
            this.lblWinner.TabIndex = 11;
            this.lblWinner.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1167, 796);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.barrier);
            this.Controls.Add(this.player1Score);
            this.Controls.Add(this.player2Score);
            this.Controls.Add(this.ball);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "GameScreen";
            this.Text = "Pong";
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyReleased);
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private PictureBox ball;
        private PictureBox barrier;
        private Label player2Score;
        private Label player1Score;
        private PictureBox player2;
        private PictureBox player1;
        private System.Windows.Forms.Timer timer;
        private Label lblWinner;
    }
}