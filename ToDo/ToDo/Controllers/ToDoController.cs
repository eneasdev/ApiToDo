using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
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
            string []lista = new[] {""};
            if (_tarefaRepository.Get() == null) 
                return StatusCode(100,
                    "NaoExisteTarefas"
                    //["Error":"NaoExisteTarefas"]
                    );
            if (_tarefaRepository.Get().Count == 0)
                return Ok(lista);
            else
                return Ok(_tarefaRepository.Get());
        }

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Adicionar([FromBody]Tarefa tarefa)
        {
            if(tarefa == null)
                return NotFound(
                    "Insira uma tarefa."
                    );
            else
                _tarefaRepository.Adicionar(tarefa);
                return Ok(tarefa);
        }

        [Route("api/[controller]/{id}")]
        [HttpGet]
        public IActionResult Pegar([FromRoute]int id)
        {
            if (id <= 0)
                return NotFound(
                    "Tarefa não existe"
                    );
            else
                return Ok(_tarefaRepository.Pegar(id));
        }

        [Route("api/[controller]/{id}")]
        [HttpDelete]
        public IActionResult Deletar([FromRoute] int id)
        {
            if (id != 0)
                _tarefaRepository.Deletar(id);
                return Ok();
        }

        [Route("api/[controller]")]
        [HttpPatch]
        public IActionResult Atualizar([FromBody] Tarefa tarefa)
        {
            if(tarefa == null)
                return NotFound(
                    "Tarefa não encontrada"
                    );
            else
                _tarefaRepository.Atualizar(tarefa);
                return Ok();
        }
    }
}