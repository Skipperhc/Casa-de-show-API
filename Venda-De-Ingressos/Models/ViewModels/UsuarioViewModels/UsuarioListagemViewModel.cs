using System;
using System.ComponentModel.DataAnnotations;

namespace Venda_De_Ingressos.Models.ViewModels.UsuarioViewModels {
    public class UsuarioListagemViewModel {
        
        [Required(ErrorMessage = "O campo {0} é requerido")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [MinLength(3, ErrorMessage = "Deve ter ao menos {1}")]
        [MaxLength(60, ErrorMessage = "Deve ter no máximo {1}")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [MinLength(3, ErrorMessage = "Deve ter ao menos {1}")]
        [MaxLength(60, ErrorMessage = "Deve ter no máximo {1}")]
        [EmailAddress(ErrorMessage = "Insira um email válido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "{0} Requerida")]
        [DataType(DataType.Date)]
        [Display(Name="Data de nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Nascimento { get; set; }
    }
}