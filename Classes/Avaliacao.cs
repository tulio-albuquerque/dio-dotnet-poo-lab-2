using System;
using System.Collections.Generic;

namespace DIO.Biblioteca
{
    public class Avaliacao : EntidadeBase
    {
        private int Nota { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }

        private bool Excluido { get; set; }

        public Avaliacao(int id, int nota, string titulo, string descricao)
        {
            this.Id = id;
            this.Nota = nota;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Excluido = false;
        }

        public string retornarTitulo()
		{
			return this.Titulo;
		}

		public int retornarId()
		{
			return this.Id;
		}
        
        public bool retornarExcluido()
		{
			return this.Excluido;
		}

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}