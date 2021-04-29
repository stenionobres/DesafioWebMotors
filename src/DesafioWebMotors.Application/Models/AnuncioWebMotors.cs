using System.ComponentModel.DataAnnotations;

namespace DesafioWebMotors.Application.Models
{
    public class AnuncioWebMotors
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(45)]
        public string Marca { get; set; }

        [MaxLength(45)]
        public string Modelo { get; set; }

        [Required]
        [MaxLength(45)]
        public string Versao { get; set; }

        [Required]
        [Range(1900, int.MaxValue, ErrorMessage = "Por favor entre com um valor maior que {1}")]
        public int Ano { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Por favor entre com um valor maior que {1}")]
        public int Quilometragem { get; set; }

        [Required(ErrorMessage = "A observação é obrigatória")]
        public string Observacao { get; set; }
      
    }
}
