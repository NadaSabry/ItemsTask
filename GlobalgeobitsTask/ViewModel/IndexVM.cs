using GlobalgeobitsTask.Models;

namespace GlobalgeobitsTask.ViewModel
{
    public class IndexVM
    {
        public IEnumerable<Item> Items { get; set; } = Enumerable.Empty<Item>();
        public int ItemID { get; set; }
        public decimal Price { get; set; }
    }
}
