using System;

namespace Venda_De_Ingressos.Models {
    public class Evento {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public DateTime Data { get; set; }
        public CasaDeShow CasaDeShow { get; set; }
        public int CasaDeShowId { get; set; }
    }
}