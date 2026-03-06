using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vinculaciones.Persistence.Entities;

[Table("permissions")]
[Index("RoleId", "MenuId", Name = "permissions_role_id_menu_id_key", IsUnique = true)]
public partial class Permission
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("role_id")]
    public long RoleId { get; set; }

    [Column("menu_id")]
    public long MenuId { get; set; }

    [Column("read")]
    public bool? Read { get; set; }

    [Column("created")]
    public bool? Created { get; set; }

    [Column("updated")]
    public bool? Updated { get; set; }

    [Column("deleted")]
    public bool? Deleted { get; set; }

    [Column("allowed")]
    public bool? Allowed { get; set; }

    [ForeignKey("MenuId")]
    [InverseProperty("Permissions")]
    public virtual Menu Menu { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("Permissions")]
    public virtual Role Role { get; set; } = null!;
}
