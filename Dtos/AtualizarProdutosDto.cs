using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Dtos {
    public class AtualizarProdutosDto { 
        public List<Produto> Produtos { get; set; }
    }
}
