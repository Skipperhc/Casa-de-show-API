using System.Collections;
using System.Collections.Generic;
using Venda_De_Ingressos.Models;
using Venda_De_Ingressos.Models.ViewModels.VendaViewModels;

namespace Venda_De_Ingressos.Repositories.Interface {
    public interface IVendaRepository : IRepository<Venda>{
        IEnumerable<VendaListagemViewModel> Listar();
    }
}