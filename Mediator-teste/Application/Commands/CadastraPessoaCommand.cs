using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator_teste.Application.Commands
{
    public class CadastraPessoaCommand : IRequest<string>
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }

    }
}
