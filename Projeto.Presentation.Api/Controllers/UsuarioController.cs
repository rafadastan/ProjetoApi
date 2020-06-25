using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.CrossCutting.Cryptography;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using Projeto.Presentation.Api.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public string MD5Encrypt { get; private set; }

        [HttpPost]
        public IActionResult Post(UsuarioCadastroModel model,
            [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                if (usuarioRepository.Get(model.Email) != null)
                    return BadRequest("Erro. O email informado já encontra-se cadastrado.");

                var usuario = new Usuario();
                usuario.Nome = model.Nome;
                usuario.Email = model.Email;
                usuario.Senha = MD5Service.Encrypt(model.Senha);

                usuarioRepository.insert(usuario);

                return Ok("Usuário cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                //retornar 500 da api cai no error
                return StatusCode(500, e.Message);
            }
        }
    }
}