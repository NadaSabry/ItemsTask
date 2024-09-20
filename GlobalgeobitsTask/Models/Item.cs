using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobalgeobitsTask.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        [MaxLength(100)]
        public string ItemName { get; set; }
        [MaxLength(10)]
        public string Brand { get; set; }
        [MaxLength(10)]
        public string model { get; set; }
        [MaxLength(10)]
        public string Color { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal Price { get; set; }
    }
}
