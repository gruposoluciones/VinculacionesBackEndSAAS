using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vinculaciones.Persistence.Entities;

[Table("users")]
[Index("Email", Name = "users_email_key", IsUnique = true)]
[Index("Username", Name = "users_username_key", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("username")]
    [StringLength(100)]
    public string Username { get; set; } = null!;

    [Column("email")]
    [StringLength(150)]
    public string Email { get; set; } = null!;

    [Column("password")]
    public string Password { get; set; } = null!;

    [Column("first_session")]
    public bool? FirstSession { get; set; }

    [Column("enabled")]
    public bool? Enabled { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [InverseProperty("IdUsersNavigation")]
    public virtual AdditionalDataUser? AdditionalDataUser { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<UsersEstablishment> UsersEstablishments { get; set; } = new List<UsersEstablishment>();

    [InverseProperty("User")]
    public virtual ICollection<UsersEstablishmentsRole> UsersEstablishmentsRoles { get; set; } = new List<UsersEstablishmentsRole>();
}
