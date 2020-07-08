using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebAPIAgendaTOP.Contexts;
using WebAPIAgendaTOP.Controllers.Entities;
using System.Threading.Tasks;
using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPIAgendaTOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AuthController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Entities.User>> Get()
        {
            return context.Usuarios.ToList();
            //return context.Clientes.Include(x => x.Tareas).ToList();
        }

        //[HttpGet("login")]
        //[HttpGet("{usuario}/{clave}", Name = "Login")]
        //[HttpGet("{usuario}", Name = "Login")]
     
        
        //[HttpPost("{user}/{pass}")]
        //public ActionResult Post([FromBody] User usuario)
        [HttpPost]
        public ActionResult<UserToken> Post([FromBody] UserReq usureq)
        {
            var usu = context.Usuarios.FirstOrDefault(x => x.usuario == usureq.usuario);

            if (usu == null)
            {
                //Usuario No encontrado (status 404)
                return NotFound();
                //context.Usuarios.Add(usu);
                //context.SaveChanges();
                //return new CreatedAtRouteResult("Login", new { id = usu.id }, usu);

            } else {
                if (usu.clave == usureq.clave)
                {
                    //Usuario y pass correctos (status 200)
                    //return Ok();
                    //return usureq
                    return BuildToken(usureq);
                } else
                {
                    //Pass incorrecta (status 400)
                    return BadRequest();
                }
            }

        }

        [HttpPut("{id}")]
        public ActionResult<Cliente> Put(int id, [FromBody] User value)
        {
            if (id != value.id) 
            {
                return BadRequest();
            }

            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
            //return value;
        }

        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var usuario = context.Usuarios.FirstOrDefault(x => x.id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            context.Usuarios.Remove(usuario);
            context.SaveChanges();
            return usuario;
        }

        private UserToken BuildToken(UserReq usureq)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, usureq.usuario),
                new Claim("miValor", "Lo que me parezca poner aquí"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AFA3543ADFAD3434AFASDFFFOPO47503LKHHGFGHDD55232G"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddYears(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: creds);

            return new UserToken()
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                //Expiration = expiration
            };
        }
    }

}
