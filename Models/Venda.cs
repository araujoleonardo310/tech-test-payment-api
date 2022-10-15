using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models {
    public record Venda {
        public int IdVenda { get; init; }
        public Guid IdPedido { get; init; }
        public string Status { get; set; } 
        public Vendedor Vendedor { get; set; }
        public DateTime DataVenda { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}