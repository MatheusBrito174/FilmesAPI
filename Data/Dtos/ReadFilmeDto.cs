using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class ReadFilmeDto
    {
        [Key]
        [Required(ErrorMessage = "required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "required")]
        [Display(Name = "titulo")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "required")]
        [Display(Name = "diretor")]
        public string Diretor { get; set; }

        [Display(Name = "genero")]
        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "range")]
        [Display(Name = "duracao")]
        public int Duracao { get; set; }

        public DateTime HoraDaConsulta => DateTime.Now;
    }
}
