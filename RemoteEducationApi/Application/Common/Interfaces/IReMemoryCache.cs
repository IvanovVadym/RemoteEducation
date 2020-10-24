namespace Application.Common.Interfaces
{
    public interface IReMemoryCache<T>
    {
        T GetValue(int id);
        T SetValue(int id, T value);
        void RemoveValue(int id);
    }
}
