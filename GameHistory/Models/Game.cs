using System.ComponentModel.DataAnnotations;

namespace GameHistory.Models
{
    /// <summary>
    /// Représente un jeu vidéo.
    /// Conforme à l'examen : nom obligatoire, temps estimé > 0.
    /// </summary>
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Le temps estimé doit être supérieur à 0.")]
        public int EstimatedTime { get; set; }
    }
}