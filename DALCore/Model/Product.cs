using DALCore.Base;

namespace DALCore.Model
{
    public class Product:BaseEntity
    {
        public string? Name { get; set; }
        public string? Data { get; set; }
    }
}
