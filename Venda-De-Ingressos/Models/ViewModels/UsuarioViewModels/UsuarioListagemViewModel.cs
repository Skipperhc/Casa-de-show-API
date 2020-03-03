using System;

namespace Venda_De_Ingressos.Models.ViewModels.UsuarioViewModels {
    public class UsuarioListagemViewModel {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
    }
}