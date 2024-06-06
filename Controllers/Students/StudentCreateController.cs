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
    public class StudentCreateController : ControllerBase{
        private readonly IStudentRepository _studentRepository;
        public StudentCreateController(IStudentRepository studentRepository){
            _studentRepository = studentRepository;
        }


        [HttpPost]
        [Route("api/students")]
        public IActionResult Create([FromBody] Student student){
            try{
                _studentRepository.CreateStudent(student);
                return Ok("El estudiante se creó correctamente");
            }
            catch (System.Exception)
            {   
                return BadRequest("El estudiante no pudo crearse");
            }

        }

    


    

    }
}