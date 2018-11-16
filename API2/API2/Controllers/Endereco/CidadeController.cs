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
    [Route("api/Cidade")]
    public class CidadeController : Controller
    {
        CidadeRepository repo;
        // GET: api/Cidade
        [HttpGet]
        public IEnumerable<Cidade> Get()
        {
            repo = new CidadeRepository();

            return repo.getAll() ;
        }

        // GET: api/Cidade/5
        [HttpGet("{id}")]
        public Cidade Get(int id)
        {
            repo = new CidadeRepository();
            return repo.getById(id);
        }
        
    }
}
