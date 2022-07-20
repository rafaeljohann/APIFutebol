namespace Futebol.Domain.Entities
{
    public class Time : Entity
    {
        public string Nome { get; init; }
        public DateTime DataFundacao { get; init; }
        public string NomePresidente { get; init; }
        public string NomeMascote { get; init; }
        public string Cidade { get; init; }
        public string Estado { get; init; }
        public string Pais { get; init; }
        
        public Time(
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
    }
}