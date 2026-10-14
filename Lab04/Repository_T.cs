namespace Lab04_PRODUCT_MANAGER
{
    public class Repository<T> where T : IEntity
    {
        private readonly List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public T? FindById(string id)
        {
            return items.FirstOrDefault(x => x.Id == id);
        }

        public bool Remove(string id)
        {
            T? item = FindById(id);
            if (item == null)
            {
                return false;
            }
            items.Remove(item);
            return true;
        }

        public List<T> Find(Func<T, bool> predicate)
        {
            return items.Where(predicate).ToList();
        }

        public List<T> GetAll()
        {
            return new List<T>(items);
        }
    }
}