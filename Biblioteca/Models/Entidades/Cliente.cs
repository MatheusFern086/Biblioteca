using Biblioteca.Models.Enum;

namespace Biblioteca.Models.Entidades
{
    public class Cliente:EntidadeBase
    {
        public String Nome { get; set; }
        public String CPF { get; set; }
        public String Email { get; set; }
        public StatusCliente StatusCliente { get; set; }
    }
}
