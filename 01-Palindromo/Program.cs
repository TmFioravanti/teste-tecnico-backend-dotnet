using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite uma palavra ou frase: ");
        string texto = Console.ReadLine();

        string textoTratado = "";

        foreach (char c in texto.ToLower())
        {
            if (c != ' ')
            {
                textoTratado += c;
            }
        }

        bool palindromo = true;

        int inicio = 0;
        int fim = textoTratado.Length - 1;

        while (inicio < fim)
        {
            if (textoTratado[inicio] != textoTratado[fim])
            {
                palindromo = false;
                break;
            }

            inicio++;
            fim--;
        }

        if (palindromo)
        {
            Console.WriteLine("É um palíndromo.");
        }
        else
        {
            Console.WriteLine("Não é um palíndromo.");
        }
    }
}
