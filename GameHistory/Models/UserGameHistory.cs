using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameHistory.Models
{
    /// <summary>
    /// Historique des sessions de jeu d'un utilisateur.
    /// Conforme à l'examen : minutes >= 0, date par défaut = DateTime.Now.
    /// </summary>
    public class UserGameHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [ForeignKey("Game")]
        public int GameId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Les minutes jouées ne peuvent pas être négatives.")]
        public int MinutesPlayed { get; set; }

        [Required]
        public DateTime PlayedAt { get; set; } = DateTime.Now;
    }
}