using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Venda_De_Ingressos.Models {
    public class Vendas {
        public int Id { get; set; }
        public double Preco { get; set; }
        public Evento Evento { get; set; }
        public int EventoId { get; set; }
        public int QtdIngressos { get; set; }
    }
}
