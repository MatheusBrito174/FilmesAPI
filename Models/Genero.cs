using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Genero
    {
        [Key]
        [Required(ErrorMessage = "required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "length")]
        [RegularExpression("^[A-Z_]+$", ErrorMessage = "regexCodigo")]
        [Display(Name = "codigo")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "required")]
        [Display(Name = "nome")]
        public string Nome { get; set; }

        [StringLength(150, MinimumLength = 10, ErrorMessage = "length")]
        [Display(Name = "descricao")]
        public string Descricao { get; set; }
    }
}
