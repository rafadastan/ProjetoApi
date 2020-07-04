using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using Projeto.Presentation.Api.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [Authorize]
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ProdutoCadastroModel model,
            [FromServices] IProdutoRepository produtoRepository)
        {
            try
            {
                var produto = new Produto();
                produto.Nome = model.Nome;
                produto.Preco = decimal.Parse(model.Preco);
                produto.Quantidade = int.Parse(model.Quantidade);
                produto.IdFornecedor = int.Parse(model.IdFornecedor);

                produtoRepository.insert(produto);

                return Ok("Produto cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ProdutoEdicaoModel model,
            [FromServices] IProdutoRepository produtoRepository)
        {
            try
            {
                var produto = new Produto();
                produto.IdProduto = model.IdProduto;
                produto.Nome = model.Nome;
                produto.Preco = decimal.Parse(model.Preco);
                produto.Quantidade = int.Parse(model.Quantidade);
                produto.IdFornecedor = int.Parse(model.IdFornecedor);

                produtoRepository.Update(produto);

                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IProdutoRepository produtoRepository)
        {
            try
            {
                var produto = produtoRepository.GetById(id);
                produtoRepository.Delete(produto);

                return Ok("Produto excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet] //consulta
        public IActionResult Get([FromServices] IProdutoRepository produtoRepository)
        {
            try
            {
                return Ok(produtoRepository.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")] //consulta
        public IActionResult Get(int id,
            [FromServices] IProdutoRepository produtoRepository)
        {
            try
            {
                return Ok(produtoRepository.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}