﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Venda_De_Ingressos.Models.ViewModels.CasaDeShowViewModels {
    public class CasaDeShowCadastroViewModel {
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [MinLength(3, ErrorMessage = "Deve ter ao menos {1}")]
        [MaxLength(60, ErrorMessage = "Deve ter no máximo {1}")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string Endereco { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [MinLength(3, ErrorMessage = "Deve ter ao menos {1}")]
        [MaxLength(10000, ErrorMessage = "Deve ter no máximo {1}")]
        public int Capacidade { get; set; }
    }
}