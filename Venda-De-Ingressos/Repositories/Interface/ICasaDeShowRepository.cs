using System.Collections.Generic;
using Venda_De_Ingressos.Models;
using Venda_De_Ingressos.Models.ViewModels.CasaDeShowViewModels;

namespace Venda_De_Ingressos.Repositories.Interface {
    public interface ICasaDeShowRepository : IRepository<CasaDeShow> {
        bool Existe(int id);
        CasaDeShow BuscarNome(string Nome);
        IEnumerable<CasaDeShowListagemViewModel> Listar();
        IEnumerable<CasaDeShowListagemViewModel> ListarAsc();
        IEnumerable<CasaDeShowListagemViewModel> ListarDesc();
    }
}