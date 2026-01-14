using System.ComponentModel.DataAnnotations;

namespace GameHistory.DTOs
{
    /// <summary>
    /// DTO pour la création d'un utilisateur.
    /// Conforme à l'examen : inclut le mot de passe en clair pour hashage.
    /// </summary>
    
    public class UserCreateDto
    {
        [Required]
        [MaxLength(100)]
        public required string Pseudo { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(150)]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        public required string Password { get; set; }

        [Required]
        public required string Role { get; set; } // admin ou user
    }

}