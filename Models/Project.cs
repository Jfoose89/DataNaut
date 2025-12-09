using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datanaut.Models;

[Table("Project")]
public partial class Project
{
    [Key]
    [Column("PKProjectID")]
    public int PkprojectId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string ProjectName { get; set; } = null!;

    public DateOnly ProjectStartDate { get; set; }

    public DateOnly? ProjectEndDate { get; set; }

    [Column(TypeName = "decimal(12, 2)")]
    public decimal? Budget { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("FKProjectManagerID")]
    public int FkprojectManagerId { get; set; }

    [ForeignKey("FkprojectManagerId")]
    [InverseProperty("Projects")]
    public virtual ProjectManager FkprojectManager { get; set; } = null!;

    [InverseProperty("Fkproject")]
    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    [InverseProperty("Fkproject")]
    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();

    [InverseProperty("Fkproject")]
    public virtual ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
}
