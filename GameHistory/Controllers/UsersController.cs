
using GameHistory.DTOs;
using GameHistory.Models;
using GameHistory.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BCryptNet = BCrypt.Net.BCrypt;

namespace GameHistory.Controllers
{
    /// <summary>
    /// Contrôleur pour la gestion des utilisateurs.
    /// Conforme à l'examen : route REST, validation, hash Bcrypt.
    /// </summary>
    [ApiController]
    [Route("users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Crée un nouvel utilisateur.
        /// POST /users
        /// Codes : 201 (Created), 409 (Conflict)
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto dto)
        {
            // Vérification des données envoyées
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Vérifier doublons Email
            if (await _userRepository.EmailExistsAsync(dto.Email))
                return Conflict(new { message = "Email déjà utilisé." });

            // Vérifier doublons Pseudo
            if (await _userRepository.PseudoExistsAsync(dto.Pseudo))
                return Conflict(new { message = "Pseudo déjà utilisé." });

            // Hash du mot de passe avec Bcrypt (BCrypt.Net-Next)
            var hashedPassword = BCryptNet.HashPassword(dto.Password);

            // Instanciation du modèle User
            var user = new User
            {
                Pseudo = dto.Pseudo,
                Email = dto.Email,
                PasswordHash = hashedPassword, // ✅ string
                Role = dto.Role
            };

            // Création en base via Repository Pattern
            var createdUser = await _userRepository.CreateUserAsync(user);

            // Retourne un objet sans mot de passe
            var response = new UserDto
            {
                Id = createdUser.Id,
                Pseudo = createdUser.Pseudo,
                Email = createdUser.Email,
                Role = createdUser.Role
            };

            // Retourne 201 Created avec URL simple
            return Created($"users/{createdUser.Id}", response);
        }
    }
}
