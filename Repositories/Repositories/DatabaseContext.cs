﻿using Domains.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        
        public DbSet<Button> Button { get; set; }
        
        public DbSet<Tag> Tag { get; set; }

        //public DbSet<CategoryTag> CategoryTag { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Button>()
                .HasOne(s => s.Category)
                .WithMany(g => g.Buttons)
                .HasForeignKey(s => s.CategoryId);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Categories);
        }
    }
}
