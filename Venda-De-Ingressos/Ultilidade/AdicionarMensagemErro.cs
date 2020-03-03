using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Venda_De_Ingressos.Ultilidade {
    public static class AdicionarMensagemErro {
        public static List<string> ListarErros(this ModelStateDictionary modelstate) {
            return modelstate
                   .Values.SelectMany(mensagens => mensagens.Errors)
                   .Select(mensagens => mensagens.ErrorMessage + " " + mensagens.Exception).ToList();
        }
    }
}