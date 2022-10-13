using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public record Venda
    {
        public Guid Id { get; init; }
        public int IdPedido { get; set; }
        public string Status { get; set; }
        public Vendedor Vendedor { get; set; }
        public DateTime DataVenda { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}