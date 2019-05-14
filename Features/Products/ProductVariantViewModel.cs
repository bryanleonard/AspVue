namespace AspVue.Features.Products
{
    public class ProductVariantViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public int ColorId { get; set; }
        public string Color { get; set; }
        public int StorageId { get; set; }
        public string Capacity { get; set; }
        public decimal Price { get; set; }
    }
}