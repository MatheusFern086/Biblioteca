using Biblioteca.Models.Contracts.Repositories;
using Biblioteca.Models.Dtos;
using Biblioteca.Models.Services;

namespace Biblioteca.Models.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        public void Atualizar(LivroDto livro)
        {
            var objPesquisa = PesquisarPorId(livro.Id);
            ContextDataFake.Livros.Remove(objPesquisa);

            objPesquisa.Nome = livro.Nome;
            objPesquisa.Editora = livro.Editora;
            objPesquisa.Autor = livro.Autor;

            Cadastrar(objPesquisa);
        }

        public void Cadastrar(LivroDto livro)
        {
            ContextDataFake.Livros.Add(livro);
        }

        public void Excluir(string id)
        {
            var objPesquisa = PesquisarPorId(id);
            ContextDataFake.Livros.Remove(objPesquisa);
        }

        public List<LivroDto> Listar()
        {
            var livros = ContextDataFake.Livros;
            return livros
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public LivroDto PesquisarPorId(string id)
        {
            return ContextDataFake.Livros.FirstOrDefault(x => x.Id == id);
        }
    }
}
