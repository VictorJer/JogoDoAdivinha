using System;
using System.Security.Cryptography;
internal class Program
{
    private static void Main(string[] args)
    {


        do
        {
            //1. tela de menu e espera o input do usuario
            string? dificuldade = ExibirMenuDificuldade();

            // 2. configuração do jogo
            int[] configuracoes = ConfigurarPartida(dificuldade);

            int numeroMaximo = configuracoes[0];
            int tentativasMaximas = configuracoes[1];

            //3. execução do jogo
            execuçãoDoJogo(numeroMaximo, tentativasMaximas);

            // 4. pergunta se o jogador vai continuar o jogo
            }while (JogadorDesejaContinuar() == true);


    }


    static string? ExibirMenuDificuldade()
    {
        //Console.Clear();

        Console.WriteLine("------------------------------");
        Console.WriteLine("Jogo Do Adivinha !");
        Console.WriteLine("------------------------------");
        Console.WriteLine("Escolha o nivel de dificuldade");
        Console.WriteLine("------------------------------");
        Console.WriteLine("1 - facil (10 tentativas)");
        Console.WriteLine("2 - Médio (5 tentativas)");
        Console.WriteLine("3 - Dificil (3 tentativas)");
        Console.WriteLine("------------------------------");


        System.Console.Write("Digite sua escolha: ");
        string? dificuldade = Console.ReadLine();

        return dificuldade;


    }
    static int[] ConfigurarPartida(string? dificuldade)
    {
        int numeroMaximo = 0;
        int tentativasMaximas = 0;

        switch (dificuldade)
        {
            case "1":
                numeroMaximo = 20;
                tentativasMaximas = 10;
                break;

            case "2":
                numeroMaximo = 50;
                tentativasMaximas = 5;
                break;

            case "3":
                numeroMaximo = 100;
                tentativasMaximas = 3;
                break;

            default:
                Console.WriteLine("------------------------------");
                System.Console.WriteLine("Por favor selecione uma dificuldade valida");
                System.Console.Write("Digite ENTER para continuar...");
                Console.ReadLine();
                break;
        }
        int[] configuracoes = new int[2];

        configuracoes[0] = numeroMaximo;
        configuracoes[1] = tentativasMaximas;


        return configuracoes;
    }
    static void execuçãoDoJogo(int numeroMaximo, int tentativasMaximas)
    {
        int[] numerosDigitados = new int[tentativasMaximas];
        int contadorDeNumerosDigitados = 0;
        int pontuacao = 1000;

        int numeroAleatorio = RandomNumberGenerator.GetInt32(1, numeroMaximo + 1);

        for (int tentativa = 1; tentativa <= tentativasMaximas; tentativa++)
        {
            Console.Clear();
            System.Console.WriteLine("------------------------------");
            System.Console.WriteLine($"tentativa {tentativa} de {tentativasMaximas}");
            System.Console.WriteLine("------------------------------");



            System.Console.Write($"digirte um numero entre 1 e {numeroMaximo}: ");
            string? numeroJogador = Console.ReadLine();
            System.Console.WriteLine("----------------------------");

            int numeroJogadorInti = Convert.ToInt32(numeroJogador);

            for (int i = 0; i < numerosDigitados.Length; i++)
            {
                if (numeroJogadorInti == numerosDigitados[i])
                {
                    System.Console.WriteLine($"você ja digitou o numero {numerosDigitados[i]}");
                    System.Console.WriteLine("ENETER para continuar...");
                    Console.ReadLine();

                    tentativa--;

                    continue;
                }
            }

            if (contadorDeNumerosDigitados < numerosDigitados.Length)
            {
                numerosDigitados[contadorDeNumerosDigitados] = numeroJogadorInti;
            }

            if (numeroJogadorInti == numeroAleatorio)
            {
                System.Console.WriteLine("-----------------------");
                System.Console.WriteLine("parabéns, você acertou");
                System.Console.WriteLine("-----------------------");

                break;
            }
            else if (numeroJogadorInti > numeroAleatorio)
            {
                System.Console.WriteLine("-----------------------");
                System.Console.WriteLine("o numero digitado e maior");
                System.Console.WriteLine("ENTER para continuar...");
                System.Console.WriteLine("-----------------------");
                Console.ReadLine();

            }
            else
            {
                System.Console.WriteLine("-----------------------");
                System.Console.WriteLine("o numero digitado e menor");
                System.Console.WriteLine("Enter para continuar...");
                System.Console.WriteLine("-----------------------");
                Console.ReadLine();
            }


            int diferencaNumerica = Math.Abs(numeroAleatorio - numeroJogadorInti); // Math.Abs pega o numero seco


            if (diferencaNumerica >= 10)
            {
                pontuacao -= 100;
            }
            else if (diferencaNumerica >= 5)
            {
                pontuacao -= 50;
            }
            else
            {
                pontuacao -= 20;
            }


            System.Console.WriteLine("sua pontuação é: " + pontuacao);
            System.Console.WriteLine("ENTER para continuar...");
            System.Console.WriteLine("--------------------------------");
            Console.ReadLine();



            if (tentativa == tentativasMaximas)
            {
                System.Console.WriteLine($"você chegou no numero maximo de tentativas, o numero era {numeroAleatorio}");
                System.Console.WriteLine("----------------------------------------");
                break;
            }

        }
    }
    static bool JogadorDesejaContinuar()
    {
        System.Console.WriteLine("Quer continuar (S/N): ");
        string? SoN = Console.ReadLine();

        if (SoN?.ToUpper() != "S")
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}