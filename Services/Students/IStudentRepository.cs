using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesempeno.Models;

namespace PruebaDesempeno.Services
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Task<Student> GetByIdAsync(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
            
        /* ENNPOINTS MEDIOS */
        /* 1.Listar estudiantes por fecha de cumpleaños  */
        Task<IEnumerable<Student>> studentsForBirthDate(DateOnly birhdateDate);
    }
}