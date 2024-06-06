using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PruebaDesempeno.Models{
    public class Course{
         public int Id {get; set;}

        [Required]
        public string Name {get; set;}

        [Required]
        public string Description {get; set;}

        [Required] /* Relacion con la tabla Teachers */
        public int? TeacherId {get; set;}
        public Teacher Teacher {get; set;}

        [Required]
        public string Schedule {get; set;}

        [Required]
        public string Duration {get; set;}

        [Required]
        public int Capacity {get; set;}

        [JsonIgnore]
        public List<Enrollment>? Enrollments { get; set; }

    }
}