
﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
        public bool Active { get; internal set; }
    }
}
