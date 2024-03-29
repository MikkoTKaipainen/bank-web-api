﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BankWepApi.Models
{
    public partial class BackendbankdbContext : DbContext
    {
        public BackendbankdbContext()
        {
        }

        public BackendbankdbContext(DbContextOptions<BackendbankdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-SODL96L\\SQLEXPRESS;Initial Catalog=BackendBankdb;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.IBAN).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Bank");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Account_Customer");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.Property(e => e.BIC).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.Psw).IsUnicode(false);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_Customer_Bank");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.IBAN).IsUnicode(false);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Transaction_Account");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}