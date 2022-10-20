using System.ComponentModel.DataAnnotations;

namespace CustomerWebAPI.Entities 
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string? Name { get; set; }

        

        [Required]
        [StringLength(50)]
        public string? Email { get; set; }

        [Required]
        public long Phone { get; set; }

        
        public string? ImageUrl { get; set; }
    }
}
