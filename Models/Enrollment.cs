using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PruebaDesempeno.Models{
    public class Enrollment{
        public int Id {get; set;}

        [Required]
        public DateOnly Date {get; set;}

        [Required] /* Relacion con la tabla Students */
        public int StudentId {get; set;}
        public Student Student {get; set;}

        [Required] /* Relacion con la tabla Courses */
        public int CourseId {get; set;}
        public Course Course {get; set;}

        [Required]
        public string Status {get; set;}

    }
}