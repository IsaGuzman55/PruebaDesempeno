using Microsoft.EntityFrameworkCore;
using PruebaDesempeno.Data;
using PruebaDesempeno.Models;
using PruebaDesempeno.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesempeno.Services
{
    public class TeacherRepository : ITeacherRepository
    {
        public readonly PruebaBaseContext _context;

        public TeacherRepository(PruebaBaseContext context)
        {
            _context = context;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return _context.Teachers.ToList();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            _context.SaveChanges();
        }

        public void CreateTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }
    }
}