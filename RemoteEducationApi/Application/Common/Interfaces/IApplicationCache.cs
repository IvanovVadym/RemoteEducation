namespace Application.Common.Interfaces
{
    public interface IApplicationCache<T>
    {
        T Get(int key);
        void Set(int key, T value);
        void Remove(int key);
    }
}
