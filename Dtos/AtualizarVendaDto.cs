using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Dtos {
	public class AtualizarVendaDto {
        [Required(ErrorMessage ="Status de venda é obrigatório.")]
        public string Status { get; set; }
    }
}
