using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos
{
    public class AnnouncementDtoUpdate
    {
        [Required(ErrorMessage = "Marca é campo obrigatório.")]
        [StringLength(45, ErrorMessage = "Marca deve ter no máximo {1} caracteres.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Modelo é campo obrigatório.")]
        [StringLength(45, ErrorMessage = "Modelo deve ter no máximo {1} caracteres.")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Versão é campo obrigatório.")]
        [StringLength(45, ErrorMessage = "Versão deve ter no máximo {1} caracteres.")]
        public string Version { get; set; }
        
        [Required(ErrorMessage = "Year é campo obrigatório.")]
        public int Year { get; set; }
        
        [Required(ErrorMessage = "Quilometragem é campo obrigatório.")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "Observação é campo obrigatório.")]
        public string Note { get; set; }
      
    }
}
