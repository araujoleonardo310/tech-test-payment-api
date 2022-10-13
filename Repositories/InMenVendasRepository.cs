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
                IdPedido = Guid.NewGuid(),
                Status = "Aguardando pagamento",
                Vendedor = new() {
                    Id = 25,
                    Nome = "Leo",
                    Cpf = "604154154",
                    Email = "testes@email.com",
                    Telefone = "897448747"
                },
                DataVenda = DateTime.Today,
                Produtos = new List<Produto>() { 
                    new Produto { 
                        Descricao = "TV 40°",
                        QuantVenda = 1,
                        PrecoUnitario = 2500.99M 
                    } 
                }
            },
            new Venda {
                Id = Guid.NewGuid(),
                IdPedido = Guid.NewGuid(),
                Status = "Aguardando pagamento",
                Vendedor = new() {
                    Id = 25,
                    Nome = "Carlos",
                    Cpf = "604154154",
                    Email = "testes@email.com",
                    Telefone = "897448747"
                },
                DataVenda = DateTime.Today,
                Produtos = new List<Produto>() { 
                    new Produto { 
                        Descricao = "",
                        QuantVenda = 1,
                        PrecoUnitario = 6949.21M 
                    } 
                }
            },
            new Venda {
                Id = Guid.NewGuid(),
                IdPedido = Guid.NewGuid(),
                Status = "Aguardando pagamento",
                Vendedor = new() {
                    Id = 25,
                    Nome = "Pedro",
                    Cpf = "604154154",
                    Email = "testes@email.com",
                    Telefone = "897448747"
                },
                DataVenda = DateTime.Today,
                Produtos = new List<Produto>() { 
                    new Produto { 
                        Descricao = "Mesa",
                        QuantVenda = 1,
                        PrecoUnitario = 300.50M
                    } 
                }
            },
            new Venda {
                Id = Guid.NewGuid(),
                IdPedido = Guid.NewGuid(),
                Status = "Aguardando pagamento",
                Vendedor = new() {
                    Id = 25,
                    Nome = "Leo",
                    Cpf = "604154154",
                    Email = "testes@email.com",
                    Telefone = "897448747"
                },
                DataVenda = DateTime.Today,
                Produtos = new List<Produto>() { 
                    new Produto { 
                        Descricao = "Mesa", 
                        QuantVenda = 2,
                        PrecoUnitario = 300.50M 
                    } 
                }
            }
        };

        public IEnumerable<Venda> GetVendas() {
            return vendas;
        }

    }
}
