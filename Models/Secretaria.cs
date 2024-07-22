
﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Template_Desafio_Ods_Comunidades.Models
{
    public class Secretaria
    {
        [Key]
        public string SiglaSecretaria { get; set; }
        

        [Required(ErrorMessage = "O Nome da Secretaria é obrigatório.")]
        public string NomeSecretaria {get; set;}
        
    }
}
