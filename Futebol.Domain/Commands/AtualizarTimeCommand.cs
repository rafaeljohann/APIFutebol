using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Futebol.Domain.Commands.Contracts;

namespace Futebol.Domain.Commands
{
    public class AtualizarTimeCommand : ICommand
    {
        public AtualizarTimeCommand() { }
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataFundacao { get; set; }
        public string NomePresidente { get; set; }
        public string NomeMascote { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
    }
}