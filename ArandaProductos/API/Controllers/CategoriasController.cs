using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Transversal.Common.Parameters;
using X.PagedList;

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

        [HttpGet(Name = "GetCategories")]
        public IActionResult Get(string orderby, string size, string page)
        {
            var response = categoriasApplication.GetCategorias(orderby);
            int pageSize = (string.IsNullOrEmpty(size)) ? 1 : int.Parse(size);
            int pageNumber = (string.IsNullOrEmpty(page)) ? 1 : int.Parse(page);
            var dataPage = response.Data.ToList().ToPagedList(pageNumber, pageSize);
            return Ok(dataPage);
        }

    }
}
