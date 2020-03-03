using System;

namespace Venda_De_Ingressos.Models.UltilidadeFormatos {
    public class ResultadoDoComando {
        public ResultadoDoComando(string mensagem, object obj) {
            Mensagem = mensagem;
            Obj = obj;
        }
        
        public string Mensagem { get; set; }
        public Object Obj { get; set; }
    }
}