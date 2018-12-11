namespace api.Model.PackgePessoa
{
    public class Juridico : Pessoa
    {
        public string razaoSocial { get; set; }
        public string cnpj { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public GrupoUsuario grupo{get;set;}
    }
}
