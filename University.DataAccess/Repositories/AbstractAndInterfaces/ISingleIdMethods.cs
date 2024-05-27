namespace University.DataAccess.Repositories.AbstractAndInterfaces
{
    internal interface ISingleIdMethods<T>
    {
        Task<T?> GetByIdAsync(long id);

        Task DeleteByIdAsync(long id);
    }
}