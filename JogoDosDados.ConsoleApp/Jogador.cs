using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;

static class Jogador
{
    public static int posicao = 0;
    private const int limiteLinhaChegada = 30;
    private const int bonusAvancoExtra = 3;
    private const int penalidadeRecuo = 2;
    public static void ExecutarRodada()
    {
        do
        {
            ExibirCabecalho();
            Console.Write("\nPressione ENTER para lançar o dado...");
            Console.ReadLine();

            int resultadoJogador = LancarDado();

            posicao += resultadoJogador;

            Console.WriteLine($"\nVocê está na posição {posicao} de {limiteLinhaChegada}");

            posicao = AplicarEventos();

            if (posicao >= limiteLinhaChegada)
            {
                Console.WriteLine("\nParabéns! Você alcançou a linha de chegada!");

                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();

                break;
            }

            if (resultadoJogador == 6)
            {
                Console.WriteLine($"\nEVENTO: Rodada Extra!");

                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();

                continue;
            }
            else
            {
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();

                break;
            }
        } while (true);

    }
    static void ExibirCabecalho()
    {
        Console.Clear();
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("Rodada do Jogador");
        Console.WriteLine("------------------------------------------------------");
    }

    static int LancarDado()
    {
        int resultado = RandomNumberGenerator.GetInt32(1, 7);
        Console.Write($"\nO número sorteado foi: {resultado}");

        return resultado;
    }

    static int AplicarEventos()
    {
        if (posicao == 5 || posicao == 10 || posicao == 15 || posicao == 25)
        {
            Console.WriteLine($"\nEVENTO: Avanço de {bonusAvancoExtra} casas!");
            posicao += bonusAvancoExtra;

            Console.WriteLine($"\nPosição atual: {posicao} de {limiteLinhaChegada}");
        }

        else if (posicao == 7 || posicao == 13 || posicao == 20)
        {
            Console.WriteLine($"\nEVENTO: Recuo de {penalidadeRecuo} casas");
            posicao -= penalidadeRecuo;

            Console.WriteLine($"\nPosição atual: {posicao} de {limiteLinhaChegada}");
        }

        return posicao;
    }

    public static bool Venceu()
    {
        return posicao >= limiteLinhaChegada;
    }
}
