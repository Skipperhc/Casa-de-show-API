using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Venda_De_Ingressos.Models.ViewModels.VendaViewModels {
    public class VendaListagemViewModel {

        [Required(ErrorMessage = "O campo {0} é requerido")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Range(3, 5000, ErrorMessage = "O campo {0} aceita numeros de {1} até {2}")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        public int EventoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [Range(1,10,ErrorMessage = "O campo {0} tem de ter no minimo {1} e no máximo {2}")]
        public int QtdIngressos { get; set; }
    }
}
