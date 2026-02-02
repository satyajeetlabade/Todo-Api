using System;
using Cached_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Cached_Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    public DbSet<Todo> todos {get; set;}
}
