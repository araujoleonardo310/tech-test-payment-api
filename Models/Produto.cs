using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models {
    public class Produto {
        [Required]
        public string Descricao { get; set; }

        [Required]
        [Range(1, 100)]
        public int QuantVenda { get; set; }

        [Required]
        [Range(0.50, 50000)]
        public decimal PrecoUnitario { get; set; }
    }
}