using System;
using System.Collections.Generic;

namespace DIO.Biblioteca
{
    public class Livro : EntidadeBase
    {
        // Atributos
        private List<Genero> Generos { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private List<Avaliacao> Avaliacoes { get; set; }
        private bool Excluido { get; set; }

        public Livro(int id, List<Genero> generos, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Generos = generos;
            this.Titulo = titulo;
            this.Ano = ano;
            this.Avaliacoes = new List<Avaliacao>();
            this.Excluido = false;
        }

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gêneros: " + String.Join('.', this.Generos) + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de publicação: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
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

        public List<Avaliacao> ListarAvaliacoes()
        {
            return this.Avaliacoes;
        }

        public void AddAvaliacao(Avaliacao objeto)
        {
            this.Avaliacoes.Add(objeto);
        }

        public void ExcluirAvaliacao(int avaliacaoId)
        {
            this.Avaliacoes[avaliacaoId].Excluir();
        }
    }
}
