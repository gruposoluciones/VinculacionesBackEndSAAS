using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vinculaciones.Persistence.Entities;

[Table("tipos_doc_identidad")]
[Index("DescripcionCorta", Name = "tipos_doc_identidad_descripcion_corta_key", IsUnique = true)]
[Index("Descripcion", Name = "tipos_doc_identidad_descripcion_key", IsUnique = true)]
public partial class TiposDocIdentidad
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("descripcion")]
    [StringLength(100)]
    public string Descripcion { get; set; } = null!;

    [Column("descripcion_corta")]
    [StringLength(10)]
    public string DescripcionCorta { get; set; } = null!;

    [Column("enabled")]
    public bool? Enabled { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("IdTipoDocIdenNavigation")]
    public virtual ICollection<AdditionalDataUser> AdditionalDataUsers { get; set; } = new List<AdditionalDataUser>();
}
