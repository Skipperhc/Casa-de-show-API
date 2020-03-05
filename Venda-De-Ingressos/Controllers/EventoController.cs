using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Venda_De_Ingressos.Models;
using Venda_De_Ingressos.Models.ViewModels.EventoViewModels;
using Venda_De_Ingressos.Repositories;
using Venda_De_Ingressos.Repositories.Interface;
using Venda_De_Ingressos.Ultilidade;

namespace Venda_De_Ingressos.Controllers {
    public class EventoController : Controller {
        private readonly IEventoRepository _eventoRepository;

        public EventoController(IEventoRepository eventoRepository) {
            _eventoRepository = eventoRepository;
        }

        /// <summary>
        /// Retorna uma lista de eventos.
        /// </summary>
        /// <response code="200">Se a listagem for um sucesso.</response>
        /// <response code="404">Se nenhum evento for encontrado.</response>
        [HttpGet] [Route("api/eventos")] public ObjectResult Get() {
            var evento = _eventoRepository.Listar();

            if (!evento.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhum evento encontrado.", evento);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem das eventos", evento);
        }

        /// <summary>    
        /// Retorna um evento através do id.
        /// </summary>
        /// <param name="id">Id do evento</param>
        /// <response code="200">Se o evento for retornado com sucesso.</response>
        /// <response code="404">Se nenhuma casa for encontrada.</response>
        [HttpGet] [Route("api/eventos/{id}")] public ObjectResult Get(int id) {
            var evento = _eventoRepository.Buscar(id);

            if (evento == null) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Evento não encontrado!");
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Evento encontrada!", evento);
        }

        /// <summary>
        /// lista os eventos ordenados pela capacidade crescente.
        /// </summary>
        /// <response code="200">Se a listagem for um sucesso.</response>
        /// <response code="404">Se nenhum evento for encontrado.</response>
        [HttpGet] [Route("api/eventos/capacidade/asc")]
        public ObjectResult GetCapAsc() {
            var evento = _eventoRepository.ListarCapAsc();

            if (!evento.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhum evento encontrado.", evento);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de eventos!", evento);
        }

        /// <summary>
        /// lista os eventos ordenados pela capacidade decrescente.
        /// </summary>
        /// <response code="200">Se a listagem for um sucesso.</response>
        /// <response code="404">Se nenhum evento for encontrado.</response>
        [HttpGet] [Route("api/eventos/capacidade/desc")]
        public ObjectResult GetCapDesc() {
            var evento = _eventoRepository.ListarCapDesc();

            if (!evento.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhum evento encontrado.", evento);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de eventos!", evento);
        }

        /// <summary>
        /// lista os eventos ordenados pela data crescente.
        /// </summary>
        /// <response code="200">Se a listagem for um sucesso.</response>
        /// <response code="404">Se nenhum evento for encontrado.</response>
        [HttpGet] [Route("api/eventos/data/asc")]
        public ObjectResult GetDataAsc() {
            var evento = _eventoRepository.ListarDataAsc();

            if (!evento.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhum evento encontrado.", evento);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de eventos!", evento);
        }

        /// <summary>
        /// lista os eventos ordenados pela data decrescente.
        /// </summary>
        /// <response code="200">Se a listagem for um sucesso.</response>
        /// <response code="404">Se nenhum evento for encontrado.</response>
        [HttpGet] [Route("api/eventos/data/desc")]
        public ObjectResult GetDataDesc() {
            var evento = _eventoRepository.ListarDataDesc();

            if (!evento.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhum evento encontrado.", evento);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de eventos!", evento);
        }

        /// <summary>
        /// lista os eventos em ordem alfabética.
        /// </summary>
        /// <response code="200">Se a listagem for um sucesso.</response>
        /// <response code="404">Se nenhum evento for encontrado.</response>
        [HttpGet] [Route("api/eventos/nome/asc")]
        public ObjectResult GetNomeAsc() {
            var evento = _eventoRepository.ListarNomeAsc();

            if (!evento.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhum evento encontrada.", evento);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de eventos!", evento);
        }

        /// <summary>
        /// lista os eventos em ordem alfabética decrescente.
        /// </summary>
        /// <response code="200">Se a listagem for um sucesso.</response>
        /// <response code="404">Se nenhum evento for encontrado.</response>
        [HttpGet] [Route("api/eventos/nome/desc")]
        public ObjectResult GetNomeDesc() {
            var evento = _eventoRepository.ListarNomeDesc();

            if (!evento.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhum evento encontrada.", evento);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de eventos!", evento);
        }

        /// <summary>
        /// lista os eventos ordenados pelo preço crescente.
        /// </summary>
        /// <response code="200">Se a listagem for um sucesso.</response>
        /// <response code="404">Se nenhum evento for encontrado.</response>
        [HttpGet] [Route("api/eventos/preco/asc")]
        public ObjectResult GetPrecoAsc() {
            var evento = _eventoRepository.ListarPrecoAsc();

            if (!evento.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhum evento encontrado.", evento);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de eventos!", evento);
        }

        /// <summary>
        /// lista os eventos ordenados pelo preço decrescente.
        /// </summary>
        /// <response code="200">Se a listagem for um sucesso.</response>
        /// <response code="404">Se nenhum evento for encontrado.</response>
        [HttpGet] [Route("api/eventos/preco/desc")]
        public ObjectResult GetPrecoDesc() {
            var evento = _eventoRepository.ListarPrecoDesc();

            if (!evento.Any()) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhum evento encontrado.", evento);
            }

            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de eventos!", evento);
        }

        /// <summary>
        /// Cadastra um evento.
        /// </summary>
        /// <remarks>
        /// Exemplo de cadastro:
        ///
        ///     Post/Todo
        ///     {
        ///      "nome": "string",
        ///      "preco": 0,
        ///      "data": "2020-03-04",
        ///      "casaDeShowId": 0
        ///     }
        /// </remarks>
        /// <response code="201">Se o cadastro for um sucesso.</response>
        /// <response code="400">Se der erro ao cadastrar: parâmetros errados ou incompatíveis, falta de informação.</response>
        [HttpPost] [Route("api/eventos/")]
        public ObjectResult Post([FromBody] EventoCadastroViewModel eventoTemporario) {
            if (!ModelState.IsValid) {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return RespostaFormato.GerarResultado("Não foi possível cadastrar.", ModelState.ListarErros());
            }

            var evento = new Evento() {
                Id = 0,
                Nome = eventoTemporario.Nome,
                CasaDeShowId = eventoTemporario.CasaDeShowId,
                Data = eventoTemporario.Data,
                Preco = eventoTemporario.Preco
            };
            _eventoRepository.Criar(evento);
            Response.StatusCode = StatusCodes.Status201Created;
            return RespostaFormato.GerarResultado("Evento cadastrada com sucesso!", evento);
        }

        /// <summary>
        /// Edita um evento.
        /// </summary>
        /// <param name="id"> do evento</param>  
        /// <remarks>
        /// Exemplo de edição:
        ///     {
        ///      "id": 0,
        ///      "nome": "string",
        ///      "preco": 0,
        ///      "data": "2020-03-04",
        ///      "casaDeShowId": 0
        ///     }
        /// </remarks>
        /// <response code="201">Se o cadastro for um sucesso.</response>
        /// <response code="400">Se der erro ao cadastrar: parâmetros errados ou incompatíveis, falta de informação.</response>
        [HttpPut] [Route("api/eventos/{id}")]
        public ObjectResult Put(int id, [FromBody] EventoEdicaoViewModel eventoTemporario) {
            if (eventoTemporario == null) {
                Response.StatusCode = StatusCodes.Status406NotAcceptable;
                return RespostaFormato.GerarResultado("Campos não foram preenchidos corretamente");
            }
            
            if (id != eventoTemporario.Id) {
                ModelState.AddModelError("Id", "Id da requisição difere do Id da categoria.");
            }

            if (!_eventoRepository.Existe(eventoTemporario.Id)) {
                ModelState.AddModelError("EventoId", "Evento inexistente.");
            }

            if (!ModelState.IsValid) {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return RespostaFormato.GerarResultado("Erro ao editar evento.", ModelState.ListarErros());
            }

            var evento = new Evento() {
                Id = eventoTemporario.Id,
                Nome = eventoTemporario.Nome,
                Data = eventoTemporario.Data,
                Preco = eventoTemporario.Preco,
                CasaDeShowId = eventoTemporario.CasaDeShowId
            };
            _eventoRepository.Editar(evento);
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Evento editado com sucesso!", eventoTemporario);
        }

        /// <summary>
        /// Deleta um evento através do id.
        /// </summary>
        /// <param name="id"> do evento</param>
        /// <response code="200">Se a exclusão for um sucesso.</response>
        /// <response code="404">Se o evento não for encontrado</response>
        /// <response code="406">Se não for possível deletar este evento</response>
        [HttpDelete] [Route("api/evento/{id}")]
        public ObjectResult Delete(int id) {
            var evento = _eventoRepository.Buscar(id);
            if (evento == null) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Evento inexistente.");
            }

            try {
                _eventoRepository.Deletar(evento);
                Response.StatusCode = StatusCodes.Status200OK;
                return RespostaFormato.GerarResultado("Evento deletado com sucesso!", evento);
            } catch (Exception) {
                Response.StatusCode = StatusCodes.Status406NotAcceptable;
                return RespostaFormato.GerarResultado("Não foi possivel deletar o evento", evento);
            }
        }
    }
}