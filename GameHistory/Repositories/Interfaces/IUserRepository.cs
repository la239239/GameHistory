using GameHistory.Models;
using System.Threading.Tasks;

namespace GameHistory.Repositories.Interfaces
{
    /// <summary>
    /// Interface pour la gestion des utilisateurs.
    /// Conforme à l'examen : pattern Repository + méthodes asynchrones.
    /// </summary>
    
    public interface IUserRepository
    {
        Task<bool> EmailExistsAsync(string email);
        Task<bool> PseudoExistsAsync(string pseudo);
        Task<User> CreateUserAsync(User user);
    }

}