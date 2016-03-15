using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Cliente
    {
        [Key]
        public int IDCliente { get; set; }
        public string Nome { get; set; }
        //TODO: Possivel Refactoring
        public string Endereco { get; set; }
        [Column(TypeName ="image")]
        public byte[] Imagem { get; set; }
    }
}
