namespace Simple_Punch_Out_Game_MOO_ICT
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
            boxerHealthBar = new ProgressBar();
            playerHealthBar = new ProgressBar();
            player = new PictureBox();
            boxer = new PictureBox();
            BoxerAttackTimer = new System.Windows.Forms.Timer(components);
            BoxerMoveTimer = new System.Windows.Forms.Timer(components);
            btnRestart = new Button();
            lblMensagem = new Label();
            label_combo = new Label();
            label_combo_quebrado = new Label();
            FimComboTimer = new System.Windows.Forms.Timer(components);
            stamineBar = new ProgressBar();
            quadroCor = new Panel();
            cor2 = new Button();
            cor1 = new Button();
            labelCor = new Label();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)boxer).BeginInit();
            quadroCor.SuspendLayout();
            SuspendLayout();
            // 
            // boxerHealthBar
            // 
            boxerHealthBar.Location = new Point(12, 43);
            boxerHealthBar.Name = "boxerHealthBar";
            boxerHealthBar.Size = new Size(239, 23);
            boxerHealthBar.TabIndex = 0;
            // 
            // playerHealthBar
            // 
            playerHealthBar.Location = new Point(483, 43);
            playerHealthBar.Name = "playerHealthBar";
            playerHealthBar.Size = new Size(239, 23);
            playerHealthBar.TabIndex = 0;
            // 
            // player
            // 
            player.BackColor = Color.Transparent;
            player.Image = Properties.Resources.boxer_stand;
            player.Location = new Point(348, 407);
            player.Name = "player";
            player.Size = new Size(61, 153);
            player.SizeMode = PictureBoxSizeMode.AutoSize;
            player.TabIndex = 1;
            player.TabStop = false;
            // 
            // boxer
            // 
            boxer.BackColor = Color.Transparent;
            boxer.Image = Properties.Resources.enemy_stand;
            boxer.Location = new Point(404, 321);
            boxer.Name = "boxer";
            boxer.Size = new Size(77, 185);
            boxer.SizeMode = PictureBoxSizeMode.AutoSize;
            boxer.TabIndex = 2;
            boxer.TabStop = false;
            // 
            // BoxerAttackTimer
            // 
            BoxerAttackTimer.Enabled = true;
            BoxerAttackTimer.Interval = 500;
            BoxerAttackTimer.Tick += BoxerAttackTImerEvent;
            // 
            // BoxerMoveTimer
            // 
            BoxerMoveTimer.Enabled = true;
            BoxerMoveTimer.Interval = 20;
            BoxerMoveTimer.Tick += BoxerMoveTimerEvent;
            // 
            // btnRestart
            // 
            btnRestart.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            btnRestart.Location = new Point(278, 150);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(193, 111);
            btnRestart.TabIndex = 3;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Visible = false;
            btnRestart.Click += btnRestart_Click;
            // 
            // lblMensagem
            // 
            lblMensagem.BackColor = Color.White;
            lblMensagem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMensagem.ForeColor = SystemColors.ControlText;
            lblMensagem.Location = new Point(292, 167);
            lblMensagem.Name = "lblMensagem";
            lblMensagem.Size = new Size(166, 15);
            lblMensagem.TabIndex = 4;
            lblMensagem.Text = "label1";
            lblMensagem.TextAlign = ContentAlignment.MiddleCenter;
            lblMensagem.Visible = false;
            // 
            // label_combo
            // 
            label_combo.BackColor = Color.Transparent;
            label_combo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label_combo.ForeColor = Color.Red;
            label_combo.Location = new Point(12, 256);
            label_combo.Name = "label_combo";
            label_combo.Size = new Size(47, 27);
            label_combo.TabIndex = 5;
            label_combo.Text = "0";
            label_combo.Visible = false;
            label_combo.Click += label1_Click;
            // 
            // label_combo_quebrado
            // 
            label_combo_quebrado.BackColor = Color.Transparent;
            label_combo_quebrado.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label_combo_quebrado.ForeColor = Color.Red;
            label_combo_quebrado.Location = new Point(1, 293);
            label_combo_quebrado.Name = "label_combo_quebrado";
            label_combo_quebrado.Size = new Size(186, 29);
            label_combo_quebrado.TabIndex = 6;
            label_combo_quebrado.Text = "Combo quebrado!";
            label_combo_quebrado.Visible = false;
            label_combo_quebrado.Click += label1_Click_1;
            // 
            // FimComboTimer
            // 
            FimComboTimer.Enabled = true;
            FimComboTimer.Interval = 2000;
            FimComboTimer.Tick += FimComboTimer_Tick;
            // 
            // stamineBar
            // 
            stamineBar.Location = new Point(603, 526);
            stamineBar.Name = "stamineBar";
            stamineBar.Size = new Size(119, 23);
            stamineBar.TabIndex = 5;
            stamineBar.Value = 100;
            stamineBar.Click += stamineBar_Click_1;
            // 
            // quadroCor
            // 
            quadroCor.Controls.Add(cor2);
            quadroCor.Controls.Add(cor1);
            quadroCor.Controls.Add(labelCor);
            quadroCor.Location = new Point(261, 242);
            quadroCor.Name = "quadroCor";
            quadroCor.Size = new Size(229, 132);
            quadroCor.TabIndex = 7;
            // 
            // cor2
            // 
            cor2.BackColor = Color.Red;
            cor2.Location = new Point(135, 65);
            cor2.Name = "cor2";
            cor2.Size = new Size(75, 50);
            cor2.TabIndex = 2;
            cor2.UseVisualStyleBackColor = false;
            cor2.Click += cor2_Click;
            // 
            // cor1
            // 
            cor1.BackColor = Color.Cyan;
            cor1.Location = new Point(19, 65);
            cor1.Name = "cor1";
            cor1.Size = new Size(75, 50);
            cor1.TabIndex = 1;
            cor1.UseVisualStyleBackColor = false;
            cor1.Click += cor1_Click;
            // 
            // labelCor
            // 
            labelCor.AutoSize = true;
            labelCor.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            labelCor.Location = new Point(12, 22);
            labelCor.Name = "labelCor";
            labelCor.Size = new Size(206, 20);
            labelCor.TabIndex = 0;
            labelCor.Text = "Escolha a cor das suas luvas:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(734, 561);
            Controls.Add(quadroCor);
            Controls.Add(label_combo_quebrado);
            Controls.Add(label_combo);
            Controls.Add(stamineBar);
            Controls.Add(lblMensagem);
            Controls.Add(btnRestart);
            Controls.Add(player);
            Controls.Add(playerHealthBar);
            Controls.Add(boxerHealthBar);
            Controls.Add(boxer);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Simple Punch Out Game MOO ICT";
            Load += Form1_Load;
            KeyDown += KeyIsDown;
            KeyUp += KeyIsUp;
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)boxer).EndInit();
            quadroCor.ResumeLayout(false);
            quadroCor.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private ProgressBar boxerHealthBar;
        private ProgressBar playerHealthBar;
        private PictureBox player;
        private PictureBox boxer;
        private System.Windows.Forms.Timer BoxerAttackTimer;
        private System.Windows.Forms.Timer BoxerMoveTimer;
        private Button btnRestart;
        private Label lblMensagem;
        private Label label_combo;
        private Label label_combo_quebrado;
        private System.Windows.Forms.Timer FimComboTimer;
        private ProgressBar stamineBar;
        private Panel quadroCor;
        private Label labelCor;
        private Button cor2;
        private Button cor1;
    }
}