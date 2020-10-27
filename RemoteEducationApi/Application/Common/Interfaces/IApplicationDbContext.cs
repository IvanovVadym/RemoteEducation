using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Teacher> Teachers { get; set; }

        DbSet<Student> Students { get; set; }

        DbSet<Subject> Subjects { get; set; }

        DbSet<Group> Groups { get; set; }

        DbSet<Schedule> Schedules { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
