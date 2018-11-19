using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Data.Repository.PackageCategorias;
using api.Model.PackageCategorias;

namespace api.Controllers.Categorias
{
     [Produces("application/json")]
    [Route("api/Artigo")]
    public class ArtigoController
    {
         ArtigoRepository repo;
        //GET api/Artigo
        [HttpGet]
        public IEnumerable<Artigo>Get()
        {
            repo=new ArtigoRepository();
            return repo.getAll();
        }

        // GET: api/Artigo/5
        [HttpGet("{id}")]
        public Artigo Get(int id)
        {
            repo = new ArtigoRepository();

            return repo.getById(id);
        }
        // GET: api/Artigo/name/Artigo
        [HttpGet("name/{name}")]
        public Artigo Get(string name)
        {
            repo = new ArtigoRepository();

            return repo.getByName(name);
        }
    }
}