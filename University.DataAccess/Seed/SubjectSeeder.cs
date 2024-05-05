using University.DataAccess.Models;

namespace University.DataAccess.Seed
{
    internal static class SubjectSeeder
    {
        public static Subject Math = new()
        { 
            Id = 1, 
            Name = "Mathematics", 
            HoursNo = 4, 
            ProfessorId = 1 
        };

        public static Subject Physics = new()
        { 
            Id = 2, 
            Name = "Physics", 
            HoursNo = 3, 
            ProfessorId = 2 
        };

        public static Subject Chemistry = new()
        { 
            Id = 3, 
            Name = "Chemistry", 
            HoursNo = 3, 
            ProfessorId = 3 
        };

        public static Subject Biology = new()
        { 
            Id = 4, 
            Name = "Biology", 
            HoursNo = 3, 
            ProfessorId = 4 
        };

        public static Subject EnglishLiterature = new()
        { 
            Id = 5, 
            Name = "English Literature", 
            HoursNo = 2, 
            ProfessorId = 5 
        };

        public static ICollection<Subject> Subjects =
        [
            Math,
            Physics,
            Chemistry,
            Biology,
            EnglishLiterature
        ];
    }
}
