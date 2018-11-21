using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Data.Repository.PackgePessoa;
using api.Model.PackgePessoa;

namespace api.Controllers.PackgePessoa
{
    [Produces("application/json")]
    [Route("api/Fisico")]
    public class FisicoController : Controller
    {
        FisicoRepository repo;

        // GET: api/Fisico
        [HttpGet]
        public IEnumerable<Fisico> Get()
        {
            repo = new FisicoRepository();
            
            return repo.getAll();
        }

        // GET: api/Fisico/5
        [HttpGet("{id}")]
        public Fisico Get(int id)
        {
            repo = new FisicoRepository();

            return repo.getById(id);
        }
        
         // GET: api/Fisico/name/name
        [HttpGet("name/{name}")]
        public Fisico Get(string name)
        {
            repo = new FisicoRepository();

            return repo.getByName(name);
        }
        
        // POST: api/Fisico
        [HttpPost]
        public void Post([FromBody]Fisico value)
        {
            repo = new FisicoRepository();

            repo.insert(value);
        }
        
        // PUT: api/Fisico/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Fisico value)
        {
            repo=new FisicoRepository();

            repo.update(id,value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo = new FisicoRepository();

            repo.delete(id);
        }
    }
}
