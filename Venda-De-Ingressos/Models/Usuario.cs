using System;

namespace Venda_De_Ingressos.Models {
    public class Usuario {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public string Senha { get; set; }
    }
}