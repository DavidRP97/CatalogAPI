using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatalogAPI_BLL.Models;
using CatalogAPI_DAL.Context;
using CatalogAPI_DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using CatalogAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using CatalogAPI_DAL.Interfaces.Mongo;
using MongoDB.Bson;
using CatalogAPI_SERVICES.Interfaces;

namespace CatalogAPI.Controllers
{

    //[Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly IProductDA _productDa;
        private readonly IMapper _mapper;
        public ProductsController(IProductDA productDa, IMapper mapper, IProductServices productServices)
        {
            _mapper = mapper;
            _productDa = productDa;
            _productServices = productServices;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            try
            {
                //var prod = _mapper.Map<Product>(productDto);

                //var produtoDto = _mapper.Map<ProductDTO>(prod);

                await _productServices.SaveProduct(product);

                return new ObjectResult(product) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao inserir um produto");
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var produtos = await _productServices.GetProducts();

            return produtos;
        }

        //[HttpGet("{categoryId}")]
        //public async Task<IEnumerable<Product>> Get(int categoryId)
        //{
        //    return await _productDa.GetByCategoryId(categoryId);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(string id)
        {
            try
            {
                var prod = await _productServices.GetProductById(ObjectId.Parse(id));

                if (prod == null)
                {
                    return NotFound("Categoria não encontrada!");
                }

                await _productServices.DeleteProduct(ObjectId.Parse(id));

                return prod;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao excluir a categoria");
            }
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Put(int id, [FromBody] ProductCategoryDTO product)
        //{
        //    try
        //    {
        //        var prod = new Product();                

        //        prod.ProductId = product.ProductId;
        //        prod.CategoryId = product.CategoryIdDto;
        //        prod.Name = _productDa.GetProductName(id);

        //        if (id != product.ProductId)
        //        {
        //            return BadRequest();
        //        }

        //        await _productDa.Update(prod);

        //        return new ObjectResult(prod);
        //    }
        //    catch (Exception)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar produto");
        //    }
        //}

    }
}
