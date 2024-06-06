using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesempeno.Models;
using PruebaDesempeno.Utils;

namespace PruebaDesempeno.Services
{
    public interface IEnrollmentRepository
    {
        IEnumerable<Enrollment> GetAll();
        Task<Enrollment> GetByIdAsync(int id);
        void Update(Enrollment enrollment);
        
        /* ENVIAR CORREO CUANDO SE CREA UNA MATRICULA */
        Task<ResponseUtils<Enrollment>> CreateAsync(Enrollment enrollment, int idStudent, int idTeacher);

        /* ENNPOINTS MEDIOS */
        /* 1.Listar matriculas en una fecha especifica  */
        Task<IEnumerable<Enrollment>> enrollmentsForDate(DateOnly enrollmentDate);
      
        /* 2.Listar todas las matriculas que ha tenido un estudiante  */
        Task<IEnumerable<Enrollment>> enrollmentsOfOneStudent(int idStudent);


    }
}