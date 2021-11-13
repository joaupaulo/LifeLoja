using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeLoja.Entidades;
using LifeLoja.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeLoja.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosAPI : ControllerBase
    {
        private readonly ProdutosService _produtoRepository;

        public ProdutosAPI(ProdutosService produtoRepository)
        {
            _produtoRepository = produtoRepository;

        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Produtos>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProducts()
        {
            var products = await _produtoRepository.GetProduto();

            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Produtos), StatusCodes.Status200OK)]
        public async Task<ActionResult<Produtos>> GetProductById(string id)
        {
            var product = await _produtoRepository.GetProdut(id);

            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Produtos>))]
        public async Task<ActionResult<IEnumerable<Produtos>>> GetProductByCategory(string category)
        {
            if (category is null)
            {
                return BadRequest("Invalid category");
            }

            var products = await _produtoRepository.GetProductByCategory(category);

            return Ok(products);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Produtos), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Produtos>> CreateProduto([FromBody] Produtos produto)
        {
            if (produto is null)
            {
                return BadRequest("Produto Invalido");
            }

             await _produtoRepository.CreateProduct(produto);



            return CreatedAtRoute("GetProduct", new { id = produto.Id }, produto);
        }


        [HttpPut]
        [ProducesResponseType(typeof(Produtos), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduto([FromBody] Produtos produto)
        {
            if (produto is null)
            {
                return BadRequest("Produto invalido");
            }

            return Ok(await _produtoRepository.UpdateProduct(produto));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteProduct")]
        [ProducesResponseType(typeof(Produtos), StatusCodes.Status200OK)]

        public async Task<IActionResult> DeleteProductId(string id)
        {
            return Ok(await _produtoRepository.DeleteProduct(id));
        }

    }
}
