using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator_teste.Application.Notifications
{
    public class PessoaExcluidaNotification : INotification
    {
        public int Id { get; set; }
        public bool IsEfetivado { get; set; }
    }
}
