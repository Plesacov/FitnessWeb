using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Fitness.Core.Models;
using FitnessWeb.API.Commands;
using FitnessWeb.API.Queries;
using FitnessWeb.API.ViewModels;
using FitnessWeb.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FitnessWeb.API.Identity
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<Person> _userManager;
        private readonly SignInManager<Person> _signInManager;
        private readonly IMapper _mapper;
        private readonly IMediator mediator;
        public AccountsController(UserManager<Person> userManager, 
            IMapper mapper, 
            SignInManager<Person> signInManager,
            IMediator mediator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

            if(user != null && user.IsAdmin)
            {
                var adminCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
                var jwtAdminSecurityToken = new JwtSecurityToken(
                     issuer: AuthOptions.ISSUER,
                     audience: AuthOptions.AUDIENCE,
                     claims: new List<Claim>()
                     {
                     new Claim("username", user.Email),
                     new Claim("id", user.Id.ToString()),
                     new Claim("isAdmin", "true")
                     },
                     expires: DateTime.Now.AddDays(30),
                     signingCredentials: adminCredentials
                );
                var tokenAdminHandler = new JwtSecurityTokenHandler();

                var encodedAdminToken = tokenAdminHandler.WriteToken(jwtAdminSecurityToken);
                return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = encodedAdminToken });
            }
            var signinCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                 issuer: AuthOptions.ISSUER,
                 audience: AuthOptions.AUDIENCE,
                 claims: new List<Claim>()
                 {
                     new Claim("username", user.Email),
                     new Claim("id", user.Id.ToString()),
                     new Claim("isAdmin", "false")
                 },
                 expires: DateTime.Now.AddDays(30),
                 signingCredentials: signinCredentials
            );
            var tokenHandler = new JwtSecurityTokenHandler();

            var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);
            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = encodedToken });
        }

        [AllowAnonymous]
        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            var user = _mapper.Map<Person>(userForRegistration);
            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            switch (userForRegistration.Gender)
            {
                case "male":
                    user.Gender = Gender.Male;
                    break;
                case "female":
                    user.Gender = Gender.Female;
                    break;
                default:
                    user.Gender = Gender.Child;
                    break;
            }

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            return StatusCode(201);
        }

        [HttpPost]
        [Route("logout")]
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        [HttpPost]
        [Route("uploadPhoto")]
        public async Task UploadImage([FromBody] UploadImageCommand command)
        {
            var files = Request.Form.Files;
            foreach (var file in files)
            {
                var blobContainerClient = new BlobContainerClient("UseDevelopmentStorage=true", "images");
                blobContainerClient.CreateIfNotExists();
                var containerClient = blobContainerClient.GetBlobClient(file.FileName);
                var blobHttpHeader = new BlobHttpHeaders
                {
                    ContentType = file.ContentType
                };
                await containerClient.UploadAsync(file.OpenReadStream(), blobHttpHeader);
            }

            this.mediator.Send(command);
        }

        [HttpPost("getUserdata")]
        public async Task<PersonDataDto> GetUserData([FromBody] GetUserDataQuery query)
        {
            Person user = await _userManager.FindByEmailAsync(query.Email);
            Task<FitnessProgramViewModel>? currentFitnessProgram = this.mediator.Send(new FindPersonFitnessProgramQuery { UserId = user.Id });
            var personData = _mapper.Map<PersonDataDto>(user);
            if (currentFitnessProgram.Result != null)
            {
                personData.CurrentFitnessProgram = currentFitnessProgram.Result;
            }
            return personData;
        }
    }
}
