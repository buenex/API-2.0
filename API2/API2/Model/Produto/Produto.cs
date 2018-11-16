using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.PackgeProduto
{
    public class Produto
    {
        public int Id { get; set; }
        public String descricao { get; set; }
        public double valorVenda { get; set; }
        public String preparo { get; set; }
        public String conservacao { get; set; }
        public String codigoBarra { get; set; }
        public List<Ingredientes> ingredientes { get; set; }
    }
}
