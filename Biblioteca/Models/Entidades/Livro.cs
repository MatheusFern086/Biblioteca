using Biblioteca.Models.Enum;

namespace Biblioteca.Models.Entidades
{
    public class Livro: EntidadeBase
    {
        public String Nome { get; set; }
        public String Autor { get; set; }
        public String Editora { get; set; }
        public StatusLivro StatusLivro {  get; set; } 
    }
}
