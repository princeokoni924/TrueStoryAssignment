using DALCore.IRepository;
using DALCore.Model;
using DALCore.Model.Dtos;
using System.Net.Http.Json;
using System.Text.Json;

namespace BLLInfrastructure.ProductRepository
{
    public class ProductRepo : IProductRepository
    { 
        private readonly HttpClient _httpClient;

        public ProductRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://restful-api.dev.");
        }
        
        public async Task<Product> CreatProductAsync(AddProductDto productDto)
        {
            var productJsonContent = JsonContent.Create(new { productName = productDto.Name, productData = productDto.Data });
            var res = await _httpClient.PostAsync("objects", productJsonContent);
            res.EnsureSuccessStatusCode();
            return await res.Content.ReadFromJsonAsync<Product>();
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var delete = await _httpClient.DeleteAsync($"object/{id}");
            return delete.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync(string? name, int page, int size)
        {
            var productList = await _httpClient.GetAsync("objects");
            var contentString = await productList.Content.ReadAsStringAsync();
            var deSerilize = JsonSerializer.Deserialize<List<Product>>(contentString);
            var filterData = deSerilize!.Where(data => name ==null || data.Name!.Contains(name, StringComparison.OrdinalIgnoreCase));
            return filterData.Skip((page -1) * size).Take(size)?? Enumerable.Empty<Product>();
        }
    }
}
