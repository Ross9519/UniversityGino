using Microsoft.EntityFrameworkCore;
using University.DataAccess.Models;
using University.DataAccess.Repositories.AbstractAndInterfaces;

namespace University.DataAccess.Repositories
{
    public class OfficeStaffRepository(UniversityContext context) : BaseEntityRepository<OfficeStaff>(context)
    {
        public override async Task<IReadOnlyList<OfficeStaff>> GetAllAsync()
           => await Context.OfficeStaff.ToListAsync();

        public override async Task<OfficeStaff?> GetByIdAsync(int id)
            => await Context.OfficeStaff.FirstOrDefaultAsync(s => s.Id == id);

        public override async Task<int> InsertAsync(OfficeStaff toInsert)
        {
            await Context.OfficeStaff.AddAsync(toInsert);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> InsertRangeAsync(List<OfficeStaff> toInsertList)
        {
            await Context.OfficeStaff.AddRangeAsync(toInsertList);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> UpdateAsync(OfficeStaff toUpdate)
        {
            Context.OfficeStaff.Update(toUpdate);
            return await Context.SaveChangesAsync();
        }

        public override async Task<int> UpdateRangeAsync(List<OfficeStaff> toUpdateList)
        {
            Context.OfficeStaff.UpdateRange(toUpdateList);
            return await Context.SaveChangesAsync();
        }

        public override async Task DeleteByIdAsync(int id)
        {
            OfficeStaff? toDeactivate = await GetByIdAsync(id);
            if (toDeactivate is not null)
                toDeactivate.Active = false;
            await Context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(OfficeStaff toDeactivate)
        {
            toDeactivate.Active = false;
            await UpdateAsync(toDeactivate);
        }

        public override async Task<int> DeleteRangeAsync(List<OfficeStaff> toDeactivateList)
        {
            toDeactivateList.ForEach(s => s.Active = false);
            return await UpdateRangeAsync(toDeactivateList);
        }
    }
}
