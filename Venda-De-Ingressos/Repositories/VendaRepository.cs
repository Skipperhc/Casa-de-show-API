using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Venda_De_Ingressos.Data;
using Venda_De_Ingressos.Models;
using Venda_De_Ingressos.Models.ViewModels.VendaViewModels;
using Venda_De_Ingressos.Repositories.Interface;

namespace Venda_De_Ingressos.Repositories {
    public class VendaRepository : IVendaRepository {
        private readonly ApplicationDbContext _dbContext;

        public VendaRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public void Criar(Venda obj) {
            _dbContext.Set<Venda>().Add(obj);
            _dbContext.SaveChanges();        }

        public void Deletar(Venda obj) {
            _dbContext.Set<Venda>().Remove(obj);
            _dbContext.SaveChanges();        }

        public void Editar(Venda obj) {
            _dbContext.Set<Venda>().Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();        }

        public Venda Buscar(int id) {
            return _dbContext.Set<Venda>().FirstOrDefault(x => x.Id == id);        }

        public IEnumerable<VendaListagemViewModel> Listar() {
            return _dbContext.Set<Venda>().Select
            (x => new VendaListagemViewModel()
            {
                Id = x.Id,
                Preco = x.Preco,
                EventoId = x.EventoId,
                QtdIngressos = x.QtdIngressos
            }).ToList();        }
    }
}