using System;
using Business.Abstract;
using Entity.Abstract;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AbcController : ControllerBase
	{
        private IProductService _productservice;
        public AbcController(IProductService productService)
        {
            _productservice = productService;
        }

        [HttpGet("getProductList")]
        public async Task<IActionResult> GetProductList()
        {
            return Ok(await _productservice.GetList());
        }

        [HttpGet("getFilteredProductList")]
        public async Task<IActionResult> GetFilteredProductList([FromBody] FilteredProductInput filteredProductInput)
        {
            return Ok(await _productservice.GetFilteredProductList(filteredProductInput));
        }

    }
}

