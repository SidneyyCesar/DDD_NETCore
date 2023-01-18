using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DDD.Presentation.Models
{
    public class ProductVm
    {
        public ProductVm()
        {
            this.Customer = new CustomerVm();
        }
        [Key]
        public int  Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo de {0} caracteres")]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "99999999999")]
        [Required(ErrorMessage = "Preencha o campo Valor")]
        public decimal Value { get; set; }

        [DisplayName("Disponível")]
        public bool Avaliable { get; set; }
        public int CustomerId { get; set; }
        public virtual CustomerVm Customer { get; set; }

    }
}