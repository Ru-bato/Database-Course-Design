﻿using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using DB_Backend.DB_BackendModel;

namespace DB_Backend.DB_BackendDAL
{
    public class MyTicketDbContext : DbContext
    {
        public MyTicketDbContext(DbContextOptions<MyTicketDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyTicket> ORDERLIST { get; set; }
        public DbSet<Train> TRAIN { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 配置主键、外键等关系
            modelBuilder.Entity<MyTicket>()
                .HasOne<Train>()
                .WithMany()
                .HasForeignKey(o => o.Train_id);
        }
    }
}
