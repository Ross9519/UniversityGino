namespace University.DataAccess.Repositories.AbstractAndInterfaces
{
    internal interface ISingleIdMethods<T>
    {
        Task<T?> GetByIdAsync(int id);

        Task DeleteByIdAsync(int id);
    }
}