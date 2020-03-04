using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Venda_De_Ingressos.Data;
using Venda_De_Ingressos.Models;
using Venda_De_Ingressos.Models.ViewModels.CasaDeShowViewModels;
using Venda_De_Ingressos.Repositories.Interface;

namespace Venda_De_Ingressos.Repositories {
    public class CasaDeShowRepository : ICasaDeShowRepository {
        private readonly ApplicationDbContext _dbContext;

        public CasaDeShowRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public void Criar(CasaDeShow obj) {
            _dbContext.Set<CasaDeShow>().Add(obj);
            _dbContext.SaveChanges();
        }

        public void Deletar(CasaDeShow obj) {
            _dbContext.Set<CasaDeShow>().Remove(obj);
            _dbContext.SaveChanges();
        }

        public void Editar(CasaDeShow obj) {
            _dbContext.Set<CasaDeShow>().Attach(obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public CasaDeShow Buscar(int id) {
            return _dbContext.Set<CasaDeShow>().Include(x => x.Eventos).FirstOrDefault(x => x.Id == id);
        }

        public bool Existe(int id) {
            return _dbContext.Set<CasaDeShow>().Any(x => x.Id == id);
        }

        //busco no banco todos os nomes que tenham o {nome} no meio, isso é muito bom, aumenta a eficácia 
        public List<CasaDeShow> BuscarNome(string nome) {
            return _dbContext.Set<CasaDeShow>().Include(x => x.Eventos).Where
                (x => x.Nome.Contains(nome, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        public IEnumerable<CasaDeShowListagemViewModel> Listar() {
            return _dbContext.Set<CasaDeShow>().Select
            (x => new CasaDeShowListagemViewModel() {
                Id = x.Id, Nome = x.Nome, Endereco = x.Endereco, Capacidade = x.Capacidade
            }).ToList();
        }

        public IEnumerable<CasaDeShowListagemViewModel> ListarAsc() {
            return _dbContext.Set<CasaDeShow>().Select
            (x => new CasaDeShowListagemViewModel() {
                Id = x.Id, Nome = x.Nome, Endereco = x.Endereco, Capacidade = x.Capacidade
            }).OrderBy(x => x.Nome).ToList();
        }

        public IEnumerable<CasaDeShowListagemViewModel> ListarDesc() {
            return _dbContext.Set<CasaDeShow>().Select
            (x => new CasaDeShowListagemViewModel() {
                Id = x.Id, Nome = x.Nome, Endereco = x.Endereco, Capacidade = x.Capacidade
            }).OrderByDescending(x => x.Nome).ToList();
        }
    }
}