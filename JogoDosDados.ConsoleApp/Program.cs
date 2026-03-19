using System.Security.Cryptography;

namespace JogoDosDados.ConsoleApp

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

{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
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
            
                Console.Write("Deseja continuar? (S/N): ");
                string? opcaoContinuar = Console.ReadLine()?.ToUpper();

                if (opcaoContinuar != "S")
                    break;
            }
        }
    }
}