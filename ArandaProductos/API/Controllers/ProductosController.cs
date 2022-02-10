using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transversal.Common;
using Transversal.Common.Parameters;
using X.PagedList;

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

            try
            {
                var response = productosApplication.AddValidation(productoDto);
                return StatusCode(response.StatusCode, response);
                //if (response.IsSuccess)
                //    return Ok(response);
                //return BadRequest(response.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response<bool>
                {
                    Code = "500",
                    Message = "Error no controlado",
                    Result = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("~/Productos/GuardarAsync")]
        public async Task<IActionResult> GuardarAsync([FromBody] ProductosDto productoDto)
        {
            Response<List<Error>> errores = await productosApplication.ValidateObjetc(productoDto);
            if (!errores.IsSuccess)
                return StatusCode(errores.StatusCode, errores);

            try
            {
                var response = await productosApplication.AddAsync(productoDto);
                return StatusCode(response.StatusCode, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response<bool>
                {
                    Code = "500",
                    Message = "Error no controlado",
                    Result = ex.Message
                });
            }
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

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await productosApplication.DeleteAsync(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet(Name = "GetProductos")]
        public IActionResult Get(string filter, string orderby, string size, string page)
        {
            var response = productosApplication.GetProducts(filter, orderby);
            int pageSize = (string.IsNullOrEmpty(size)) ? 1 : int.Parse(size);
            int pageNumber = (string.IsNullOrEmpty(page)) ? 1 : int.Parse(page);
            var dataPage = response.Data.ToList().ToPagedList(pageNumber, pageSize);
            return Ok(dataPage);
        }

        [HttpGet(Name = "GetProductosQuery")]
        public IActionResult GetQuery([FromQuery] ProductsParameters productsParameters)
        {
            var response = productosApplication.GetProductsFilters(productsParameters);
            var dataPage = response.Data.ToList().ToPagedList(productsParameters.Page, productsParameters.Size);
            return Ok(dataPage);
        }
    }
}
