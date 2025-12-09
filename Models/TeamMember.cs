using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datanaut.Models;

[Table("TeamMember")]
public partial class TeamMember
{
    [Key]
    [Column("PKTeamMemberID")]
    public int PkteamMemberId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string? Skill { get; set; }

    [Column("FKProjectID")]
    public int FkprojectId { get; set; }

    [Column("FKProjectManagerID")]
    public int FkprojectManagerId { get; set; }

    [Column("FKRoleID")]
    public int FkroleId { get; set; }

    [ForeignKey("FkprojectId")]
    [InverseProperty("TeamMembers")]
    public virtual Project Fkproject { get; set; } = null!;

    [ForeignKey("FkprojectManagerId")]
    [InverseProperty("TeamMembers")]
    public virtual ProjectManager FkprojectManager { get; set; } = null!;

    [ForeignKey("FkroleId")]
    [InverseProperty("TeamMembers")]
    public virtual Role Fkrole { get; set; } = null!;

    [InverseProperty("FkteamMember")]
    public virtual ICollection<TimeLog> TimeLogs { get; set; } = new List<TimeLog>();
}
