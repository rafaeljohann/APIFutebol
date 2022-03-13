namespace Futebol.Domain.Entities
{
    public class Time : Entity
    {
        public Time(string nome, DateTime dataFundacao, string nomePresidente, string nomeMascote, string cidade, string estado, string pais)
        {
            Nome = nome;
            DataFundacao = dataFundacao;
            NomePresidente = nomePresidente;
            NomeMascote = nomeMascote;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public string Nome { get; private set; }
        public DateTime DataFundacao { get; private set; }
        public string NomePresidente { get; private set; }
        public string NomeMascote { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }
    }
}