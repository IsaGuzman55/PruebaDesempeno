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
    public class TeacherCreateController : ControllerBase{
        private readonly ITeacherRepository _teacherRepository;
        public TeacherCreateController(ITeacherRepository teacherRepository){
            _teacherRepository = teacherRepository;
        }


        [HttpPost]
        [Route("api/teachers")]
        public IActionResult Create([FromBody] Teacher teacher){
            try{
                _teacherRepository.CreateTeacher(teacher);
                return Ok("El profesor se creó correctamente");
            }
            catch (System.Exception)
            {   
                return BadRequest("El profesor no pudo crearse");
            }

        }

    

    }
}