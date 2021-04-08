using course.api.Models;
using course.api.Models.Courses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace course.api.Controllers
{
    [Route("api/v1/courses")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        [SwaggerResponse(statusCode: 200, description: "SUCESSO ao obter os CURSOS!", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "NÃO AUTORIZADO!", Type = typeof(ValidaCampoViewModel))]
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Post(CourseViewModelInput courseViewModelInput)
        {
            //var codeUser = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            return Created("", courseViewModelInput);
        }


        [SwaggerResponse(statusCode: 200, description: "SUCESSO ao obter os CURSOS!", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "NÃO AUTORIZADO!", Type = typeof(ValidaCampoViewModel))]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var codeUser = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var courses = new List<CourseViewModelOutput>();
            courses.Add(new CourseViewModelOutput()
            {
                //Login = codeUser.ToString(),
                Login = "1",
                Description = "1st Course",
                Name = "Course 101"

            });

            return Ok(courses);
        }

    }
}
