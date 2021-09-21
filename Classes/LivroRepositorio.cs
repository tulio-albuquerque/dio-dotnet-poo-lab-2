using System;
using System.Collections.Generic;

namespace DIO.Biblioteca
{
    public class LivroRepositorio : IRepositorio<Livro, Avaliacao>
    {
        private List<Livro> listaLivro = new List<Livro>();

        public void Atualizar(int id, Livro objeto)
        {
            listaLivro[id] = objeto;
        }

        public void Excluir(int id)
        {
            listaLivro[id].Excluir();
        }

        public void Excluir(int livroId, int avaliacaoId)
        {
            listaLivro[livroId].ExcluirAvaliacao(avaliacaoId);
        }

        public void Inserir(Livro objeto)
        {
            listaLivro.Add(objeto);
        }

        public void Inserir(int livroId, Avaliacao objeto)
        {
            listaLivro[livroId].AddAvaliacao(objeto);
        }

        public List<Livro> Listar()
        {
            return listaLivro;
        }

        public List<Avaliacao> Listar(int livroId)
        {
            return listaLivro[livroId].ListarAvaliacoes();
        }

        public int ProximoId()
        {
            return listaLivro.Count;
        }

        public int ProximoId(int livroId)
        {
            return Listar(livroId).Count;
        }

        public Livro RetornarPorId(int id)
        {
            return listaLivro[id];
        }
    }
}
