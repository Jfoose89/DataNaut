using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datanaut.Models;

[Index("ResourceName", "FkprojectId", Name = "UQ_Resources_Name_Project", IsUnique = true)]
public partial class Resource
{
    [Key]
    [Column("PKResourceID")]
    public int PkresourceId { get; set; }

    [Column("FKProjectID")]
    public int FkprojectId { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string ResourceName { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string ResourceType { get; set; } = null!;

    [ForeignKey("FkprojectId")]
    [InverseProperty("Resources")]
    public virtual Project Fkproject { get; set; } = null!;
}
