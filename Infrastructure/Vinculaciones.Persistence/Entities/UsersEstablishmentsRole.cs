using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vinculaciones.Persistence.Entities;

[PrimaryKey("UserId", "EstablecimientoId", "RoleId")]
[Table("users_establishments_roles")]
public partial class UsersEstablishmentsRole
{
    [Key]
    [Column("user_id")]
    public long UserId { get; set; }

    [Key]
    [Column("establecimiento_id")]
    public long EstablecimientoId { get; set; }

    [Key]
    [Column("role_id")]
    public long RoleId { get; set; }

    [Column("enabled")]
    public bool? Enabled { get; set; }

    [ForeignKey("EstablecimientoId")]
    [InverseProperty("UsersEstablishmentsRoles")]
    public virtual Establishment Establecimiento { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("UsersEstablishmentsRoles")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UsersEstablishmentsRoles")]
    public virtual User User { get; set; } = null!;
}
