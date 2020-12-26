using MVP.Data.Models;

namespace MVP.Services
{
    public interface IProductService
    {
        bool SetNewProduct(Product product );
        Product GetProductById(int id);
        Product GetProductByName(string name);
        void RemoveProduct(Product product);
        void RemoveProductById(int id);
    }
}
