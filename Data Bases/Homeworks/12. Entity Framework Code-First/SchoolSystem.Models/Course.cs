using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public class Course
    {
        private const int MaxNameLength = 40;
        private const int MaxDescriptionLength = 100;

        public Course()
        {
            this.Materials = new HashSet<Material>();
            this.Students = new HashSet<Student>();
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Material> Materials { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
