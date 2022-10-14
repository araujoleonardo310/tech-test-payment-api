using System.ComponentModel.DataAnnotations;

namespace tech_test_payment_api.Models {
    public class Vendedor {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome completo � obrigat�rio.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
             "N�meros e caracteres especiais n�o s�o permitidos no nome.")]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email v�lido...")]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }
    }
}