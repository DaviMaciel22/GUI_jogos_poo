using System.Drawing;
using System.Windows.Forms;

namespace Simple_Punch_Out_Game_MOO_ICT
{
    /// <summary>
    /// Tela de seleção de cenário (fundo + inimigo).
    /// </summary>
    public class ScenarioForm : Form
    {
        private readonly List<Cenario> cenarios = Cenario.Todos();

        /// <summary>Cenário escolhido pelo jogador.</summary>
        public Cenario CenarioSelecionado { get; private set; }

        public ScenarioForm(Cenario? atual = null)
        {
            CenarioSelecionado = atual ?? cenarios[0];

            Text = "Escolha o Cenário";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(760, 520);
            BackColor = Color.FromArgb(18, 18, 22);
            ForeColor = Color.Gainsboro;
            KeyPreview = true;

            Label titulo = new Label
            {
                Text = "ESCOLHA O CENÁRIO",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = Color.Gold,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 55
            };

            Label subtitulo = new Label
            {
                Text = "Cada cenário tem seu próprio ringue e seu próprio adversário.",
                Font = new Font("Segoe UI", 10F),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 28
            };

            TableLayoutPanel grid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                Padding = new Padding(20, 10, 20, 10)
            };
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 50));

            foreach (Cenario c in cenarios)
            {
                grid.Controls.Add(CriarCartao(c));
            }

            Button fechar = new Button
            {
                Text = "Jogar neste cenário",
                Dock = DockStyle.Bottom,
                Height = 46,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Gold,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };
            fechar.Click += (s, e) => { DialogResult = DialogResult.OK; Close(); };

            Controls.Add(grid);
            Controls.Add(fechar);
            Controls.Add(subtitulo);
            Controls.Add(titulo);

            AcceptButton = fechar;
        }

        private Control CriarCartao(Cenario c)
        {
            Panel painel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                BackColor = Color.FromArgb(30, 30, 36),
                Padding = new Padding(3),
                Cursor = Cursors.Hand,
                Tag = c
            };

            PictureBox preview = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = c.Fundo,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand
            };

            PictureBox inimigo = new PictureBox
            {
                Image = c.EnemyStand,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Size = new Size(70, 110),
                Location = new Point(15, 15),
                Parent = preview,
                Cursor = Cursors.Hand
            };

            Label nome = new Label
            {
                Text = c.Nome + "  •  " + c.NomeInimigo,
                Dock = DockStyle.Bottom,
                Height = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(30, 30, 36),
                ForeColor = Color.Gainsboro,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            painel.Controls.Add(preview);
            preview.Controls.Add(inimigo);
            painel.Controls.Add(nome);

            void Selecionar(object? s, EventArgs e)
            {
                CenarioSelecionado = c;
                AtualizarDestaques();
            }

            painel.Click += Selecionar;
            preview.Click += Selecionar;
            inimigo.Click += Selecionar;
            nome.Click += Selecionar;

            void Confirmar(object? s, EventArgs e)
            {
                CenarioSelecionado = c;
                DialogResult = DialogResult.OK;
                Close();
            }

            preview.DoubleClick += Confirmar;
            inimigo.DoubleClick += Confirmar;
            nome.DoubleClick += Confirmar;

            return painel;
        }

        private void AtualizarDestaques()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TableLayoutPanel grid)
                {
                    foreach (Control card in grid.Controls)
                    {
                        bool selecionado = ReferenceEquals(card.Tag, CenarioSelecionado);
                        card.BackColor = selecionado ? Color.Gold : Color.FromArgb(30, 30, 36);
                        foreach (Control filho in card.Controls)
                        {
                            if (filho is Label lbl)
                            {
                                lbl.BackColor = selecionado ? Color.Gold : Color.FromArgb(30, 30, 36);
                                lbl.ForeColor = selecionado ? Color.Black : Color.Gainsboro;
                            }
                        }
                    }
                }
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            AtualizarDestaques();
        }
    }
}
