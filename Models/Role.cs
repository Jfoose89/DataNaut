using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datanaut.Models;

[Table("Role")]
[Index("RoleName", Name = "UQ_Role_RoleName", IsUnique = true)]
public partial class Role
{
    [Key]
    [Column("PKRoleID")]
    public int PkroleId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string RoleName { get; set; } = null!;

    [InverseProperty("Fkrole")]
    public virtual ICollection<ProjectManager> ProjectManagers { get; set; } = new List<ProjectManager>();

    [InverseProperty("Fkrole")]
    public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
}
