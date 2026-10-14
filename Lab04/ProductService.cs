using Lab04_PRODUCT_MANAGER;

namespace Lab04_PRODUCT_MANAGER
{
    public class ProductService
    {
        private readonly Repository<Product> repository = new Repository<Product>();

        // Event thong bao khi them / xoa thanh cong
        public event Action<Product>? ProductAdded;
        public event Action<Product>? ProductRemoved;

        public void AddProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.MaSP))
            {
                throw new ArgumentException("Ma san pham khong duoc rong!");
            }

            if (repository.FindById(product.MaSP) != null)
            {
                throw new DuplicateProductException(product.MaSP);
            }

            repository.Add(product);
            ProductAdded?.Invoke(product);
        }

        public void RemoveProduct(string maSP)
        {
            Product? product = repository.FindById(maSP);
            if (product == null)
            {
                throw new ProductNotFoundException(maSP);
            }

            repository.Remove(maSP);
            ProductRemoved?.Invoke(product);
        }

        public List<Product> GetAll()
        {
            return repository.GetAll();
        }

        public Product? FindById(string maSP)
        {
            return repository.FindById(maSP);
        }

        // Tim theo ten
        public List<Product> Search(string keyword)
        {
            Func<Product, bool> condition = p =>
                p.TenSP.Contains(keyword, StringComparison.OrdinalIgnoreCase);
            return repository.Find(condition);
        }

        // Loc theo dieu kien bat ky
        public List<Product> Filter(Func<Product, bool> condition)
        {
            return repository.Find(condition);
        }

        public List<Product> FilterByPrice(decimal minPrice, decimal maxPrice)
        {
            return Filter(p => p.Price >= minPrice && p.Price <= maxPrice);
        }

        public decimal GetTotalInventoryValue()
        {
            return repository.GetAll().Sum(p => p.Price * p.Quantity);
        }
    }
}