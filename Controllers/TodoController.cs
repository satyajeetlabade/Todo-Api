using System;
using Cached_Api.DTOs;
using Cached_Api.Interfaces;
using Cached_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Cached_Api.Controllers
{
    [EnableRateLimiting("fixed")]
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodoController(ITodoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/todo
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var todos = await _repository.GetAllAsync(pageNumber, pageSize);
            return Ok(todos);
        }

        // GET: api/todo/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var todo = await _repository.GetByIdAsync(id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }

        // POST: api/todo
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateTodoDto dto)
        {
            var todo = new Todo
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(todo);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = todo.Id }, todo);
        }

        // PUT: api/todo/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromBody] Todo todo, int id)
        {
            if (id != todo.Id)
                return BadRequest("Id Mismatch");

            await _repository.UpdateAsync(todo);

            return NoContent();
        }

        // DELETE: api/todo/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
