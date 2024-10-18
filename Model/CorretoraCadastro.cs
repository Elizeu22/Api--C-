using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Corretora.Model
{
    public class CorretoraCadastro
    {


        [Key]
        [Required]
        public int IdCorretor { get; set; }
        public string? cnpj { get; set; }
        public string? type { get; set; }
        public string? nome_social { get; set; }
        public string? nome_comercial { get; set; }
        public string? status { get; set; }
        public string? email { get; set; }
        public string? telefone { get; set; }
        public string? cep { get; set; }
        public string? pais { get; set; }
        public string? uf { get; set; }
        public string? municipio { get; set; }
        public string? bairro { get; set; }
        public string? complemento { get; set; }
        public string? logradouro { get; set; }
        public string? data_patrimonio_liquido { get; set; }
        public string?  valor_patrimonio_liquido { get; set; }
        public string? codigo_cvm { get; set; }

        public string? data_inicio_situacao { get; set; }
        public string? data_registro { get; set; }

    

    } 
}
