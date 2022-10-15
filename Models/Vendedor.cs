using System.ComponentModel.DataAnnotations;

namespace tech_test_payment_api.Models {
    public class Vendedor {

        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
             "Números e caracteres especiais não são permitidos.")]
        public string Nome { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }
    }
}