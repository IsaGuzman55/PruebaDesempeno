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
    public class TeacherController : ControllerBase{
        private readonly ITeacherRepository _teacherRepository;
        public TeacherController(ITeacherRepository teacherRepository){
            _teacherRepository = teacherRepository;
        }

        /* Listar profesores */
        [HttpGet, Route("api/teachers")]
        public IActionResult GetTeachers(){
            var searchTeacher = _teacherRepository.GetAll();
            if(!searchTeacher.Any()){
                return Ok(new {message = "No hay profesores registradas"});
            }else{
                return Ok(searchTeacher);
            }
        }

        /* Listar profesores por Id */
         [HttpGet, Route("api/teachers/{id}")]
        public async Task<IActionResult> Details(int id){
            var searchTeacher = await _teacherRepository.GetByIdAsync(id);
            if(searchTeacher == null){
                return Ok(new {message = "El profesor buscado no existe"});
            }

            return Ok(searchTeacher);
        }
        
    

    }
}