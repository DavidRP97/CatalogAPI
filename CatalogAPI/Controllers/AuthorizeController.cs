using CatalogAPI.DTOs;
using CatalogAPI.JWT_Configuration.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenGenerate _tokenGenerate;

        public AuthorizeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ITokenGenerate tokenGenerate)
        {
            _roleManager = roleManager;
            _tokenGenerate = tokenGenerate;
            _userManager = userManager;
            _signInManager = signInManager;
        }     
        
        //[HttpPost("Register")]
        //public async Task<ActionResult> UserRegister([FromBody] UserDTO model)
        //{
        //    var userExist = await _userManager.FindByIdAsync(model.Email);

        //    if (userExist != null)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "User already exists!");
        //    }

        //    var user = new IdentityUser
        //    {
        //        UserName = model.Email,
        //        Email = model.Email
        //    };

        //    var result = await _userManager.CreateAsync(user, model.Password);

        //    if (result.Succeeded)
        //    {      
        //        var login = new UserLoginDTO
        //        {
        //            Password = model.Password,
        //            UserName = model.Email
        //        };

        //        await _signInManager.SignInAsync(user, false);
        //        return Ok(_tokenGenerate.UserTokenGenerate(login));
        //    }
        //    else
        //    {
        //        var stringBuilder = new StringBuilder();

        //        foreach (var error in result.Errors)
        //        {
        //            stringBuilder.Append(error.Description);
        //            stringBuilder.Append("\r\n");
        //        }

        //        return Ok(new { Result = $"Register Fail: {stringBuilder.ToString()}" });
        //    }

            
        //}

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDTO user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.UserName,
                user.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return Ok(_tokenGenerate.UserTokenGenerate(user));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Credenciais inválidas...");
                return BadRequest();
            }
        }       
    }
}
