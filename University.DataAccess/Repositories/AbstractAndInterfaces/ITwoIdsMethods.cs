namespace University.DataAccess.Repositories.AbstractAndInterfaces
{
    internal interface ITwoIdsMethods<T>
    {
        Task<T?> GetByIdAsync(long id1, long id2);

        Task DeleteByIdAsync(long id1, long id2);
    }
}
