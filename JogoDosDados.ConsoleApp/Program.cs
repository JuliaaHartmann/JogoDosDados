using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;

/*
1. Pista:
    - A pista é representada por uma linha numérica (ex.: de 0 a 30).
    - O jogador e o computador começam na posição 0.

2. Turnos:
    - O jogador e o computador alternam turnos para rolar um dado (gerar um número aleatório entre 1 e 6).
    - O número gerado é somado à posição atual do competidor.
    - O jogo exibe a posição atual do jogador e do computador após cada rodada.

3. Eventos Especiais:
    - Para tornar o jogo mais interessante, algumas posições na pista podem ter eventos especiais.
    - Avanço extra: Se o competidor parar em uma posição específica (ex.: 5, 10, 15), ele avança +3 casas.
    - Recuo: Se o competidor parar em outra posição específica (ex.: 7, 13, 20), ele recua -2 casas.
    - Rodada extra: Se o competidor tirar 6 no dado, ele ganha uma rodada extra.

4. Condição de Vitória:
    - O primeiro competidor a alcançar ou ultrapassar a posição final (ex.: 30) vence o jogo.
*/

class Program
{
    static void Main(string[] args)
    {
        const int limiteLinhaChegada = 30;
        const int bonusAvancoExtra = 3;
        const int penalidadeRecuo = 2;

        ExecutarPartida(limiteLinhaChegada, bonusAvancoExtra, penalidadeRecuo);
    }

    static void ExecutarPartida(int limiteLinhaChegada, int bonusAvancoExtra, int penalidadeRecuo)
    {
        while (true)
        {
            int posicaoJogador = 0;
            int posicaoComputador = 0;

            while (true)
            {
                posicaoJogador = RodadaJogador(posicaoJogador, limiteLinhaChegada, bonusAvancoExtra, penalidadeRecuo);

                if (posicaoJogador >= limiteLinhaChegada)
                    break;

                posicaoComputador = RodadaComputador(posicaoComputador, limiteLinhaChegada, bonusAvancoExtra, penalidadeRecuo);

                if (posicaoComputador >= limiteLinhaChegada)
                    break;
            }

            if (!JogadorDesejaContinuar())
                break;
        }
    }
    static void ExibirCabecalho(string nomeJogador)
    {
        Console.Clear();
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("Jogo dos Dados");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine($"Rodada do {nomeJogador}");
        Console.WriteLine("------------------------------------------------------");
    }

    static int LancarDado()
    {
        int resultado = RandomNumberGenerator.GetInt32(1, 7);
        Console.Write($"\nO número sorteado foi: {resultado}");

        return resultado;
    }

    static int RodadaJogador(int posicaoJogador, int limiteLinhaChegada, int bonusAvancoExtra, int penalidadeRecuo)
    {
        do
        {
            ExibirCabecalho("Jogador");
            Console.Write("\nPressione ENTER para lançar o dado...");
            Console.ReadLine();

            int resultadoJogador = LancarDado();

            posicaoJogador += resultadoJogador;

            Console.WriteLine($"\nVocê está na posição {posicaoJogador} de {limiteLinhaChegada}");

            posicaoJogador = AplicarEventos(posicaoJogador, limiteLinhaChegada, bonusAvancoExtra, penalidadeRecuo);

            if (posicaoJogador >= limiteLinhaChegada)
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

        return posicaoJogador;
    }

    static int RodadaComputador(int posicaoComputador, int limiteLinhaChegada, int bonusAvancoExtra, int penalidadeRecuo)
    {
        do
        {
            ExibirCabecalho("Computador");

            int resultadoComputador = LancarDado();

            posicaoComputador += resultadoComputador;

            Console.WriteLine($"\nVocê está na posição {posicaoComputador} de {limiteLinhaChegada}");

            posicaoComputador = AplicarEventos(posicaoComputador, limiteLinhaChegada, bonusAvancoExtra, penalidadeRecuo);

            if (posicaoComputador >= limiteLinhaChegada)
            {
                Console.WriteLine("\nQue pena! O computador alcançou a linha de chegada!");

                break;
            }
            if (resultadoComputador == 6)
            {
                Console.WriteLine($"\nEVENTO: Rodada Extra!");
                Console.WriteLine("-------------------------------------------");

                continue;
            }
            else
            {
                Console.Write("\nPressione ENTER para continuar...");
                Console.ReadLine();

                break;
            }
        } while (true);

        return posicaoComputador;
    }

    static int AplicarEventos(int posicao, int limiteLinhaChegada, int bonusAvancoExtra, int penalidadeRecuo)
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

    static bool JogadorDesejaContinuar()
    {
        Console.Write("Deseja continuar? (S/N): ");
        string? opcaoContinuar = Console.ReadLine()?.ToUpper();

        if (opcaoContinuar != "S")
            return false;

        return true;
    }
}