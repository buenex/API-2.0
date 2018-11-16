using api.Model.PackageCategorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace api.Model.PackageCategorias
{
    public class ArtigoUsuario
    {
        public Artigo artigo{get;set;}
        public DateTime dataPublicacao{get;set;}
        public int Id{get;set;}
    }
}