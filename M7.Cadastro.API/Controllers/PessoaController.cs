using M7.Cadastro.Domain.Interfaces;
using M7.Cadastro.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace M7.Cadastro.API.Controllers
{
    /// <summary>
    /// Pessoa
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaApplication _pessoaApplication;

        public PessoaController(IPessoaApplication pessoaApplication)
        {
            _pessoaApplication = pessoaApplication;
        }

        /// <summary>
        /// Get Pessoas
        /// </summary>
        /// <returns>Pessoas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var resultado = _pessoaApplication.ListarPessoas();

            if (resultado.IsNullOrEmpty())
                return NotFound();

            return Ok(resultado);
        }

        /// <summary>
        /// Get Pessoa por id
        /// </summary>
        /// <param name="id">id da pessoa</param>
        /// <returns>pessoa</returns>
        [HttpGet]
        [Route("getId")]
        public IActionResult GetId(int id)
        {
            var pessoa = _pessoaApplication.BuscarPorId(id);

            if (pessoa == null)
                return NotFound();

            return Ok(pessoa);
        }

        /// <summary>
        /// Incluir Pessoa
        /// </summary>
        /// <param name="pessoaInsert">Pessoa a ser inserida</param>
        /// <returns>Pessoa inserida</returns>
        [HttpPost]
        public IActionResult Post(PessoaInsert pessoaInsert)
        {
            var pessoa = _pessoaApplication.Inserir(pessoaInsert);

            if (!pessoa.IsValid)
                return BadRequest(pessoa.Notifications);

            return Created("", pessoa);
        }

        /// <summary>
        /// Remoção de Pessoa
        /// </summary>
        /// <param name="id">Id da pessoa para ser removida</param>
        /// <returns>Ok para solicitação recebida</returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _pessoaApplication.Delete(id);

            return Ok();
        }

        /// <summary>
        /// Atualizar Pessoa
        /// </summary>
        /// <param name="pessoaUpdate">Pessoa a ser atualizada</param>
        /// <returns>Pessoa atualizada</returns>
        [HttpPut]
        public IActionResult Atualizar(PessoaUpdate pessoaUpdate)
        {
            var pessoa = _pessoaApplication.Atualizar(pessoaUpdate);

            if (!pessoa.IsValid)
                return BadRequest(pessoa.Notifications);

            return Created("", pessoa);
        }
    }
}
