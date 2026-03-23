using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp;
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
            InicializarPartida();

            while (true)
            {
                Jogador.ExecutarRodada();

                if (Jogador.Venceu())
                    break;

                Computador.ExecutarRodada();

                if (Computador.Venceu())
                    break;
            }

            if (!JogadorDesejaContinuar())
                break;
        }
    }
    
    static void InicializarPartida()
    {
        Jogador.posicao = 0;

        Computador.posicao = 0;
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