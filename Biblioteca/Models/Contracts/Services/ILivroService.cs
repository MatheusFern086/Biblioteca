using Biblioteca.Models.Dtos;

namespace Biblioteca.Models.Contracts.Services
{
    public interface ILivroService
    {
        List<LivroDto> Listar();
    }
}
