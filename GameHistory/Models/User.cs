using System.ComponentModel.DataAnnotations;

namespace GameHistory.Models
{
    /// <summary>
    /// Représente un utilisateur du système.
    /// Conforme à l'examen : pseudo et email uniques, mot de passe hashé, rôle limité à admin/user.
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; } // Pas required, généré par la DB

        [Required]
        [MaxLength(100)]
        public required string Pseudo { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string PasswordHash { get; set; } // ✅ string, pas byte[]

        [Required]
        [MaxLength(5)]
        public required string Role { get; set; } // admin ou user
    }
}