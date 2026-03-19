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

        while(true)
        {
            int posicaoJogador = 0;
            bool jogoEstaEmAndamento = true;

            while(jogoEstaEmAndamento)
            {                        
                Console.Clear();
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Jogo dos Dados");
                Console.WriteLine("------------------------------------------------------");
            
                // Lógica do Jogo
                Console.Write("Presione ENTER para lançar o dado...");
                Console.ReadLine();

                int resultado = RandomNumberGenerator.GetInt32(1, 7);

                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine($"O número sorteado foi: {resultado}");
                Console.WriteLine("------------------------------------------------------");

                posicaoJogador += resultado;

                Console.WriteLine($"Você está na posição {posicaoJogador} de {limiteLinhaChegada}");

                if (posicaoJogador == 5 || posicaoJogador == 10 || posicaoJogador == 15 || posicaoJogador == 25)
                {
                    Console.WriteLine($"\nEVENTO: Avanço de {bonusAvancoExtra} casas!");
                    posicaoJogador += bonusAvancoExtra; 

                    Console.WriteLine($"\nVocê está na posição {posicaoJogador} de {limiteLinhaChegada}");
                }

                else if (posicaoJogador == 7 || posicaoJogador == 13 || posicaoJogador == 20)
                {
                    Console.WriteLine($"\nEVENTO: Recuo de {penalidadeRecuo} casas");
                    posicaoJogador -= penalidadeRecuo;

                    Console.WriteLine($"\nVocê está na posição {posicaoJogador} de {limiteLinhaChegada}");
                }

                if(posicaoJogador >= limiteLinhaChegada)
                {
                    Console.WriteLine("\nParabéns! Você alcançou a linha de chegada!");

                    jogoEstaEmAndamento = false;
                }

                Console.WriteLine();
                Console.Write("Pressione ENTER para continuar...");
                Console.ReadLine();
            }

            Console.Write("Deseja continuar? (S/N): ");
            string? opcaoContinuar = Console.ReadLine()?.ToUpper();

            if (opcaoContinuar != "S")
                break;
        }
    }
}