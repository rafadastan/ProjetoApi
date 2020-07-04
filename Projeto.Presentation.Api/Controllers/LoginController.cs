using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.CrossCutting.Cryptography;
using Projeto.Infra.Data.Contracts;
using Projeto.Presentation.Api.Configurations;
using Projeto.Presentation.Api.Models;

namespace Projeto.Presentation.Api.Controllers
{
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(LoginModel model,
            [FromServices] IUsuarioRepository usuarioRepository,
            [FromServices] TokenService tokenService)
        {
            try
            {
                if (usuarioRepository.Get(model.Email, MD5Service.Encrypt(model.Senha)) != null)
                {
                    var token = tokenService.GenerateToken(model.Email);
                    return Ok(token); 
                }
                else
                {
                    return StatusCode(403,"Acesso negado. Usuário não foi encontrado.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}