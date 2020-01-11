using MVP.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
