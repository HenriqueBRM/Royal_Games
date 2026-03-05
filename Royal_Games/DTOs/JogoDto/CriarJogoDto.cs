namespace Royal_Games.DTOs.JogoDto
{
    public class CriarJogoDto
    {
        public string Nome { get; set; } = null!;
        public decimal Preco { get; set; }
        public string Descricao { get; set; } = null!;
        public IFormFile Imagem { get; set; } = null!;
        public List<int>? GeneroID { get; set; }
        public List<int>? JogoPromocaoID { get; set; }
        public List<int>? Log_AlteracaoJogoID { get; set; }
        public List<int>? PlataformaID { get; set; }
    }
}