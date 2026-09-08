using System.Drawing;

namespace Simple_Punch_Out_Game_MOO_ICT
{
    /// <summary>
    /// Representa um cenário do jogo: imagem de fundo + sprites do inimigo daquele cenário.
    /// </summary>
    public class Cenario
    {
        public string Nome { get; set; } = "";
        public string NomeInimigo { get; set; } = "";
        public Image Fundo { get; set; } = null!;
        public Image EnemyStand { get; set; } = null!;
        public Image EnemyPunch1 { get; set; } = null!;
        public Image EnemyPunch2 { get; set; } = null!;
        public Image EnemyBlock { get; set; } = null!;

        /// <summary>
        /// Lista de todos os cenários disponíveis para escolha.
        /// </summary>
        public static List<Cenario> Todos()
        {
            return new List<Cenario>
            {
                new Cenario
                {
                    Nome = "Ringue Clássico",
                    NomeInimigo = "Tough Rob",
                    Fundo = Properties.Resources.background,
                    EnemyStand = Properties.Resources.enemy_stand,
                    EnemyPunch1 = Properties.Resources.enemy_punch1,
                    EnemyPunch2 = Properties.Resources.enemy_punch2,
                    EnemyBlock = Properties.Resources.enemy_block
                },
                new Cenario
                {
                    Nome = "Arena Alternativa",
                    NomeInimigo = "Tough Rob",
                    Fundo = Properties.Resources.background2_enemy1,
                    EnemyStand = Properties.Resources.enemy_stand,
                    EnemyPunch1 = Properties.Resources.enemy_punch1,
                    EnemyPunch2 = Properties.Resources.enemy_punch2,
                    EnemyBlock = Properties.Resources.enemy_block
                },
                new Cenario
                {
                    Nome = "Ringue do Desafiante",
                    NomeInimigo = "Enemy 2",
                    Fundo = Properties.Resources.background_enemy2,
                    EnemyStand = Properties.Resources.enemy2_stand,
                    EnemyPunch1 = Properties.Resources.enemy2_punch1,
                    EnemyPunch2 = Properties.Resources.enemy2_punch2,
                    EnemyBlock = Properties.Resources.enemy2_block
                },
                new Cenario
                {
                    Nome = "Arena do Desafiante",
                    NomeInimigo = "Enemy 2",
                    Fundo = Properties.Resources.background2_enemy2,
                    EnemyStand = Properties.Resources.enemy2_stand,
                    EnemyPunch1 = Properties.Resources.enemy2_punch1,
                    EnemyPunch2 = Properties.Resources.enemy2_punch2,
                    EnemyBlock = Properties.Resources.enemy2_block
                }
            };
        }
    }
}
