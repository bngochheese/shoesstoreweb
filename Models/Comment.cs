using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShoesStoreWebsite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        // Foreign Key relationship with Movie model
        public int ShoesId { get; set; }
        [ForeignKey("ShoesId")]
        public Shoes Shoes { get; set; }
       

    }

}
