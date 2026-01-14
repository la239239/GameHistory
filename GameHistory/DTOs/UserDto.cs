namespace GameHistory.DTOs
{
    /// <summary>
    /// DTO pour exposer les données utilisateur sans mot de passe.
    /// Conforme à l'examen : ne jamais renvoyer PasswordHash.
    /// </summary>
    public class UserDto
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}