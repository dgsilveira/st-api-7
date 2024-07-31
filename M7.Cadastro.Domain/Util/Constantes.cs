using M7.Cadastro.Domain.Entitys;

namespace M7.Cadastro.Domain.Util
{
    public static class Constantes
    {
            public const string GENERO_ESPACO_EM_BRANCO = $"{nameof(Pessoa.Genero)} é espaço em branco";
            public const string GENERO_EXCEDEU_LIMITE_CARACTERES = $"{nameof(Pessoa.Genero)} excedeu o limite de caracteres";
            public const string GENERO_NULO = $"{nameof(Pessoa.Genero)} está nulo";
            public static readonly int GENERO_TAMANHO_MAXIMO = 1;
            public const string GENERO_VAZIO = $"{nameof(Pessoa.Genero)} está vazio";

            public const string ID_INVALIDO = $"{nameof(Pessoa.Id)} inválido";

            public const string NOME_ESPACO_EM_BRANCO = $"{nameof(Pessoa.Nome)} é espaço em branco";
            public const string NOME_EXCEDEU_LIMITE_CARACTERES = $"{nameof(Pessoa.Nome)} excedeu o limite de caracteres";
            public const string NOME_NULO = $"{nameof(Pessoa.Nome)} está nulo";
            public const int NOME_TAMANHO_MAXIMO = 100;
            public const string NOME_VAZIO = $"{nameof(Pessoa.Nome)} está vazio";
    }
}
