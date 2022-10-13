using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models {
    public class Produto {
        public string Descricao { get; set; }
        public int QuantVenda { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}