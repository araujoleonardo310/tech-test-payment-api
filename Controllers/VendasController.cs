using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<Venda> GetVendas() {
            var vendas = _repository.GetVendas();
            return vendas;
        }
        /// <summary>
        /// Busca a venda pelo seu id
        /// </summary>
        /// <param name="idVenda"></param>
        /// <returns>Object or NotFound()</returns>
        [HttpGet("{idVenda}")]
        public ActionResult<Venda> GetVenda(Guid idVenda) {
            var venda = _repository.GetVenda(idVenda);
            if(venda is null) {
                return NotFound();
            }
            return Ok(venda);
        }
    }
}