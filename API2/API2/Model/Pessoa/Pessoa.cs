using api.Model.PackgeEndereco;
using System;

namespace api.Model.PackgePessoa
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public DateTime dataCadastro { get; set; }
        public Endereco endereco { get; set; }
        public GrupoUsuario grupo{get;set;}
    }
}
