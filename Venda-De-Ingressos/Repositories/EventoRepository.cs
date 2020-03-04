using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Venda_De_Ingressos.Data;
using Venda_De_Ingressos.Models;
using Venda_De_Ingressos.Models.ViewModels.EventoViewModels;
using Venda_De_Ingressos.Repositories.Interface;

namespace Venda_De_Ingressos.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EventoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Criar(Evento obj)
        {
            _dbContext.Set<Evento>().Add(obj);
            _dbContext.SaveChanges();
        }

        public void Deletar(Evento obj)
        {
            _dbContext.Set<Evento>().Remove(obj);
            _dbContext.SaveChanges();
        }

        public void Editar(Evento obj)
        {
            _dbContext.Set<Evento>().Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public Evento Buscar(int id)
        {
            return _dbContext.Set<Evento>()
                      .Include(x => x.CasaDeShow)
                      .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<EventoListagemViewModel> Listar()
        {
            return _dbContext.Set<Evento>().Select
                (x => new EventoListagemViewModel()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Preco = x.Preco,
                    Data = x.Data,
                    Capacidade = x.CasaDeShow.Capacidade,
                    CasaShowNome = x.CasaDeShow.Nome,
                    CasaDeShowId = x.CasaDeShowId
                }).ToList();
        }

        public IEnumerable<EventoListagemViewModel> ListarCapAsc()
        {
            return _dbContext.Set<Evento>().Select
                (x => new EventoListagemViewModel()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    CasaDeShowId = x.CasaDeShow.Id,
                    CasaShowNome = x.CasaDeShow.Nome,
                    Data = x.Data,
                    Preco = x.Preco,
                    Capacidade = x.CasaDeShow.Capacidade

                }).OrderBy(x => x.Capacidade).ToList();
        }

        public IEnumerable<EventoListagemViewModel> ListarCapDesc()
        {
            return _dbContext.Set<Evento>().Select
                (x => new EventoListagemViewModel()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    CasaDeShowId = x.CasaDeShow.Id,
                    CasaShowNome = x.CasaDeShow.Nome,
                    Data = x.Data,
                    Preco = x.Preco,
                    Capacidade = x.CasaDeShow.Capacidade

                }).OrderByDescending(x => x.Capacidade).ToList();
        }

        public IEnumerable<EventoListagemViewModel> ListarDataAsc()
        {
            return _dbContext.Set<Evento>().Select
                (x => new EventoListagemViewModel()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    CasaDeShowId = x.CasaDeShow.Id,
                    CasaShowNome = x.CasaDeShow.Nome,
                    Data = x.Data,
                    Preco = x.Preco,
                    Capacidade = x.CasaDeShow.Capacidade

                }).OrderBy(x => x.Data).ToList();
        }

        public IEnumerable<EventoListagemViewModel> ListarDataDesc()
        {
            return _dbContext.Set<Evento>().Select
                (x => new EventoListagemViewModel()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    CasaDeShowId = x.CasaDeShow.Id,
                    CasaShowNome = x.CasaDeShow.Nome,
                    Data = x.Data,
                    Preco = x.Preco,
                    Capacidade = x.CasaDeShow.Capacidade

                }).OrderByDescending(x => x.Data).ToList();
        }

        public IEnumerable<EventoListagemViewModel> ListarNomeAsc()
        {
            return _dbContext.Set<Evento>().Select
                (x => new EventoListagemViewModel()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    CasaDeShowId = x.CasaDeShow.Id,
                    CasaShowNome = x.CasaDeShow.Nome,
                    Data = x.Data,
                    Preco = x.Preco,
                    Capacidade = x.CasaDeShow.Capacidade

                }).OrderBy(x => x.Nome).ToList();
        }

        public IEnumerable<EventoListagemViewModel> ListarNomeDesc()
        {
            return _dbContext.Set<Evento>().Select
                (x => new EventoListagemViewModel()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    CasaDeShowId = x.CasaDeShow.Id,
                    CasaShowNome = x.CasaDeShow.Nome,
                    Data = x.Data,
                    Preco = x.Preco,
                    Capacidade = x.CasaDeShow.Capacidade

                }).OrderByDescending(x => x.Nome).ToList();
        }

        public IEnumerable<EventoListagemViewModel> ListarPrecoAsc()
        {
            return _dbContext.Set<Evento>().Select
                (x => new EventoListagemViewModel()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    CasaDeShowId = x.CasaDeShow.Id,
                    CasaShowNome = x.CasaDeShow.Nome,
                    Data = x.Data,
                    Preco = x.Preco,
                    Capacidade = x.CasaDeShow.Capacidade

                }).OrderBy(x => x.Preco).ToList();
        }

        public IEnumerable<EventoListagemViewModel> ListarPrecoDesc()
        {
            return _dbContext.Set<Evento>().Select
                (x => new EventoListagemViewModel()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    CasaDeShowId = x.CasaDeShow.Id,
                    CasaShowNome = x.CasaDeShow.Nome,
                    Data = x.Data,
                    Preco = x.Preco,
                    Capacidade = x.CasaDeShow.Capacidade

                }).OrderByDescending(x => x.Preco).ToList();
        }
        
        public bool Existe(int id) {
            return _dbContext.Set<Evento>().Any(x => x.Id == id);
        }
    }
}