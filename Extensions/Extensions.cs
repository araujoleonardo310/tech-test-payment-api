using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Dtos;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Extensions {
    public static class Extensions {
        public static VendaDto AsDto(this Venda venda) {
            return new VendaDto {
                IdVenda = venda.IdVenda,
                IdPedido = venda.IdPedido,
                DataVenda = venda.DataVenda,
                Status = venda.Status,
                Vendedor = venda.Vendedor,
                Produtos = venda.Produtos
            };
        }
    }
}
