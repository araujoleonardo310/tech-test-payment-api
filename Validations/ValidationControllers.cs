using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Validations {
    public static class ValidationControllers {
       
        public static bool IsValideTelef(string telefone) {

            Regex regexTelef = new(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$");

            if(regexTelef.Match(telefone).Success)
                return true;

            return false;
        }

        public static bool IsValideCPF(string cpf) {

            Regex regexCpf = new(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})");

            if(regexCpf.IsMatch(cpf))
                return true;

            return false;
        }

        public static bool IsAguardandoPag(Venda venda) {
            if(String.Equals(venda.Status, "aguardando pagamento", StringComparison.InvariantCultureIgnoreCase)
                )
                return true;

            return false;
        }


        // Validar se venda pode alterar status para "pag... aprovado" ou "cancelada"
        public static bool IsAguardandoPag(Venda venda, string msgStatus) {
            if(String.Equals(venda.Status, "aguardando pagamento", StringComparison.InvariantCultureIgnoreCase) &&
                (String.Equals(msgStatus, "pagamento aprovado", StringComparison.InvariantCultureIgnoreCase)
                || String.Equals(msgStatus, "cancelada", StringComparison.InvariantCultureIgnoreCase)))
                return true;

            return false;
        }

        // Validar se venda pode alterar status para "Envia... trans" ou "cancelada"
        public static bool IsPagAprovado(Venda venda, string msgStatus) {
            if(String.Equals(venda.Status, "pagamento aprovado", StringComparison.InvariantCultureIgnoreCase) &&
                (String.Equals(msgStatus, "enviado para transportadora", StringComparison.InvariantCultureIgnoreCase)
                || String.Equals(msgStatus, "cancelada", StringComparison.InvariantCultureIgnoreCase))) {

                return true;

            }

            return false;
        }

        // Validar se venda pode alterar status para "entregue"
        public static bool IsEnviadoTransp(Venda venda, string msgStatus) {
            if(String.Equals(venda.Status, "enviado para transportadora", StringComparison.InvariantCultureIgnoreCase) &&
                String.Equals(msgStatus, "entregue", StringComparison.InvariantCultureIgnoreCase)
                )
                return true;

            return false;
        }

        public static bool IsDeleteVenda(Venda venda) {
            if(String.Equals(venda.Status, "cancelada", StringComparison.InvariantCultureIgnoreCase) || String.Equals(venda.Status, "aguardando pagamento", StringComparison.InvariantCultureIgnoreCase)
                )
                return true;

            return false;
        }
    }
}
