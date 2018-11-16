using api.Model.PackgeEndereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.PackgePessoa
{
    public class Pessoa
    {
        public int Id { get; set; }
        public String nome { get; set; }
        public DateTime dataCadastro { get; set; }
        public Endereco endereco { get; set; }
        public GrupoUsuario grupo{get;set;}
    }
}
