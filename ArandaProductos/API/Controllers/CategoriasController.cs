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
        public IActionResult Get(string orderby)
        { 
            var response = categoriasApplication.GetCategorias(orderby);
             
            int pageSize = 2;
            var pageNumber = 2; 
            var dataPage  = response.Data.ToList().ToPagedList(pageNumber, pageSize); 
            return Ok(dataPage); 
        }
         
    }
}
