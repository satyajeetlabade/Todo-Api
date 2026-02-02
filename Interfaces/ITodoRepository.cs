using System;
using Cached_Api.DTOs;
using Cached_Api.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cached_Api.Interfaces;

public interface ITodoRepository
{
    Task<PagedResult<Todo>> GetAllAsync(int pageNumber, int pageSize);
    Task<Todo> GetByIdAsync(int id);
    Task AddAsync(Todo todo);
    Task UpdateAsync(Todo todo);
    Task DeleteAsync(int id);

}
