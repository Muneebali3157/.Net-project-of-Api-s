using Crud_Operation_with_Repo.Models;

namespace Crud_Operation_with_Repo.Services.IServices

{
    public interface IProductServices
    {
        IEnumerable<Product> GetAllProducts();

        Product Getbyid(int id);

        void CreateProduct(Product product);
        void UpdateProduct(Product product);

        void DeleteProduct(int id);
    }
}
