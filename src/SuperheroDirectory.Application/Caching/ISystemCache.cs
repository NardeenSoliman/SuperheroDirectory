namespace SuperheroDirectory.Application.Caching
{
    public interface ISystemCache
    {
        void Set<TItem>(string key, TItem value);
        TItem Get<TItem>(string key);
    }
}
