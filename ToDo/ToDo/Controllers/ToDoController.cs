using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.Repository;

namespace ToDo.Controllers
{
    public class ToDoController : Controller
    {
        readonly ITarefaRepository _tarefaRepository;
        public ToDoController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [Route("api/[controller]")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tarefaRepository.Get());
        }

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Adicionar([FromBody]Tarefa tarefa)
        {
            _tarefaRepository.Adicionar(tarefa);
            return Ok(tarefa);
        }

        [Route("api/[controller]/{id}")]
        [HttpGet]
        public IActionResult Pegar([FromRoute]int id)
        {
            return Ok(_tarefaRepository.Pegar(id));
        }

        [Route("api/[controller]/{id}")]
        [HttpDelete]
        public IActionResult Deletar([FromRoute] int id)
        {
            _tarefaRepository.Deletar(id);
            return Ok();
        }

        [Route("api/[controller]")]
        [HttpPatch]
        public IActionResult Atualizar([FromBody] Tarefa tarefa)
        {
            _tarefaRepository.Atualizar(tarefa);
            return Ok();
        }
    }
}
