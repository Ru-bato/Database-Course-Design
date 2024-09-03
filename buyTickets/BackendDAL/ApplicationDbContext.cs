using Microsoft.EntityFrameworkCore;
using buyTickets.BackendModel;

namespace buyTickets.BackendDAL

{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        // 添加更多的 DbSet 属性，根据你的模型定义

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // 可以在这里配置实体和表之间的关系
        }
    }
}
