using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _items;

        public TodoQueryTests()
        {
            _items = new List<TodoItem>();
            _items.Add(new TodoItem("Tarefa 1", "guilherme", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 2", "userA", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 3", "guilherme", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 4", "userB", DateTime.Now));
            _items.Add(new TodoItem("Tarefa 5", "UserC", DateTime.Now));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_usuario_guilherme()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAll("guilherme"));
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_concluidas_do_usuario_guilherme()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("guilherme"));
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_nao_concluidas_do_usuario_guilherme()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("guilherme"));
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_concluidas_de_um_periodo_do_usuario_guilherme()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("guilherme", DateTime.Now, true));
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void Dada_a_consulta_deve_retornar_tarefas_nao_concluidas_de_um_periodo_do_usuario_guilherme()
        {
            var result = _items.AsQueryable().Where(TodoQueries.GetByPeriod("guilherme", DateTime.Now, false));
            Assert.AreEqual(2, result.Count());
        }

    }
}