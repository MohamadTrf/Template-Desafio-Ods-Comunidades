using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Template_Desafio_Ods_Comunidades.Models
{
    //essa classe precisa refletir todo o seu banco de dados para o ORM fazer o relacionamento das tabelas com o banco de dados
    public class Oligarquia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOligarquia { get; set; }

        public string TipoBase { get; set; }

        public string Sigla { get; set; }

        public string Nome { get; set; }

        public int QuantidadeBases { get; set; }

        public int QuantidadeRegistros { get; set; }

        public Boolean Concluido { get; set; }

        public Boolean Interessante { get; set; }

    }
}
