using M7.Cadastro.Domain.Entitys;
using M7.Cadastro.Domain.Interfaces;
using M7.Cadastro.Domain.Models;

namespace M7.Cadastro.Application.Application
{
    /// <summary>
    /// Application de Pessoa
    /// Responsável pelas regras de Pessoa
    /// </summary>
    public class PessoaApplication : IPessoaApplication
    {
        private readonly IPessoaRepository _pessoaRepository;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="pessoaRepository">Repositório de Pessoas</param>
        public PessoaApplication(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        /// <summary>
        /// Listar Pessoas
        /// </summary>
        /// <returns>Lista de PessoaModel</returns>
        public IEnumerable<PessoaModel> ListarPessoas()
        {
            var pessoas = _pessoaRepository.ListarPessoas();

            if (!pessoas.Any())
                return null;

            return MapearListPessoaParaListPessoaModel(pessoas);
        }

        /// <summary>
        /// Buscar Pessoa por Id
        /// </summary>
        /// <param name="id">Id da pessoa</param>
        /// <returns>PessoaModel</returns>
        public PessoaModel BuscarPorId(int id)
        {
            var pessoa = _pessoaRepository.BuscarPorId(id);

            if (pessoa == null)
                return null;

            return new PessoaModel()
            {
                Ativo = pessoa.Ativo,
                DataModificacao = pessoa.DataModificacao,
                DataNascimento = pessoa.DataNascimento,
                Genero = pessoa.Genero,
                Id = id,
                Nome = pessoa.Nome
            };
        }

        /// <summary>
        /// Insere Pessoa
        /// </summary>
        /// <param name="pessoaInsert">Pessoa a ser inserida</param>
        /// <returns>Pessoa inserida</returns>
        public Pessoa Inserir(PessoaInsert pessoaInsert)
        {
            var pessoa = new Pessoa(true, pessoaInsert.DataNascimento, pessoaInsert.Genero, pessoaInsert.Nome);

            if (!pessoa.IsValid)
                return pessoa;

            _pessoaRepository.Inserir(pessoa);

            return pessoa;
        }

        /// <summary>
        /// Remove pessoa
        /// </summary>
        /// <param name="id">Id da pessoa para ser removida</param>
        public void Delete(int id)
        {
            _pessoaRepository.Delete(id);
        }

        /// <summary>
        /// Atualizar Pessoa
        /// </summary>
        /// <param name="pessoaUpdate">Pessoa a ser atualizada</param>
        /// <returns>Pessoa atualizada</returns>
        public Pessoa Atualizar(PessoaUpdate pessoaUpdate)
        {
            var pessoa = new Pessoa(pessoaUpdate.Ativo, DateTime.Now, pessoaUpdate.DataNascimento, pessoaUpdate.Genero, pessoaUpdate.Id, pessoaUpdate.Nome);

            if (!pessoa.IsValid)
                return pessoa;

            _pessoaRepository.Atualizar(pessoa);

            return pessoa;
        }

        private List<PessoaModel> MapearListPessoaParaListPessoaModel(IEnumerable<Pessoa> pessoas)
        {
            var retorno = new List<PessoaModel>();

            foreach (var pessoa in pessoas)
                retorno.Add(new PessoaModel()
                {
                    Ativo = pessoa.Ativo,
                    DataModificacao = pessoa.DataModificacao,
                    DataNascimento = pessoa.DataNascimento,
                    Genero = pessoa.Genero,
                    Id = pessoa.Id,
                    Nome = pessoa.Nome
                });

            return retorno;
        }
    }
}
