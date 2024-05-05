using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.DataAccess.Models
{
    [Table("exam")]
    public class Exam
    {
        [Key]
        [Column("student_id")]
        public long StudentId { get; set; }

        [Key]
        [Column("professor_id")]
        public long ProfessorId { get; set; }

        [Key]
        [Column("subject_id")]
        public long SubjectId { get; set; }

        [Required]
        [Column("exam_grade")]
        public int Grade { get; set; }

        [Required]
        [Column("exam_date")]
        public DateTime Date { get; set; }

        public Student? Student { get; set; }

        public Professor? Professor { get; set; }

        public Subject? Subject { get; set; }

        public override string ToString()
            => $"Student: {Student?.FirstName} {Student?.LastName} | Professor: {Professor?.FirstName} {Professor?.LastName} | Subject: {Subject?.Name} | Grade: {Grade} | Date: {Date}";
    }
}
