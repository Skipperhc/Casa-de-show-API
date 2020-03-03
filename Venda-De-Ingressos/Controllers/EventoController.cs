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
        private readonly EventoRepository _eventoRepository;

        public EventoController(EventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }
        
        [HttpGet]
        [Route("api/eventos")]
        public ObjectResult Get()
        {
            var evento = _eventoRepository.Listar();

            if (!evento.Any())
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma categoria encontrada.", evento);
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem das Casas!", evento);
        }

        [HttpGet]
        [Route("api/eventos/{id}")]
        public ObjectResult Get(int id)
        {
            var evento = _eventoRepository.Buscar(id);

            if (evento == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Casa de show não encontrada!");
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Casa de show encontrada!", evento);
        }

        [HttpGet]
        [Route("api/eventos/capacidade/asc")]
        public ObjectResult GetCapAsc()
        {
            var evento = _eventoRepository.ListarCapAsc();

            if (!evento.Any())
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma categoria encontrada.", evento);
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de Categorias!", evento);
        }

        [HttpGet]
        [Route("api/eventos/capacidade/desc")]
        public ObjectResult GetCapDesc()
        {
            var evento = _eventoRepository.ListarCapDesc();

            if (!evento.Any())
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma categoria encontrada.", evento);
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de Categorias!", evento);
        }

        [HttpGet]
        [Route("api/eventos/data/asc")]
        public ObjectResult GetDataAsc()
        {
            var evento = _eventoRepository.ListarDataAsc();

            if (!evento.Any())
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma categoria encontrada.", evento);
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de Categorias!", evento);
        }

        [HttpGet]
        [Route("api/eventos/data/desc")]
        public ObjectResult GetDataDesc()
        {
            var evento = _eventoRepository.ListarDataDesc();

            if (!evento.Any())
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma categoria encontrada.", evento);
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de Categorias!", evento);
        }

        [HttpGet]
        [Route("api/eventos/nome/asc")]
        public ObjectResult GetNomeAsc()
        {
            var evento = _eventoRepository.ListarNomeAsc();

            if (!evento.Any())
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma categoria encontrada.", evento);
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de Categorias!", evento);
        }

        [HttpGet]
        [Route("api/eventos/nome/desc")]
        public ObjectResult GetNomeDesc()
        {
            var evento = _eventoRepository.ListarNomeDesc();

            if (!evento.Any())
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma categoria encontrada.", evento);
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de Categorias!", evento);
        }

        [HttpGet]
        [Route("api/eventos/preco/asc")]
        public ObjectResult GetPrecoAsc()
        {
            var evento = _eventoRepository.ListarPrecoAsc();

            if (!evento.Any())
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma categoria encontrada.", evento);
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de Categorias!", evento);
        }

        [HttpGet]
        [Route("api/eventos/preco/desc")]
        public ObjectResult GetPrecoDesc()
        {
            var evento = _eventoRepository.ListarPrecoDesc();

            if (!evento.Any())
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma categoria encontrada.", evento);
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de Categorias!", evento);
        }

        [HttpPost]
        [Route("api/eventos/")]
        public ObjectResult Post([FromBody] EventoCadastroViewModel eventoTemporario)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return RespostaFormato.GerarResultado("Não foi possível cadastrar",
                    ModelState.ListarErros());
            }
            var evento = new Evento()
            {
                Id = 0,
                Nome = eventoTemporario.Nome,
                CasaDeShowId = eventoTemporario.CasaDeShowId,
                Data = eventoTemporario.Data,
                Preco = eventoTemporario.Preco
            };
            _eventoRepository.Criar(evento);
            Response.StatusCode = StatusCodes.Status201Created;
            return RespostaFormato.GerarResultado("Casa de show cadastrada com sucesso!", evento);
        }

        [HttpPut]
        [Route("v1/categorias/{id}")]
        public ObjectResult Put(int id, [FromBody] EventoEdicaoViewModel eventoTemporario)
        {
            if (id != eventoTemporario.Id)
            {
                ModelState.AddModelError("Id", "Id da requisição difere do Id da categoria.");
            }

            if (!_eventoRepository.Existe(eventoTemporario.Id))
            {
                ModelState.AddModelError("CasaDeShowId", "Casa de show inexistente.");
            }
            if (!ModelState.IsValid)
            {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return RespostaFormato.GerarResultado("Erro ao editar casa de show.",
                    ModelState.ListarErros());
            }
            var casaDeShow = new CasaDeShow()
            {
                Id = eventoTemporario.Id,
                Nome = eventoTemporario.Nome
            };
            _eventoRepository.Editar(casaDeShow);
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Casa de show editada com sucesso!", casaDeShow);
        }
    }
}