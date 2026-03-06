using Microsoft.EntityFrameworkCore;
using Royal_Games.Contexts;
using Royal_Games.Domains;
using Royal_Games.Interfaces;

namespace Royal_Games.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly Royal_GamesContext _context;

        public JogoRepository(Royal_GamesContext context)
        {
            _context = context;
        }

        public List<Jogo> Listar()
        {
            List<Jogo> jogos = _context.Jogo
                .Include(jogo => jogo.Genero)
                .Include(jogo => jogo.Plataforma)
                .Include(jogo => jogo.ClassificacaoIndicativa)
                .ToList();

            return jogos;
        }

        public Jogo ObterPorId(int Id)
        {
            Jogo? jogo = _context.Jogo
                .Include(jogo => jogo.Genero)
                .Include(jogo => jogo.JogoPromocao)
                .Include(jogo => jogo.Log_AlteracaoJogo)
                .Include(jogo => jogo.Plataforma)
                .Include(jogo => jogo.Usuario)
                .FirstOrDefault(jogoDB => jogoDB.JogoID == Id);

            return jogo!;
        }

        public bool JogoExiste(string nome, int? jogoIdAtual = null)
        {
            var jogoConsultado = _context.Jogo.AsQueryable();

            if (jogoIdAtual.HasValue)
            {
                jogoConsultado = jogoConsultado.Where(jogo => jogo.JogoID != jogoIdAtual.Value);
            }

            return jogoConsultado.Any(jogo => jogo.Nome == nome);
        }

        public byte[] ObterImagem(int Id)
        {
            var jogo = _context.Jogo
                .Where(jogo => jogo.JogoID == Id)
                .Select(jogo => jogo.Imagem)
                .FirstOrDefault();

            return jogo!;
        }

        public void Adicionar(Jogo jogo, List<int> GeneroID)
        {
            List<Genero> generos = _context.Genero
                .Where(genero => GeneroID.Contains(genero.GeneroID))
                .ToList();

            jogo.Genero = generos;

            _context.Jogo.Add(jogo);
            _context.SaveChanges();
        }

        public void Atualizar(Jogo jogo, List<int> GeneroID)
        {
            Jogo? jogoBanco = _context.Jogo
                .Include(jogo => jogo.Genero)
                .FirstOrDefault(jogoAux => jogo.JogoID == jogo.JogoID);

            if (jogoBanco == null)
            {
                return;
            }

            jogoBanco.Nome = jogo.Nome;
            jogoBanco.Preco = jogo.Preco;
            jogoBanco.Descricao = jogo.Descricao;

            if (jogo.Imagem != null && jogo.Imagem.Length > 0)
            {
                jogoBanco.Imagem = jogo.Imagem;
            }

            if (jogo.StatusJogo.HasValue)
            {
                jogoBanco.StatusJogo = jogo.StatusJogo;
            }

            var generos = _context.Genero
                .Where(genero => GeneroID.Contains(genero.GeneroID))
                .ToList();

            jogoBanco.Genero.Clear();

            foreach (var genero in generos) { jogoBanco.Genero.Add(genero); }

            _context.SaveChanges();
        }

        public void Remover(int Id)
        {
            Jogo? jogo = _context.Jogo.FirstOrDefault(jogo => jogo.JogoID == Id);

            if (jogo == null)
            {
                return;
            }

            _context.Jogo.Remove(jogo);
            _context.SaveChanges();
        }
    }
}