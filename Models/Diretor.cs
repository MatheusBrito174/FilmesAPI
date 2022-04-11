using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Diretor
    {
        [Key]
        [Required(ErrorMessage = "required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "required")]
        [Display(Name = "nome")]
        public string Nome { get; set; }

        [Display(Name = "dataNascimento")]
        public DateOnly DataNascimento { get; set; }
    }
}
