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
        /// Retorna todas as vendas.
        /// </summary>
        /// <returns>string de status Http</returns>
        [HttpGet]
        public IEnumerable<VendaDto> GetVendas() {
            var vendas = _repository.GetVendas().Select(v => v.AsDto());
            return vendas;
        }

        /// <summary>
        /// Busca a venda pelo seu id
        /// </summary>
        /// <param name="idVenda"></param>
        /// <returns>string de status Http</returns>
        [HttpGet("venda/{idVenda}")]
        public ActionResult<VendaDto> GetVenda(int idVenda) {

            var venda = _repository.GetVenda(idVenda);

            if(venda is null) {
                return NotFound();
            }

            return Ok(venda.AsDto());
        }

        /// <summary>
        /// Busca de vendas por status
        /// </summary>
        /// <param name="status"></param>
        /// <returns>string de status Http</returns>
        [HttpGet("vendas-status/{status}")]
        public IEnumerable<Venda> GetVendaStatus(string status) {

            var vendas = _repository.GetVendasPorStatus(status);
            return vendas;
        }

        /// <summary>
        /// Adiciona nova venda a API.
        /// </summary>
        /// <param name="vendaDto"></param>
        /// <returns>string de status Http</returns>
        [HttpPost("venda/adicionar")]
        public ActionResult<VendaDto> AdicionarVenda(AdicionarVendaDto vendaDto) {

            var httpResp = Content("");

            if(!ValidationControllers.IsValideTelef(vendaDto.Vendedor.Telefone)) {

                httpResp = Content($"Vendedor {vendaDto.Vendedor.Nome} está com Telefone incorreto.");
                httpResp.StatusCode = 400;

                return httpResp;
            }

            if(!ValidationControllers.IsValideCPF(vendaDto.Vendedor.Cpf)) {

                httpResp = Content($"Vendedor {vendaDto.Vendedor.Nome} está com CPF incorreto.");
                httpResp.StatusCode = 400;

                return httpResp;
            }

            // buscar ultimo registro para calcular novo ID ao vendedor
            var ultimoRegistroDeVenda = _repository.GetVendas().Last().AsDto();

            Venda newVenda =
                new() {
                    IdVenda = ultimoRegistroDeVenda.IdVenda + 1,
                    IdPedido = Guid.NewGuid(),
                    Status = "aguardando pagamento",
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

        /// <summary>
        /// Atualiza status de uma venda.
        /// </summary>
        /// <param name="idVenda"></param>
        /// <param name="newStatusVenda"></param>
        /// <returns>string de status Http</returns>
        [HttpPut("venda/atualizar-status/{idVenda}")]
        public ActionResult AtualizarStatus(int idVenda, AtualizarVendaDto newStatusVenda) {

            var vendaIndex = _repository.GetVenda(idVenda);

            if(vendaIndex is null) {
                return NotFound();
            }

            var httpResp = Content($"Venda {idVenda} atualizada com sucesso.");
            httpResp.StatusCode = 200;


            /* Atualizar status de acordo com a condição de status atual
             * o switch evita entrar em cada condição if
             */
            switch(vendaIndex.Status.ToLower()) {

            case "aguardando pagamento":

                if(ValidationControllers.IsAguardandoPag(vendaIndex, newStatusVenda.Status)) {
                    Venda updateVenda = vendaIndex with {
                        Status = newStatusVenda.Status.ToLower()
                    };
                    _repository.AtualizarStatusVenda(updateVenda);
                }

                break;

            case "pagamento aprovado":
                if(ValidationControllers.IsPagAprovado(vendaIndex, newStatusVenda.Status)) {
                    Venda updateVenda = vendaIndex with {
                        Status = newStatusVenda.Status.ToLower()
                    };
                    _repository.AtualizarStatusVenda(updateVenda);

                }

                break;
            case "enviado para transportador":
                if(ValidationControllers.IsEnviadoTransp(vendaIndex, newStatusVenda.Status)) {
                    Venda updateVenda = vendaIndex with {
                        Status = newStatusVenda.Status.ToLower()
                    };
                    _repository.AtualizarStatusVenda(updateVenda);

                }

                break;

            default:
                break;
            }


            return httpResp;
        }

        /// <summary>
        /// Atualiza a lista de produtos de uma venda.
        /// </summary>
        /// <param name="idVenda"></param>
        /// <param name="newProdutos"></param>
        /// <returns>string de status Http</returns>
        [HttpPut("venda/atualizar-produtos/{idVenda}")]
        public ActionResult AtualizarProdutos(int idVenda, AtualizarProdutosDto newProdutos) {
            var vendaIndex = _repository.GetVenda(idVenda);

            if(vendaIndex is null) {
                return NotFound();
            }

            var httpResp = Content($"Produtos de Venda {idVenda} atualizados com sucesso.");
            httpResp.StatusCode = 200;

            if(!ValidationControllers.IsAguardandoPag(vendaIndex)) {
                httpResp = Content($"Não permitido. Venda com status: {vendaIndex.Status}");
                httpResp.StatusCode = 500;

                return httpResp;
            }

            Venda vendaProdutos = vendaIndex with {
                Produtos = newProdutos.Produtos
            };
            _repository.AtualizarStatusVenda(vendaProdutos);



            return httpResp;
        }

        /// <summary>
        /// Atualiza os dados de vendedor de uma venda.
        /// </summary>
        /// <param name="idVenda"></param>
        /// <param name="vendedorDto"></param>
        /// <returns>string de status Http</returns>
        [HttpPut("venda/atualizar-vendedor/{idVenda}")]
        public ActionResult AtualizarVendedor(int idVenda, AtualizarVendedorDto vendedorDto) {
            var vendaIndex = _repository.GetVenda(idVenda);

            if(vendaIndex is null) {
                return NotFound();
            }
            var httpResp = Content($"Produtos de Venda {idVenda} atualizados com sucesso.");


            if(!ValidationControllers.IsValideCPF(vendedorDto.vendedor.Cpf)) {
                httpResp = Content($"Vendedor {vendedorDto.vendedor.Nome} está com CPF incorreto.");
                httpResp.StatusCode = 400;

                return httpResp;
            }

            httpResp.StatusCode = 200;

            if(!ValidationControllers.IsAguardandoPag(vendaIndex)) {
                httpResp = Content($"Não permitido. Venda com status: {vendaIndex.Status}");
                httpResp.StatusCode = 500;

                return httpResp;
            }

            Venda vendaProdutos = vendaIndex with {
                Vendedor = vendedorDto.vendedor
            };
            _repository.AtualizarStatusVenda(vendaProdutos);

            return httpResp;
        }

        /// <summary>
        /// Deleta uma venda.
        /// </summary>
        /// <param name="idVenda"></param>
        /// <returns>string de status Http</returns>
        [HttpDelete("venda/deletar-venda/{idVenda}")]
        public ActionResult<Venda> DeletarVenda(int idVenda) {
            var vendaIndex = _repository.GetVenda(idVenda);
            if(vendaIndex is null) {
                return NotFound();
            }

            var httpResp = Content($"Venda {idVenda} deletada com sucesso.");
            httpResp.StatusCode = 200;

            if(!ValidationControllers.IsCancelado(vendaIndex)) {
                httpResp = Content($"Não permitido. Venda com status: {vendaIndex.Status}");
                httpResp.StatusCode = 500;

                return httpResp;
            }

            _repository.DeletarVenda(idVenda);
            return httpResp;
        }
    }
}