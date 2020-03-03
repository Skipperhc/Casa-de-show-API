using System.Collections.Generic;
using Venda_De_Ingressos.Models;
using Venda_De_Ingressos.Models.ViewModels.UsuarioViewModels;

namespace Venda_De_Ingressos.Repositories.Interface {
    public interface IUsuarioRepository : IRepository<Usuario> {
        IEnumerable<UsuarioListagemViewModel> Listar();
    }
}