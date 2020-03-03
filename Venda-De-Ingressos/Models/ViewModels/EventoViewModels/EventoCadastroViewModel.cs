using System;

namespace Venda_De_Ingressos.Models.ViewModels.EventoViewModels {
    public class EventoCadastroViewModel {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public DateTime Data { get; set; }
        public int CasaDeShowId { get; set; }
    }
}