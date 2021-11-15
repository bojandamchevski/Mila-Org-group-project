namespace DataAccess.Interfaces
{
    public interface IPersonRepository<T> : IRepository<T>
    {
        T GetPersonByEmail(string email);
        T LoginPerson(string email, string password);
    }
}
