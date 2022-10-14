using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Dtos;
using tech_test_payment_api.Extensions;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repositories;
using tech_test_payment_api.Validations;

namespace tech_test_payment_api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class VendasController : ControllerBase {
        private readonly IVendasRepository _repository;

        public VendasController(IVendasRepository vendasRepository) {
            this._repository = vendasRepository;
        }

        /// <summary>
        /// Retorna todas as vendas
        /// </summary>
        /// <returns>object</returns>
        [HttpGet]
        public IEnumerable<VendaDto> GetVendas() {
            var vendas = _repository.GetVendas().Select(v => v.AsDto());
            return vendas;
        }
        /// <summary>
        /// Busca a venda pelo seu id
        /// </summary>
        /// <param name="idVenda"></param>
        /// <returns>Object or NotFound()</returns>
        [HttpGet("{idVenda}")]
        public ActionResult<VendaDto> GetVenda(Guid idVenda) {
            var venda = _repository.GetVenda(idVenda).AsDto();
            if(venda is null) {
                return NotFound();
            }
            return Ok(venda);
        }

        /// <summary>
        /// Busca de vendas por status
        /// </summary>
        /// <param name="status"></param>
        /// <returns>object</returns>
        [HttpGet("status/{status}")]
        public IEnumerable<Venda> GetVendaStatus(string status) {
            var vendas = _repository.GetVendasPorStatus(status);
            return vendas;
        }

        [HttpPost]
        public ActionResult<VendaDto> AddVenda(AdicionarVendaDto vendaDto) {

            // buscar ultimo registro para calcular novo ID ao vendedor
            var ultimoRegistroDeVenda = _repository.GetVendas().Last().AsDto();

            Venda newVenda =
                new() {
                    IdVenda = Guid.NewGuid(),
                    IdPedido = Guid.NewGuid(),
                    Status = "Aguardando pagamento",
                    Vendedor = new() {
                        Id = ultimoRegistroDeVenda.Vendedor.Id + 1,
                        Nome = vendaDto.Vendedor.Nome,
                        Cpf = vendaDto.Vendedor.Cpf,
                        Email = vendaDto.Vendedor.Email,
                        Telefone = vendaDto.Vendedor.Telefone
                    },
                    DataVenda = DateTime.Today,
                    Produtos = vendaDto.Produtos
                };

            _repository.AdicionarVenda(newVenda);
            return CreatedAtAction(nameof(GetVenda), new { IdVenda = newVenda.IdVenda }, newVenda.AsDto());
        }

        [HttpPut("{idVenda}")]
        public ActionResult AtualizarStatus(Guid idVenda, AtualizarVendaDto newStatusVenda) {

            var vendaIndex = _repository.GetVenda(idVenda);

            if(vendaIndex is null) {
                return NotFound();
            }

            /* Atualizar status de acordo com a condição de status atual
             * usando switch para evitar entrar em cada condição if
             */
            switch(vendaIndex.Status.ToLower()) {

            case "aguardando pagamento":

                if(ValidationStatus.IsAguardandoPag(vendaIndex, newStatusVenda.Status)) {
                    Venda updateVenda = vendaIndex with {
                        Status = newStatusVenda.Status
                    };
                    _repository.AtualizarStatusVenda(updateVenda);
                }

                break;

            case "pagamento aprovado":
                if(ValidationStatus.IsPagAprovado(vendaIndex, newStatusVenda.Status)) {
                    Venda updateVenda = vendaIndex with {
                        Status = newStatusVenda.Status
                    };
                    _repository.AtualizarStatusVenda(updateVenda);

                }

                break;
            case "enviado para transportador":
                if(ValidationStatus.IsEnviadoTransp(vendaIndex, newStatusVenda.Status)) {
                    Venda updateVenda = vendaIndex with {
                        Status = newStatusVenda.Status
                    };
                    _repository.AtualizarStatusVenda(updateVenda);

                }

                break;

            default:
                break;
            }

            var httpResp = Content($"Venda {idVenda} atualizada com sucesso.");
            httpResp.StatusCode = 200;

            return httpResp;
        }

        [HttpDelete("{idVenda}")]
        public ActionResult<Venda> DeletarVenda(Guid idVenda) {
            var vendaIndex = _repository.GetVenda(idVenda);
            if(vendaIndex is null) {
                return NotFound();
            }

            var httpResp = Content($"Venda {idVenda} deletada com sucesso.");
            httpResp.StatusCode = 200;

            if(!ValidationStatus.IsCancelado(vendaIndex)) {
                httpResp = Content($"Não permitido. Venda com status: {vendaIndex.Status}");
                httpResp.StatusCode = 500;

                return httpResp;
            }

            _repository.DeletarVenda(idVenda);
            return httpResp;
        }
    }
}