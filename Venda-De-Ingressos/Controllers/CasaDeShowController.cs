using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Venda_De_Ingressos.Models;
using Venda_De_Ingressos.Models.ViewModels.CasaDeShowViewModels;
using Venda_De_Ingressos.Repositories;
using Venda_De_Ingressos.Ultilidade;

namespace Venda_De_Ingressos.Controllers {
    public class CasaDeShowController : Controller {
        private readonly CasaDeShowRepository _casaDeShowRepository;

        public CasaDeShowController(CasaDeShowRepository casaDeShowRepository) {
            _casaDeShowRepository = casaDeShowRepository;
        }

        // GET
        public IActionResult Index() {
            return View();
        }
        
        [HttpGet]
        [Route("api/casas")]
        public ObjectResult Get() {
            var casasDeShows = _casaDeShowRepository.Listar();

            if(!casasDeShows.Any()){
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma categoria encontrada.", casasDeShows);
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem das Casas!", casasDeShows);
        }
        
        [HttpGet]
        [Route("v1/categorias/{id}")]
        public ObjectResult Get(int id) {
            var casaDeShow = _casaDeShowRepository.Buscar(id);

            if (casaDeShow == null) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Casa de show não encontrada!");
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Casa de show encontrada!", casaDeShow);
        }
        
        [HttpGet] [Route("api/casas/{nome}")] public ObjectResult GetNome(string nome) {
            var casaDeShow = _casaDeShowRepository.BuscarNome(nome);

            if (casaDeShow == null) {
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Casa de show não encontrada!");
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Casa de show encontrada!", casaDeShow);
        }

        [HttpGet] [Route("api/casas/asc")] public ObjectResult GetAsc() {
            var casaDeShow = _casaDeShowRepository.ListarAsc();

            if(!casaDeShow.Any()){
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma categoria encontrada.", casaDeShow);
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de Categorias!", casaDeShow);
        }
        
        [HttpGet] [Route("api/casas/desc")] public ObjectResult GetDesc() {
            var casaDeShow = _casaDeShowRepository.ListarDesc();

            if(!casaDeShow.Any()){
                Response.StatusCode = StatusCodes.Status404NotFound;
                return RespostaFormato.GerarResultado("Nenhuma categoria encontrada.", casaDeShow);
            }
            Response.StatusCode = StatusCodes.Status200OK;
            return RespostaFormato.GerarResultado("Listagem de Categorias!", casaDeShow);
        }
        
        [HttpPost]
        [Route("v1/categorias/")]
        public ObjectResult Post([FromBody] CasaDeShowCadastroViewModel casaDeShowTemporaria) {
            if (!ModelState.IsValid) {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return RespostaFormato.GerarResultado("Não foi possível cadastrar",
                    ModelState.ListarErros());
            }
            var casaDeShow = new CasaDeShow() {
                Id = 0,
                Nome = casaDeShowTemporaria.Nome,
                Capacidade = casaDeShowTemporaria.Capacidade,
                Endereco = casaDeShowTemporaria.Endereco,
            };
            _casaDeShowRepository.Criar(casaDeShow);
            Response.StatusCode = StatusCodes.Status201Created;
            return RespostaFormato.GerarResultado("Casa de show cadastrada com sucesso!", casaDeShow);
        }

        [HttpPut]
        [Route("v1/categorias/{id}")]
        public ObjectResult Put(int id, [FromBody] CasaDeShowEdicaoViewModel casaDeShowTemporaria) {
            if (id != casaDeShowTemporaria.Id) {
                ModelState.AddModelError("Id", "Id da requisição difere do Id da categoria.");
            }
            
            if (!(_casaDeShowRepository).Existe(casaDeShowTemporaria.Id)) {
                ModelState.AddModelError("CategoriaId", "Casa de show inexistente.");
            }
            if (!ModelState.IsValid) {
                Response.StatusCode = StatusCodes.Status400BadRequest;
                return ResponseUtils.GenerateObjectResult("Erro ao editar categoria.",
                    ModelState.ListarErros());
            }
            var categoria = new Categoria() {
                Id = categoriaTemp.Id,
                Nome = categoriaTemp.Nome
            };
            _categoriaRepository.Editar(categoria);
            Response.StatusCode = StatusCodes.Status200OK;
            return ResponseUtils.GenerateObjectResult("Categoria editada com sucesso!", categoria);
        }
        
    }
}