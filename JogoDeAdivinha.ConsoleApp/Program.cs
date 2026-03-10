using System;
using System.Security.Cryptography;
internal class Program
{
    private static void Main(string[] args)
    {
        bool verificador = true;

        while (verificador == true)
        {
            Console.Clear();

            Console.WriteLine("------------------------------");
            Console.WriteLine("Jogo Do Adivinha !");
            Console.WriteLine("------------------------------");

            Console.ReadLine();

            int numeroAleatorio = RandomNumberGenerator.GetInt32(1, 21);



            System.Console.Write("digirte um numero: ");
            string? numeroJogador = Console.ReadLine();
            System.Console.WriteLine("----------------------------");

            int numeroJogadorInti = Convert.ToInt32(numeroJogador);

            if (numeroJogadorInti == numeroAleatorio)
            {
                System.Console.WriteLine("-----------------------");
                System.Console.WriteLine("parabéns, você acertou");
                System.Console.WriteLine("-----------------------");
            }
            else if (numeroJogadorInti > numeroAleatorio)
            {
                System.Console.WriteLine("-----------------------");
                System.Console.WriteLine("o numero digitado era maior");
                System.Console.WriteLine("-----------------------");
            }
            else
            {
                System.Console.WriteLine("-----------------------");
                System.Console.WriteLine("o numero digitado e menor");
                System.Console.WriteLine("-----------------------");
            }

            System.Console.WriteLine("Quer continuar (S/N): ");
            string? SoN = Console.ReadLine();

            if (SoN?.ToUpper() != "S")
            {
                break;
            }

            Console.ReadLine();
        }


    }

}