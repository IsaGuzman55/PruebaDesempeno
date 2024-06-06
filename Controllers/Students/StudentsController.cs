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
    public class StudentsController : ControllerBase{
        private readonly IStudentRepository _studentRepository;
        public StudentsController(IStudentRepository studentRepository){
            _studentRepository = studentRepository;
        }

        /* Listar estudiantes */
        [HttpGet, Route("api/students")]
        public IActionResult GetStudents(){
            var searchStudents = _studentRepository.GetAll();
            if(!searchStudents.Any()){
                return Ok(new {message = "No hay estudiantes registrados"});
            }else{
                return Ok(searchStudents);
            }
        }

        /* Listar estudiantes por Id */
         [HttpGet, Route("api/students/{id}")]
        public async Task<IActionResult> Details(int id){
            var searchStudent = await _studentRepository.GetByIdAsync(id);
            if(searchStudent == null){
                return Ok(new {message = "El estudiante buscado no existe"});
            }

            return Ok(searchStudent);
        }

        /* ENDPOINTS MEDIOS */
        /* 4. Listar estudiantes por fecha de cumpleaños */
        [HttpGet, Route("api/students/{birhdateDate}/birthday")]
        public async Task<IEnumerable<Student>> studentsForBirthDate(DateOnly birhdateDate){
            return await _studentRepository.studentsForBirthDate(birhdateDate);
        }
    

    }
}