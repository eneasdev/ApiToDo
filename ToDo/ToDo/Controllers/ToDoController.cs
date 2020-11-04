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
            var listaDeTarefas = _tarefaRepository.Get();
            return Ok(listaDeTarefas);
        }

        [Route("api/[controller]/{id}")]
        [HttpGet]
        public IActionResult Pegar([FromRoute] int id)
        {
            if (id <= 0)
                return NotFound();

            var tarefa = _tarefaRepository.Pegar(id);

            if (tarefa == null)
                return NotFound();

            else
                return Ok(tarefa);
        }

        [Route("api/[controller]")]
        [HttpPost]
        public IActionResult Adicionar([FromBody] Tarefa tarefa)
        {
            if (string.IsNullOrEmpty(tarefa.Nome))
                return BadRequest();
            else
                _tarefaRepository.Adicionar(tarefa);
            return Ok(tarefa);
        }

        [Route("api/[controller]/{id}")]
        [HttpDelete]
        public IActionResult Deletar([FromRoute] int id)
        {
            if (id > 0)
            {
                var tarefa = _tarefaRepository.Pegar(id);

                if (tarefa == null)
                {
                    return BadRequest();
                }
                    _tarefaRepository.Deletar(tarefa);
                    return Ok();
                    //Se Ok() retornar com parametro conseguimos verificar se o stuatus http é 200
                    //return Ok(tarefa);
            } 
            else
            {
                return BadRequest();
            }

            
        }

        [Route("api/[controller]")]
        [HttpPatch]
        public IActionResult Atualizar([FromBody] Tarefa tarefa)
        {
            if (tarefa.Id <= 0 || string.IsNullOrEmpty(tarefa.Nome))
                return BadRequest();
            else
                _tarefaRepository.Atualizar(tarefa);
            return Ok();
        }
    }
}