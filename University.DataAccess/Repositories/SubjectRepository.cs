using Microsoft.EntityFrameworkCore;
using University.DataAccess.Models;
using University.DataAccess.Repositories.AbstractAndInterfaces;

namespace University.DataAccess.Repositories
{
    public class SubjectRepository(UniversityContext context) : BaseEntityRepository<Subject>(context)
    {
        public override async Task<IReadOnlyList<Subject>> GetAllAsync()
            => await Context.Subjects.Include(s => s.Professor).Include(s => s.StudyPlans).Include(s => s.Exams).ToListAsync();

        public override async Task<Subject?> GetByIdAsync(long id)
            => await Context.Subjects.Include(s => s.Professor).Include(s => s.StudyPlans).Include(s => s.Exams).FirstOrDefaultAsync(s => s.Id == id);

        public override async Task<int> InsertAsync(Subject toInsert)
        {
            await Context.Subjects.AddAsync(toInsert);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> InsertRangeAsync(List<Subject> toInsertList)
        {
            await Context.Subjects.AddRangeAsync(toInsertList);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> UpdateAsync(Subject toUpdate)
        {
            Context.Subjects.Update(toUpdate);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> UpdateRangeAsync(List<Subject> toUpdateList)
        {
            Context.Subjects.UpdateRange(toUpdateList);
            return await Context.SaveChangesAsync();
        }

        public override async Task DeleteByIdAsync(long id)
        {
            Subject? toDelete = await GetByIdAsync(id);
            if (toDelete is not null)
                Context.Subjects.Remove(toDelete);
            await Context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(Subject toDelete)
        {
            Context.Subjects.Remove(toDelete);
            await Context.SaveChangesAsync();
        }

        public override async Task<int> DeleteRangeAsync(List<Subject> toDeleteList)
        {
            Context.Subjects.RemoveRange(toDeleteList);
            return await Context.SaveChangesAsync();
        }
    }
}
