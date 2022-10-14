using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Validations {
    public static class ValidationProdutos {
        public static bool IsAguardandoPag(Venda venda) {
            if(String.Equals(venda.Status, "Aguardando pagamento", StringComparison.InvariantCultureIgnoreCase)
                ) {

                return true;
            }

            return false;
        }
    }
}
