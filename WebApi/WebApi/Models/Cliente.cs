using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public byte[] Imagem { get; set; }
    }
}
