using ErrorCenter.Data;
using ErrorCenter.Dtos;
using ErrorCenter.Models;
using ErrorCenter.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorCenter.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ErrorCenterContext _context;

        public AuthController(ErrorCenterContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginDto model)
        {
            // Recupera o usuário
            var users = await _context.User.ToListAsync();
            var userCount = users.Where(x => x.Email.ToLower() == model.Email.ToLower()
            && x.Password == model.Password).Count();

            if (userCount == 0)
            {
                return NotFound(new { message = "Email ou senha inválidos" });
            }

            var user = users.Where(x => x.Email.ToLower() == model.Email.ToLower()
            && x.Password == model.Password).ToList().Cast<User>().ToArray()[0];


            // Gera o Token
            var token = TokenService.GenerateToken(user);


            // Retorna os dados
            return token;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> PostUser(CreateUserDto userDto)
        {
            User user = new()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password
            };
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetUser", new { id = user.Id }, user);
            return user;
        }


    }
}
