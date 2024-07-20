using Biblioteca.Models.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _livroService;
        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            try
            {
                var livros = _livroService.Listar();
                return View(livros);
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
