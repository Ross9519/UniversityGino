using Microsoft.EntityFrameworkCore;
using University.DataAccess.Models;
using University.DataAccess.Repositories.AbstractAndInterfaces;

namespace University.DataAccess.Repositories
{
    public class ExamRepository(UniversityContext context) : BaseThreeFkJoinTableRepository<Exam>(context)
    {
        public override async Task<IReadOnlyList<Exam>> GetAllAsync()
          => await Context.Exams.Include(e => e.Student).Include(e => e.Professor).Include(e => e.Subject).ToListAsync();

        public override async Task<Exam?> GetByIdAsync(int studentId, int professorId, int subjectId)
        {
            return await Context.Exams.Include(e => e.Student).Include(e => e.Subject).FirstOrDefaultAsync(e => e.StudentId == studentId && e.ProfessorId == professorId && e.SubjectId == subjectId);
        }

        public override async Task<int> InsertAsync(Exam toInsert)
        {
            await Context.Exams.AddAsync(toInsert);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> InsertRangeAsync(List<Exam> toInsertList)
        {
            await Context.Exams.AddRangeAsync(toInsertList);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> UpdateAsync(Exam toUpdate)
        {
            Context.Exams.Update(toUpdate);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> UpdateRangeAsync(List<Exam> toUpdateList)
        {
            Context.Exams.UpdateRange(toUpdateList);
            return await Context.SaveChangesAsync();
        }

        public override async Task DeleteByIdAsync(int studentId, int professorId, int subjectId)
        {
            Exam? toDelete = await GetByIdAsync(studentId, professorId, subjectId);
            if (toDelete is not null)
                Context.Exams.Remove(toDelete);
            await Context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(Exam toDelete)
        {
            Context.Exams.Remove(toDelete);
            await Context.SaveChangesAsync();
        }

        public override async Task<int> DeleteRangeAsync(List<Exam> toDeleteList)
        {
            Context.Exams.RemoveRange(toDeleteList);
            return await Context.SaveChangesAsync();
        }
    }
}
