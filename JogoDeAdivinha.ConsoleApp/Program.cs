        using System;
        using System.Security.Cryptography;
internal class Program
{
    private static void Main(string[] args)
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

        System.Console.WriteLine("Numero Digitado: " + numeroJogadorInti);
        System.Console.WriteLine("O numero aleatorio era: " + numeroAleatorio);
    }

}