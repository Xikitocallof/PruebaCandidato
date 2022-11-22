using System.Xml.Serialization;

namespace Catalog.Models
{
    public class ProductosModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; } 
    }
}
