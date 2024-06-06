using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesempeno.Models;
using PruebaDesempeno.Models;

namespace PruebaDesempeno.Services
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Task<Course> GetByIdAsync(int id);
        void CreateCourse(Course course);
        void UpdateCourse(Course course);

        /* ENDPOINT MEDIO */
        /* 2. Listar todos los cursos que le pertenecen a un determinado profesor */
        Task<IEnumerable<Course>> coursesOfOneTeacher(int idTeacher);
    }
}