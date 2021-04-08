using course.api.Filters;
using course.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace course.api.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [SwaggerResponse(statusCode: 200, description: "SUCESSO na Autenticação!", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos OBRIGATÓRIOS!", Type = typeof(ValidaCampoViewModel))]
        [SwaggerResponse(statusCode: 500, description: "ERRO na Autenticação!", Type = typeof(ValidaCampoViewModel))]
        [HttpPost]
        [Route("login")]
        [ValidacaoModelStateCustom]
        public IActionResult Logmein(LoginViewModelInput loginViewModelInput)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new ValidaCampoViewModelOutput(ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage)));
            //}

            return Ok(loginViewModelInput);
        }

        [SwaggerResponse(statusCode: 200, description: "SUCESSO no Registro!", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos OBRIGATÓRIOS!", Type = typeof(ValidaCampoViewModel))]
        [SwaggerResponse(statusCode: 500, description: "ERRO no Registro!", Type = typeof(ValidaCampoViewModel))]
        [HttpPost]
        [Route("register")]
        [ValidacaoModelStateCustom]
        public IActionResult Register(RegisterViewModelInput registerViewModelInput)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new ValidaCampoViewModelOutput(ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage)));
            //}

            return Created("", registerViewModelInput);
        }
    }
}
