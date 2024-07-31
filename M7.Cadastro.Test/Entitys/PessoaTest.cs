using M7.Cadastro.Domain.Entitys;

namespace M7.Cadastro.Test.Entitys
{
    public class PessoaTest
    {
        private bool ativo;
        private DateTime dataModificacao;
        private DateTime dataNascimento;
        private string feminino;
        private int idA;
        private int idB;
        private bool inativo;
        private string masculino;
        private string nomeA;
        private string nomeB;

        public PessoaTest()
        {
            this.ativo = true;
            this.dataModificacao = DateTime.Now;
            this.dataNascimento = dataModificacao;
            this.feminino = "F";
            this.idA = 1;
            this.idB = 2;
            this.inativo = false;
            this.masculino = "M";
            this.nomeA = "NomeA";
            this.nomeB = "NomeB";
        }

        [Fact]
        public void QuandoCriarPessoa_ConstrutorCriarETudoOk_EntaoOk()
        {
            //Act
            var pessoa = new Pessoa(ativo, dataModificacao, dataNascimento, feminino, idA, nomeA);

            //Assert
            Assert.True(pessoa.IsValid);
            Assert.Empty(pessoa.Notifications);
        }

        [Fact]
        public void QuandoCriarPessoa_ConstrutorLeituraETudoOk_EntaoOk()
        {
            //Act
            var pessoa = new Pessoa(ativo, dataModificacao, dataNascimento, feminino, idA, nomeA);

            //Assert
            Assert.True(pessoa.IsValid);
            Assert.Empty(pessoa.Notifications);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("ab")]

        public void QuandoCriarPessoa_QuandoErroGenero_EntaoNaoOk(string genero)
        {
            //Act
            var pessoa = new Pessoa(ativo, dataNascimento, genero, nomeA);

            //Assert
            Assert.False(pessoa.IsValid);
            Assert.NotEmpty(pessoa.Notifications);
        }

        [Fact]
        public void QuandoCriarpessoa_QuandoErroid_EntaoNaoOk()
        {
            //Arrange
            int idErro = -1;

            //Act
            var pessoa = new Pessoa(ativo, dataModificacao, dataNascimento, feminino, idErro, nomeA);

            //Assert
            Assert.False(pessoa.IsValid);
            Assert.NotEmpty(pessoa.Notifications);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901")]

        public void QuandoCriarPessoa_QuandoErroNome_EntaoNaoOk(string nome)
        {
            //Act
            var pessoa = new Pessoa(ativo, dataNascimento, feminino, nome);

            //Assert
            Assert.False(pessoa.IsValid);
            Assert.NotEmpty(pessoa.Notifications);
        }
    }
}
