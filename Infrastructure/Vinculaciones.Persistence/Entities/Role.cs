using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vinculaciones.Persistence.Entities;

[Table("roles")]
[Index("Name", Name = "roles_name_key", IsUnique = true)]
public partial class Role
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("enabled")]
    public bool? Enabled { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();

    [InverseProperty("Role")]
    public virtual ICollection<UsersEstablishmentsRole> UsersEstablishmentsRoles { get; set; } = new List<UsersEstablishmentsRole>();
}
