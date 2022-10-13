using System;
using System.Collections.Generic;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repositories {
    public interface IVendasRepository {
        Venda GetVenda(Guid idVenda);
        IEnumerable<Venda> GetVendas();
    }
}