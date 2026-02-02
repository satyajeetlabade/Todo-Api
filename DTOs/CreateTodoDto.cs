using System;
using System.ComponentModel.DataAnnotations;

namespace Cached_Api.DTOs;

public class CreateTodoDto
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public bool IsCompleted { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
