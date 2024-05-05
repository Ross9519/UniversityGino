using Microsoft.EntityFrameworkCore;
using University.DataAccess.Models;
using University.DataAccess.Repositories.AbstractAndInterfaces;

namespace University.DataAccess.Repositories
{
    public class StudyPlanRepository(UniversityContext context) : BaseTwoFkJoinTableRepository<StudyPlan>(context)
    {
        public override async Task<IReadOnlyList<StudyPlan>> GetAllAsync()
          => await Context.StudyPlans.Include(s => s.Student).Include(s => s.Subject).ToListAsync();

        public override async Task<StudyPlan?> GetByIdAsync(int studentId, int subjectId)
            => await Context.StudyPlans.Include(s => s.Student).Include(s => s.Subject).FirstOrDefaultAsync(s => s.StudentId == studentId && s.SubjectId == subjectId);

        public override async Task<int> InsertAsync(StudyPlan toInsert)
        {
            await Context.StudyPlans.AddAsync(toInsert);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> InsertRangeAsync(List<StudyPlan> toInsertList)
        {
            await Context.StudyPlans.AddRangeAsync(toInsertList);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> UpdateAsync(StudyPlan toUpdate)
        {
            Context.StudyPlans.Update(toUpdate);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> UpdateRangeAsync(List<StudyPlan> toUpdateList)
        {
            Context.StudyPlans.UpdateRange(toUpdateList);
            return await Context.SaveChangesAsync();
        }

        public override async Task DeleteByIdAsync(int studentId, int subjectId)
        {
            StudyPlan? toDelete = await GetByIdAsync(studentId, subjectId);
            if (toDelete is not null)
                Context.StudyPlans.Remove(toDelete);
            await Context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(StudyPlan toDelete)
        {
            Context.StudyPlans.Remove(toDelete);
            await Context.SaveChangesAsync();
        }

        public override async Task<int> DeleteRangeAsync(List<StudyPlan> toDeleteList)
        {
            Context.StudyPlans.RemoveRange(toDeleteList);
            return await Context.SaveChangesAsync();
        }
    }
}
