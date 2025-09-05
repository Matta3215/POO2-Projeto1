using System;
using System.Windows.Forms;

namespace SimplePongGame
{
    public partial class Form1 : Form
    {
        int ballx = 5;
        int bally = 5;
        int score = 0;
        int cpuPoint = 0;

        bool goup;
        bool godown;

        Random rand = new Random();

        // Controle de pausa ap�s o gol (apenas para a bola)
        bool ballPaused = false;
        int pauseCounter = 0;
        int pauseDuration = 60; // ~1 segundo se o Timer for 16ms (60 FPS)

        public Form1()
        {
            InitializeComponent();
            ball.Image = Image.FromFile("C:\\DevC\\SimplePongGame\\Imagens\\ballsprite_large.png"); // ou "Images/ballSprite.png" se estiver numa subpasta
            ball.SizeMode = PictureBoxSizeMode.StretchImage;
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);
            gameTimer.Start(); // Certifique-se de iniciar o Timer
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                goup = true;
            if (e.KeyCode == Keys.Down)
                godown = true;
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                goup = false;
            if (e.KeyCode == Keys.Down)
                godown = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            playerScore.Text = score.ToString();
            cpuLabel.Text = cpuPoint.ToString();

            // ?? Controle da pausa da bola
            if (ballPaused)
            {
                pauseCounter++;
                if (pauseCounter >= pauseDuration)
                {
                    ballPaused = false;
                    pauseCounter = 0;
                }
            }

            // ? Movimento da bola (se n�o estiver pausada)
            if (!ballPaused)
            {
                ball.Top -= bally;
                ball.Left -= ballx;
            }

            // ? Movimento do jogador
            if (goup && player.Top > 0)
                player.Top -= 8;

            if (godown && player.Top + player.Height < ClientSize.Height)
                player.Top += 8;

            // ? Movimento da CPU com atraso e erro (n�o � perfeita)
            int cpuCenter = cpu.Top + cpu.Height / 2;
            int ballCenter = ball.Top + ball.Height / 2;

            if (Math.Abs(cpuCenter - ballCenter) > 20)
            {
                if (cpuCenter < ballCenter)
                    cpu.Top += 5;
                else
                    cpu.Top -= 5;
            }

            // ? Colis�o com topo ou base
            if (ball.Top < 0 || ball.Top + ball.Height > ClientSize.Height)
                bally = -bally;

            // ? Colis�o com jogador ou CPU (se n�o estiver pausada)
            if (!ballPaused && (ball.Bounds.IntersectsWith(player.Bounds) || ball.Bounds.IntersectsWith(cpu.Bounds)))
            {
                ballx = -ballx;

                // ? Aumenta a velocidade da bola a cada colis�o (com limite)
                if (ballx < 0 && Math.Abs(ballx) < 12)
                    ballx -= 1;
                else if (ballx > 0 && Math.Abs(ballx) < 12)
                    ballx += 1;

                if (bally < 0 && Math.Abs(bally) < 12)
                    bally -= 1;
                else if (bally > 0 && Math.Abs(bally) < 12)
                    bally += 1;
            }

            // ? Gol da CPU
            if (ball.Left < 0)
            {
                cpuPoint++;
                ResetBall(toRight: true);
            }

            // ? Gol do jogador
            if (ball.Left + ball.Width > ClientSize.Width)
            {
                score++;
                ResetBall(toRight: false);
            }

            // ? Fim de jogo
            if (score >= 10)
            {
                gameTimer.Stop();
                MessageBox.Show("Voc� venceu!", "Fim de Jogo");
            }

            if (cpuPoint >= 10)
            {
                gameTimer.Stop();
                MessageBox.Show("CPU venceu!", "Fim de Jogo");
            }
        }

        private void ResetBall(bool toRight)
        {
            ball.Left = ClientSize.Width / 2 - ball.Width / 2;
            ball.Top = rand.Next(100, ClientSize.Height - 100);

            // Define dire��o da bola
            ballx = toRight ? Math.Abs(ballx) : -Math.Abs(ballx);
            bally = rand.Next(0, 2) == 0 ? 5 : -5;

            // Limita a velocidade para evitar bug
            ballx = Math.Max(-12, Math.Min(ballx, 12));
            bally = Math.Max(-12, Math.Min(bally, 12));

            // Ativa a pausa na bola
            ballPaused = true;
            pauseCounter = 0;
        }
    }
}