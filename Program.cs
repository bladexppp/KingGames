using System;

namespace dio.games
{
    class Program
    {

        static JogosRepositorio repositorio = new JogosRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarJogos();
						break;
					case "2":
						InserirJogos();
						break;
					case "3":
						AtualizarJogos();
						break;
					case "4":
						ExcluirJogos();
						break;
					case "5":
						VisualizarJogos();
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

		private static void ExcluirJogos()
		{
			Console.Write("Digite o id do jogo: ");
			int indiceJogos = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceJogos);
		}

		private static void VisualizarJogos()
		{
			Console.Write("Digite o id do jogo: ");
			int indiceJogos = int.Parse(Console.ReadLine());

			var jogos = repositorio.RetornaPorId(indiceJogos);

			Console.WriteLine(jogos);
		}


        private static void AtualizarJogos()
		{
			Console.Write("Digite o id do jogo: ");
			int indiceJogos = int.Parse(Console.ReadLine());


			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

            foreach (int o in Enum.GetValues(typeof(Plataforma)))
			{
				Console.WriteLine("{0}-{1}", o, Enum.GetName(typeof(Plataforma), o));
			} 
            Console.Write("Digite a plataforma entre as opções acima: ");
			int entradaPlataforma = int.Parse(Console.ReadLine());           

			Console.Write("Digite o Título do jogo: ");
			string entradaTitulo = Console.ReadLine();

 			Console.Write("Digite o Estudio do jogo: ");
			string entradaEstudio = Console.ReadLine();           

			Console.Write("Digite o Ano de Início do jogo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do jogo: ");
			string entradaDescricao = Console.ReadLine();

			Jogos atualizaJogos = new Jogos(id: indiceJogos,
										genero: (Genero)entradaGenero,
                                        plataforma: (Plataforma)entradaPlataforma,
										titulo: entradaTitulo,
                                        estudio: entradaEstudio,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceJogos, atualizaJogos);
		}      
	   
	   
	   private static void ListarJogos()
		{
			Console.WriteLine("Listar jogos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum jogo cadastrado.");
				return;
			}

			foreach (var jogos in lista)
			{
                var excluido = jogos.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", jogos.retornaId(), jogos.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
        private static void InserirJogos()
		{
			Console.WriteLine("Inserir novo jogo");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

             foreach (int o in Enum.GetValues(typeof(Plataforma)))
			{
				Console.WriteLine("{0}-{1}", o, Enum.GetName(typeof(Plataforma), o));
			} 
            Console.Write("Digite a plataforma entre as opções acima: ");
			int entradaPlataforma = int.Parse(Console.ReadLine());            

			Console.Write("Digite o Título da jogo: ");
			string entradaTitulo = Console.ReadLine();

  			Console.Write("Digite o Estudio do jogo: ");
			string entradaEstudio = Console.ReadLine();            

			Console.Write("Digite o Ano de Início do jogo: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do jogo: ");
			string entradaDescricao = Console.ReadLine();

			Jogos novoJogo = new Jogos(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
                                        plataforma: (Plataforma)entradaPlataforma,
										titulo: entradaTitulo,
                                        estudio: entradaEstudio,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoJogo);
		}
        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("King Jogos a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar jogos");
			Console.WriteLine("2- Inserir novo jogo");
			Console.WriteLine("3- Atualizar jogo");
			Console.WriteLine("4- Excluir jogo");
			Console.WriteLine("5- Visualizar jogo");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
