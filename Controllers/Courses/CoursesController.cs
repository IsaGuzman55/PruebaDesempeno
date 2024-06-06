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
    public class CoursesController : ControllerBase{
        private readonly ICourseRepository _courseRepository;
        public CoursesController(ICourseRepository courseRepository){
            _courseRepository = courseRepository;
        }

        /* Listar cursos */
        [HttpGet, Route("api/courses")]
        public IActionResult GetCourses(){
            var searchCourses = _courseRepository.GetAll();
            if(!searchCourses.Any()){
                return Ok(new {message = "No hay cursos registradas"});
            }else{
                return Ok(searchCourses);
            }
        }

        /* Listar cursos por Id */
         [HttpGet, Route("api/courses/{id}")]
        public async Task<IActionResult> Details(int id){
            var searchCourse = await _courseRepository.GetByIdAsync(id);
            if(searchCourse == null){
                return Ok(new {message = "El curso buscado no existe"});
            }

            return Ok(searchCourse);
        }

         /* ENDPOINTS MEDIOS */
         /* 2. Listar todos los cursos que le pertenecen a un determinado profesor */
        [HttpGet, Route("api/teachers/{idTeacher}/courses")]
        public async Task<IEnumerable<Course>> listCoursesOfOneTeacher(int idTeacher){
            return await _courseRepository.coursesOfOneTeacher(idTeacher);
        }
    
        
    

    }
}