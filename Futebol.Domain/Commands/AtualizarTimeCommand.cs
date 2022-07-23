using MediatR;

namespace Futebol.Domain.Commands
{
    public class AtualizarTimeCommand : IRequest
    {
        public int Id { get; private set; }
        public string Nome { get; init; }
        public DateTime DataFundacao { get; init; }
        public string NomePresidente { get; init; }
        public string NomeMascote { get; init; }
        public string Cidade { get; init; }
        public string Estado { get; init; }
        public string Pais { get; init; }

        public AtualizarTimeCommand(
            string nome, 
            DateTime dataFundacao, 
            string nomePresidente, 
            string nomeMascote, 
            string cidade, 
            string estado, 
            string pais)
        {
            Nome = nome;
            DataFundacao = dataFundacao;
            NomePresidente = nomePresidente;
            NomeMascote = nomeMascote;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public AtualizarTimeCommand ComId(int id)
        {
            Id = id;

            return this;
        }
    }
}