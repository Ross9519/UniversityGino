namespace University.DataAccess.Repositories.AbstractAndInterfaces
{
    internal interface IThreeIdsMethods<T>
    {
        Task<T?> GetByIdAsync(long id1, long id2, long id3);

        Task DeleteByIdAsync(long id1, long id2, long id3);
    }
}
