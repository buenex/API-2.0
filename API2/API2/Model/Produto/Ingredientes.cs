using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace api.Model.PackgeProduto
{
    public class Ingredientes
    {
        public int Id { get; set; }
        public Produto produto { get; set; }
        public MateriaPrima materiaPrima { get; set; }
        public Double valorEnergetico { get; set; }
        public Double valorDiario { get; set; }
    }
}
