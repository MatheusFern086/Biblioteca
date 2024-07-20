namespace Biblioteca.Models.Entidades
{
    public abstract class EntidadeBase
    {
        public string Id { get; set; }

        public EntidadeBase()
        {
            //Guid gera um código
            Id = Guid.NewGuid().ToString();
        }
    }
}
