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
    public class EnrollmentUpdateController : ControllerBase{
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentUpdateController(IEnrollmentRepository enrollmentRepository){
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpPut]
        [Route("api/enrollments/{id}")]
        public IActionResult Update([FromBody] Enrollment enrollment){
            try
            {
                _enrollmentRepository.Update(enrollment);
                return Ok("La matricula se actualizó correctamente");

            }
            catch (System.Exception)
            {   
                return BadRequest("La matricula no se pudo actualizar");
            }
        }

        
    

    }
}