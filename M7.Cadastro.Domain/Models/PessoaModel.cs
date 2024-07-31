namespace M7.Cadastro.Domain.Models
{
    /// <summary>
    /// Modelo de Pessoa
    /// </summary>
    public class PessoaModel
    {
        /// <summary>
        /// ativo
        /// </summary>
        public bool Ativo { get; set; }
        /// <summary>
        /// data de modificação
        /// </summary>
        public DateTime DataModificacao { get; set; }
        /// <summary>
        /// data de nascimento
        /// </summary>
        public DateTime DataNascimento { get; set; }
        /// <summary>
        /// gênero
        /// </summary>
        public string Genero { get; set; }
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nome
        /// </summary>
        public string Nome { get; set; }
    }
}
