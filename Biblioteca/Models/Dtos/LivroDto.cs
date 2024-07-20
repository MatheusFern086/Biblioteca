using Biblioteca.Models.Entidades;
using Microsoft.AspNetCore.Components.Forms;

namespace Biblioteca.Models.Dtos
{
    public class LivroDto : EntidadeBase
    {
        public String Nome { get; set; }
        public String Autor { get; set; }
        public String Editora { get; set; }

        public LivroDto() 
        {
        
        }

        public LivroDto(string id, string nome, string autor, string editora)
            : this(nome, autor, editora)
        {
            this.Id = id;
        }

        public LivroDto(string nome, string autor, string editora)
        {
            this.Nome = nome;
            this.Autor = autor;
            this.Editora = editora;
        }
    }
}
