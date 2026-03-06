using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vinculaciones.Persistence.Entities;

[PrimaryKey("UserId", "EstablecimientoId")]
[Table("users_establishments")]
public partial class UsersEstablishment
{
    [Key]
    [Column("user_id")]
    public long UserId { get; set; }

    [Key]
    [Column("establecimiento_id")]
    public long EstablecimientoId { get; set; }

    [Column("enabled")]
    public bool? Enabled { get; set; }

    [ForeignKey("EstablecimientoId")]
    [InverseProperty("UsersEstablishments")]
    public virtual Establishment Establecimiento { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("UsersEstablishments")]
    public virtual User User { get; set; } = null!;
}
