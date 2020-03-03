using System.Collections.Generic;
using Venda_De_Ingressos.Models;
using Venda_De_Ingressos.Models.ViewModels.EventoViewModels;

namespace Venda_De_Ingressos.Repositories.Interface {
    public interface IEventoRepository : IRepository<Evento> {
        IEnumerable<EventoListagemViewModel> Listar();
        IEnumerable<EventoListagemViewModel> ListarCapAsc();
        IEnumerable<EventoListagemViewModel> ListarCapDesc();
        IEnumerable<EventoListagemViewModel> ListarDataAsc();
        IEnumerable<EventoListagemViewModel> ListarDataDesc();
        IEnumerable<EventoListagemViewModel> ListarNomeAsc();
        IEnumerable<EventoListagemViewModel> ListarNomeDesc();
        IEnumerable<EventoListagemViewModel> ListarPrecoAsc();
        IEnumerable<EventoListagemViewModel> ListarPrecoDesc();


    }
}