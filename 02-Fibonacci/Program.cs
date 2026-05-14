using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite a quantidade de elementos: ");
        int x = int.Parse(Console.ReadLine());

        int primeiro = 0;
        int segundo = 1;

        for (int i = 0; i < x; i++)
        {
            Console.Write(primeiro);

            if (i < x - 1)
            {
                Console.Write(", ");
            }

            int proximo = primeiro + segundo;
            primeiro = segundo;
            segundo = proximo;
        }
    }
}
