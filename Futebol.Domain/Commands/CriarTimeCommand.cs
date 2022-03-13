using FluentValidation;
using Futebol.Domain.Commands.Contracts;

namespace Futebol.Domain.Commands
{
    public class CriarTimeCommand : ICommand
    {
        public CriarTimeCommand(){ }
        public CriarTimeCommand(string nome, DateTime dataFundacao, string nomePresidente, string nomeMascote, string cidade, string estado, string pais)
        {
            Nome = nome;
            DataFundacao = dataFundacao;
            NomePresidente = nomePresidente;
            NomeMascote = nomeMascote;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public string Nome { get; set; }
        public DateTime DataFundacao { get; set; }
        public string NomePresidente { get; set; }
        public string NomeMascote { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
    }
}