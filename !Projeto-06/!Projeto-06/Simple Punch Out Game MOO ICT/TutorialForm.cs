using System;
using System.Drawing;
using System.Windows.Forms;

namespace Simple_Punch_Out_Game_MOO_ICT
{
    public class TutorialForm : Form
    {
        public TutorialForm()
        {
            this.Text = "Tutorial - Punch Out";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ClientSize = new Size(560, 520);
            this.BackColor = Color.FromArgb(20, 20, 28);

            Label titulo = new Label();
            titulo.Text = "TUTORIAL";
            titulo.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            titulo.ForeColor = Color.Gold;
            titulo.TextAlign = ContentAlignment.MiddleCenter;
            titulo.Dock = DockStyle.Top;
            titulo.Height = 60;

            Label corpo = new Label();
            corpo.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            corpo.ForeColor = Color.White;
            corpo.Location = new Point(30, 70);
            corpo.Size = new Size(500, 380);
            corpo.Text =
                "OBJETIVO\r\n" +
                "Zerar a barra de vida do Tough Rob antes que ele zere a sua.\r\n" +
                "\r\n" +
                "CONTROLES\r\n" +
                "  Seta ESQUERDA  ->  Soco de esquerda\r\n" +
                "  Seta DIREITA   ->  Soco de direita\r\n" +
                "  Seta BAIXO     ->  Defesa (bloqueio)\r\n" +
                "  F1             ->  Reabrir este tutorial\r\n" +
                "\r\n" +
                "ESTAMINA\r\n" +
                "Cada soco gasta 30 de estamina. Sem estamina suficiente o golpe\r\n" +
                "nao sai. Ela recarrega sozinha com o tempo, entao controle o ritmo.\r\n" +
                "\r\n" +
                "COMBO\r\n" +
                "Socos que acertam (quando o inimigo NAO esta bloqueando) somam combo.\r\n" +
                "  Combo 1 a 4   ->  5 de dano\r\n" +
                "  Combo 5 a 9   ->  7 de dano\r\n" +
                "  Combo 10+     ->  10 de dano\r\n" +
                "Errar o soco ou levar um golpe sem defesa QUEBRA o combo.\r\n" +
                "\r\n" +
                "DEFESA PERFEITA\r\n" +
                "Se voce bloquear ate 300ms antes do golpe inimigo acertar, alem de\r\n" +
                "nao levar dano voce ainda GANHA +1 de combo.\r\n" +
                "\r\n" +
                "FIM DE PARTIDA\r\n" +
                "Ao vencer ou perder, use o botao Restart na tela para jogar de novo.";

            Button ok = new Button();
            ok.Text = "COMECAR";
            ok.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            ok.BackColor = Color.Gold;
            ok.ForeColor = Color.Black;
            ok.FlatStyle = FlatStyle.Flat;
            ok.Size = new Size(180, 44);
            ok.Location = new Point((this.ClientSize.Width - 180) / 2, 455);
            ok.Click += (s, e) => this.Close();

            this.Controls.Add(titulo);
            this.Controls.Add(corpo);
            this.Controls.Add(ok);
            this.AcceptButton = ok;
        }
    }
}
