namespace University.DataAccess.Repositories.AbstractAndInterfaces
{
    public abstract class BaseTwoFkJoinTableRepository<T>(UniversityContext context) : BaseRepository<T>(context), ITwoIdsMethods<T>
    {
        public abstract Task<T?> GetByIdAsync(int id1, int id2);

        public abstract Task DeleteByIdAsync(int id1, int id2);
    }
}
