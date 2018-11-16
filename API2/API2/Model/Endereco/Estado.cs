using api.Model.PackgeEndereco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model.PackgeEndereco
{
    public class Estado
    {
        public int Id { get; set; }
        public Pais pais { get; set; }
        public String descricao { get; set; }
        public String sigla { get; set; }
    }
}
