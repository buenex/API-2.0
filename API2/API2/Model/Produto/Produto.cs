using System.Collections.Generic;

namespace api.Model.PackgeProduto
{
    public class Produto
    {
        public int Id { get; set; }
        public string descricao { get; set; }
        public double valorVenda { get; set; }
        public string preparo { get; set; }
        public string conservacao { get; set; }
        public string codigoBarra { get; set; }
        public List<Ingredientes> ingredientes { get; set; }
    }
}
