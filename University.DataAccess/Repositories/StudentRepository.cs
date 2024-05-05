using Microsoft.EntityFrameworkCore;
using University.DataAccess.Models;
using University.DataAccess.Repositories.AbstractAndInterfaces;

namespace University.DataAccess.Repositories
{
    public class StudentRepository(UniversityContext context) : BaseEntityRepository<Student>(context)
    {
        public override async Task<IReadOnlyList<Student>> GetAllAsync()
            => await Context.Students.Include(s => s.StudyPlans).Include(s => s.Exams).ToListAsync();

        public override async Task<Student?> GetByIdAsync(int id)
            => await Context.Students.Include(s => s.StudyPlans).Include(s => s.Exams).FirstOrDefaultAsync(s => s.Id == id);

        public override async Task<int> InsertAsync(Student toInsert)
        {
            await Context.Students.AddAsync(toInsert);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> InsertRangeAsync(List<Student> toInsertList)
        {
            await Context.Students.AddRangeAsync(toInsertList);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> UpdateAsync(Student toUpdate)
        {
            Context.Students.Update(toUpdate);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> UpdateRangeAsync(List<Student> toUpdateList)
        {
            Context.Students.UpdateRange(toUpdateList);
            return await Context.SaveChangesAsync();
        }

        public override async Task DeleteByIdAsync(int id)
        {
            Student? toDeactivate = await GetByIdAsync(id);
            if (toDeactivate is not null)
                toDeactivate.Active = false;
            await Context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(Student toDeactivate)
        {
            toDeactivate.Active = false;
            await UpdateAsync(toDeactivate);
        }

        public override async Task<int> DeleteRangeAsync(List<Student> toDeactivateList)
        {
            toDeactivateList.ForEach(s => s.Active = false);
            return await UpdateRangeAsync(toDeactivateList);
        }
    }
}
