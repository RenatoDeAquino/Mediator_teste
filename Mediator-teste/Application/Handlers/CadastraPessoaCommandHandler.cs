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
    public class CadastraPessoaCommandHandler : IRequestHandler<CadastraPessoaCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Pessoa> _repository;

        public CadastraPessoaCommandHandler(IMediator mediator, IRepository<Pessoa> repository)
        {
            this._repository = repository;
            this._mediator = mediator;
        }
        public async Task<string> Handle(CadastraPessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = new Pessoa { Nome = request.Nome, Idade = request.Idade, Sexo = request.Sexo };

            try
            {
                pessoa = await _repository.Add(pessoa);

                await _mediator.Publish(new PessoaCriadaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo });

                return await Task.FromResult("Pessoa criada com sucesso");

            } catch (Exception ex)
            {
                await _mediator.Publish(new PessoaCriadaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }
        }
    }
}
