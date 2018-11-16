using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.PackgePessoa
{
    public class Fisico : Pessoa
    {
        public DateTime dataNascimento { get; set; }
        public String email { get; set; }
        public String senha { get; set; }
        
    }
}
