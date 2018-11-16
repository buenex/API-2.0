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
        
        // POST: api/ArtigoUsuario
        [HttpPost]
        public void Post([FromBody]api.Model.PackageCategorias.ArtigoUsuario value)
        {
            repo = new ArtigoUsuarioRepository();

            repo.insert(value);
        }
        
        // PUT: api/ArtigoUsuario/5
        [HttpPut("{attribute9}")]
        public void Put(int id, [FromBody]api.Model.PackageCategorias.ArtigoUsuario value)
        {
            repo = new ArtigoUsuarioRepository();

            repo.update(id, value);
        }
        
        // DELETE: api/ArtigoUsuario/5
        [HttpDelete("{attribute9}")]
        public void Delete(int id)
        {
            repo = new ArtigoUsuarioRepository();

            repo.delete(id);
        }
    }
}