using System.ComponentModel.DataAnnotations;

namespace CustomerWebAPI.Dto
{
    public class CustomerDto
    {
       

        [Required]
        [StringLength(30)]
        public string? Name { get; set; }



        [Required]
        [StringLength(50)]
        public string? Email { get; set; }

        [Required]
        public long Phone { get; set; }

        [Required]
        public string? ImageUrl { get; set; }
    }
}
