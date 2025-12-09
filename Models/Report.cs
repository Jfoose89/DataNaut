using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datanaut.Models;

[Table("Report")]
[Index("FkprojectId", "ReportStartDate", "ReportEndDate", Name = "UQ_Report_Project_DateRange", IsUnique = true)]
public partial class Report
{
    [Key]
    [Column("PKReportId")]
    public int PkreportId { get; set; }

    [Column("FKProjectId")]
    public int FkprojectId { get; set; }

    public DateOnly ReportStartDate { get; set; }

    public DateOnly ReportEndDate { get; set; }

    [ForeignKey("FkprojectId")]
    [InverseProperty("Reports")]
    public virtual Project Fkproject { get; set; } = null!;

    [InverseProperty("Fkreport")]
    public virtual ICollection<TimeLog> TimeLogs { get; set; } = new List<TimeLog>();
}
