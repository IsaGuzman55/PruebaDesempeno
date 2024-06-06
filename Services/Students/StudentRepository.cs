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
    public class StudentRepository : IStudentRepository
    {
        public readonly PruebaBaseContext _context;

        public StudentRepository(PruebaBaseContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
 
        }

        public IEnumerable<Student> GetAll()
        {
           return _context.Students.ToList();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        }


        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }


        public async Task<IEnumerable<Student>> studentsForBirthDate(DateOnly birhdateDate)
        {
            return await _context.Students.Where(s => s.BirthDate == birhdateDate).ToListAsync();
        }
    }
}