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
        ///<returns>Uma lista de usuarios</returns>
        [HttpGet] [Route("api/usuarios")] public ObjectResult Get() {
            var usuarios = _usuarioRepository.Listar();

            if (!usuarios.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhum usuário encontrado.", usuarios);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem dos usuários!", usuarios);
        }

        /// <summary>
        /// Retorna um usuário com o mesmo id.
        /// </summary>
        /// <param name="id">Id do usuário</param>
        ///<returns>Um usuario que tenha o id solicitado</returns>
        /// <response code="200">Se a casa de show for retornada com sucesso.</response>
        /// <response code="404">Se nenhuma casa de show for encontrada.</response>
        [HttpGet]
        [Route("api/casas/{id}")]
        public ObjectResult Get(int id)
        {
            var usuario = _usuarioRepository.Buscar(id);

            if (usuario == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma casa de show encontrada!");
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Casa de show encontrada!", usuario);
        }
    }
}