using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using api.Data.Repository.PackgeEndereco;
using api.Model.PackgeEndereco;
//GET, POST, PUT, DELETE OK
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

         [HttpGet("pais/{pais}")]
        public List<Estado> GetEstadoByPais(int pais)
        {
            repo = new EstadoRepository();

            return repo.getEstadoByPais(pais);
        }

    }
}
