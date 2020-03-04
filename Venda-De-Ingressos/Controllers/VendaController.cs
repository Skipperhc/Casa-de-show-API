using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Venda_De_Ingressos.Data;

namespace Venda_De_Ingressos.Controllers
{
    public class VendaController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public VendaController(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }
        /*
         * 
         * 
         * 
         * tem de fazer sa merda qui poxa
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */



        /// <summary>
        /// Lista todos as vendas.
        /// </summary>
        ///<returns>Uma lista de vendas</returns>
        [HttpGet]
        [Route("api/usuarios")]
        public ObjectResult Get() {
            var usuarios = _.Listar();

            if (!usuarios.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhum usuário encontrado.", usuarios);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem dos usuários!", usuarios);
        }
    }
}