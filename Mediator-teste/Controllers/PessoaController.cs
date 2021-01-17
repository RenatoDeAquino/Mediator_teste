using Mediator_teste.Application.Commands;
using Mediator_teste.Application.Models;
using Mediator_teste.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediator_teste.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Pessoa> _repository;

        public PessoaController(IMediator mediator, IRepository<Pessoa> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _repository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CadastraPessoaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(AlteraPessoaCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var obj = new ExcluiPessoaCommand { Id = id };
            var result = await _mediator.Send(obj);
            return Ok(result);
        }
    }
}
