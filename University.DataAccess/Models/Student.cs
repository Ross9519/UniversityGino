using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University.DataAccess.Models
{
    [Table("student")]
    public class Student : Person
    {
        [Key]
        [Column("student_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("student_no")]
        public string StudentNo { get; set; } = string.Empty;

        public ICollection<StudyPlan>? StudyPlans { get; set; }

        public ICollection<Exam>? Exams { get; set; }

        public override string ToString()
            => $"{base.ToString()} | Student Number: {StudentNo}";
    }
}
