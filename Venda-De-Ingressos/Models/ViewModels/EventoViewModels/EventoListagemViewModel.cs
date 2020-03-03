using System;

namespace Venda_De_Ingressos.Models.ViewModels.EventoViewModels {
    public class EventoListagemViewModel {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public DateTime Data { get; set; }
        public string CasaShowNome { get; set; }
        public int CasaDeShowId { get; set; }
        public int Capacidade { get; set; }
    }
}