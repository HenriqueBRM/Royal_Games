using Royal_Games.Domains;
using Royal_Games.DTOs.JogoDto;


namespace Royal_Games.Applications.Conversoes
{
    public class JogoParaDto
    {
        public static LerJogoDto ConverterParaDto(Jogo jogo)
        {
            return new LerJogoDto
            {
                JogoID = jogo.JogoID,
                Nome = jogo.Nome,
                Preco = jogo.Preco,
                Descricao = jogo.Descricao,
                StatusJogo = jogo.StatusJogo,

                // EXTREMAMENTE NECESSÁRIO FAZER COMO NO EXEMPLO COMENTADO ABAIXO DO VH_BURGUER COM GENERO, JOGOPROMOCAO, LOG_ALTERACAOJOGO E PLATAFORMA.

                /*CategoriaIds = jogo.Categoria.Select(categoria => categoria.CategoriaId).ToList(),
                Categorias = jogo.Categoria.Select(categoria => categoria.Nome).ToList(),*/

                UsuarioID = jogo.UsuarioID,
                UsuarioNome = jogo.Usuario!.Nome,
                UsuarioEmail = jogo.Usuario.Email
            };
        }
    }
}