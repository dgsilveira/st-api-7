namespace M7.Cadastro.Domain.Models
{
    /// <summary>
    /// Modelo para Inserir Pessoa
    /// </summary>
    public class PessoaInsert
    {
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
    }
}
