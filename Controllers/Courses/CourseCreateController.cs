using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesempeno.Data;
using PruebaDesempeno.Models;
using Microsoft.AspNetCore.Mvc;
using PruebaDesempeno.Services;

namespace PruebaDesempeno.Controllers{
    public class CourseCreateController : ControllerBase{
        private readonly ICourseRepository _courseRepository;
        public CourseCreateController(ICourseRepository courseRepository){
            _courseRepository = courseRepository;
        }


        [HttpPost]
        [Route("api/courses")]
        public IActionResult Create([FromBody] Course course){
            try{
                _courseRepository.CreateCourse(course);
                return Ok("El curso se creó correctamente");
            }
            catch (System.Exception)
            {   
                return BadRequest("El curso no pudo crearse");
            }

        }

    

    }
}