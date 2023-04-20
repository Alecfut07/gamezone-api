using gamezone_api.Models;

namespace gamezone_api.Networking
{
    public class ProductResponse
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string? Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public virtual Condition Condition { get; set; }

        public virtual Edition Edition { get; set; }
    }
}
