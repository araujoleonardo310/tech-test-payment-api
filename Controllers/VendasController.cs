using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Dtos;
using tech_test_payment_api.Extensions;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repositories;

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
        public IEnumerable<Venda> GetVendaStatus (string status) {
            var vendas = _repository.GetVendasPorStatus(status);
            return vendas;
        }
    }
}