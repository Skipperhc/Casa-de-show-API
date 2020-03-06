using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Venda_De_Ingressos.Data;
using Venda_De_Ingressos.Repositories.Interface;
using Venda_De_Ingressos.Ultilidade;

namespace Venda_De_Ingressos.Controllers {
    [Authorize]
    public class VendaController : Controller {
        private readonly IVendaRepository _vendaRepository;

        public VendaController(IVendaRepository vendaRepository) {
            _vendaRepository = vendaRepository;
        }
        
        /// <summary>
        /// Retorna uma venda com o mesmo id.
        /// </summary>
        /// <param name="id">Id da venda</param>
        /// <returns>Uma venda que tenha o id solicitado</returns>
        /// <response code="200">Se a venda for retornada com sucesso.</response>
        /// <response code="401">Se o usuário não estiver autenticado.</response>
        /// <response code="404">Se nenhuma venda for encontrada.</response>
        [HttpGet] [Route("api/vendas/{id}")] public ObjectResult Get(int id) {
            var vendas = _vendaRepository.Buscar(id);

            if (vendas == null) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma venda encontrada!");
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Venda encontrada!", vendas);
        }
        
        
        /// <summary>
        /// Lista todos as vendas.
        /// </summary>
        ///<returns>Uma lista de vendas</returns>
        /// <response code="200">Se a lista de vendas for retornada com sucesso.</response>
        /// <response code="401">Se o usuário não estiver autenticado.</response>
        /// <response code="404">Se nenhuma venda for encontrada.</response>
        [HttpGet] [Route("api/vendas")] public ObjectResult Get() {
            var vendas = _vendaRepository.Listar();

            if (!vendas.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma venda encontrada.", vendas);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem das vendas!", vendas);
        }
        
    }
}