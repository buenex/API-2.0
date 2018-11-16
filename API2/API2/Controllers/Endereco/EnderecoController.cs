using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Data.Repository.PackgeEndereco;

namespace api.Controllers.PackgeEndereco
{
    [Produces("application/json")]
    [Route("api/Endereco")]
    public class EnderecoController : Controller
    {
        EnderecoRepository repo;

        // GET: api/Endereco
        [HttpGet]
        public IEnumerable<api.Model.PackgeEndereco.Endereco> Get()
        {
            repo = new EnderecoRepository();
            return repo.getAll();
        }

        // GET: api/Endereco/5
        [HttpGet("{id}")]
        public api.Model.PackgeEndereco.Endereco Get(int id)
        {
            repo = new EnderecoRepository();
            return repo.getById(id);
        }
        
        // POST: api/Endereco
        [HttpPost]
        public void Post([FromBody]api.Model.PackgeEndereco.Endereco value)
        {
            repo = new EnderecoRepository();

            repo.insert(value);
        }
        
        // PUT: api/Endereco/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]api.Model.PackgeEndereco.Endereco value)
        {
            repo = new EnderecoRepository();

            repo.update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo = new EnderecoRepository();

            repo.delete(id);
        }
    }
}
