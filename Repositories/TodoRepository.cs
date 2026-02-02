using Cached_Api.Data;
using Cached_Api.DTOs;
using Cached_Api.Interfaces;
using Cached_Api.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;

namespace Cached_Api.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IDatabase _redisDb;

    public TodoRepository(ApplicationDbContext context, IConnectionMultiplexer redis)
    {
        _context = context;
        _redisDb = redis.GetDatabase();
    }

    public async Task<PagedResult<Todo>> GetAllAsync(int pageNumber = 1, int pageSize = 10)
{
    string cacheKey = $"todos:page:{pageNumber}:size:{pageSize}";

    var cachedTodos = await _redisDb.StringGetAsync(cacheKey);
    if (cachedTodos.HasValue)
    {
        return JsonSerializer.Deserialize<PagedResult<Todo>>(cachedTodos);
    }

    var totalCount = await _context.todos.CountAsync();

    var todos = await _context.todos
                              .AsNoTracking().OrderBy(t => t.Id)
                              .Skip((pageNumber - 1) * pageSize)
                              .Take(pageSize)
                              .ToListAsync();

    var result = new PagedResult<Todo>
    {
        Items = todos,
        TotalCount = totalCount,
        PageNumber = pageNumber,
        PageSize = pageSize
    };

    await _redisDb.StringSetAsync(cacheKey, JsonSerializer.Serialize(result), TimeSpan.FromMinutes(5));

    return result;
}

    public async Task<Todo> GetByIdAsync(int id)
    {
        string cacheKey = $"todo:{id}";

        var cachedTodo = await _redisDb.StringGetAsync(cacheKey);
        if (cachedTodo.HasValue)
        {
            return JsonSerializer.Deserialize<Todo>(cachedTodo);
        }

        var todo = await _context.todos.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

        if (todo != null)
            await _redisDb.StringSetAsync(cacheKey, JsonSerializer.Serialize(todo), TimeSpan.FromMinutes(5));

        return todo;
    }
    public async Task AddAsync(Todo todo)
    {
        await _context.AddAsync(todo);
        await _context.SaveChangesAsync();

        // Invalidate cache
        await _redisDb.KeyDeleteAsync("todos");
    }

    public async Task UpdateAsync(Todo todo)
    {
        _context.Update(todo);
        await _context.SaveChangesAsync();

        await _redisDb.KeyDeleteAsync("todos");
        await _redisDb.KeyDeleteAsync($"todo:{todo.Id}");
    }

    public async Task DeleteAsync(int id)
    {
        var result = await _context.todos.FirstOrDefaultAsync(t => t.Id == id);
        if (result == null) return;

        _context.todos.Remove(result);
        await _context.SaveChangesAsync();

        await _redisDb.KeyDeleteAsync("todos");
        await _redisDb.KeyDeleteAsync($"todo:{id}");
    }

}