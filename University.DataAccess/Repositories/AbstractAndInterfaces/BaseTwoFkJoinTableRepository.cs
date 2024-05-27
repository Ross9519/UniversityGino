namespace University.DataAccess.Repositories.AbstractAndInterfaces
{
    public abstract class BaseTwoFkJoinTableRepository<T>(UniversityContext context) : BaseRepository<T>(context), ITwoIdsMethods<T>
    {
        public abstract Task<T?> GetByIdAsync(long id1, long id2);

        public abstract Task DeleteByIdAsync(long id1, long id2);
    }
}
