using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesempeno.Data;
using PruebaDesempeno.Utils;
using PruebaDesempeno.Models;
using Microsoft.AspNetCore.Mvc;
using PruebaDesempeno.Services;

namespace PruebaDesempeno.Controllers{
    public class EnrollmentCreateController : ControllerBase{
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentCreateController(IEnrollmentRepository enrollmentRepository){
            _enrollmentRepository = enrollmentRepository;
        }


        [HttpPost]
        [Route("api/enrollments")]
        public async Task<ActionResult<ResponseUtils<Enrollment>>> Create([FromBody] Enrollment enrollment)
        {
            var response = await _enrollmentRepository.CreateAsync(enrollment, enrollment.StudentId, enrollment.CourseId);
            if(!response.Status){
                return StatusCode(422, response);
            }else{
                return Ok(response);
            }
        }

    

    }
}