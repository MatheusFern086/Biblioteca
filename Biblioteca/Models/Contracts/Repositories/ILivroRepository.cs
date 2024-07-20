using Biblioteca.Models.Dtos;

namespace Biblioteca.Models.Contracts.Repositories
{
    public interface ILivroRepository
    {
        List<LivroDto> Listar();
    }
}
