namespace Royal_Games.DTOs.JogoDto
{
    public class LerJogoDto
    {
        public int JogoID { get; set; }
        public string Nome { get; set; } = null!;
        public decimal Preco { get; set; }
        public string Descricao { get; set; } = null!;
        public bool? StatusJogo { get; set; }

        // Gênero
        public List<int> GeneroID { get; set; } = new();
        public List<string> Generos { get; set; } = new();

        // Jogo Promoção
        public List<int> JogoPromocaoID { get; set; } = new();
        public List<string> JogoPromocoes { get; set; } = new();

        // Log Alteração
        public List<int> Log_AlteracaoJogoID { get; set; } = new();
        public List<string> Log_Alteracoes { get; set; } = new();

        // Plataforma
        public List<int> PlataformaID { get; set; } = new();
        public List<string> Plataformas { get; set; } = new();

        // Usuário
        public int? UsuarioID { get; set; }
        public string? UsuarioNome { get; set; }
        public string? UsuarioEmail { get; set; }
    }
}