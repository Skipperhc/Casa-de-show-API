using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Venda_De_Ingressos.Repositories;
using Venda_De_Ingressos.Repositories.Interface;
using Venda_De_Ingressos.Ultilidade;

namespace Venda_De_Ingressos.Controllers {
    public class UsuarioController : Controller {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository) {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Lista todos os usuários.
        /// </summary>
        [HttpGet] [Route("api/usuarios")] public ObjectResult Get() {
            var usuarios = _usuarioRepository.Listar();

            if (!usuarios.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhum usuário encontrado.", usuarios);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem dos usuários!", usuarios);
        }

        [HttpGet] [Route("api/usuarios/{id}")] public ObjectResult Get(int id) {
            var usuario = _usuarioRepository.Buscar(id);
            return RespostaFormato.GerarResultado("Usuário encontrado", usuario);
        }
        
    }
}