namespace University.DataAccess.Repositories.AbstractAndInterfaces
{
    public abstract class BaseEntityRepository<T>(UniversityContext context) : BaseRepository<T>(context), ISingleIdMethods<T>
    {
        public abstract Task<T?> GetByIdAsync(long id);

        public abstract Task DeleteByIdAsync(long id);
    }
}
