using System.ComponentModel.DataAnnotations;

namespace Farma24.Models
{
    public class RegisterView
    {
        [Required]
        public Morada Morada { get; set; }
        [Required]
        public Utilizador Utilizador { get; set;}
    }
}