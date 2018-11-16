using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.PackgeProduto
{
    public class MateriaPrima
    {
        public int Id { get; set; }
        public String descricao { get; set; }
        public Boolean causaAlergia { get; set; }
    }
}
