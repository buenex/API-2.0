using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Data.Repository.PackageCategorias;
using api.Model.PackageCategorias;

namespace api.Controllers.PackgeCategoria
{
    [Produces("application/json")]
    [Route("api/Categoria")]
    public class CategoriaController:Controller
    {
        CategoriaRepository repo;
        //GET api/Categoria
        [HttpGet]

        public IEnumerable<Categoria>Get()
        {
            repo=new CategoriaRepository();
            return repo.getAll();
        }

        // GET: api/Categoria/5
        [HttpGet("{id}")]
        public Categoria Get(int id)
        {
            repo = new CategoriaRepository();

            return repo.getById(id);
        }

        // GET: api/Categoria/name/Artigo
        [HttpGet("name/{name}")]
        public Categoria Get(string name)
        {
            repo = new CategoriaRepository();

            return repo.getByName(name);
        }

        // POST: api/Categoria
        [HttpPost]
        public void Post([FromBody]Categoria name)
        {
            repo = new CategoriaRepository();
            repo.insert(name);
        }

        // PUT: api/Categoria
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]api.Model.PackageCategorias.Categoria value)
        {
            repo = new CategoriaRepository();

            repo.update(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo = new CategoriaRepository();

            repo.delete(id);
        }
    }
}