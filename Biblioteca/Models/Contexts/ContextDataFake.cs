using Biblioteca.Models.Contracts.Contexts;
using Biblioteca.Models.Dtos;

namespace Biblioteca.Models.Contexts
{
    public class ContextDataFake : IContextData
    {
        private static List<LivroDto> livros;

        public ContextDataFake()
        {
            livros = new List<LivroDto>();
            InitializeData();
        }

        public void AtualizarLivro(LivroDto livro)
        {
            try
            {
                var objPesquisa = PesquisarLivroPorId(livro.Id);
                livros.Remove(objPesquisa);

                objPesquisa.Nome = livro.Nome;
                objPesquisa.Editora = livro.Editora;
                objPesquisa.Autor = livro.Autor;

                CadastrarLivro(objPesquisa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CadastrarLivro(LivroDto livro)
        {
            try
            {
                livros.Add(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirLivro(string id)
        {
            try
            {
                var objPesquisa = PesquisarLivroPorId(id);
                livros.Remove(objPesquisa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LivroDto> ListarLivro()
        {
            try
            {
                return livros
                    .OrderBy(x => x.Nome)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LivroDto PesquisarLivroPorId(string id)
        {
            try
            {
                return livros.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InitializeData()
        {
            var livro = new LivroDto("Implementando Domain-Driven Design", "Vaugh Vermon", "Alta Books");
            livros.Add(livro);

            livro = new LivroDto("Domain-Driven Design", "Erick Evans", "Alta Books");
            livros.Add(livro);

            livro = new LivroDto("Redes Guia Prático", "Carlos E. Marimoto", "Sul Editores");
            livros.Add(livro);

            livro = new LivroDto("PHP Programando com POO", "Pablo Dall 'Ogllio", "Novatec");
            livros.Add(livro);

            livro = new LivroDto("Introdução a Programação em Python", "Nilo N. C. Menezes", "Novatec");
            livros.Add(livro);
        }
    }
}
