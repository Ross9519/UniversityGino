using Microsoft.EntityFrameworkCore;
using University.DataAccess.Models;
using University.DataAccess.Seed;

namespace University.DataAccess
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<OfficeStaff> OfficeStaff { get; set; }
        public DbSet<StudyPlan> StudyPlans { get; set; }
        public DbSet<Exam> Exams { get; set; }

        public UniversityContext()
        { }

        public UniversityContext(DbContextOptions options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OfficeStaff>(staff =>
            {
                staff.HasData(OfficeStaffSeeder.OfficeStaff);
            });

            modelBuilder.Entity<Professor>(professor =>
            {
                professor.HasOne(p => p.Subject)
                    .WithOne(s => s.Professor)
                    .HasForeignKey<Subject>(s => s.ProfessorId);

                professor.HasMany(p => p.Exams)
                    .WithOne(e => e.Professor)
                    .HasForeignKey(e => e.ProfessorId)
                    .OnDelete(DeleteBehavior.NoAction);

                professor.HasData(ProfessorSeeder.Professors);
            });

            modelBuilder.Entity<Student>(student =>
            {
                student.HasMany(s => s.Exams)
                    .WithOne(e => e.Student)
                    .HasForeignKey(e => e.StudentId);

                student.HasMany(s => s.StudyPlans)
                    .WithOne(e => e.Student)
                    .HasForeignKey(e => e.StudentId)
                    .OnDelete(DeleteBehavior.NoAction);

                student.HasData(StudentSeeder.Students);
            });

            modelBuilder.Entity<Subject>(subject => 
            {
                subject.HasOne(s => s.Professor)
                    .WithOne(p => p.Subject)
                    .HasForeignKey<Professor>(p => p.SubjectId)
                    .OnDelete(DeleteBehavior.SetNull);

                subject.HasMany(s => s.Exams)
                    .WithOne(e => e.Subject)
                    .HasForeignKey(e => e.SubjectId)
                    .OnDelete(DeleteBehavior.NoAction);
                
                subject.HasMany(s => s.StudyPlans)
                    .WithOne(e => e.Subject)
                    .HasForeignKey(e => e.SubjectId)
                    .OnDelete(DeleteBehavior.NoAction);

                subject.HasData(SubjectSeeder.Subjects);
            });

            modelBuilder.Entity<Exam>(exam =>
            {
                exam.HasKey(e => new {e.StudentId, e.ProfessorId, e.SubjectId});

                exam.HasData(ExamSeeder.Exams);
            });

            modelBuilder.Entity<StudyPlan>(studyplan =>
            {
                studyplan.HasKey(sp => new {sp.StudentId, sp.SubjectId});

                studyplan.HasData(StudyPlanSeeder.StudyPlans);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constants.ConnectionString);
        }
    }
}
