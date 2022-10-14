using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace tech_test_payment_api.Validations {
    public static class ValidationCPF {
        public static bool IsCPFValido(string cpf) {

            Regex regexCpf = new Regex(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})");

            if(regexCpf.Match(cpf).Success) return true;

            return false;
        }
    }
}
