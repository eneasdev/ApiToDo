using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using ToDo.Controllers;
using ToDo.Models;
using ToDo.Repository;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {

        [Trait("TodoController", "Buscar todas as tarefas")]
        [Fact(DisplayName = "Deveria retornar null")]
        public void DeveriaRetornarNull()
        {
            //Arrange
            var TarefaRepositoryMock = new Mock<ITarefaRepository>();
            var sutTodoController = new ToDoController(TarefaRepositoryMock.Object);

            //Act
            var retorno = sutTodoController.Get() as StatusCodeResult;

            //Assert
            Assert.True(retorno.StatusCode == 404);
        }

        [Trait("TodoController", "Buscar todas as tarefas")]
        [Fact(DisplayName = "Deveria retornar uma lista de tarefas")]
        public void DeveriaRetornarUmaListaDeTarefas()
        {
            //Arrange
            var TarefaRepositoryMock = new Mock<ITarefaRepository>();
            TarefaRepositoryMock.Setup(t => t.Get()).Returns(new List<Tarefa>());
            var sutTodoController = new ToDoController(TarefaRepositoryMock.Object);

            //Act
            var retorno = sutTodoController.Get();

            //Assert
            Assert.True(retorno != null);
        }
    }
}
