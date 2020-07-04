using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using Projeto.Presentation.Api.Models;
using System;

namespace Projeto.Presentation.Api.Controllers
{
    [Authorize]
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(FornecedorCadastroModel model,
           [FromServices] IFornecedorRepository fornecedorRepository)
        {
            try
            {
                var fornecedor = new Fornecedor();
                fornecedor.Nome = model.Nome;
                fornecedor.Cnpj = model.Cnpj;

                fornecedorRepository.insert(fornecedor);

                return Ok("Fornecedor cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(FornecedorEdicaoModel model,
            [FromServices] IFornecedorRepository fornecedorRepository)
        {
            try
            {
                var fornecedor = new Fornecedor();
                fornecedor.IdFornecedor = model.IdFornecedor;
                fornecedor.Nome = model.Nome;
                fornecedor.Cnpj = model.Cnpj;

                fornecedorRepository.Update(fornecedor);

                return Ok("Fornecedor atualizado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id,
            [FromServices] IFornecedorRepository fornecedorRepository)
        {
            try
            {
                var fornecedor = fornecedorRepository.GetById(id);

                fornecedorRepository.Delete(fornecedor);

                return Ok("Fornecedor excluído com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get([FromServices] IFornecedorRepository fornecedorRepository)
        {
            try
            {
                return Ok(fornecedorRepository.GetAll());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id,
            [FromServices] IFornecedorRepository fornecedorRepository)
        {
            try
            {
                return Ok(fornecedorRepository.GetById(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}