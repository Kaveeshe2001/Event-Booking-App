using EventBookingBackend.Data;
using EventBookingBackend.Models;
using EventBookingBackend.Models.Domain;
using EventBookingBackend.Models.DTO.Account;
using EventBookingBackend.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EventBookingBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenService _tokenService;

        public AuthorizationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService) 
        { 
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;

        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto passwordDto)
        {
            var status = new Status();
            // check validations
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "please pass all the valid fields";
                return Ok(status);
            }
            // lets find the user
            var user = await _userManager.FindByNameAsync(passwordDto.UserName);
            if (user is null)
            {
                status.StatusCode = 0;
                status.Message = "invalid username";
                return Ok(status);
            }
            // check current password
            if (!await _userManager.CheckPasswordAsync(user, passwordDto.CurrentPassword))
            {
                status.StatusCode = 0;
                status.Message = "invalid current password";
                return Ok(status);
            }

            // change password here
            var result = await _userManager.ChangePasswordAsync(user, passwordDto.CurrentPassword, passwordDto.NewPassword);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "Failed to change password";
                return Ok(status);
            }
            status.StatusCode = 1;
            status.Message = "Password has changed successfully";
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = _tokenService.GetToken(authClaims);
                var refreshToken = _tokenService.GetRefreshToken();
                var tokenInfo = _context.TokenInfo.FirstOrDefault(a => a.UserName == user.UserName);
                if (tokenInfo == null)
                {
                    var info = new TokenInfo
                    {
                        UserName = user.UserName,
                        RefreshToken = refreshToken,
                        RefreshTokenExpiry = DateTime.Now.AddDays(7)
                    };
                    _context.TokenInfo.Add(info);
                }

                else
                {
                    tokenInfo.RefreshToken = refreshToken;
                    tokenInfo.RefreshTokenExpiry = DateTime.Now.AddDays(7);
                }
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
                return Ok(new LoginResponse
                {
                    Name = user.Name,
                    Username = user.UserName,
                    Token = token.TokenString,
                    RefreshToken = refreshToken,
                    Expiration = token.ValidTo,
                    StatusCode = 1,
                    Message = "Logged in"
                });
            }

            //login failed condition

            return Ok(
                new LoginResponse
                {
                    StatusCode = 0,
                    Message = "Invalid Username or Password",
                    Token = "", Expiration = null });
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody]RegistrationDto registerDto)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass all the required fields";
                return Ok(status);
            }
            // check if user exists
            var userExists = await _userManager.FindByNameAsync(registerDto.Username);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid username";
                return Ok(status);
            }
            var user = new ApplicationUser
            {
                UserName = registerDto.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = registerDto.Email,
                Name = registerDto.Name
            };

            // create a user here
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed";
                return Ok(status);
            }

            // add roles here
            // for admin registration UserRoles.Admin instead of UserRoles.Roles
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }
            status.StatusCode = 1;
            status.Message = "Sucessfully registered";
            return Ok(status);
        }

        // after registering admin we will comment this code, because i want only one admin in this application
        [HttpPost("RegistrationAdmin")]
        public async Task<IActionResult> RegistrationAdmin([FromBody] RegistrationDto registerDto)
        {
            var status = new Status();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Please pass all the required fields";
                return Ok(status);
            }
            // check if user exists
            var userExists = await _userManager.FindByNameAsync(registerDto.Username);
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid username";
                return Ok(status);
            }
            var user = new ApplicationUser
            {
                UserName = registerDto.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = registerDto.Email,
                Name = registerDto.Name
            };

            // create a user here
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed";
                return Ok(status);
            }

            // add roles here
            // for admin registration UserRoles.Admin instead of UserRoles.Roles
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            status.StatusCode = 1;
            status.Message = "Sucessfully registered";
            return Ok(status);
        }
    }
}
 