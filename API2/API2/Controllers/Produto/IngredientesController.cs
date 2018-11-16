using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Data.Repository.PackgeProduto;
using api.Model.PackgeProduto;

namespace api.Controllers.PackgeProduto
{
    [Produces("application/json")]
    [Route("api/Ingredientes")]
    public class IngredientesController : Controller
    {
        IngredientesRepository repo;

        // GET: api/Ingredientes
        [HttpGet]
        public IEnumerable<Ingredientes> Get()
        {
            repo = new IngredientesRepository();

            return repo.getAll();
        }

        // GET: api/Ingredientes/5
        [HttpGet("{id}")]
        public Ingredientes Get(int id)
        {
            repo = new IngredientesRepository();

            return repo.getById(id);
        }
        
        // POST: api/Ingredientes
        [HttpPost]
        public void Post([FromBody]Ingredientes value)
        {
            repo = new IngredientesRepository();
            repo.insert(value);
        }
        
        // PUT: api/Ingredientes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Ingredientes value)
        {
            repo = new IngredientesRepository();
            repo.update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo = new IngredientesRepository();
            repo.delete(id);
        }
    }
}
