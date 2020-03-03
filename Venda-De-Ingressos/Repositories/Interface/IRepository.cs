using System.Collections.Generic;

namespace Venda_De_Ingressos.Repositories.Interface {
    public interface IRepository<T> {
        void Criar(T obj);
        void Deletar(T obj);
        void Editar(T obj);
        T Buscar(int id);
    }
}