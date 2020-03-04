using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.CompilerServices;

namespace Venda_De_Ingressos.Models.ViewModels.EventoViewModels {
    public class EventoCadastroViewModel {
        
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [MinLength(3, ErrorMessage = "Deve ter ao menos {1}")]
        [MaxLength(60, ErrorMessage = "Deve ter no máximo {1}")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Range(3,5000, ErrorMessage = "O campo {0} aceita numeros de {1} até {2}")]
        [Display(Name="Preço")]
        public double Preco { get; set; }
        
        [Required(ErrorMessage = "{0} Requerida")]
        [DataType(DataType.Date)]
        [Display(Name="Data")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Range(3,10000, ErrorMessage = "O campo {0} aceita numeros de {1} até {2}")]
        [Display(Name="Id da casa de show")]
        public int CasaDeShowId { get; set; }
    }
}