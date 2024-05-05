using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace University.DataAccess.Models
{
    [Table("professor")]
    public class Professor : Person
    {
        [Key]
        [Column("professor_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }

        [MaxLength(100)]
        [Column("subject_id")]
        public long? SubjectId { get; set; }

        public Subject? Subject { get; set; }

        public ICollection<Exam>? Exams { get; set; }

        public override string ToString()
            => $"{base.ToString()} | Subject: {Subject?.Name}";
    }
}
