namespace Fighter_Jet_Shooting_Game_MOO_ICT
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
            enemyOne = new PictureBox();
            enemyTwo = new PictureBox();
            enemyThree = new PictureBox();
            player = new PictureBox();
            txtScore = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)enemyOne).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemyTwo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemyThree).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            SuspendLayout();
            // 
            // enemyOne
            // 
            enemyOne.BackColor = Color.Transparent;
            enemyOne.Image = Properties.Resources.enemy;
            enemyOne.Location = new Point(30, 72);
            enemyOne.Margin = new Padding(4, 3, 4, 3);
            enemyOne.Name = "enemyOne";
            enemyOne.Size = new Size(100, 85);
            enemyOne.SizeMode = PictureBoxSizeMode.AutoSize;
            enemyOne.TabIndex = 0;
            enemyOne.TabStop = false;
            // 
            // enemyTwo
            // 
            enemyTwo.BackColor = Color.Transparent;
            enemyTwo.Image = Properties.Resources.enemy;
            enemyTwo.Location = new Point(390, 72);
            enemyTwo.Margin = new Padding(4, 3, 4, 3);
            enemyTwo.Name = "enemyTwo";
            enemyTwo.Size = new Size(100, 85);
            enemyTwo.SizeMode = PictureBoxSizeMode.AutoSize;
            enemyTwo.TabIndex = 0;
            enemyTwo.TabStop = false;
            // 
            // enemyThree
            // 
            enemyThree.BackColor = Color.Transparent;
            enemyThree.Image = Properties.Resources.enemy;
            enemyThree.Location = new Point(775, 72);
            enemyThree.Margin = new Padding(4, 3, 4, 3);
            enemyThree.Name = "enemyThree";
            enemyThree.Size = new Size(100, 85);
            enemyThree.SizeMode = PictureBoxSizeMode.AutoSize;
            enemyThree.TabIndex = 0;
            enemyThree.TabStop = false;
            // 
            // player
            // 
            player.BackColor = Color.Transparent;
            player.Image = Properties.Resources.player;
            player.Location = new Point(390, 651);
            player.Margin = new Padding(4, 3, 4, 3);
            player.Name = "player";
            player.Size = new Size(110, 98);
            player.SizeMode = PictureBoxSizeMode.AutoSize;
            player.TabIndex = 0;
            player.TabStop = false;
            // 
            // txtScore
            // 
            txtScore.BackColor = Color.Transparent;
            txtScore.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtScore.Location = new Point(172, 274);
            txtScore.Margin = new Padding(4, 0, 4, 0);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(541, 252);
            txtScore.TabIndex = 1;
            txtScore.Text = "0";
            txtScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 20;
            gameTimer.Tick += mainGameTimerEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(128, 255, 255);
            ClientSize = new Size(933, 778);
            Controls.Add(player);
            Controls.Add(enemyThree);
            Controls.Add(enemyTwo);
            Controls.Add(enemyOne);
            Controls.Add(txtScore);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Fighet Jet Shooting Game MOOI CT";
            KeyDown += keyisdown;
            KeyUp += keyisup;
            ((System.ComponentModel.ISupportInitialize)enemyOne).EndInit();
            ((System.ComponentModel.ISupportInitialize)enemyTwo).EndInit();
            ((System.ComponentModel.ISupportInitialize)enemyThree).EndInit();
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ResumeLayout(false);
            PerformLayout();


        }

        #endregion

        private System.Windows.Forms.PictureBox enemyOne;
        private System.Windows.Forms.PictureBox enemyTwo;
        private System.Windows.Forms.PictureBox enemyThree;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Timer gameTimer;

    }
}
