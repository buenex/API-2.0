using api.Model.PackageCategorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace api.Model.PackageCategorias
{
    public class Artigo
    {
        public string titulo{get;set;}
      //  public int Titulo{get;set;}
        public Categoria categoria{get;set;}
        public string texto{get;set;}
    }
}