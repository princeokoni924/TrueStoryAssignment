using DALCore.Model;
using DALCore.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALCore.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductAsync(string? name, int page, int size );
        Task<Product> CreatProductAsync(AddProductDto product);
        Task<bool> DeleteProduct(int id);
    }
}
