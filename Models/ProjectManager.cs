using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datanaut.Models;

[Table("ProjectManager")]
public partial class ProjectManager
{
    [Key]
    [Column("PKProjectManagerID")]
    public int PkprojectManagerId { get; set; }

    [Column("FKRoleID")]
    public int FkroleId { get; set; }

    [ForeignKey("FkroleId")]
    [InverseProperty("ProjectManagers")]
    public virtual Role Fkrole { get; set; } = null!;

    [InverseProperty("FkprojectManager")]
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    [InverseProperty("FkprojectManager")]
    public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
}
