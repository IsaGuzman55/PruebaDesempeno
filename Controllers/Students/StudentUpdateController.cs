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
    public class StudentUpdateController : ControllerBase{
        private readonly IStudentRepository _studentRepository;
        public StudentUpdateController(IStudentRepository studentRepository){
            _studentRepository = studentRepository;
        }

        [HttpPut]
        [Route("api/students/{id}")]
        public IActionResult Update([FromBody] Student student){
            try
            {
                _studentRepository.UpdateStudent(student);
                return Ok("Los datos del estudiante se actualizaron correctamente");

            }
            catch (System.Exception)
            {   
                return BadRequest("Los datos del estudiante no pudieron actualizarse");
            }
        }

        
    

    }
}