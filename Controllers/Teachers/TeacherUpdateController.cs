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
    public class TeacherUpdateController : ControllerBase{
        private readonly ITeacherRepository _teacherRepository;
        public TeacherUpdateController(ITeacherRepository teacherRepository){
            _teacherRepository = teacherRepository;
        }

        [HttpPut]
        [Route("api/teachers/{id}")]
        public IActionResult Update([FromBody] Teacher teacher){
            try
            {
                _teacherRepository.UpdateTeacher(teacher);
                return Ok("Los datos del profesor se actualizaron correctamente");

            }
            catch (System.Exception)
            {   
                return BadRequest("Los datos del profesor no pudieron ser actualizados");
            }
        }

        
    

    }
}