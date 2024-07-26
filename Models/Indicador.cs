using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Template_Desafio_Ods_Comunidades.Models
{
    public class Indicador
    {
        public int IdCodigoArquivo { get; set; }
        public int IdCodigoValor { get; set; }
    
        public double ValorIndicador { get; set; }
        public double Mediana { get; set; }
        public double DesvioPadrao { get; set; }
        public double LimiteSuperior { get; set; }
        public double LimiteInferior { get; set; }
        public int IdOds { get; set; }
        public string DescricaoOds { get; set; }
        
        [ForeignKey("Responsavel")]
        public string Email { get; set; }
        
        [ForeignKey("Secretaria")]
        public string SiglaSecretaria { get; set; }



    }
}
