using Microsoft.EntityFrameworkCore;
using MVP.Data;
using MVP.Data.Models;
using MVP.Services;

namespace MVP.InitializeDataBase
{
    class Program
    {
        static MVPContext context;

        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MVPContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-K6IKGE9;Database=MVP;Trusted_Connection=True;MultipleActiveResultSets=true");

            context = new MVPContext(optionsBuilder.Options);

            SetProducts();
            SetCountries();
        }

        static void SetProducts()
        {
            ProductService service = new ProductService(context);
            service.SetNewProduct(new Product() { Name = "Apple" , Price = 100 });
            service.SetNewProduct(new Product() { Name = "Banana", Price = 199 });
            service.SetNewProduct(new Product() { Name = "Car", Price = 9990.5 });
            service.SetNewProduct(new Product() { Name = "Pizza", Price = 30 });
            service.SetNewProduct(new Product() { Name = "Eggs", Price = 24 });
        }

        static void SetCountries()
        {
            CountryService service = new CountryService(context);
            service.SetNewCountry(new Country() { Name = "Austria", Tax = 20 });
            service.SetNewCountry(new Country() { Name = "Belgium", Tax = 21 });
            service.SetNewCountry(new Country() { Name = "Bulgaria", Tax = 20 });
            service.SetNewCountry(new Country() { Name = "Cyprus", Tax = 19 });
            service.SetNewCountry(new Country() { Name = "Czech Republic", Tax = 21 });
            service.SetNewCountry(new Country() { Name = "Croatia", Tax = 25 });
            service.SetNewCountry(new Country() { Name = "Denmark", Tax = 25 });
            service.SetNewCountry(new Country() { Name = "Estonia", Tax = 20 });
            service.SetNewCountry(new Country() { Name = "Finland", Tax = 24 });
            service.SetNewCountry(new Country() { Name = "France", Tax = 20 });
            service.SetNewCountry(new Country() { Name = "Germany", Tax = 19 });
            service.SetNewCountry(new Country() { Name = "Greece", Tax = 24 });
            service.SetNewCountry(new Country() { Name = "Hungary", Tax = 27 });
            service.SetNewCountry(new Country() { Name = "Ireland", Tax = 23 });
            service.SetNewCountry(new Country() { Name = "Italy", Tax = 22 });
            service.SetNewCountry(new Country() { Name = "Latvia", Tax = 21 });
            service.SetNewCountry(new Country() { Name = "Lithuania", Tax = 21 });
            service.SetNewCountry(new Country() { Name = "Luxembourg", Tax = 17 });
            service.SetNewCountry(new Country() { Name = "Malta", Tax = 18 });
            service.SetNewCountry(new Country() { Name = "Netherlands", Tax = 21 });
            service.SetNewCountry(new Country() { Name = "Poland", Tax = 23 });
            service.SetNewCountry(new Country() { Name = "Portugal", Tax = 23 });
            service.SetNewCountry(new Country() { Name = "Romania", Tax = 19 });
            service.SetNewCountry(new Country() { Name = "Slovakia", Tax = 20 });
            service.SetNewCountry(new Country() { Name = "Slovenia", Tax = 22 });
            service.SetNewCountry(new Country() { Name = "Spain", Tax = 21 });
            service.SetNewCountry(new Country() { Name = "Sweden", Tax = 25 });
            service.SetNewCountry(new Country() { Name = "United Kingdom", Tax = 20 });
        }
    }
}
