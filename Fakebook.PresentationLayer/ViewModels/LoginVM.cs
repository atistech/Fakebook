using System.ComponentModel.DataAnnotations;

namespace Fakebook.PresentationLayer.Areas.Member.ViewModels
{
    public class LoginVM
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}