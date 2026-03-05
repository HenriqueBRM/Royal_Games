namespace Royal_Games.DTOs.JogoDto
{
    public class AtualizarJogoDto
    {
        public string Nome { get; set; } = null!;
        public decimal Preco { get; set; }
        public string Descricao { get; set; } = null!;
        public IFormFile Imagem { get; set; } = null!;
        public List<int>? GeneroID { get; set; } = new();
        public List<int>? JogoPromocaoID { get; set; } = new();
        public List<int>? Log_AlteracaoJogoID { get; set; } = new();
        public List<int>? PlataformaID { get; set; } = new();
        public bool? StatusJogo { get; set; }
    }
}