

namespace ProductsManager.Core.Entites
{
    public class Product
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? EntryDate { get; set; }

        public int Cost { get; set; }

        public int Units { get; set; }
        public int StoreNumber { get; set; }

        public string? Dispatcher { get; set; }

    }
}
