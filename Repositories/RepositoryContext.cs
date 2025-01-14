﻿using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Config;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Repositories;
  public class RepositoryContext : IdentityDbContext<IdentityUser>
    {
        //veritabanindaki Products tablosunu olusturduk
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

    public RepositoryContext(DbContextOptions<RepositoryContext> options) :base(options)
        {
              
        }

        //tabloda veri yoksa bu 5 kayıdı veri tabanina yansit.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new ProductConfig());
            //modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}
