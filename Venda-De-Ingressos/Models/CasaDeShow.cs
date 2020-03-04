using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Venda_De_Ingressos.Models {
    public class CasaDeShow {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Capacidade { get; set; }
        [IgnoreDataMember]
        public IEnumerable<Evento> Eventos { get; set; }
    }
}