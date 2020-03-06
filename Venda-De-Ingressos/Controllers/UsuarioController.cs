using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Venda_De_Ingressos.Repositories;
using Venda_De_Ingressos.Repositories.Interface;
using Venda_De_Ingressos.Ultilidade;

namespace Venda_De_Ingressos.Controllers {
    [Authorize]
    public class UsuarioController : Controller {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository) {
            _usuarioRepository = usuarioRepository;
        }

        /// <summary>
        /// Retorna um usuário com o mesmo id.
        /// </summary>
        /// <param name="id">Id do usuário</param>
        /// <returns>Um usuario que tenha o id solicitado</returns>
        /// <response code="200">Se o usuário for retornado com sucesso.</response>
        /// <response code="404">Se nenhum usuário for encontrado.</response>
        [HttpGet] [Route("api/usuarios/{id}")] public ObjectResult Get(int id) {
            var usuario = _usuarioRepository.Buscar(id);

            if (usuario == null) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhum usuário encontrado!");
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Usuário encontrado!", usuario);
        }

        /// <summary>
        /// Lista todos os usuários.
        /// </summary>
        ///<returns>Uma lista de usuarios</returns>
        /// <response code="200">Se a lista de usuários for retornada com sucesso.</response>
        /// <response code="404">Se nenhum usuário for encontrado.</response>
        [HttpGet] [Route("api/usuarios")] public ObjectResult Get() {
            var usuarios = _usuarioRepository.Listar();

            if (!usuarios.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhum usuário encontrado.", usuarios);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem dos usuários!", usuarios);
        }
    }
}