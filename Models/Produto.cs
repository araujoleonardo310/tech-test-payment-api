using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models {
    public class Produto {
        [Required(ErrorMessage = "Descri��o � obrigat�rio.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Quantidade de venda � obrigat�rio.")]
        [Range(1, 100, ErrorMessage = "Quantidade de venda dever� ser 1 ou menor igual a 100")]
        public int QuantVenda { get; set; }

        [Required(ErrorMessage = "Pre�o Unit�rio � obrigat�rio.")]
        [Range(0.50, 50000, ErrorMessage = "O pre�o dever� ser entre R$0.50 e R$50.000,00")]
        public decimal PrecoUnitario { get; set; }
    }
}