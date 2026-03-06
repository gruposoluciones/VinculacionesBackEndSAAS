using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vinculaciones.Persistence.Entities;

[Table("establishments")]
public partial class Establishment
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(150)]
    public string Name { get; set; } = null!;

    [Column("address")]
    public string? Address { get; set; }

    [Column("enabled")]
    public bool? Enabled { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("Establecimiento")]
    public virtual ICollection<UsersEstablishment> UsersEstablishments { get; set; } = new List<UsersEstablishment>();

    [InverseProperty("Establecimiento")]
    public virtual ICollection<UsersEstablishmentsRole> UsersEstablishmentsRoles { get; set; } = new List<UsersEstablishmentsRole>();
}
