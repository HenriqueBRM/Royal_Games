using Royal_Games.Domains;

namespace Royal_Games.Interfaces
{
    public interface IJogoRepository
    {
        List<Jogo> Listar();
        Jogo ObterPorId(int Id);
        byte[] ObterImagem(int Id);
        bool JogoExiste(string nome, int? jogoIdAtual = null);

        void Adicionar(Jogo jogo, List<int>? GeneroID);
        void Atualizar(Jogo jogo, List<int>? GeneroID);
        void Remover(int Id);
    }
}