using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator_teste.Application.Notifications
{
    public class PessoaAlteradaNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public bool IsEfetivado { get; set; }
    }
}
