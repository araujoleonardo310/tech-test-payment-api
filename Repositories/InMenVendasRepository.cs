using System;
using System.Collections.Generic;
using System.Linq;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repositories {
    public class InMenVendasRepository {
        private readonly List<Venda> vendas = new()
            {
            new Venda {
                Id = Guid.NewGuid(),
                IdPedido = 101,
                Status = "Aguardando pagamento",
                Vendedor = new() {
                    Id = 25,
                    Nome = "Leo",
                    Cpf = "604154154",
                    Email = "testes@email.com",
                    Telefone = "897448747"
                },
                DataVenda = DateTime.Today,
                Produtos = new List<Produto>() { new Produto { Descricao = "Mesa", Preco = 6949.21M } }
            },
            new Venda {
                Id = Guid.NewGuid(),
                IdPedido = 101,
                Status = "Aguardando pagamento",
                Vendedor = new() {
                    Id = 25,
                    Nome = "Carlos",
                    Cpf = "604154154",
                    Email = "testes@email.com",
                    Telefone = "897448747"
                },
                DataVenda = DateTime.Today,
                Produtos = new List<Produto>() { new Produto { Descricao = "Mesa", Preco = 6949.21M } }
            },
            new Venda {
                Id = Guid.NewGuid(),
                IdPedido = 101,
                Status = "Aguardando pagamento",
                Vendedor = new() {
                    Id = 25,
                    Nome = "Pedro",
                    Cpf = "604154154",
                    Email = "testes@email.com",
                    Telefone = "897448747"
                },
                DataVenda = DateTime.Today,
                Produtos = new List<Produto>() { new Produto { Descricao = "Mesa", Preco = 6949.21M } }
            },
            new Venda {
                Id = Guid.NewGuid(),
                IdPedido = 101,
                Status = "Aguardando pagamento",
                Vendedor = new() {
                    Id = 25,
                    Nome = "Leo",
                    Cpf = "604154154",
                    Email = "testes@email.com",
                    Telefone = "897448747"
                },
                DataVenda = DateTime.Today,
                Produtos = new List<Produto>() { new Produto { Descricao = "Mesa", Preco = 6949.21M } }
            }


        };

        public IEnumerable<Venda> GetVendas() {
            return vendas;
        }

        public Venda GetVenda(Guid Id) {
            return vendas.Where(venda => venda.Id == Id).SingleOrDefault();
        }
    }
}
