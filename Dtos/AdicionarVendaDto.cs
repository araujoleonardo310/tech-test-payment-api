﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Dtos {
    public record AdicionarVendaDto {
        [Required]
        public Vendedor Vendedor { get; set; }

        [Required]
        public List<Produto> Produtos { get; set; }
    }
}
