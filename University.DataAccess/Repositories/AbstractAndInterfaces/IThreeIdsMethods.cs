namespace University.DataAccess.Repositories.AbstractAndInterfaces
{
    internal interface IThreeIdsMethods<T>
    {
        Task<T?> GetByIdAsync(int id1, int id2, int id3);

        Task DeleteByIdAsync(int id1, int id2, int id3);
    }
}
