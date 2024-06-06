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
    public class CourseUpdateController : ControllerBase{
        private readonly ICourseRepository _courseRepository;
        public CourseUpdateController(ICourseRepository courseRepository){
            _courseRepository = courseRepository;
        }

        [HttpPut]
        [Route("api/courses/{id}")]
        public IActionResult Update([FromBody] Course course){
            try
            {
                _courseRepository.UpdateCourse(course);
                return Ok("Los datos del curso se actualizaron correctamente");

            }
            catch (System.Exception)
            {   
                return BadRequest("Los datos del curso no pudieron actualizarse");
            }
        }

        
    

    }
}