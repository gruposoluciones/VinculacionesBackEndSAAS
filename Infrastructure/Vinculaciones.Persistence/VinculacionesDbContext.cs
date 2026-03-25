using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Vinculaciones.Application.dtos.User;
using Vinculaciones.Persistence.Entities;

namespace Vinculaciones.Persistence;

public partial class VinculacionesDbContext : DbContext
{
    public VinculacionesDbContext(DbContextOptions<VinculacionesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdditionalDataUser> AdditionalDataUsers { get; set; }

    public virtual DbSet<Establishment> Establishments { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TiposDocIdentidad> TiposDocIdentidads { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UsersEstablishment> UsersEstablishments { get; set; }

    public virtual DbSet<UsersEstablishmentsRole> UsersEstablishmentsRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdditionalDataUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("additional_data_users_pkey");

            entity.HasOne(d => d.IdTipoDocIdenNavigation).WithMany(p => p.AdditionalDataUsers).HasConstraintName("additional_data_users_id_tipo_doc_iden_fkey");

            entity.HasOne(d => d.IdUsersNavigation).WithOne(p => p.AdditionalDataUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("additional_data_users_id_users_fkey");
        });

        modelBuilder.Entity<Establishment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("establishments_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Enabled).HasDefaultValue(true);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("menus_pkey");

            entity.Property(e => e.Enabled).HasDefaultValue(true);

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent).HasConstraintName("menus_parent_id_fkey");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("permissions_pkey");

            entity.Property(e => e.Allowed).HasDefaultValue(true);

            entity.HasOne(d => d.Menu).WithMany(p => p.Permissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("permissions_menu_id_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.Permissions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("permissions_role_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");

            entity.Property(e => e.Enabled).HasDefaultValue(true);
        });

        modelBuilder.Entity<TiposDocIdentidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tipos_doc_identidad_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Enabled).HasDefaultValue(true);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.Enabled).HasDefaultValue(true);
            entity.Property(e => e.FirstSession).HasDefaultValue(false);
        });

        modelBuilder.Entity<UsersEstablishment>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.EstablecimientoId }).HasName("users_establishments_pkey");

            entity.Property(e => e.Enabled).HasDefaultValue(true);

            entity.HasOne(d => d.Establecimiento).WithMany(p => p.UsersEstablishments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_establishments_establecimiento_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UsersEstablishments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_establishments_user_id_fkey");
        });

        modelBuilder.Entity<UsersEstablishmentsRole>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.EstablecimientoId, e.RoleId }).HasName("users_establishments_roles_pkey");

            entity.Property(e => e.Enabled).HasDefaultValue(true);

            entity.HasOne(d => d.Establecimiento).WithMany(p => p.UsersEstablishmentsRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_establishments_roles_establecimiento_id_fkey");

            entity.HasOne(d => d.Role).WithMany(p => p.UsersEstablishmentsRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_establishments_roles_role_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.UsersEstablishmentsRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_establishments_roles_user_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
