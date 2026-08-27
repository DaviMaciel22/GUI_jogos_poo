using System.Numerics;
namespace Fighter_Jet_Shooting_Game_MOO_ICT
{
    public partial class Form1 : Form
    {

        bool goLeft, goRight, shooting, isGameOver;
        int score;
        int playerSpeed = 25;
        int enemySpeed;
        int bulletSpeed;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            resetGame();
        }

        private void mainGameTimerEvent(object sender, EventArgs e)
        {

            txtScore.Text = score.ToString();


            enemyOne.Top += enemySpeed;
            enemyTwo.Top += enemySpeed;
            enemyThree.Top += enemySpeed;


            if (enemyOne.Top > 710 || enemyTwo.Top > 710 || enemyThree.Top > 710)
            {
                gameOver();
            }



            // player movement logic starts

            if (goLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }
            if (goRight == true && player.Left < 688)
            {
                player.Left += playerSpeed;
            }
            // player movement logic ends

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "tiro")
                {
                    x.Top -= 20;

                    if (x.Top < -50)
                    {
                        this.Controls.Remove(x);
                        x.Dispose();
                    }

                    if (x.Bounds.IntersectsWith(enemyOne.Bounds))
                    {
                        score += 1;
                        enemyOne.Top = -450;
                        enemyOne.Left = rnd.Next(20, 600);

                        this.Controls.Remove(x);
                        x.Dispose();
                    }

                    if (x.Bounds.IntersectsWith(enemyTwo.Bounds))
                    {
                        score += 1;
                        enemyTwo.Top = -450;
                        enemyTwo.Left = rnd.Next(20, 600);

                        this.Controls.Remove(x);
                        x.Dispose();
                    }

                    if (x.Bounds.IntersectsWith(enemyThree.Bounds))
                    {
                        score += 1;
                        enemyThree.Top = -450;
                        enemyThree.Left = rnd.Next(20, 600);

                        this.Controls.Remove(x);
                        x.Dispose();
                    }
                }
            }

            if (score == 5)
            {
                enemySpeed = 10;
            }
            if (score == 10)
            {
                enemySpeed = 15;
            }


        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                CriarTiro();
            }
            if (e.KeyCode == Keys.Enter && isGameOver == true)
            {
                resetGame();
            }
        }

        private void CriarTiro()
        {
            PictureBox novoTiro = new PictureBox();

            novoTiro.BackColor = Color.Yellow;
            novoTiro.Size = new Size(5, 20);
            novoTiro.Top = player.Top - 30;
            novoTiro.Left = player.Left + (player.Width / 2);

            novoTiro.Tag = "tiro";

            this.Controls.Add(novoTiro);
        }

        private void resetGame()
        {
            gameTimer.Start();
            enemySpeed = 6;


            enemyOne.Left = rnd.Next(20, 600);
            enemyTwo.Left = rnd.Next(20, 600);
            enemyThree.Left = rnd.Next(20, 600);

            enemyOne.Top = rnd.Next(0, 200) * -1;
            enemyTwo.Top = rnd.Next(0, 500) * -1;
            enemyThree.Top = rnd.Next(0, 900) * -1;

            score = 0;
            bulletSpeed = 0;
            bullet.Left = -300;
            shooting = false;


            txtScore.Text = score.ToString();

        }

        private void gameOver()
        {
            isGameOver = true;
            gameTimer.Stop();
            txtScore.Text += Environment.NewLine + "Game Over!!" + Environment.NewLine + "Press Enter to try again.";

        }
    }
}