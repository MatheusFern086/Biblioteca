using Biblioteca.Models.Dtos;

namespace Biblioteca.Models.Contracts.Repositories
{
    public interface ILivroRepository
    {
        void Cadastrar(LivroDto livro);
        List<LivroDto> Listar();
        LivroDto PesquisarPorId(string id);
        void Atualizar(LivroDto livro);
        void Excluir(string id);
    }
}
