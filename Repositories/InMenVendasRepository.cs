using System;
using System.Collections.Generic;
using System.Linq;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repositories {
    public class InMenVendasRepository : IVendasRepository {

        private readonly List<Venda> vendas = new()
            {
            new Venda {
                IdVenda = Guid.NewGuid(),
                IdPedido = Guid.NewGuid(),
                Status = "Aguardando pagamento",
                Vendedor = new() {
                    Id = 1,
                    Nome = "Mariana",
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
                    },
                     new Produto {
                        Descricao = "Escova Secadora Cadence Sublime 4x1 Branca - 127v",
                        QuantVenda = 2,
                        PrecoUnitario = 109.99M
                    }
                }
            },
            new Venda {
                IdVenda = Guid.NewGuid(),
                IdPedido = Guid.NewGuid(),
                Status = "Aguardando pagamento",
                Vendedor = new() {
                    Id = 2,
                    Nome = "Carlos",
                    Cpf = "604154154",
                    Email = "testes@email.com",
                    Telefone = "897448747"
                },
                DataVenda = DateTime.Today,
                Produtos = new List<Produto>() {
                    new Produto {
                        Descricao = "Refrigerador Electrolux Cycle Defrost 260 Litros Branco DC35A 220 Volts",
                        QuantVenda = 1,
                        PrecoUnitario = 1885.30M
                    },
                    new Produto {
                        Descricao = "Micro-ondas Electrolux MTD30",
                        QuantVenda = 1,
                        PrecoUnitario = 512.05M
                    },
                    new Produto {
                        Descricao = "Micro-ondas Electrolux MTD30",
                        QuantVenda = 1,
                        PrecoUnitario = 512.05M
                    }
                }
            },
            new Venda {
                IdVenda = Guid.NewGuid(),
                IdPedido = Guid.NewGuid(),
                Status = "Aguardando pagamento",
                Vendedor = new() {
                    Id = 3,
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
                    },
                    new Produto {
                        Descricao = "Smartphone Samsung Galaxy A03 64GB 4GB RAM Processador Octa Core 48MP + 2MP 5MP Tela Infinita de 6.5\" Dual Chip Android - Preto",
                        QuantVenda = 1,
                        PrecoUnitario = 779.99M
                    }
                }
            },
            new Venda {
                IdVenda = Guid.NewGuid(),
                IdPedido = Guid.NewGuid(),
                Status = "Aguardando pagamento",
                Vendedor = new() {
                    Id = 4,
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

        // GET/vendas
        public IEnumerable<Venda> GetVendas() {
            return vendas;
        }

        // GET/vendas/{idVenda}
        public Venda GetVenda(Guid idVenda) {
            return vendas.Where(v => v.IdVenda == idVenda).SingleOrDefault();
        }

        // GET/vendas/{status}
        public IEnumerable<Venda> GetVendasPorStatus(string status) {
            return vendas.Where(v => v.Status == status);
        }

        // POST/vendas/{venda}
        public void AdicionarVenda(Venda venda) {
            vendas.Add(venda);
        }

        // PUT/vendas/Status/{status}
        public void AtualizarStatusVenda(Venda newStatusVenda) {
            var vendaIndex = vendas.FindIndex(v => v.IdVenda == newStatusVenda.IdVenda);
            vendas[vendaIndex] = newStatusVenda;
        }

        // DELETE/vendas/{idVenda}
        public void DeletarVenda(Guid IdVenda) {
            var vendaIndex = vendas.FindIndex(v => v.IdVenda == IdVenda);
            vendas.RemoveAt(vendaIndex);
        }

        // PUT/vendas/Produtos/{idVenda}
        public void AtualizarProdutos(Venda newVenda) {
            var vendaIndex = vendas.FindIndex(v => v.IdVenda == newVenda.IdVenda);
            vendas[vendaIndex] = newVenda;
        }

        // PUT/vendas/Vendedor/{idVenda}
        public void AtualizarVendedor(Venda venda) {
            var vendaIndex = vendas.FindIndex(v => v.IdVenda == venda.IdVenda);
            vendas[vendaIndex] = venda;
        }
    }
}
