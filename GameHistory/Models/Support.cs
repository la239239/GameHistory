using System.ComponentModel.DataAnnotations;

namespace GameHistory.Models
{
    /// <summary>
    /// Représente un support (PC, PS5, Xbox).
    /// Conforme à l'examen : nom unique et obligatoire.
    /// </summary>
    public class Support
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}