using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vinculaciones.Persistence.Entities;

[Table("additional_data_users")]
[Index("IdUsers", Name = "additional_data_users_id_users_key", IsUnique = true)]
public partial class AdditionalDataUser
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("id_users")]
    public long IdUsers { get; set; }

    [Column("primer_nombre")]
    [StringLength(150)]
    public string? PrimerNombre { get; set; }

    [Column("segundo_nombre")]
    [StringLength(150)]
    public string? SegundoNombre { get; set; }

    [Column("apellido_paterno")]
    [StringLength(150)]
    public string? ApellidoPaterno { get; set; }

    [Column("apellido_materno")]
    [StringLength(150)]
    public string? ApellidoMaterno { get; set; }

    [Column("fecha_nacimiento")]
    public DateOnly? FechaNacimiento { get; set; }

    [Column("id_tipo_doc_iden")]
    public long? IdTipoDocIden { get; set; }

    [Column("nro_doc_identidad")]
    [StringLength(15)]
    public string? NroDocIdentidad { get; set; }

    [Column("nro_telefono")]
    [StringLength(10)]
    public string? NroTelefono { get; set; }

    [ForeignKey("IdTipoDocIden")]
    [InverseProperty("AdditionalDataUsers")]
    public virtual TiposDocIdentidad? IdTipoDocIdenNavigation { get; set; }

    [ForeignKey("IdUsers")]
    [InverseProperty("AdditionalDataUser")]
    public virtual User IdUsersNavigation { get; set; } = null!;
}
