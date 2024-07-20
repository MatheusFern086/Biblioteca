using Biblioteca.Models.Dtos;

namespace Biblioteca.Models.Contracts.Contexts
{
    public interface IContextData
    {
        void CadastrarLivro(LivroDto livro);
        List<LivroDto> ListarLivro();
        LivroDto PesquisarLivroPorId(string id);
        void AtualizarLivro(LivroDto livro);
        void ExcluirLivro(string id);
    }
}
