using Biblioteca.Models.Contracts.Repositories;
using Biblioteca.Models.Dtos;

namespace Biblioteca.Models.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        public List<LivroDto> Listar()
        {
            var livros = ContextDataFake.Livros;
            return livros
                .OrderBy(x => x.Nome)
                .ToList();
        }
    }
}
