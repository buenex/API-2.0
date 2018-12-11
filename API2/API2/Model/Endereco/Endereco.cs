namespace api.Model.PackgeEndereco
{
    public class Endereco
    {
        public int Id { get; set; }
        public string descricao { get; set; }
        public string bairro { get; set; }
        public Cidade cidade { get; set; }
    }
}
