namespace GameHistory.DTOs
{
    /// <summary>
    /// DTO pour exposer les données d'un jeu.
    /// </summary>
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EstimatedTime { get; set; }
    }
}