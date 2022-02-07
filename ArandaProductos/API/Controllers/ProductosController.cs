using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductosController : Controller
    {
        private readonly IProductosApplication productosApplication;

        public ProductosController(IProductosApplication productosApplication)
        {
            this.productosApplication = productosApplication;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            var response = productosApplication.GetProductos();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPost]
        public IActionResult Guardar([FromBody] ProductosDto productoDto)
        {
            if (productoDto == null)
                return BadRequest();

            var response = productosApplication.Add(productoDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductosDto productoDto)
        {
            if (productoDto == null)
                return BadRequest();

            var response = await productosApplication.UpdateAsync(productoDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        //Debemos indicar el nombre del parametro
        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(int id)
        {
            //if (string.IsNullOrEmpty(id))
            //    return BadRequest();
            //TODO Validar que no sean letras

            var response = await productosApplication.DeleteAsync(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("{productoId}")]
        public async Task<IActionResult> Get(int id)
        {
            //if (id ==null)
            //    return BadRequest();
            //TODO Validar que no sean letras

            var response = await productosApplication.GetAsync(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
