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
    public class CourseRepository : ICourseRepository
    {
        public readonly PruebaBaseContext _context;

        public CourseRepository(PruebaBaseContext context)
        {
            _context = context;
        }

        public void CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
 
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.Include(c => c.Teacher).ToList();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses.Include(c => c.Teacher).FirstOrDefaultAsync(c => c.Id == id);
        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

          /* ENDPOINTS MEDIOS */
        /* 2. */
        public async Task<IEnumerable<Course>> coursesOfOneTeacher(int idTeacher){
            return await _context.Courses.Include(e => e.Teacher).Where(e => e.TeacherId == idTeacher).ToListAsync();
        }
    }
}