using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Dtos {
    public record VendaDto {
        public int IdVenda { get; set; }
        public Guid IdPedido { get; init; }
        public string Status { get; set; }
        public Vendedor Vendedor { get; set; }
        public DateTime DataVenda { get; set; }
        public List<Produto> Produtos { get; set; }

    }
}
