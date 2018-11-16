using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.PackgeEndereco
{
    public class Endereco
    {
        public int Id { get; set; }
        public String descricao { get; set; }
        public String bairro { get; set; }
        public Cidade cidade { get; set; }
    }
}
