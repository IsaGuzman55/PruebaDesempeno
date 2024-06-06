using Microsoft.EntityFrameworkCore;
using PruebaDesempeno.Models;
using PruebaDesempeno.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesempeno.Data{
    public class PruebaBaseContext : DbContext{
        public PruebaBaseContext(DbContextOptions<PruebaBaseContext> options) : base(options){
        }

        public DbSet<Student> Students {get;set;}
        public DbSet<Teacher> Teachers {get;set;}
        public DbSet<Course> Courses {get;set;}
        public DbSet<Enrollment> Enrollments {get;set;}

    }
}