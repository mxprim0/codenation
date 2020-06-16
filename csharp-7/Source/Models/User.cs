using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("user")]
    public class User
    {
        [Required]
        [Key]
        [Column("id")]
        public int UserId { get; set; }

        [Required]
        [Column("full_name")]
        public string UserName { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("nickname")]
        public string Nickname { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Required]
        [Timestamp]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Required]
        public List<Submission> Submissions { get; set; }

        [Required]
        public List<Candidate> Candidates { get; set; }
    }
}