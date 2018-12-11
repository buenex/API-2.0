using System.Collections.Generic;
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

        // POST: api/Artigo
        [HttpPost]
        public void Post([FromBody]Artigo name)
        {
            repo = new ArtigoRepository();
            repo.insert(name);
        }

        // PUT: api/Artigo/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]api.Model.PackageCategorias.Artigo value)
        {
            repo = new ArtigoRepository();

            repo.update(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo = new ArtigoRepository();

            repo.delete(id);
        }
    }
}