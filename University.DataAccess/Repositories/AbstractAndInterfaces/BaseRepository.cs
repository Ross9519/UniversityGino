namespace University.DataAccess.Repositories.AbstractAndInterfaces
{
    public abstract class BaseRepository<T>(UniversityContext context)
    {
        protected readonly UniversityContext Context = context;

        public abstract Task<IReadOnlyList<T>> GetAllAsync();

        public abstract Task<int> InsertAsync(T toInsert);

        public abstract Task<int> InsertRangeAsync(List<T> toInsertList);

        public abstract Task<int> UpdateAsync(T toUpdate);

        public abstract Task<int> UpdateRangeAsync(List<T> toUpdateList);

        public abstract Task DeleteAsync(T toDelete);

        public abstract Task DeleteRangeAsync(List<T> toDeleteList);
    }
}
