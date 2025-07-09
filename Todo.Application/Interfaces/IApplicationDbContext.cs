using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Todo.Domain.Entities;

namespace Todo.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoItem> TodoItems { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
