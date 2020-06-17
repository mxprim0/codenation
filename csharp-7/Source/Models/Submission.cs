using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class Submission
    {
        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("challenge_id")]
        public int ChallengeId { get; set; }

        [Required]
        [Column("score")]
        public decimal Score { get; set; }

        [Required]
        [Timestamp]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ChallengeId")]
        public Challenge Challenge { get; set; }
    }
}