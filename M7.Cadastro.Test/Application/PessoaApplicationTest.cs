using M7.Cadastro.Application.Application;
using M7.Cadastro.Domain.Entitys;
using M7.Cadastro.Domain.Interfaces;
using M7.Cadastro.Domain.Models;
using M7.Cadastro.Domain.Util;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M7.Cadastro.Test.Application
{
    public class PessoaApplicationTest
    {
        private Mock<IPessoaRepository> _pessoaRepositoryMock;

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
        private string generoErro;
        private string nomeErro;


        public PessoaApplicationTest()
        {
            _pessoaRepositoryMock = new Mock<IPessoaRepository>();

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
            this.generoErro = "UltrapassarMáximoCaracteres";
            this.nomeErro = "        ";
        }

        [Fact]
        public void QuandoListarPessoa_TendoPessoasNoBanco_RetornaPessoas()
        {
            //Arrange
            var pessoas = new List<Pessoa>()
            {
                new Pessoa(ativo, dataModificacao, dataNascimento, feminino, idA, nomeA),
                new Pessoa(ativo, dataModificacao, dataNascimento, masculino, idB, nomeB),
            };

            var application = ObterApplication();

            _pessoaRepositoryMock
                .Setup(a => a.ListarPessoas())
                .Returns(pessoas);

            //Act
            var resultado = application.ListarPessoas();

            //Assert
            Assert.NotEmpty(resultado);
            Assert.Equal(2, resultado.Count());
        }

        [Fact]
        public void QuandoListarPessoa_NaoTendoPessoasNoBanco_RetornaNull()
        {
            //Arrange
            var pessoas = new List<Pessoa>();

            var application = ObterApplication();

            _pessoaRepositoryMock
                .Setup(a => a.ListarPessoas())
                .Returns(pessoas);

            //Act
            var resultado = application.ListarPessoas();

            //Assert
            Assert.Null(resultado);
        }

        [Fact]
        public void QuandoBuscarPorId_TendoPessoaNoBanco_RetornaPessoa()
        {
            //Arrange
            var pessoa = new Pessoa(ativo, dataModificacao, dataNascimento, feminino, idA, nomeA);

            var application = ObterApplication();

            _pessoaRepositoryMock
                .Setup(a => a.BuscarPorId(It.IsAny<int>()))
                .Returns(pessoa);

            //Act
            var resultado = application.BuscarPorId(idA);

            //Assert
            Assert.NotNull(resultado);
            Assert.Equal(resultado.Id, idA);
            Assert.Equal(resultado.Nome, nomeA);
        }

        [Fact]
        public void QuandoBuscarPorId_NaoTendoPessoaNoBanco_RetornaNull()
        {
            //Arrange
            var application = ObterApplication();

            _pessoaRepositoryMock
                .Setup(a => a.BuscarPorId(It.IsAny<int>()))
                .Returns<Pessoa>(null);

            //Act
            var resultado = application.BuscarPorId(idA);

            //Assert
            Assert.Null(resultado);
        }

        [Fact]
        public void QuandoInserir_PessoaValida_Ok()
        {
            //Arrange
            var pessoa = new PessoaInsert()
            {
                DataNascimento = dataNascimento,
                Genero = feminino,
                Nome = nomeA
            };

            var application = ObterApplication();

            _pessoaRepositoryMock
                .Setup(a => a.Inserir(It.IsAny<Pessoa>()));

            //Act
            var resultado = application.Inserir(pessoa);

            //Assert
            Assert.NotNull(resultado);
            Assert.Equal(resultado.Nome, nomeA);
            Assert.True(resultado.IsValid);
        }

        [Fact]
        public void QuandoInserir_PessoaInValida_NaoOk()
        {
            //Arrange
            var pessoa = new PessoaInsert()
            {
                DataNascimento = dataNascimento,
                Genero = generoErro,
                Nome = nomeErro
            };

            var application = ObterApplication();

            _pessoaRepositoryMock
                .Setup(a => a.Inserir(It.IsAny<Pessoa>()));

            //Act
            var resultado = application.Inserir(pessoa);

            //Assert
            Assert.NotNull(resultado);
            Assert.False(resultado.IsValid);
            Assert.Contains(resultado.Notifications, x => x.Message == Constantes.GENERO_EXCEDEU_LIMITE_CARACTERES);
            Assert.Contains(resultado.Notifications, x => x.Message == Constantes.NOME_ESPACO_EM_BRANCO);
        }

        [Fact]
        public void QuandoAtualizar_PessoaValida_Ok()
        {
            //Arrange
            var pessoaUpdate = new PessoaUpdate()
            {
                Ativo = true,
                DataNascimento = dataNascimento,
                Genero = masculino,
                Id = idA,
                Nome = nomeA
            };

            var application = ObterApplication();

            _pessoaRepositoryMock
                .Setup(a => a.Atualizar(It.IsAny<Pessoa>()));

            //Act
            var resultado = application.Atualizar(pessoaUpdate);

            //Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.IsValid);
            Assert.Empty(resultado.Notifications);
        }

        [Fact]
        public void QuandoAtualizar_PessoaInValida_NaoOk()
        {
            //Arrange
            int idErro = -1;

            var pessoaUpdate = new PessoaUpdate()
            {
                Ativo = true,
                DataNascimento = dataNascimento,
                Genero = generoErro,
                Id = idErro,
                Nome = nomeErro
            };

            var application = ObterApplication();

            _pessoaRepositoryMock
                .Setup(a => a.Atualizar(It.IsAny<Pessoa>()));

            //Act
            var resultado = application.Atualizar(pessoaUpdate);

            //Assert
            Assert.NotNull(resultado);
            Assert.False(resultado.IsValid);
            Assert.NotEmpty(resultado.Notifications);
            Assert.Contains(resultado.Notifications, x => x.Message == Constantes.GENERO_EXCEDEU_LIMITE_CARACTERES);
            Assert.Contains(resultado.Notifications, x => x.Message == Constantes.NOME_ESPACO_EM_BRANCO);
            Assert.Contains(resultado.Notifications, x => x.Message == Constantes.ID_INVALIDO);
        }

        private PessoaApplication ObterApplication()
        {
            return new PessoaApplication(_pessoaRepositoryMock.Object);
        }
    }
}
