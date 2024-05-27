namespace University.Api.Dtos
{
    public class SubjectDto
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int HoursNo { get; set; }

        public long ProfessorId { get; set; }
    }
}
