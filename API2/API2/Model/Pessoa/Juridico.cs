using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.PackgePessoa
{
    public class Juridico : Pessoa
    {
        public String razaoSocial { get; set; }
        public String cnpj { get; set; }
        public String senha { get; set; }
        public GrupoUsuario grupo{get;set;}
    }
}
