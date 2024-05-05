using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.DataAccess.Models
{
    [Table("subject")]
    public class Subject
    {
        [Key]
        [Column("subject_id")]
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("subject_name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column("hours_no")]
        public int HoursNo { get; set; }

        [Required]
        [Column("professor_id")]
        public long ProfessorId { get; set; }

        public Professor? Professor { get; set; }

        public ICollection<Exam>? Exams { get; set; }

        public ICollection<StudyPlan>? StudyPlans { get; set; } 

        public override string ToString()
            => $"Id: {Id} | Name: {Name} | Number of hours: {HoursNo} | Professor: {Professor?.FirstName} {Professor?.LastName}";
    }
}
