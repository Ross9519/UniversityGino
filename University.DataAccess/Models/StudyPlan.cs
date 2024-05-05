using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace University.DataAccess.Models
{
    [Table("student_subject")]
    public class StudyPlan
    {
        [Key]
        [Column("student_id")]
        public long StudentId { get; set; }

        [Key]
        [Column("subject_id")]
        public long SubjectId { get; set; }

        public Student? Student { get; set; }

        public Subject? Subject { get; set; }

        public override string ToString()
            => $"Student: {Student?.FirstName} {Student?.LastName} | Subject: {Subject?.Name}";
    }
}
