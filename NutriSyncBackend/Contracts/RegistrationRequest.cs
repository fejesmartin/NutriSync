using System.ComponentModel.DataAnnotations;

namespace NutriSyncBackend.Contracts;

public record RegistrationRequest( 
    [Required]string Email, 
    [Required]string Username, 
    [Required]string Password
    );