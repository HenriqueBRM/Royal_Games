using Royal_Games.Domains;

namespace Royal_Games.Interfaces
{
    public interface IJogoRepository
    {
        List<Jogo> Listar();
        Jogo ObterPorId(int Id);
        byte[] ObterImagem(int Id);
        bool JogoExiste(string nome, int? jogoIdAtual = null);

        void Adicionar(Jogo jogo, List<int>? GeneroID, List<int> Log_AlteracaoJogoID, List<int> PlataformaID);
        void Adicionar(Jogo jogo, List<int>? generoID);
        void Atualizar(Jogo jogo, List<int>? GeneroID, List<int> Log_AlteracaoJogoID, List<int> PlataformaID);
        void Atualizar(Jogo jogoBanco, List<int>? generoID);
        void Remover(int Id);
    }
}