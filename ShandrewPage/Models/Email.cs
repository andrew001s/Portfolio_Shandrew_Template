using System.ComponentModel.DataAnnotations;

namespace ShandrewPage.Models
{
    public class Email
    {
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Required Field/Campo Requerido")]
        public string? Name { get; set; }
        [EmailAddress]
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Required Field/Campo Requerido")]
        public string? EmailAddress { get; set; }
        [StringLength(50, MinimumLength = 5)]
        [Required(ErrorMessage = "Required Field/Campo Requerido")]
        public string? Subject { get; set; }
        [StringLength(50, MinimumLength = 20)]
        [Required(ErrorMessage = "Required Field/Campo Requerido")]
        public string? Message { get; set; }
    }
}
