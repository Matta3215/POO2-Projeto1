namespace SimplePongGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gameTimer = new System.Windows.Forms.Timer(components);
            player = new PictureBox();
            ball = new PictureBox();
            cpu = new PictureBox();
            playerScore = new Label();
            cpuLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ball).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cpu).BeginInit();
            SuspendLayout();
            // 
            // gameTimer
            // 
            gameTimer.Enabled = true;
            gameTimer.Interval = 20;
            gameTimer.Tick += timer1_Tick;
            // 
            // player
            // 
            player.BackColor = SystemColors.Info;
            player.Location = new Point(12, 186);
            player.Name = "player";
            player.Size = new Size(27, 127);
            player.TabIndex = 0;
            player.TabStop = false;
            // 
            // ball
            // 
            ball.BackColor = SystemColors.ButtonHighlight;
            ball.Location = new Point(434, 239);
            ball.Name = "ball";
            ball.Size = new Size(27, 26);
            ball.TabIndex = 1;
            ball.TabStop = false;
            // 
            // cpu
            // 
            cpu.BackColor = SystemColors.GrayText;
            cpu.Location = new Point(897, 230);
            cpu.Name = "cpu";
            cpu.Size = new Size(27, 127);
            cpu.TabIndex = 2;
            cpu.TabStop = false;
            // 
            // playerScore
            // 
            playerScore.AutoSize = true;
            playerScore.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            playerScore.ForeColor = Color.Lime;
            playerScore.Location = new Point(105, 9);
            playerScore.Name = "playerScore";
            playerScore.Size = new Size(21, 15);
            playerScore.TabIndex = 3;
            playerScore.Text = "00";
            // 
            // cpuLabel
            // 
            cpuLabel.AutoSize = true;
            cpuLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cpuLabel.ForeColor = Color.Red;
            cpuLabel.Location = new Point(735, 9);
            cpuLabel.Name = "cpuLabel";
            cpuLabel.Size = new Size(21, 15);
            cpuLabel.TabIndex = 4;
            cpuLabel.Text = "00";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(928, 574);
            Controls.Add(cpuLabel);
            Controls.Add(playerScore);
            Controls.Add(cpu);
            Controls.Add(ball);
            Controls.Add(player);
            Name = "Form1";
            Text = "Pong Game";
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)ball).EndInit();
            ((System.ComponentModel.ISupportInitialize)cpu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private PictureBox player;
        private PictureBox ball;
        private PictureBox cpu;
        private Label playerScore;
        private Label cpuLabel;
    }
}
