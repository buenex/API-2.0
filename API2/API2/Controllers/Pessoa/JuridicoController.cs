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
    [Route("api/Juridico")]
    public class JuridicoController : Controller
    {
        JuridicoRepository repo;

        // GET: api/Juridico
        [HttpGet]
        public IEnumerable<Juridico> Get()
        {
            repo = new JuridicoRepository();
            
            return repo.getAll();
        }

        // GET: api/juridico/5
        [HttpGet("{id}")]
        public Juridico Get(int id)
        {
            repo = new JuridicoRepository();

            return repo.getById(id);
        }
        
        // POST: api/Juridico
        [HttpPost]
        public void Post([FromBody]Juridico value)
        {
            repo = new JuridicoRepository();

            repo.insert(value);
        }
        
        // PUT: api/Juridico/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Juridico value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo = new JuridicoRepository();

            repo.delete(id);
        }
    }
}
