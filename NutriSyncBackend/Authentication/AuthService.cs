using Microsoft.AspNetCore.Identity;

namespace NutriSyncBackend.Authentication;

// Service responsible for user authentication operations
        public class AuthService : IAuthService
        {
            private readonly UserManager<IdentityUser> _userManager;   // Manages user-related operations
            private readonly ITokenService _tokenService;              // Generates authentication tokens
            private readonly RoleManager<IdentityRole> _roleManager;   // Manages user roles

            public AuthService(UserManager<IdentityUser> userManager, ITokenService tokenService, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _tokenService = tokenService;
                _roleManager = roleManager;
            }

            // Registers a new user
            public async Task<AuthResult> RegisterAsync(string email, string username, string password, string role)
            {
                var user = new IdentityUser { UserName = username, Email = email };
                var result = await _userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    return FailedRegistration(result, email, username);
                }

                // Create the "User" role if it doesn't exist and assign it to the user
                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("User"));
                }
                await _userManager.AddToRoleAsync(user, role);

                return new AuthResult(true, email, username, "");
            }

            // Handles failed user registration
            private static AuthResult FailedRegistration(IdentityResult result, string email, string username)
            {
                var authResult = new AuthResult(false, email, username, "");

                foreach (var error in result.Errors)
                {
                    authResult.ErrorMessages.Add(error.Code, error.Description);
                }

                return authResult;
            }

            // Logs in a user
            public async Task<AuthResult> LoginAsync(string email, string password)
            {
                var managedUser = await _userManager.FindByEmailAsync(email);

                if (managedUser == null)
                {
                    return InvalidEmail(email);
                }

                var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, password);
                if (!isPasswordValid)
                {
                    return InvalidPassword(email, managedUser.UserName);
                }

                // Create an authentication token
                var accessToken = _tokenService.CreateToken(managedUser, "User");

                // If logging in as an admin, create an admin token
                if (email == Environment.GetEnvironmentVariable("ASPNETCORE_ADMINEMAIL") &&
                    password == Environment.GetEnvironmentVariable("ASPNETCORE_ADMINPASSWORD"))
                {
                    accessToken = _tokenService.CreateToken(managedUser, "Admin");
                }

                return new AuthResult(true, managedUser.Email, managedUser.UserName, accessToken);
            }

            // Handles invalid email during login
            private static AuthResult InvalidEmail(string email)
            {
                var result = new AuthResult(false, email, "", "");
                result.ErrorMessages.Add("Bad credentials", "Invalid email");
                return result;
            }

            // Handles invalid password during login
            private static AuthResult InvalidPassword(string email, string userName)
            {
                var result = new AuthResult(false, email, userName, "");
                result.ErrorMessages.Add("Bad credentials", "Invalid password");
                return result;
            }
}
