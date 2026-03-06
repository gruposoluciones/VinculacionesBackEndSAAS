using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vinculaciones.Persistence.Entities;

[Table("menus")]
public partial class Menu
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("route")]
    [StringLength(150)]
    public string? Route { get; set; }

    [Column("icon")]
    [StringLength(50)]
    public string? Icon { get; set; }

    [Column("parent_id")]
    public long? ParentId { get; set; }

    [Column("enabled")]
    public bool? Enabled { get; set; }

    [InverseProperty("Parent")]
    public virtual ICollection<Menu> InverseParent { get; set; } = new List<Menu>();

    [ForeignKey("ParentId")]
    [InverseProperty("InverseParent")]
    public virtual Menu? Parent { get; set; }

    [InverseProperty("Menu")]
    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
