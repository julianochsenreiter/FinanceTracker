﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FinanceTrackerLibrary.Models
{
    public partial class financetrackerContext : DbContext
    {
        public financetrackerContext()
        {
        }

        public financetrackerContext(DbContextOptions<financetrackerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Bonds> Bonds { get; set; }
        public virtual DbSet<Depot> Depot { get; set; }
        public virtual DbSet<DepotBonds> DepotBonds { get; set; }
        public virtual DbSet<DepotStocks> DepotStocks { get; set; }
        public virtual DbSet<Stocks> Stocks { get; set; }
        public virtual DbSet<Transactionlog> Transactionlog { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=financetracker;User Id=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Aid)
                    .HasName("account_pkey");

                entity.ToTable("account");

                entity.Property(e => e.Aid)
                    .ValueGeneratedNever()
                    .HasColumnName("aid");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.Uid)
                    .HasConstraintName("account_uid_fkey");
            });

            modelBuilder.Entity<Bonds>(entity =>
            {
                entity.HasKey(e => e.Seid)
                    .HasName("bonds_pkey");

                entity.ToTable("bonds");

                entity.Property(e => e.Seid)
                    .ValueGeneratedNever()
                    .HasColumnName("seid");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Runtime).HasColumnName("runtime");

                entity.Property(e => e.Securitynumber).HasColumnName("securitynumber");

                entity.Property(e => e.Yield).HasColumnName("yield");
            });

            modelBuilder.Entity<Depot>(entity =>
            {
                entity.HasKey(e => e.Did)
                    .HasName("depot_pkey");

                entity.ToTable("depot");

                entity.Property(e => e.Did)
                    .ValueGeneratedNever()
                    .HasColumnName("did");

                entity.Property(e => e.Aid).HasColumnName("aid");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Type)
                    .HasColumnType("character varying")
                    .HasColumnName("type");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.HasOne(d => d.AidNavigation)
                    .WithMany(p => p.Depot)
                    .HasForeignKey(d => d.Aid)
                    .HasConstraintName("depot_aid_fkey");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Depot)
                    .HasForeignKey(d => d.Uid)
                    .HasConstraintName("depot_uid_fkey");
            });

            modelBuilder.Entity<DepotBonds>(entity =>
            {
                entity.HasKey(e => new { e.Did, e.Seid })
                    .HasName("depot_bonds_pkey");

                entity.ToTable("depot_bonds");

                entity.Property(e => e.Did).HasColumnName("did");

                entity.Property(e => e.Seid).HasColumnName("seid");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.HasOne(d => d.DidNavigation)
                    .WithMany(p => p.DepotBonds)
                    .HasForeignKey(d => d.Did)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("depot_bonds_did_fkey");

                entity.HasOne(d => d.Se)
                    .WithMany(p => p.DepotBonds)
                    .HasForeignKey(d => d.Seid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("depot_bonds_seid_fkey");
            });

            modelBuilder.Entity<DepotStocks>(entity =>
            {
                entity.HasKey(e => e.Sharenumber)
                    .HasName("depot_stocks_pkey");

                entity.ToTable("depot_stocks");

                entity.Property(e => e.Sharenumber)
                    .ValueGeneratedNever()
                    .HasColumnName("sharenumber");

                entity.Property(e => e.Did).HasColumnName("did");

                entity.Property(e => e.Purcharsevalue).HasColumnName("purcharsevalue");

                entity.Property(e => e.Seid).HasColumnName("seid");

                entity.HasOne(d => d.DidNavigation)
                    .WithMany(p => p.DepotStocks)
                    .HasForeignKey(d => d.Did)
                    .HasConstraintName("depot_stocks_did_fkey");

                entity.HasOne(d => d.Se)
                    .WithMany(p => p.DepotStocks)
                    .HasForeignKey(d => d.Seid)
                    .HasConstraintName("depot_stocks_seid_fkey");
            });

            modelBuilder.Entity<Stocks>(entity =>
            {
                entity.HasKey(e => e.Seid)
                    .HasName("stocks_pkey");

                entity.ToTable("stocks");

                entity.Property(e => e.Seid)
                    .ValueGeneratedNever()
                    .HasColumnName("seid");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Securitynumber).HasColumnName("securitynumber");

                entity.Property(e => e.Stockvalue).HasColumnName("stockvalue");
            });

            modelBuilder.Entity<Transactionlog>(entity =>
            {
                entity.HasKey(e => e.Tlid)
                    .HasName("transactionlog_pkey");

                entity.ToTable("transactionlog");

                entity.Property(e => e.Tlid).HasColumnName("tlid");

                entity.Property(e => e.Seid).HasColumnName("seid");

                entity.Property(e => e.Sharenumber).HasColumnName("sharenumber");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.HasOne(d => d.Se)
                    .WithMany(p => p.Transactionlog)
                    .HasForeignKey(d => d.Seid)
                    .HasConstraintName("transactionlog_seid_fkey");

                entity.HasOne(d => d.SharenumberNavigation)
                    .WithMany(p => p.Transactionlog)
                    .HasForeignKey(d => d.Sharenumber)
                    .HasConstraintName("transactionlog_sharenumber_fkey");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Transactionlog)
                    .HasForeignKey(d => d.Uid)
                    .HasConstraintName("transactionlog_uid_fkey");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Uid)
                    .ValueGeneratedNever()
                    .HasColumnName("uid");

                entity.Property(e => e.Firstname)
                    .HasColumnType("character varying")
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasColumnType("character varying")
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .HasColumnType("character varying")
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasColumnType("character varying")
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}