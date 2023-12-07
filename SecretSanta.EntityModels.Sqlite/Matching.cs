using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SecretSanta.EntityModels;

[Table("Matching")]
[Index("MatchId", IsUnique = true)]
public partial class Matching
{
    [Key]
    [Column("MatchID")]
    public int MatchId { get; set; }

    [Column(TypeName = "datetime")]
    [Required]
    public DateTime MatchDate { get; set; }
    [Required]
    public string MatchContent { get; set; } = null!;
}
