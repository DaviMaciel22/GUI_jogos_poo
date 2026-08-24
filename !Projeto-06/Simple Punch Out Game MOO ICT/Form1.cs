namespace Simple_Punch_Out_Game_MOO_ICT
{
    public partial class Form1 : Form
    {

        bool playerBlock = false;
        bool enemyBlock = false;
        Random random = new Random();
        int enemySpeed = 5;
        int index = 0;
        int playerHealth = 100;
        int enemyHealth = 100;
        List<string> enemyAttack = new List<string> { "left", "right", "block" };



        public Form1()
        {
            InitializeComponent();
            ResetGame();
        }

        private void BoxerAttackTImerEvent(object sender, EventArgs e)
        {

            index = random.Next(0, enemyAttack.Count);

            switch (enemyAttack[index].ToString())
            {
                case "left":
                    boxer.Image = Properties.Resources.enemy_punch1;
                    enemyBlock = false;

                    if (boxer.Bounds.IntersectsWith(player.Bounds) && playerBlock == false)
                    {
                        playerHealth -= 5;
                    }

                    break;

                case "right":

                    boxer.Image = Properties.Resources.enemy_punch2;
                    enemyBlock = false;

                    if (boxer.Bounds.IntersectsWith(player.Bounds) && playerBlock == false)
                    {
                        playerHealth -= 5;
                    }
                    break;

                case "block":

                    boxer.Image = Properties.Resources.enemy_block;
                    enemyBlock = true;

                    break;
            }


        }

        private void BoxerMoveTimerEvent(object sender, EventArgs e)
        {
            // 1. Atualiza as barras de vida na tela
            if (playerHealth > 0)
            {
                playerHealthBar.Value = playerHealth;
            }
            if (enemyHealth > 0)
            {
                boxerHealthBar.Value = enemyHealth;
            }

            // 2. Movimenta o lutador inimigo
            boxer.Left += enemySpeed;

            if (boxer.Left > 430)
            {
                enemySpeed = -5;
            }
            if (boxer.Left < 220)
            {
                enemySpeed = 5;
            }

            // 3. Verifica o cenário de fim de jogo
            if (enemyHealth < 1)
            {
                BoxerAttackTimer.Stop();
                BoxerMoveTimer.Stop();

                // Mostra o texto e o botão de restart na própria tela
                lblMensagem.Text = "Você Venceu!";
                lblMensagem.Visible = true;
                btnRestart.Visible = true;
            }
            else if (playerHealth < 1)
            {
                BoxerAttackTimer.Stop();
                BoxerMoveTimer.Stop();

                // Mostra o texto e o botão de restart na própria tela
                lblMensagem.Text = "Tough Rob Venceu!";
                lblMensagem.Visible = true;
                btnRestart.Visible = true;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                player.Image = Properties.Resources.boxer_left_punch;
                playerBlock = false;

                if (player.Bounds.IntersectsWith(boxer.Bounds) && enemyBlock == false)
                {
                    enemyHealth -= 5;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                player.Image = Properties.Resources.boxer_right_punch;
                playerBlock = false;

                if (player.Bounds.IntersectsWith(boxer.Bounds) && enemyBlock == false)
                {
                    enemyHealth -= 5;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                player.Image = Properties.Resources.boxer_block;
                playerBlock = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            player.Image = Properties.Resources.boxer_stand;
            playerBlock = false;
        }

        private void ResetGame()
        {
            BoxerAttackTimer.Start();
            BoxerMoveTimer.Start();
            playerHealth = 100;
            enemyHealth = 100;

            boxer.Left = 400;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            // Esconde a mensagem e o botão novamente
            lblMensagem.Visible = false;
            btnRestart.Visible = false;

            // Reinicia o jogo
            ResetGame();

            // Garante que o jogador (Form) volte a ter o "foco" do teclado para se mexer
            this.Focus();
        }
    }
    }

