namespace University.DataAccess.Repositories.AbstractAndInterfaces
{
    public abstract class BaseThreeFkJoinTableRepository<T>(UniversityContext context) : BaseRepository<T>(context), IThreeIdsMethods<T>
    {
        public abstract Task<T?> GetByIdAsync(int id1, int id2, int id3);

        public abstract Task DeleteByIdAsync(int id1, int id2, int id3);
    }
}
