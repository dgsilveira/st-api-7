namespace M7.Cadastro.Domain.Models
{
    /// <summary>
    /// Modelo para atualizar pessoa
    /// </summary>
    public class PessoaUpdate
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Gênero
        /// </summary>
        public string Genero { get; set; }

        /// <summary>
        /// Data de nascimento
        /// </summary>
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// ativo
        /// </summary>
        public bool Ativo { get; set; }
    }
}
