using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SecretSanta.EntityModels;

[Index("ParticipantId", IsUnique = true)]
public partial class Participant
{
    [Key]
    [Column("ParticipantID")]
    public int ParticipantId { get; set; }

    [StringLength(50)]
    [Required]
    public string ParticipantName { get; set; } = null!;
}
