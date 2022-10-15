using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Dtos {
	public class AtualizarVendaDto {
        [Required(ErrorMessage ="Status é obrigatório.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
             "Números e caracteres especiais não são permitidos.")]
        public string Status { get; set; }
    }
}
