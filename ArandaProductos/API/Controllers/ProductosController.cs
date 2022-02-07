﻿using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;

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

            var response = productosApplication.Guardar(productoDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}