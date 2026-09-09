using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Fighter_Jet_Shooting_Game_MOO_ICT
{
    public partial class Form1 : Form
    {
        // Gamestate
        private enum GameState { Menu, Tutorial, Playing, GameOver }
        private GameState state = GameState.Menu;

        // Movimento
        private bool goLeft, goRight, goUp, goDown;
        private int score;
        private int playerSpeed = 25;
        private int enemySpeed = 6;
        private readonly Random rnd = new Random();

        // Limites verticais do jogador (98 de altura)
        private const int PlayerTopLimit = 300;    // até onde a nave pode subir
        private const int PlayerBottomLimit = 680; // até onde pode descer

        // Imagem dos inimigos
        private Image currentEnemyImage;

        // Paineis
        private Panel menuPanel;
        private Panel tutorialPanel;
        private PictureBox previewInimigo;

        public Form1()
        {
            InitializeComponent();

            KeyPreview = true;
            DoubleBuffered = true;

            CriarMenu();
            CriarTutorial();
            AplicarEstiloInimigo(Color.FromArgb(120, 255, 120));


            enemyOne.Top = -300;
            enemyTwo.Top = -400;
            enemyThree.Top = -500;

            gameTimer.Stop();
        }


        // Escolha de cenário e estilo de inimigo
        private void CriarMenu()
        {
            menuPanel = new Panel
            {
                Size = new Size(460, 430),
                BackColor = Color.FromArgb(25, 25, 55),
                BorderStyle = BorderStyle.FixedSingle
            };
            menuPanel.Left = (ClientSize.Width - menuPanel.Width) / 2;
            menuPanel.Top = (ClientSize.Height - menuPanel.Height) / 2;

            // Preview do inimigo no canto do menu (SUGESTÃO 100% DA IA QUE EU RESOLVI ADOTAR)
            previewInimigo = new PictureBox
            {
                Size = new Size(50, 43),
                Location = new Point(398, 14),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent
            };

            var titulo = CriarTexto(menuPanel, "Jogo 2", 25, 22, FontStyle.Bold);
            var lblCenario = CriarTexto(menuPanel, "ESCOLHA O CENÁRIO", 95, 11, FontStyle.Bold);
            var lblInimigo = CriarTexto(menuPanel, "ESCOLHA A COR DOS INIMIGOS", 185, 11, FontStyle.Bold);

            var btnCeu = CriarBotao("Céu", new Point(20, 125), () => AplicarCenario(Color.FromArgb(128, 255, 255), false));
            var btnEspaco = CriarBotao("Espaço", new Point(170, 125), () => AplicarCenario(Color.FromArgb(10, 10, 35), true));
            var btnPorDoSol = CriarBotao("Pôr do Sol", new Point(320, 125), () => AplicarCenario(Color.FromArgb(255, 150, 90), false));

            var btnVerde = CriarBotao("Verde", new Point(20, 215), () => AplicarEstiloInimigo(Color.FromArgb(120, 255, 120)));
            var btnVermelho = CriarBotao("Vermelho", new Point(170, 215), () => AplicarEstiloInimigo(Color.FromArgb(255, 90, 90)));
            var btnAzul = CriarBotao("Azul", new Point(320, 215), () => AplicarEstiloInimigo(Color.FromArgb(120, 140, 255)));

            var btnJogar = CriarBotao("JOGAR", new Point(140, 310), IniciarTutorial);
            btnJogar.Size = new Size(180, 50);
            btnJogar.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnJogar.BackColor = Color.FromArgb(40, 160, 90);

            menuPanel.Controls.AddRange(new Control[]
            {
                titulo, previewInimigo, lblCenario, btnCeu, btnEspaco, btnPorDoSol,
                lblInimigo, btnVerde, btnVermelho, btnAzul, btnJogar
            });

            Controls.Add(menuPanel);
            menuPanel.BringToFront();
        }

        // Tutorial
        private void CriarTutorial()
        {
            tutorialPanel = new Panel
            {
                Size = new Size(560, 300),
                BackColor = Color.FromArgb(25, 25, 55),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };
            tutorialPanel.Left = (ClientSize.Width - tutorialPanel.Width) / 2;
            tutorialPanel.Top = (ClientSize.Height - tutorialPanel.Height) / 2;

            var t1 = CriarTexto(tutorialPanel, "COMO JOGAR", 20, 20, FontStyle.Bold);
            var t2 = CriarTexto(tutorialPanel, "SETAS  ←  →  ↑  ↓   :  mover a nave", 80, 13, FontStyle.Regular);
            var t3 = CriarTexto(tutorialPanel, "ESPAÇO  :  atirar", 120, 13, FontStyle.Regular);
            var t4 = CriarTexto(tutorialPanel, "Desvie dos inimigos! Encostar ou deixar passar = Game Over!", 165, 12, FontStyle.Regular);
            var t5 = CriarTexto(tutorialPanel, "Pressione ENTER para começar!", 220, 15, FontStyle.Bold);

            tutorialPanel.Controls.AddRange(new Control[] { t1, t2, t3, t4, t5 });

            Controls.Add(tutorialPanel);
            tutorialPanel.BringToFront();
        }

        private void IniciarTutorial()
        {
            state = GameState.Tutorial;
            menuPanel.Visible = false;
            tutorialPanel.Visible = true;
            ActiveControl = null;
        }




        private void AplicarCenario(Color cor, bool fundoEscuro)
        {
            BackColor = cor;
            var corTexto = fundoEscuro ? Color.White : Color.Black;
            txtScore.ForeColor = corTexto;
            gameOverLabel.ForeColor = corTexto;
        }

        private void AplicarEstiloInimigo(Color tinta)
        {
            currentEnemyImage = TintImage(Properties.Resources.enemy, tinta);
            enemyOne.Image = currentEnemyImage;
            enemyTwo.Image = currentEnemyImage;
            enemyThree.Image = currentEnemyImage;

            if (previewInimigo != null)
                previewInimigo.Image = currentEnemyImage;
        }

        // Gera uma versão colorida da imagem original em tempo de execução  (SUGESTÃO 100% DA IA)
        private Bitmap TintImage(Image original, Color tinta)
        {
            var resultado = new Bitmap(original.Width, original.Height);
            using (var g = Graphics.FromImage(resultado))
            {
                var matriz = new ColorMatrix
                {
                    Matrix00 = tinta.R / 255f,
                    Matrix11 = tinta.G / 255f,
                    Matrix22 = tinta.B / 255f,
                    Matrix33 = 1f,
                    Matrix44 = 1f
                };
                using (var attr = new ImageAttributes())
                {
                    attr.SetColorMatrix(matriz);
                    g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                        0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attr);
                }
            }
            return resultado;
        }


        // Main Game

        private void mainGameTimerEvent(object sender, EventArgs e)
        {
            txtScore.Text = score.ToString();

            enemyOne.Top += enemySpeed;
            enemyTwo.Top += enemySpeed;
            enemyThree.Top += enemySpeed;

            if (enemyOne.Top > 710 || enemyTwo.Top > 710 || enemyThree.Top > 710)
            {
                gameOver();
                return;
            }

            // Movimento do jogador (horizontal e vertical)
            if (goLeft && player.Left > 0)
                player.Left -= playerSpeed;
            if (goRight && player.Left < 688)
                player.Left += playerSpeed;
            if (goUp && player.Top > PlayerTopLimit)
                player.Top -= playerSpeed;
            if (goDown && player.Top < PlayerBottomLimit)
                player.Top += playerSpeed;

            VerificarColisaoPlayer();

            // Tiros
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is PictureBox tiro && (string)tiro.Tag == "tiro")
                {
                    tiro.Top -= 20;

                    if (tiro.Top < -50)
                    {
                        Controls.Remove(tiro);
                        tiro.Dispose();
                        continue;
                    }

                    if (tiro.Bounds.IntersectsWith(enemyOne.Bounds))
                    {
                        AcertouInimigo(enemyOne);
                        Controls.Remove(tiro); tiro.Dispose(); continue;
                    }
                    if (tiro.Bounds.IntersectsWith(enemyTwo.Bounds))
                    {
                        AcertouInimigo(enemyTwo);
                        Controls.Remove(tiro); tiro.Dispose(); continue;
                    }
                    if (tiro.Bounds.IntersectsWith(enemyThree.Bounds))
                    {
                        AcertouInimigo(enemyThree);
                        Controls.Remove(tiro); tiro.Dispose(); continue;
                    }
                }
            }
        }

        private void AcertouInimigo(PictureBox inimigo)
        {
            AdicionarPonto();
            inimigo.Top = -450;
            inimigo.Left = rnd.Next(20, 600);
        }

        // Colisão
        private void VerificarColisaoPlayer()
        {
            if (player.Bounds.IntersectsWith(enemyOne.Bounds) ||
                player.Bounds.IntersectsWith(enemyTwo.Bounds) ||
                player.Bounds.IntersectsWith(enemyThree.Bounds))
            {
                gameOver();
            }
        }

        // Teclado
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = true;
            if (e.KeyCode == Keys.Right) goRight = true;
            if (e.KeyCode == Keys.Up) goUp = true;
            if (e.KeyCode == Keys.Down) goDown = true;
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.Right) goRight = false;
            if (e.KeyCode == Keys.Up) goUp = false;
            if (e.KeyCode == Keys.Down) goDown = false;

            if (e.KeyCode == Keys.Space && state == GameState.Playing)
                CriarTiro();

            if (e.KeyCode == Keys.Enter &&
               (state == GameState.Tutorial || state == GameState.GameOver))
                resetGame();

            if (e.KeyCode == Keys.Escape && state == GameState.GameOver)
                VoltarAoMenu();
        }

        private void resetGame()
        {
            state = GameState.Playing;
            menuPanel.Visible = false;
            tutorialPanel.Visible = false;
            gameOverLabel.Visible = false;

            RemoverTiros();
            enemySpeed = 6;

            enemyOne.Left = rnd.Next(20, 600);
            enemyTwo.Left = rnd.Next(20, 600);
            enemyThree.Left = rnd.Next(20, 600);

            enemyOne.Top = rnd.Next(0, 200) * -1;
            enemyTwo.Top = rnd.Next(0, 500) * -1;
            enemyThree.Top = rnd.Next(0, 900) * -1;

            score = 0;
            txtScore.Text = score.ToString();

            gameTimer.Start();
        }

        private void gameOver()
        {
            state = GameState.GameOver;
            gameTimer.Stop();
            gameOverLabel.Visible = true;
        }

        private void VoltarAoMenu()
        {
            state = GameState.Menu;
            gameTimer.Stop();
            gameOverLabel.Visible = false;
            RemoverTiros();

            enemyOne.Top = -300;
            enemyTwo.Top = -400;
            enemyThree.Top = -500;

            menuPanel.Visible = true;
            menuPanel.BringToFront();
        }

        private void RemoverTiros()
        {
            for (int i = Controls.Count - 1; i >= 0; i--)
            {
                if (Controls[i] is PictureBox p && (string)p.Tag == "tiro")
                {
                    Controls.Remove(p);
                    p.Dispose();
                }
            }
        }


        // Tiro e pontuação

        private void CriarTiro()
        {
            var novoTiro = new PictureBox
            {
                BackColor = Color.Yellow,
                Size = new Size(5, 20),
                Top = player.Top - 30,
                Left = player.Left + (player.Width / 2),
                Tag = "tiro"
            };
            Controls.Add(novoTiro);
        }

        private void AdicionarPonto()
        {
            score++;
            if (score % 5 == 0) enemySpeed += 2;
        }


        private Label CriarTexto(Panel painel, string texto, int y, int tamanho, FontStyle estilo)
        {
            return new Label
            {
                Text = texto,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", tamanho, estilo),
                Width = painel.Width,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, y)
            };
        }

        private Button CriarBotao(string texto, Point local, Action aoClicar)
        {
            var b = new Button
            {
                Text = texto,
                Size = new Size(120, 40),
                Location = local,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(60, 60, 110),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            b.FlatAppearance.BorderSize = 0;
            b.Click += (s, e) => aoClicar();
            return b;
        }
    }
}