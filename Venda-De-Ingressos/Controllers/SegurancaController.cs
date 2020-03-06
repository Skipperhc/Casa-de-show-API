using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Venda_De_Ingressos.Models;
using Venda_De_Ingressos.Models.ViewModels.UsuarioViewModels;

namespace Venda_De_Ingressos.Controllers {
    [Route("api/[controller]")] [ApiController]
    public class SegurancaController : ControllerBase {
        private IConfiguration _config;

        public SegurancaController(IConfiguration Configuration) {
            _config = Configuration;
        }

        [HttpPost] public IActionResult Login([FromBody] UsuarioValidacaoViewModel loginDetalhes) {
            bool resultado = ValidarUsuario(loginDetalhes);
            if (resultado) {
                var tokenString = GerarTokenJWT();
                return Ok
                (new {
                    token = tokenString
                });
            } else {
                return Unauthorized();
            }
        }

        private string GerarTokenJWT() {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
            (issuer: issuer, audience: audience, expires: expiry,
                signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        private bool ValidarUsuario(UsuarioValidacaoViewModel loginDetalhes) {
            if (loginDetalhes.NomeUsuario == "Admin" && loginDetalhes.Senha == "123123") {
                return true;
            } else {
                return false;
            }
        }
    }
}