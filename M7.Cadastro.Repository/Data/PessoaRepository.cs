using M7.Cadastro.Domain.Entitys;
using M7.Cadastro.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace M7.Cadastro.Repository.Data
{
    /// <summary>
    /// Repository de Pessoa
    /// Responsável por acesso ao banco relacionado a Pessoa
    /// </summary>
    public class PessoaRepository : IPessoaRepository
    {
        private string connectionString = "Data Source=DELL_DOUG;Initial Catalog=EstudyDB;User ID=sa;Password=sa1234;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        /// <summary>
        /// Listar Pessoas
        /// </summary>
        /// <returns>Lista de Pessoa</returns>
        public IEnumerable<Pessoa> ListarPessoas()
        {
            using var conexao = new SqlConnection(connectionString);
            conexao.Open();

            string sql = "SELECT * FROM PESSOAS";

            SqlCommand command = new SqlCommand(sql, conexao);

            using SqlDataReader reader = command.ExecuteReader();

            var pessoas = new List<Pessoa>();

            while (reader.Read())
            {
                bool ativo = Convert.ToBoolean(reader["IDC_ATIVO"]);
                DateTime dataModificacao = Convert.ToDateTime(reader["DATA_MODIFICACAO"]);
                DateTime dataNascimento = Convert.ToDateTime(reader["DATA_NASCIMENTO"]);
                string genero = Convert.ToString(value: reader["GENERO"]).Trim();
                int id = Convert.ToInt32(reader["ID"]);
                string nome = Convert.ToString(reader["NOME"]).Trim();

                pessoas.Add(new Pessoa(ativo, dataModificacao, dataNascimento, genero, id, nome));
            }

            return pessoas;
        }

        /// <summary>
        /// Buscar Pessoa por id
        /// </summary>
        /// <param name="id">Id da pessoa</param>
        /// <returns>Pessoa</returns>
        public Pessoa BuscarPorId(int id)
        {
            using var conexao = new SqlConnection(connectionString);
            conexao.Open();

            string sql = "SELECT * FROM PESSOAS WHERE ID = @id";

            SqlCommand command = new SqlCommand(sql, conexao);

            command.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = command.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                bool ativo = Convert.ToBoolean(reader["IDC_ATIVO"]);
                DateTime dataModificacao = Convert.ToDateTime(reader["DATA_MODIFICACAO"]);
                DateTime dataNascimento = Convert.ToDateTime(reader["DATA_NASCIMENTO"]);
                string genero = Convert.ToString(reader["GENERO"]).Trim();
                string nome = Convert.ToString(reader["NOME"]).Trim();

                return new Pessoa(ativo, dataModificacao, dataNascimento, genero, id, nome);
            }

            return null;
        }

        /// <summary>
        /// Inserir Pessoa
        /// </summary>
        /// <param name="pessoa">Pessoa</param>
        public void Inserir(Pessoa pessoa)
        {
            using var conexao = new SqlConnection(connectionString);

            conexao.Open();

            string sql = "INSERT INTO PESSOAS (" +
                            "NOME, " +
                            "GENERO, " +
                            "DATA_NASCIMENTO, " +
                            "IDC_ATIVO, " +
                            "DATA_MODIFICACAO" +

                            ") VALUES (" +
                            "@nome, " +
                            "@genero, " +
                            "@dataNascimento, " +
                            "@ativo, " +
                            "@dataModificacao" +
                            ")";

            SqlCommand command = new SqlCommand(sql, conexao);


            command.Parameters.AddWithValue("@nome", pessoa.Nome);
            command.Parameters.AddWithValue("@genero", pessoa.Genero);
            command.Parameters.AddWithValue("@dataNascimento", pessoa.DataNascimento);
            command.Parameters.AddWithValue("@dataModificacao", DateTime.Now);
            command.Parameters.AddWithValue("@ativo", true);

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Remover Pessoa
        /// </summary>
        /// <param name="id">Id da Pessoa</param>
        public void Delete(int id)
        {
            using var conexao = new SqlConnection(connectionString);
            conexao.Open();

            string sql = "DELETE FROM PESSOAS WHERE ID = @id";

            SqlCommand command = new SqlCommand(sql, conexao);

            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Atualizar Pessoa
        /// </summary>
        /// <param name="pessoa">Pessoa</param>
        public void Atualizar(Pessoa pessoa)
        {
            using var conexao = new SqlConnection(connectionString);
            conexao.Open();

            string sql = "UPDATE PESSOAS SET ";
            SqlCommand command = new SqlCommand(sql, conexao);

            List<string> parametros = new List<string>();

            parametros.Add("NOME = @nome");
            command.Parameters.AddWithValue("@nome", pessoa.Nome);

            parametros.Add("GENERO = @genero");
            command.Parameters.AddWithValue("@genero", pessoa.Genero);

            parametros.Add("DATA_NASCIMENTO = @dataNascimento");
            command.Parameters.AddWithValue("@dataNascimento", pessoa.DataNascimento);

            parametros.Add("IDC_ATIVO = @ativo");
            command.Parameters.AddWithValue("@ativo", pessoa.Ativo);

            parametros.Add("DATA_MODIFICACAO = @dataModificacao");
            command.Parameters.AddWithValue("@dataModificacao", DateTime.Now);

            sql = $"{sql}{string.Join(", ", parametros)} WHERE ID = @id";

            command.CommandText = sql;
            command.Parameters.AddWithValue("@id", pessoa.Id);

            command.ExecuteNonQuery();
        }
    }
}
