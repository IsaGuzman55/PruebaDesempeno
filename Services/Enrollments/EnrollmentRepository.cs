using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaDesempeno.Data;
using PruebaDesempeno.Models;
using PruebaDesempeno.Utils;

namespace PruebaDesempeno.Services
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        public readonly PruebaBaseContext _context;

        public EnrollmentRepository(PruebaBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Enrollment> GetAll()
        {
            return _context.Enrollments.Include(e => e.Student).Include(e => e.Course).Include(e => e.Course.Teacher).ToList();
        
        }

        public async Task<Enrollment> GetByIdAsync(int id)
        {
            return await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).Include(e => e.Course.Teacher).FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Update(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            _context.SaveChanges();
        }

        public async Task<ResponseUtils<Enrollment>> CreateAsync(Enrollment enrollment, int idStudent, int idTeacher){
            try{
                var studentDuplicate = await _context.Enrollments.FirstOrDefaultAsync(e => e.StudentId == enrollment.StudentId && e.CourseId == enrollment.CourseId);
                if(studentDuplicate == null){
                    /* Buscar el estudiante(userEmail) */
                    var foundStudent = await _context.Students.FirstOrDefaultAsync(s => s.Id == enrollment.StudentId);
                
                    /* Buscar el curso (studentCourse) */
                    var foundCourse = await _context.Courses.FirstOrDefaultAsync(c => c.Id == enrollment.CourseId);
                    
                    /* Crear matricula y guardar cambios */
                    _context.Enrollments.Add(enrollment);
                    _context.SaveChangesAsync();

                    /* MAIL */
                    var sendEmail = new MailController();
                    sendEmail.EnviarCorreo(foundStudent.Email, foundStudent.Names, enrollment.Date, foundCourse.Name, enrollment.Status);

                    return new ResponseUtils<Enrollment>(true, new List<Enrollment>{enrollment}, 201, message: "¡La matricula ha sido registrada!");

                }else{
                   return new ResponseUtils<Enrollment>(false, null, 406, message: "¡La matricula se interpone con otra!");
                }
            }catch(Exception ex){
                return new ResponseUtils<Enrollment>(false, null, 422, message: ex.Message);
            }
        }

        /* ENDPOINTS MEDIOS */
        /* 1. */
        public async Task<IEnumerable<Enrollment>> enrollmentsForDate(DateOnly enrollmentDate){
            return await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).Include(e => e.Course.Teacher).Where(e => e.Date == enrollmentDate).ToListAsync();
        }

        public async Task<IEnumerable<Enrollment>> enrollmentsOfOneStudent(int idStudent)
        {
            return await _context.Enrollments.Include(e => e.Student).Include(e => e.Course).Include(e => e.Course.Teacher).Where(e => e.StudentId == idStudent).ToListAsync();
        }
    }
}