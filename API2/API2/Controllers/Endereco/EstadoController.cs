using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Data.Repository.PackgeEndereco;
using api.Model.PackgeEndereco;

namespace api.Controllers.PackgeEndereco
{
    [Produces("application/json")]
    [Route("api/Estado")]
    public class EstadoController : Controller
    {
        EstadoRepository repo;
        // GET: api/Estado
        [HttpGet]
        public IEnumerable<Estado> Get()
        {
            repo = new EstadoRepository();

            return repo.getAll();
        }

        // GET: api/Estado/5
        [HttpGet("{id}")]
        public Estado Get(int id)
        {
            repo = new EstadoRepository();

            return repo.getById(id);
        }

         [HttpGet("name/{name}")]
        public Estado Get(string name)
        {
            repo = new EstadoRepository();

            return repo.getByName(name);
        }

    }
}
