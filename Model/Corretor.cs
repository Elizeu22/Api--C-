using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Reflection.Metadata;

namespace Corretora.Model
{
    public class Corretor
    {


        [Key]
        [Required]
        public int idCorretor { get; set; }
        public string? nome { get; set; }





    }
}
