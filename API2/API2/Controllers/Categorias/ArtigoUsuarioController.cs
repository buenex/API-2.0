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
    [Route("api/ArtigoUsuario")]
    public class ArtigoUsuarioController
    {
           ArtigoUsuarioRepository repo;

        // GET: api/ArtigoUsuario
        [HttpGet]
        public IEnumerable<api.Model.PackageCategorias.ArtigoUsuario> Get()
        {
            repo = new ArtigoUsuarioRepository();
            return repo.getAll();
        }

        // GET: api/ArtigoUsuario/5
        [HttpGet("{id}")]
        public api.Model.PackageCategorias.ArtigoUsuario Get(int id)
        {
            repo = new ArtigoUsuarioRepository();
            return repo.getById(id);
        }

         // GET: api/ArtigoUsuario/name/titulo
        [HttpGet("name/{name}")]
        public api.Model.PackageCategorias.ArtigoUsuario Get(string name)
        {
            repo = new ArtigoUsuarioRepository();
            return repo.getByName(name);
        }
        
        // POST: api/ArtigoUsuario
        [HttpPost]
        public void Post([FromBody]api.Model.PackageCategorias.ArtigoUsuario value)
        {
            repo = new ArtigoUsuarioRepository();

            repo.insert(value);
        }
        
        // PUT: api/ArtigoUsuario/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]api.Model.PackageCategorias.ArtigoUsuario value)
        {
            repo = new ArtigoUsuarioRepository();

            repo.update(id, value);
        }
        
        // DELETE: api/ArtigoUsuario/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo = new ArtigoUsuarioRepository();

            repo.delete(id);
        }
    }
}