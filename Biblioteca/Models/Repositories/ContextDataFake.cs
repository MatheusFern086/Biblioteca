using Biblioteca.Models.Dtos;

namespace Biblioteca.Models.Repositories
{
    public static class ContextDataFake
    {
        public static List<LivroDto> Livros;

        static ContextDataFake()
        {
            Livros = new List<LivroDto>();
            InitializeData();
        }

        private static void InitializeData()
        {
            var livro = new LivroDto("Implementando Domain-Driven Design", "Vaugh Vermon", "Alta Books");
            Livros.Add(livro);

            livro = new LivroDto("Domain-Driven Design", "Erick Evans", "Alta Books");
            Livros.Add(livro);

            livro = new LivroDto("Redes Guia Prático", "Carlos E. Marimoto", "Sul Editores");
            Livros.Add(livro);

            livro = new LivroDto("PHP Programando com POO", "Pablo Dall 'Ogllio", "Novatec");
            Livros.Add(livro);

            livro = new LivroDto("Introdução a Programação em Python", "Nilo N. C. Menezes", "Novatec");
            Livros.Add(livro);

        }
    }
}
