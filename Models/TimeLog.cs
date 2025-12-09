using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datanaut.Models;

[Table("TimeLog")]
public partial class TimeLog
{
    [Key]
    [Column("PKTimeLogID")]
    public int PktimeLogId { get; set; }

    [Column("FKTeamMemberID")]
    public int FkteamMemberId { get; set; }

    [Column("FKReportID")]
    public int FkreportId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Activity { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal TimeWorked { get; set; }

    public DateOnly DateLogged { get; set; }

    [ForeignKey("FkreportId")]
    [InverseProperty("TimeLogs")]
    public virtual Report Fkreport { get; set; } = null!;

    [ForeignKey("FkteamMemberId")]
    [InverseProperty("TimeLogs")]
    public virtual TeamMember FkteamMember { get; set; } = null!;
}
