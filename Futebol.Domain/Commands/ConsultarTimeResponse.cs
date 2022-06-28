using Futebol.Domain.Entities;

namespace Futebol.Domain.Commands
{
    public class ConsultarTimeResponse
    {
        public long? Id { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataFundacao { get; private set; }
        public string NomePresidente { get; private set; }
        public string NomeMascote { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }

        private ConsultarTimeResponse() { }

        public ConsultarTimeResponse(
            long? id, 
            string nome, 
            DateTime dataFundacao, 
            string nomePresidente, 
            string nomeMascote, 
            string cidade, 
            string estado, 
            string pais)
        {
            Id = id;
            Nome = nome;
            DataFundacao = dataFundacao;
            NomePresidente = nomePresidente;
            NomeMascote = nomeMascote;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public static ConsultarTimeResponse Map(Time time)
        {
            if (time is null)
                return default(ConsultarTimeResponse);
            
            return new ConsultarTimeResponse(
                time.Id,
                time.Nome,
                time.DataFundacao,
                time.NomePresidente,
                time.NomeMascote,
                time.Cidade,
                time.Estado,
                time.Pais
            );
        }
    }
}