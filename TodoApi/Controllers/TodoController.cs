using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Controllers
{
	
	public class TodoController : ControllerBase
	{
		private readonly TodoContext _context;

		public TodoController(TodoContext context)
		{
			_context = context;
		}

		[Route("api/todos")]
		[HttpGet]
		public List<TodoItem> GetAll()
		{
			return _context.TodoItems.ToList();
		}

		[HttpGet("{id}", Name = "GetTodo")]
		public IActionResult GetById(long id)
		{
			var item = _context.TodoItems.Find(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		[Route("api/todo/save")]
		[HttpPost]
		public IActionResult Create([FromBody] TodoItem item)
		{
			if (item == null)
			{
				return BadRequest();
			}

			_context.TodoItems.Add(item);
			_context.SaveChanges();

			return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
		}

		[Route("api/todo/update/{id}")]
		[HttpPut]
		public IActionResult Update(long id, [FromBody] TodoItem item)
		{
			if (item == null)
			{
				return BadRequest();
			}

			var todo = _context.TodoItems.Find(id);
			if (todo == null)
			{
				return NotFound();
			}

			todo.IsComplete = item.IsComplete;
			todo.Name = item.Name;

			_context.TodoItems.Update(todo);
			_context.SaveChanges();
			return NoContent();
		}

		[Route("api/todo/delete/{id}")]
		[HttpDelete]
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }
	}
}