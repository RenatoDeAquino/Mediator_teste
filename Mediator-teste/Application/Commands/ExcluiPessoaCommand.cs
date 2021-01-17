using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator_teste.Application.Commands
{
    public class ExcluiPessoaCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
