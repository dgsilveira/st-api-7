using M7.Cadastro.Domain.Entitys;

namespace M7.Cadastro.Domain.Interfaces
{
    /// <summary>
    /// Interface de PessoaRepository
    /// </summary>
    public interface IPessoaRepository
    {
        /// <summary>
        /// Listar Pessoas
        /// </summary>
        /// <returns>Lista de Pessoa</returns>
        IEnumerable<Pessoa> ListarPessoas();

        /// <summary>
        /// Buscar Pessoa Por Id
        /// </summary>
        /// <param name="id">Id da pessoa</param>
        /// <returns>Pessoa</returns>
        Pessoa BuscarPorId(int id);

        /// <summary>
        /// Inserir Pessoa
        /// </summary>
        /// <param name="pessoa">Pessoa</param>
        void Inserir(Pessoa pessoa);

        /// <summary>
        /// Remover Pessoa
        /// </summary>
        /// <param name="id">Id da Pessoa</param>
        void Delete(int id);

        /// <summary>
        /// Atualizar Pessoa
        /// </summary>
        /// <param name="pessoa">Pessoa</param>
        void Atualizar(Pessoa pessoa);
    }
}
