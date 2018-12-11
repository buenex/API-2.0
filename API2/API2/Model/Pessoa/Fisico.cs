using System;

namespace api.Model.PackgePessoa
{
    public class Fisico : Pessoa
    {
        public DateTime dataNascimento { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        
    }
}
