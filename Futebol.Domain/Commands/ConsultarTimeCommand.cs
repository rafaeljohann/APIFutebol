using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Futebol.Domain.Commands.Contracts;

namespace Futebol.Domain.Commands
{
    public class ConsultarTimeCommand : ICommand
    {
        public ConsultarTimeCommand() { }

        public long Id { get; set; }
    }
}