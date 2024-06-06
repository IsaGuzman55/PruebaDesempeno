using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesempeno.Models;
using PruebaDesempeno.Utils;

namespace PruebaDesempeno.Services
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetAll();
        Task<Teacher> GetByIdAsync(int id);
        void CreateTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        
    }
}