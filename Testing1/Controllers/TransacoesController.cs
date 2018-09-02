using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Testing1.Models;
using Testing1.RepositoriesInterfaces;

namespace Testing1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {
        public ITransacoesRepository _transacoesRepository { get; }

        public TransacoesController(ITransacoesRepository transacoesRepository)
        {
            _transacoesRepository = transacoesRepository;
        }

        // GET: api/Transacoes
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Transacoes/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Transacoes>> Get(int id)
        {
            return await _transacoesRepository.GetTransacaoById(id);
        }

        // POST: api/Transacoes
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Transacoes))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Transacoes>> Post([FromBody] string value)
        {
            try
            {
                var transacao = new Transacoes()
                {
                    Descricao = value
                };

                await _transacoesRepository.AddTransacoes(transacao);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Transacoes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Transacoes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
