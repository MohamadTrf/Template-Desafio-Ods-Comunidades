
﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Template_Desafio_Ods_Comunidades.Models
{
    public class Responsavel
    {
        [Key]
        public string Email { get; set; }
        

        [Required(ErrorMessage = "O Nome do Responsável é obrigatório.")]
        public string Nome {get; set;}

        [Required(ErrorMessage = "O Celular do Responsável é obrigatório.")]
        public string Celular {get; set;}

       [ForeignKey("Secretaria")]
        public string SiglaSecretaria { get; set; }

        public Boolean Ativo { get; set; }
    }
        
}
