using E_CODING_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_CODING_DAL
{
    //Add-Migration AddingEFExtensions -Context TemplateProjectDbContext -Project E-CODING-DAL -StartupProject E-CODING-MVC-NET6-0
    public class TemplateProjectDbContext : DbContext
    {

        public TemplateProjectDbContext(DbContextOptions<TemplateProjectDbContext> options)
            : base(options)
        {}

        public virtual DbSet<TemplateSolution> TemplateSolution { get; set; }
        public virtual DbSet<TemplateProject> TemplateProject { get; set; }        
        public virtual DbSet<TemplateTechnique> TemplateTechnique { get; set; }
        public virtual DbSet<TemplateTechniqueItem> TemplateTechniqueItem { get; set; }
        public virtual DbSet<TemplateResult> TemplateResult { get; set; }
        public virtual DbSet<TemplateResultItem> TemplateResultItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-2TG0VPH\\SQLEXPRESS;database=ELearning;Trusted_Connection=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TemplateSolution>(entity =>
            {
                entity.HasKey(z => z.TemplateSolutionId);
                entity.Property(p => p.TemplateSolutionId)
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TemplateProject>(entity =>
            {
                entity.HasKey(e => e.TemplateProjectId);
                entity.Property(p => p.TemplateProjectId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateSolution)
                    .WithMany(p => p.TemplateProject)
                    .HasForeignKey(d => d.TemplateSolutionId);
            });

            modelBuilder.Entity<TemplateTechnique>(entity =>
            {
                entity.HasKey(e => e.TemplateTechniqueId);
                entity.Property(p => p.TemplateTechniqueId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateProject)
                    .WithMany(p => p.TemplateTechnique)
                    .HasForeignKey(d => d.TemplateProjectId);
            });            

            modelBuilder.Entity<TechniqueParameter>(entity =>
            {
                entity.HasKey(e => e.TechniqueParameterId);
                entity.Property(p => p.TechniqueParameterId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateTechnique)
                    .WithMany(p => p.TechniqueParameter)
                    .HasForeignKey(d => d.TemplateTechniqueId);
            });

            modelBuilder.Entity<TemplateTechniqueItem>(entity =>
            {
                entity.HasKey(e => e.TemplateTechniqueItemId);
                entity.Property(p => p.TemplateTechniqueItemId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateTechnique)
                    .WithMany(p => p.TemplateTechniqueItem)
                    .HasForeignKey(d => d.TemplateTechniqueId);
            });
            
            modelBuilder.Entity<TemplateResult>(entity =>
            {
                entity.HasKey(e => e.TemplateResultId);
                entity.Property(p => p.TemplateResultId)
                .ValueGeneratedOnAdd();
            });                   

            modelBuilder.Entity<TemplateResultItem>(entity =>
            {
                entity.HasKey(e => e.TemplateResultItemId);
                entity.Property(p => p.TemplateResultItemId)
                .ValueGeneratedOnAdd();

                entity.HasOne(d => d.TemplateResult)
                    .WithMany(p => p.TemplateResultItem)
                    .HasForeignKey(d => d.TemplateResultId);
            });
        }
     }
}