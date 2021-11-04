using System;
using Homework27.Models;
using Microsoft.EntityFrameworkCore;


namespace Homework27.Context {
    public class MVCContext : DbContext {
        public MVCContext(DbContextOptions options) : base(options) {}

        public DbSet<Product> Products { get; set; }
    }
}
