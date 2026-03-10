using System;
using System.Security.Cryptography;
internal class Program
{
    private static void Main(string[] args)
    {
        bool verificador = true;

        while (verificador == true)
        {
            int[] numerosDigitados = new int[100];
            int contadorDeNumerosDigitados = 0;

            Console.Clear();

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
                    continue;
            }

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

                for (int i = 0; i< numerosDigitados.Length; i++)
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

                if (tentativa == tentativasMaximas)
                {
                    System.Console.WriteLine($"você chegou no numero maximo de tentativas, o numero era {numeroAleatorio}");
                    System.Console.WriteLine("----------------------------------------");
                    break;
                }
            }



            System.Console.WriteLine("Quer continuar (S/N): ");
            string? SoN = Console.ReadLine();

            if (SoN?.ToUpper() != "S")
            {
                break;
            }
        }


    }

}