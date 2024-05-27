namespace University.Api.Dtos
{
    public class ExamDto
    {
        public long StudentId { get; set; }

        public long ProfessorId { get; set; }

        public long SubjectId { get; set; }

        public int Grade { get; set; }

        public DateTime Date { get; set; }
    }
}
