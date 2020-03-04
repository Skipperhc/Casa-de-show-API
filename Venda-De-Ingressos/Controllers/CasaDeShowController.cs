using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using Venda_De_Ingressos.Models;
using Venda_De_Ingressos.Models.ViewModels.CasaDeShowViewModels;
using Venda_De_Ingressos.Repositories;
using Venda_De_Ingressos.Repositories.Interface;
using Venda_De_Ingressos.Ultilidade;

namespace Venda_De_Ingressos.Controllers {
    [Produces("application/json")]
    public class CasaDeShowController : Controller {
        private readonly ICasaDeShowRepository _casaDeShowRepository;

        public CasaDeShowController(ICasaDeShowRepository casaDeShowRepository) {
            _casaDeShowRepository = casaDeShowRepository;
        }

        /// <summary>
        /// Lista todas as casas.
        /// </summary>
        /// <returns>Uma lista contendo todas as casas de shows cadastradas</returns>
        /// <response code="200">Se a listagem for realizada com sucesso.</response>
        /// <response code="404">Se nenhuma casa de show for encontrada.</response>
        [HttpGet]
        [Route("api/casas")]
        public ObjectResult Get() {
            var casasDeShows = _casaDeShowRepository.Listar();

            if (!casasDeShows.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma casa de show encontrada!", casasDeShows);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem das Casas!", casasDeShows);
        }

        /// <summary>
        /// Retorna uma casa com o mesmo id.
        /// </summary>
        /// <param name="id">Id da casa de show</param>
        ///<returns>Uma casa de show que tenha o id solicitado</returns>
        /// <response code="200">Se a casa de show for retornada com sucesso.</response>
        /// <response code="404">Se nenhuma casa de show for encontrada.</response>
        [HttpGet]
        [Route("api/casas/{id}")]
        public ObjectResult Get(int id) {
            var casaDeShow = _casaDeShowRepository.Buscar(id);

            if (casaDeShow == null) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma casa de show encontrada!");
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Casa de show encontrada!", casaDeShow);
        }

        /// <summary>
        /// Retorna uma casa com o mesmo nome.
        /// </summary>
        /// <param name="nome">Nome da casa de show</param> 
        ///<returns>Uma casa de show que tenha o nome solicitado</returns>
        /// <response code="200">Se a casa de show foi encontrada com sucesso.</response>
        /// <response code="404">Se nenhuma casa de show for encontrada.</response>
        [HttpGet]
        [Route("api/casas/nome/{nome}")]
        public ObjectResult GetNome(string nome) {
            nome.Replace('%', ' ');

            var casaDeShow = _casaDeShowRepository.BuscarNome(nome);

            if (casaDeShow == null) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma casa de show encontrada!");
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Casa de show encontrada!", casaDeShow);
        }

        /// <summary>
        /// lista as casas de shows em ordem alfabética crescente.
        /// </summary>
        /// <response code="200">Se a listagem for um sucesso.</response>
        /// <response code="404">Se nenhuma casa for encontrada.</response>
        [HttpGet]
        [Route("api/casas/asc")]
        public ObjectResult GetAsc() {
            var casaDeShow = _casaDeShowRepository.ListarAsc();

            if (!casaDeShow.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma casa de show encontrada!", casaDeShow);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de casas!", casaDeShow);
        }

        /// <summary>
        /// lista as casas de shows em ordem alfabética decrescente.
        /// </summary>
        /// <response code="200">Se a listagem for um sucesso.</response>
        /// <response code="404">Se nenhuma casa for encontrada.</response>
        [HttpGet]
        [Route("api/casas/desc")]
        public ObjectResult GetDesc() {
            var casaDeShow = _casaDeShowRepository.ListarDesc();

            if (!casaDeShow.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma casa de show encontrada!", casaDeShow);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de casas!", casaDeShow);
        }

        /// <summary>
        /// Cadastra uma casa de show.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Todo
        /// 
        ///     {
        ///      "nome": "Casa de Rock",
        ///      "endereco": "Rua alto da 15",
        ///      "capacidade": 222
        ///     }
        /// 
        /// </remarks>
        /// <response code="201">Se o cadastro for um sucesso.</response>
        /// <response code="400">Se der erro ao cadastrar a casa de show.</response>
        [HttpPost]
        [Route("api/casas")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ObjectResult Post([FromBody] CasaDeShowCadastroViewModel casaDeShowTemporaria) {
            if (!ModelState.IsValid) {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return RespostaFormato.GerarResultado("Não foi possível cadastrar", ModelState.ListarErros());
            }

            var casaDeShow = new CasaDeShow() {
                Id = 0,
                Nome = casaDeShowTemporaria.Nome,
                Capacidade = casaDeShowTemporaria.Capacidade,
                Endereco = casaDeShowTemporaria.Endereco,
            };
            _casaDeShowRepository.Criar(casaDeShow);
            Response.StatusCode = StatusCodes.Status201Created;
            return RespostaFormato.GerarResultado("Casa de show cadastrada com sucesso!", casaDeShowTemporaria);
        }

        /// <summary>
        /// Edita uma casa de show através do id.
        /// </summary>
        /// <param name="id">Id da casa de show</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Put /Todo
        /// 
        ///     {
        ///      "id": 4,
        ///      "nome": "Show de rock",
        ///      "preco": 200,
        ///      "casaDeShowId": 5
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Se a edição for um sucesso.</response>
        /// <response code="400">Se der erro ao cadastrar a casa de show: id da requisição for diferente do id da casa de show,
        /// id da casa for inexistente, algum campo estar invalidado.</response>
        [HttpPut]
        [Route("api/casas/{id}")]
        public ObjectResult Put(int id, [FromBody] CasaDeShowEdicaoViewModel casaDeShowTemporaria) {
            if (id != casaDeShowTemporaria.Id) {
                ModelState.AddModelError("Id", "Id da requisição difere do Id da casa de show.");
            }

            if (!_casaDeShowRepository.Existe(casaDeShowTemporaria.Id)) {
                ModelState.AddModelError("CasaDeShowId", "Casa de show inexistente.");
            }

            if (!ModelState.IsValid) {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return RespostaFormato.GerarResultado("Erro ao editar casa de show.", ModelState.ListarErros());
            }

            var casaDeShow = new CasaDeShow() {
                Id = casaDeShowTemporaria.Id,
                Nome = casaDeShowTemporaria.Nome,
                Capacidade = casaDeShowTemporaria.Capacidade,
                Endereco = casaDeShowTemporaria.Endereco
            };
            _casaDeShowRepository.Editar(casaDeShow);
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Casa de show editada com sucesso!", casaDeShowTemporaria);
        }

        /// <summary>
        /// Deleta uma casa de show através do id.
        /// </summary>
        /// <param name="id">Id da casa de show</param>  
        /// <response code="200">Se a edição for um sucesso.</response>
        /// <response code="404">Se a casa de show não for encontrada</response>
        /// <response code="406">Se não for possível deletar esta casa</response>
        [HttpDelete]
        [Route("api/casas/{id}")]
        public ObjectResult Delete(int id) {
            var casaDeShow = _casaDeShowRepository.Buscar(id);
            if (casaDeShow == null) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Casa de show inexistente.", null);
            }

            try {
                _casaDeShowRepository.Deletar(casaDeShow);
                Response.StatusCode = StatusCodes.Status200OK;
                return RespostaFormato.GerarResultado("Casa de show deletada com sucesso!", casaDeShow);
            } catch (Exception) {
                Response.StatusCode = StatusCodes.Status406NotAcceptable;
                return RespostaFormato.GerarResultado("Não foi possivel deletar a casa de show", casaDeShow);
            }
        }
    }
}