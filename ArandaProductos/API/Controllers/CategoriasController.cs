using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoriasController : Controller
    {
        private readonly ICategoriasApplication categoriasApplication;

        public CategoriasController(ICategoriasApplication categoriasApplication)
        {
            this.categoriasApplication = categoriasApplication;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult Get()
        {
            var response = categoriasApplication.GetCategoriasProductos();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
