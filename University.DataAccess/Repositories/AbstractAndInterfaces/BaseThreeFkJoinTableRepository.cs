namespace University.DataAccess.Repositories.AbstractAndInterfaces
{
    public abstract class BaseThreeFkJoinTableRepository<T>(UniversityContext context) : BaseRepository<T>(context), IThreeIdsMethods<T>
    {
        public abstract Task<T?> GetByIdAsync(long id1, long id2, long id3);

        public abstract Task DeleteByIdAsync(long id1, long id2, long id3);
    }
}
