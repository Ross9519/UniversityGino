using Microsoft.EntityFrameworkCore;
using University.DataAccess.Models;
using University.DataAccess.Repositories.AbstractAndInterfaces;

namespace University.DataAccess.Repositories
{
    public class ProfessorRepository(UniversityContext context) : BaseEntityRepository<Professor>(context)
    {
        public override async Task<IReadOnlyList<Professor>> GetAllAsync()
            => await Context.Professors.Include(p => p.Subject).Include(p => p.Exams).ToListAsync();

        public override async Task<Professor?> GetByIdAsync(long id)
            => await Context.Professors.Include(p => p.Subject).Include(p => p.Exams).FirstOrDefaultAsync(s => s.Id == id);

        public override async Task<int> InsertAsync(Professor toInsert)
        {
            await Context.Professors.AddAsync(toInsert);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> InsertRangeAsync(List<Professor> toInsertList)
        {
            await Context.Professors.AddRangeAsync(toInsertList);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> UpdateAsync(Professor toUpdate)
        {
            Context.Professors.Update(toUpdate);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> UpdateRangeAsync(List<Professor> toUpdateList)
        {
            Context.Professors.UpdateRange(toUpdateList);
            return await Context.SaveChangesAsync();
        }

        public override async Task DeleteByIdAsync(long id)
        {
            Professor? toDeactivate = await GetByIdAsync(id);
            if (toDeactivate is not null)
                toDeactivate.Active = false;
            await Context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(Professor toDeactivate)
        {
            toDeactivate.Active = false;
            await UpdateAsync(toDeactivate);
        }

        public override async Task<int> DeleteRangeAsync(List<Professor> toDeactivateList)
        {
            toDeactivateList.ForEach(s => s.Active = false);
            return await UpdateRangeAsync(toDeactivateList);
        }
    }
}
