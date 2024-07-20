using Biblioteca.Models.Contracts.Contexts;
using Biblioteca.Models.Contracts.Repositories;
using Biblioteca.Models.Dtos;
using Biblioteca.Models.Services;

namespace Biblioteca.Models.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly IContextData _contextData;

        public LivroRepository(IContextData contextData)
        {
            _contextData = contextData;
        }

        public void Atualizar(LivroDto livro)
        {
            _contextData.AtualizarLivro(livro);
        }

        public void Cadastrar(LivroDto livro)
        {
            _contextData.CadastrarLivro(livro);
        }

        public void Excluir(string id)
        {
            _contextData.ExcluirLivro(id);
        }

        public List<LivroDto> Listar()
        {
            return _contextData.ListarLivro();
        }

        public LivroDto PesquisarPorId(string id)
        {
            return _contextData.PesquisarLivroPorId(id);
        }
    }
}
