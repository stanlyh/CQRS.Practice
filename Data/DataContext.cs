using CQRS.Practice.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Practice.Data
{
    public class DataContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
