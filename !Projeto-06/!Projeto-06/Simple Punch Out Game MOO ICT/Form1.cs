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
        int combo = 0;
        List<string> enemyAttack = new List<string> { "left", "right", "block" };
        int playerStamina = 100;
        DateTime momentoDefesa;




        public Form1()
        {
            InitializeComponent();
            ResetGame();
            this.Shown += Form1_Shown;
        }

        private void Form1_Shown(object? sender, EventArgs e)
        {
            ShowTutorial();
        }

        private void ShowTutorial()
        {
            bool ataqueAtivo = BoxerAttackTimer.Enabled;
            bool moveAtivo = BoxerMoveTimer.Enabled;

            BoxerAttackTimer.Stop();
            BoxerMoveTimer.Stop();

            using (TutorialForm tutorial = new TutorialForm())
            {
                tutorial.ShowDialog(this);
            }

            player.Image = Properties.Resources.boxer_stand;
            playerBlock = false;

            if (ataqueAtivo) BoxerAttackTimer.Start();
            if (moveAtivo) BoxerMoveTimer.Start();

            this.Focus();
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

                        if (combo > 0)
                        {
                            label_combo.Visible = false;
                            label_combo_quebrado.Visible = true;
                            FimComboTimer.Start();
                            combo = 0;
                        }
                    }
                    
                    if (boxer.Bounds.IntersectsWith(player.Bounds) && playerBlock == true)
                    {
                        TimeSpan tempoDecorrido = DateTime.Now - momentoDefesa;

                        if (tempoDecorrido.TotalMilliseconds < 300) 
                        {
                            combo++;
                            AtualizarTelaCombo();
                        }
                    }

                    break;

                case "right":

                    boxer.Image = Properties.Resources.enemy_punch2;
                    enemyBlock = false;

                    if (boxer.Bounds.IntersectsWith(player.Bounds) && playerBlock == false)
                    {
                        playerHealth -= 5;
                        if (combo > 0)
                        {
                            label_combo.Visible = false;
                            label_combo_quebrado.Visible = true;
                            FimComboTimer.Start();
                            combo = 0;
                        }
                    }

                    if (boxer.Bounds.IntersectsWith(player.Bounds) && playerBlock == true)
                    {
                        TimeSpan tempoDecorrido = DateTime.Now - momentoDefesa;

                        if (tempoDecorrido.TotalMilliseconds < 300)
                        {
                            combo++;
                            AtualizarTelaCombo();
                        }
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
                combo = 0;
                label_combo.Visible = false;
                playerStamina = 100;
            }
            else if (playerHealth < 1)
            {
                BoxerAttackTimer.Stop();
                BoxerMoveTimer.Stop();

                // Mostra o texto e o botão de restart na própria tela
                lblMensagem.Text = "Tough Rob Venceu!";
                lblMensagem.Visible = true;
                btnRestart.Visible = true;
                combo = 0;
                label_combo.Visible = false;
                playerStamina = 100;
            }

            if (playerStamina < 100)
            {
                playerStamina += 2; // Aumente este valor se quiser que recarregue mais rápido
            }

            // Garante que o valor não passe de 100 ou caia abaixo de 0 antes de atualizar a UI
            playerStamina = Math.Clamp(playerStamina, 0, 100);
            stamineBar.Value = playerStamina;
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ShowTutorial();
                return;
            }

            if (e.KeyCode == Keys.Left && playerStamina >= 30)
            {
                player.Image = Properties.Resources.boxer_left_punch;
                playerBlock = false;
                playerStamina -= 30;

                if (player.Bounds.IntersectsWith(boxer.Bounds) && enemyBlock == false)
                {
                    combo++;
                    if (combo >= 5 && combo < 10)
                    {
                        enemyHealth -= 7;
                    }

                    else if (combo >= 10)
                    {
                        enemyHealth -= 10;
                    }

                    else
                    {
                        enemyHealth -= 5;
                    }
                    AtualizarTelaCombo();
                }
                else
                {
                    if (combo > 0)
                    {
                        label_combo.Visible = false;
                        label_combo_quebrado.Visible = true;
                        FimComboTimer.Start();
                        combo = 0;
                    }
                }
            }
            if (e.KeyCode == Keys.Right && playerStamina >= 30)
            {
                player.Image = Properties.Resources.boxer_right_punch;
                playerBlock = false;
                playerStamina -= 30;

                if (player.Bounds.IntersectsWith(boxer.Bounds) && enemyBlock == false)
                {
                    combo++;
                    if (combo >= 5 && combo < 10)
                    {
                        enemyHealth -= 7;
                    }

                    else if (combo >= 10)
                    {
                        enemyHealth -= 10;
                    }

                    else
                    {
                        enemyHealth -= 5;
                    }
                    AtualizarTelaCombo();
                }
                else
                {
                    if (combo > 0)
                    {
                        label_combo.Visible = false;
                        label_combo_quebrado.Visible = true;
                        FimComboTimer.Start();
                        combo = 0;
                    }
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                player.Image = Properties.Resources.boxer_block;
                playerBlock = true;
                momentoDefesa = DateTime.Now;
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

        public void AtualizarTelaCombo()
        {
            label_combo.Text = combo.ToString();
            if (combo >= 1)
            {
                label_combo.Visible = true;
            }
            else
            {
                label_combo.Visible = false;
            }
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void FimComboTimer_Tick(object sender, EventArgs e)
        {
            label_combo_quebrado.Visible = false;
            FimComboTimer.Stop();
        }
        

        private void stamineBar_Click_1(object sender, EventArgs e)
        {

        }
    }
}

