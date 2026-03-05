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

                GeneroID = jogo.Genero.Select(genero => genero.GeneroID).ToList(),
                Generos = jogo.Genero.Select(genero => genero.Nome).ToList(),

                PlataformaID = jogo.Plataforma.Select(plataforma => plataforma.PlataformaID).ToList(),
                Plataformas = jogo.Plataforma.Select(plataforma => plataforma.Nome).ToList(),

                UsuarioID = jogo.UsuarioID,
                UsuarioNome = jogo.Usuario!.Nome,
                UsuarioEmail = jogo.Usuario.Email
            };
        }
    }
}