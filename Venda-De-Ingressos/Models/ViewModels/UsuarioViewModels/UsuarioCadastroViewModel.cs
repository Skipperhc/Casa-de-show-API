using System;

namespace Venda_De_Ingressos.Models.ViewModels.UsuarioViewModels {
    public class UsuarioCadastroViewModel {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public string Senha { get; set; }
    }
}