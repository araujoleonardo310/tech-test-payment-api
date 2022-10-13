using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models {
    public class Produto {
        [Required(ErrorMessage = "Descri��o � obrigat�rio.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Quantidade � obrigat�rio.")]
        [Range(1, 100)]
        public int QuantVenda { get; set; }

        [Required(ErrorMessage = "Pre�o Unit�rio � obrigat�rio.")]
        [Range(0.50, 50000)]
        public decimal PrecoUnitario { get; set; }
    }
}