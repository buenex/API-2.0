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
    [Route("api/Produto")]
    public class ProdutoController : Controller
    {
        ProdutoRepository repo;

        // GET: api/Produto
        [HttpGet]
        public IEnumerable<Produto> Get()
        {
            repo = new ProdutoRepository();

            return repo.getAll();
        }
        // GET: api/Produto/5
        [HttpGet("{id}")]
        public Produto Get(int id)
        {
            repo = new ProdutoRepository();

            return repo.getById(id);
        }
        // GET: api/Produto/codBarra/codigoBarra
        [HttpGet("codBarra/{codBarra}")]
        public Produto Get(String codBarra)
        {
            repo = new ProdutoRepository();

            return repo.getByEAN(codBarra);
        }

        // POST: api/Produto
        [HttpPost]
        public void Post([FromBody]Produto value)
        {
            repo = new ProdutoRepository();

            repo.insert(value);
        }
        
        // PUT: api/Produto/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Produto value)
        {
            repo = new ProdutoRepository();

            repo.update(id, value);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo = new ProdutoRepository();

            repo.delete(id);
        }
    }
}
