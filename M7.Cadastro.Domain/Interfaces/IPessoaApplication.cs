using M7.Cadastro.Domain.Entitys;
using M7.Cadastro.Domain.Models;

namespace M7.Cadastro.Domain.Interfaces
{
    /// <summary>
    /// Interface de PessoaApplication
    /// </summary>
    public interface IPessoaApplication
    {
        /// <summary>
        /// Listar Pessoas
        /// </summary>
        /// <returns>Lista de PessoaModel</returns>
        IEnumerable<PessoaModel> ListarPessoas();

        /// <summary>
        /// Buscar Pessoa por Id
        /// </summary>
        /// <param name="id">Id da pessoa</param>
        /// <returns>PessoaModel</returns>
        PessoaModel BuscarPorId(int id);

        /// <summary>
        /// Inserir Pessoa
        /// </summary>
        /// <param name="pessoa">Pessoa a ser inserida</param>
        /// <returns>Pessoa inserida</returns>
        Pessoa Inserir(PessoaInsert pessoa);

        /// <summary>
        /// Remover Pessoa
        /// </summary>
        /// <param name="id">Id da pessoa para ser removida</param>
        void Delete(int id);

        /// <summary>
        /// Atualizar Pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        Pessoa Atualizar(PessoaUpdate pessoa);
    }
}
