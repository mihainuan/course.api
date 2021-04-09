using course.api.Business.Entities;
using course.api.Business.Repositories;
using course.api.Configuratioins;
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
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        /// <summary>
        /// Método API para criar CURSOS
        /// </summary>
        /// <param name="courseViewModelInput"></param>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "SUCESSO ao obter os CURSOS!", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "NÃO AUTORIZADO!", Type = typeof(ValidaCampoViewModel))]
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Post(CourseViewModelInput courseViewModelInput)
        {
            Course course = new Course();
            course.Name = courseViewModelInput.Name;
            course.Description = courseViewModelInput.Description;
            var IdUser = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            course.UserId = IdUser;

            _courseRepository.Add(course);
            _courseRepository.Commit();
            
            return Created("", courseViewModelInput);
        }

        /// <summary>
        /// Método API para listar CURSOS
        /// </summary>
        /// <returns></returns>
        [SwaggerResponse(statusCode: 200, description: "SUCESSO ao obter os CURSOS!", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 401, description: "NÃO AUTORIZADO!", Type = typeof(ValidaCampoViewModel))]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var IdUser = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var courses = new List<CourseViewModelOutput>();

            _courseRepository.ObterCursoPorUsuario(IdUser)
                .Select(s => new CourseViewModelOutput()
                {
                    Name = s.Name,
                    Description = s.Description,
                    Login = s.User.Login
                });

            return Ok(courses);
        }

    }
}
