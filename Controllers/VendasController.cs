using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repositories;

namespace tech_test_payment_api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class VendasController : ControllerBase {
        private readonly InMenVendasRepository _repository;

        public VendasController() {
            _repository = new InMenVendasRepository();
        }

        [HttpGet]
        public IEnumerable<Venda> GetVendas() {
            var vendas = _repository.GetVendas();
            return vendas;
        }
    }
}