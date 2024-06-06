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
    public class EnrollmentsController : ControllerBase{
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentsController(IEnrollmentRepository enrollmentRepository){
            _enrollmentRepository = enrollmentRepository;
        }

        /* Listar Matriculas */
        [HttpGet, Route("api/enrollments")]
        public IActionResult GetEnrollments(){
            var searchEnrollments = _enrollmentRepository.GetAll();
            if(!searchEnrollments.Any()){
                return Ok(new {message = "No hay matriculas registradas"});
            }else{
                return Ok(searchEnrollments);
            }
        }

        /* Listar Matriculas por Id */
         [HttpGet, Route("api/enrollments/{id}")]
        public async Task<IActionResult> Details(int id){
            var searchEnrollment = await _enrollmentRepository.GetByIdAsync(id);
            if(searchEnrollment == null){
                return Ok(new {message = "La matricula buscada no existe"});
            }

            return Ok(searchEnrollment);
        }
        
        /* ENDPOINTS MEDIOS */
        /* 1. Listar matriculas por fecha especifica */
        [HttpGet, Route("api/enrollments/{enrollmentDate}/date")]
        public async Task<IEnumerable<Enrollment>> enrollmentsForDate(DateOnly enrollmentDate){
            return await _enrollmentRepository.enrollmentsForDate(enrollmentDate);
        }

        /* 2.Listar todas las matriculas que ha tenido un estudiante  */
        [HttpGet, Route("api/students/{idStudent}/enrollments")]
        public async Task<IEnumerable<Enrollment>> listEnrollmentsOfOneStudent(int idStudent){
            return await _enrollmentRepository.enrollmentsOfOneStudent(idStudent);
        }

    }
}