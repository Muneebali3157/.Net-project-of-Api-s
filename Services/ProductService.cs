using Crud_Operation_with_Repo.Models;
using Crud_Operation_with_Repo.Services.IServices;

namespace Crud_Operation_with_Repo.Services
{
    public class ProductService : IProductServices
    {
        private readonly ApplicationDbContext _context; 

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null) { 
                _context.Products.Remove(product);
                _context.SaveChanges();

            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product Getbyid(int id)
        {
            var prod = _context.Products.FirstOrDefault(p => p.Id == id);
            if (prod != null)
            {
                return prod;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public void UpdateProduct(Product product)
        {
           var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                _context.SaveChanges();
            }
        }
    }
}
