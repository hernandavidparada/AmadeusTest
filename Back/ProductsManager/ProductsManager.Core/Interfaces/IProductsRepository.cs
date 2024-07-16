

using ProductsManager.Core.Entites;

namespace ProductsManager.Core.Interfaces
{
    public interface IProductsRepository
    {

        public List<Product> GetProducts();

        public string InsertProducts(Product prod);

        public string DeleteProducts(int id);

    }
}
