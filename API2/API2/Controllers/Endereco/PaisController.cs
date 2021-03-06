using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Data.PackgeRepository;
using api.Model.PackgeEndereco;

namespace api.Controllers
{
    [Produces("application/json")]
    [Route("api/Pais")]
    public class PaisController : Controller
    {
        public PaisRepository repo;

        // GET: api/Pais
        [HttpGet]
        public IEnumerable<Pais> Get()
        {
            repo = new PaisRepository();

            return repo.getAll();
        }

        // GET: api/Pais/5
        [HttpGet("{id}", Name = "Get")]
        public Pais Get(int id)
        {
            repo = new PaisRepository();

            return repo.getById(id);
        }

        // GET: api/Pais/name/pais
        [HttpGet("name/{name}")]
        public Pais Get(string name)
        {
            repo = new PaisRepository();

            return repo.getByName(name);
        }

      
    }
}
