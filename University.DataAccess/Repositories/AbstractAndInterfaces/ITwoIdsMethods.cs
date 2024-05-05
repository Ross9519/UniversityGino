namespace University.DataAccess.Repositories.AbstractAndInterfaces
{
    internal interface ITwoIdsMethods<T>
    {
        Task<T?> GetByIdAsync(int id1, int id2);

        Task DeleteByIdAsync(int id1, int id2);
    }
}
