using System.Collections.Generic;

namespace DIO.Biblioteca
{
    public interface IRepositorio<T, E>
    {
        List<T> Listar();
        List<E> Listar(int livroId);
        T RetornarPorId(int id);
        void Inserir(T entidade);
        void Inserir(int livroId, E entidade);
        void Excluir(int id);
        void Excluir(int livroId, int avaliacaoId);
        void Atualizar(int id, T entidade);
        int ProximoId();
    }
}
