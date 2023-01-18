using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDD.Presentation.Models
{
    public class CustomerVm
    {
        [Key]
        public int  Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preencha o campo Sobrenome")]
        [MaxLength(50, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preencha o campo Email")]
        [MaxLength(200, ErrorMessage = "Máximo de {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; } = string.Empty;

        [ScaffoldColumn(false)]
        public DateTime CreateAt { get; set; }

        public virtual IEnumerable<ProductVm>? Products { get; set; }

    }
}