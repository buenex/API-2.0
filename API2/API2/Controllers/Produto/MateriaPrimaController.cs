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
    [Route("api/MateriaPrima")]
    public class MateriaPrimaController : Controller
    {
        MateriaPrimaRepository repo;

        // GET: api/MateriaPrima
        [HttpGet]
        public IEnumerable<MateriaPrima> Get()
        {
            repo = new MateriaPrimaRepository();

            return repo.getAll();
        }

        // GET: api/MateriaPrima/5
        [HttpGet("{id}")]
        public MateriaPrima Get(int id)
        {
            repo = new MateriaPrimaRepository();

            return repo.getById(id);
        }

        [HttpGet("alergico/{alergico}")]
        public IEnumerable<MateriaPrima> Get(Boolean alergico)
        {
            repo = new MateriaPrimaRepository();

            return repo.getByAlergico(alergico);
        }

        // POST: api/MateriaPrima
        [HttpPost]
        public void Post([FromBody]MateriaPrima value)
        {
            repo = new MateriaPrimaRepository();

            repo.insert(value);
        }

        // PUT: api/MateriaPrima/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]MateriaPrima value)
        {
            repo = new MateriaPrimaRepository();

            repo.update(id, value);
        }

        // DELETE: api/MateriaPrima/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo = new MateriaPrimaRepository();

            repo.delete(id);
        }
    }
}
