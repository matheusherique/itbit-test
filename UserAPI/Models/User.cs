using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserAPI.Models
{
    public class User
    {
        [Required]
        [Key]
        public int UserId {get; set;}

        [Required]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "The name value cannot exceed 200 characters.")]
        public string Name {get; set;}

        [Required]
        public DateTime Birthday {get; set;}

        [Required]
        [StringLength(100, ErrorMessage = "The email value cannot exceed 100 characters.")]
        public string Email {get; set;}

        [Required]
        [StringLength(30, ErrorMessage = "The password value cannot exceed 30 characters.")]
        public string Password {get; set;}

        [Required]
        public bool Active {get; set;}

        [ForeignKey("GenreId")]
        public Genre GenreFK {get; set;}
    }
}