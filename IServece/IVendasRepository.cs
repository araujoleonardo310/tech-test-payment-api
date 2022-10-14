using System;
using System.Collections.Generic;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repositories {
    public interface IVendasRepository {
        Venda GetVenda(Guid idVenda);
        IEnumerable<Venda> GetVendas();
        IEnumerable<Venda> GetVendasPorStatus(string status);
        void AdicionarVenda(Venda venda);
        void AtualizarStatusVenda(Venda newStatusVenda);
        void AtualizarProdutos(Venda newVenda);
        void AtualizarVendedor(Venda venda);
        void DeletarVenda(Guid IdVenda);

    }
}