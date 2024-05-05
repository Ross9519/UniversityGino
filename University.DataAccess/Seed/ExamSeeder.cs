using University.DataAccess.Models;

namespace University.DataAccess.Seed
{
    internal static class ExamSeeder
    {
        public static Exam Exam1 = new()
        {
            StudentId = 1,
            ProfessorId = 1,
            SubjectId = 1,
            Grade = 85,
            Date = DateTime.Now
        };

        public static Exam Exam2 = new()
        {
            StudentId = 1,
            ProfessorId = 2,
            SubjectId = 2,
            Grade = 78,
            Date = DateTime.Now.AddDays(-21)
        };

        public static Exam Exam3 = new()
        {
            StudentId = 2,
            ProfessorId = 1,
            SubjectId = 1,
            Grade = 92,
            Date = DateTime.Now.AddDays(-42)
        };

        public static Exam Exam4 = new()
        {
            StudentId = 2,
            ProfessorId = 2,
            SubjectId = 3,
            Grade = 89,
            Date = DateTime.Now.AddDays(-63)
        };

        public static Exam Exam5 = new()
        {
            StudentId = 3,
            ProfessorId = 1,
            SubjectId = 2,
            Grade = 75,
            Date = DateTime.Now.AddDays(-84)
        };

        public static ICollection<Exam> Exams =
        [
            Exam1,
            Exam2,
            Exam3,
            Exam4,
            Exam5
        ];
    }
}
