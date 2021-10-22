using AutoMapper;
using CatalogAPI.DTOs;
using CatalogAPI_BLL.Models;
using CatalogAPI_DAL.Context;
using CatalogAPI_DAL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CatalogAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesDA _categoriesDa;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoriesDA categoriesDa, IMapper mapper)
        {
            _mapper = mapper;
            _categoriesDa = categoriesDa;
        }        

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categories)
        {
            try
            {
                var cat = _mapper.Map<Categories>(categories);

                var produtoDto = _mapper.Map<CategoryDTO>(cat);

                await _categoriesDa.Insert(cat);

                return new ObjectResult(cat) { StatusCode = 200 };
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao inserir uma categoria");
            }
        }
        [HttpGet]
        public async Task<IEnumerable<Categories>> GetAll()
        {
            return await _categoriesDa.GetAll();
        }

        [HttpGet("Produtos")]
        public async Task<IEnumerable<Categories>> Get()
        {
            var ser = await _categoriesDa.GetWithProducts();

            return ser;
        }
        [HttpGet("{id}")]
        public async Task<Categories> Get(int id)
        {
            return await _categoriesDa.GetById(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categories categories)
        {
            try
            {
                if (id != categories.CategoryId)
                {
                    return BadRequest();
                }

                await _categoriesDa.Update(categories);

                return new ObjectResult(categories);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao atualizar a categoria");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categories>> Delete(int id)
        {
            try
            {
                var cat = await _categoriesDa.GetById(id);

                if (cat == null)
                {
                    return NotFound("Categoria não encontrada!");
                }

                await _categoriesDa.Delete(id);

                return cat;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao excluir a categoria");
            }
        }

    }
}
