namespace GameHistory.DTOs
{
    /// <summary>
    /// DTO pour exposer une session de jeu (historique).
    /// </summary>
    public class SessionDto
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int MinutesPlayed { get; set; }
        public DateTime PlayedAt { get; set; }
    }
}