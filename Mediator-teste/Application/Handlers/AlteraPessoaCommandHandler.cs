using Mediator_teste.Application.Commands;
using Mediator_teste.Application.Models;
using Mediator_teste.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator_teste.Application.Handlers
{
    public class AlteraPessoaCommandHandler : IRequestHandler<AlteraPessoaCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Pessoa> _repository;

        public AlteraPessoaCommandHandler(IMediator mediator, IRepository<Pessoa> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(AlteraPessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = new Pessoa { Id = request.Id, Nome = request.Nome, Idade = request.Idade, Sexo = request.Sexo};

            try
            {
                await _repository.Edit(pessoa);
                await _mediator.Publish(new PessoaAlteradaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo, IsEfetivado = true });

                return await Task.FromResult("Pessoa Alterada com sucesso");
            } catch (Exception ex)
            {
                await _mediator.Publish(new PessoaAlteradaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo, IsEfetivado = false });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da alteração");
            }

           
        }
    }
}
