using System;
using System.Collections.Generic;

namespace DIO.Biblioteca
{
    class Program
    {
        static LivroRepositorio repositorio = new LivroRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						Listar();
						break;
					case "2":
						Inserir();
						break;
					case "3":
						Atualizar();
						break;
					case "4":
						Excluir();
						break;
					case "5":
						Visualizar();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void Excluir()
		{
			Console.Write("Digite o id da série: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			repositorio.Excluir(indiceLivro);
		}

		private static void Excluir(int livroId)
		{
			Console.Write("Digite o id da avaliação: ");
			int indiceAvaliacao = int.Parse(Console.ReadLine());

			repositorio.Excluir(indiceAvaliacao);
		}

        private static void Visualizar()
		{
			Console.Write("Digite o id da série: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			var livro = repositorio.RetornarPorId(indiceLivro);

			Console.WriteLine(livro);
			Console.WriteLine();

			var opcaoUsuario = ObterOpcaoLivro();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch(opcaoUsuario)
				{
					case "1":
						Listar(indiceLivro);
						break;
					case "2":
						Inserir(indiceLivro);
						break;
					case "3":
						Excluir(indiceLivro);
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
				
				opcaoUsuario = ObterOpcaoLivro();
			}
		}

        private static void Atualizar()
		{
			Console.Write("Digite o id do livro: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			List<Genero> generosLivro = ObterGenerosLivro();

			Console.Write("Digite o Título do Livro: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início do Livro: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Livro: ");
			string entradaDescricao = Console.ReadLine();

			Livro atualizaLivro = new Livro(id: indiceLivro,
										generos: generosLivro,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualizar(indiceLivro, atualizaLivro);
		}
        private static void Listar()
		{
			Console.WriteLine("Listar livros");

			var lista = repositorio.Listar();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma livro cadastrada.");
				return;
			}

			foreach (var livro in lista)
			{
                var excluido = livro.retornarExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", livro.retornarId(), livro.retornarTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

		private static void Listar(int livroId)
		{
			Console.WriteLine("Listar avaliações");

			var lista = repositorio.Listar(livroId);

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma avaliacao cadastrada.");
				return;
			}

			foreach (var avaliacao in lista)
			{
                var excluido = avaliacao.retornarExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", avaliacao.retornarId(), avaliacao.retornarTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void Inserir()
		{
			Console.WriteLine("Inserir novo livro");

			List<Genero> generosLivro = ObterGenerosLivro();

			Console.Write("Digite o Título do Livro: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de publicação do Livro: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a sinopse da Livro: ");
			string entradaDescricao = Console.ReadLine();

			Livro novoLivro = new Livro(id: repositorio.ProximoId(),
										generos: generosLivro,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Inserir(novoLivro);
		}

		private static void Inserir(int livroId)
		{
			Console.WriteLine("Inserir nova avaliação");

			Console.Write("Digite a nota da avaliação (0 a 5): ");
			int notaAvaliacao = Convert.ToInt32(Console.ReadLine());

			Console.Write("Digite o Título da avaliação: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o texto da avaliação: ");
			string entradaDescricao = Console.ReadLine();

			Avaliacao novaAvaliacao = new Avaliacao(id: repositorio.ProximoId(livroId),
										nota: notaAvaliacao,
										titulo: entradaTitulo,
										descricao: entradaDescricao);

			repositorio.Inserir(livroId, novaAvaliacao);
		}

		private static List<Genero> ObterGenerosLivro()
		{
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.WriteLine("0- Sair");
			Console.Write("Digite o gênero entre as opções acima: ");

			int opcaoGenero = int.Parse(Console.ReadLine());

			List<Genero> generos = new List<Genero>();
			while(opcaoGenero != 0 || generos.Count == 0)
			{
				if(opcaoGenero == 0 && generos.Count == 0)
					Console.WriteLine("Porfavor escolher ao menos um gênero");
				else {
					generos.Add((Genero) opcaoGenero);
					Console.Write("Digite o gênero adicional entre as opções acima: ");
				}
				opcaoGenero = int.Parse(Console.ReadLine());
			}
			return generos;
		}

		private static string ObterOpcaoLivro()
		{
			Console.WriteLine();
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar avaliações");
			Console.WriteLine("2- Inserir nova avaliação");
			Console.WriteLine("3- Excluir avaliação");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoLivro = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoLivro;
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Biblioteca a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar livros");
			Console.WriteLine("2- Inserir novo livro");
			Console.WriteLine("3- Atualizar livro");
			Console.WriteLine("4- Excluir livro");
			Console.WriteLine("5- Visualizar livro");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			Console.WriteLine("Digite a opção desejada");
			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
