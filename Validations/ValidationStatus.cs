
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Validations {
    public static class ValidationStatus {
        public static bool IsAguardandoPag(Venda venda, string msgStatus) {
            if(String.Equals(venda.Status, "Aguardando pagamento", StringComparison.InvariantCultureIgnoreCase) &&
                (String.Equals(msgStatus, "Pagamento Aprovado", StringComparison.InvariantCultureIgnoreCase)
                || String.Equals(msgStatus, "Cancelada", StringComparison.InvariantCultureIgnoreCase))) {

                return true;

            }

            return false;
        }

        public static bool IsPagAprovado(Venda venda, string msgStatus) {
            if(String.Equals(venda.Status, "Pagamento Aprovado", StringComparison.InvariantCultureIgnoreCase) &&
                (String.Equals(msgStatus, "Enviado para Transportadora", StringComparison.InvariantCultureIgnoreCase)
                || String.Equals(msgStatus, "Cancelada", StringComparison.InvariantCultureIgnoreCase))) {

                return true;

            }

            return false;
        }

        public static bool IsEnviadoTransp(Venda venda, string msgStatus) {
            if(String.Equals(venda.Status, "Enviado para Transportador", StringComparison.InvariantCultureIgnoreCase) &&
                String.Equals(msgStatus, "Entregue", StringComparison.InvariantCultureIgnoreCase)
                ) {

                return true;

            }

            return false;
        }
    }
}
