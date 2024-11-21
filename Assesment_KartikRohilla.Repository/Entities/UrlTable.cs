using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment_KartikRohilla.Infrastructure.Entities
{
    [Table("UrlTable")]
    public class UrlTable
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string LongUrl { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ShortUrl { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
