using University.DataAccess.Models;

namespace University.DataAccess.Seed
{
    internal static class StudyPlanSeeder
    {
        public static StudyPlan StudyPlan1 = new()
        {
            StudentId = 1,
            SubjectId = 1
        };

        public static StudyPlan StudyPlan2 = new()
        {
            StudentId = 1,
            SubjectId = 2
        };

        public static StudyPlan StudyPlan3 = new()
        {
            StudentId = 2,
            SubjectId = 1
        };

        public static StudyPlan StudyPlan4 = new()
        {
            StudentId = 2,
            SubjectId = 3
        };

        public static StudyPlan StudyPlan5 = new()
        {
            StudentId = 3,
            SubjectId = 2
        };

        public static ICollection<StudyPlan> StudyPlans =
        [
            StudyPlan1,
            StudyPlan2,
            StudyPlan3,
            StudyPlan4,
            StudyPlan5
        ];
    }
}
