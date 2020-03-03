using Microsoft.AspNetCore.Mvc;
using Venda_De_Ingressos.Models.UltilidadeFormatos;

namespace Venda_De_Ingressos.Ultilidade {
    public static class RespostaFormato {
        public static ObjectResult GerarResultado(string mensagem, object obj = null) {
            return new ObjectResult(new ResultadoDoComando(mensagem, obj));
        }
    }
}