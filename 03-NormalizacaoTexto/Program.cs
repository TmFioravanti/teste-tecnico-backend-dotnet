using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Digite o texto: ");
        string texto = Console.ReadLine();

        StringBuilder resultado = new StringBuilder();

        for (int i = 0; i < texto.Length; i++)
        {
            char atual = texto[i];

            if (atual == '?' || atual == '!')
            {
                if (resultado.Length == 0 || resultado[resultado.Length - 1] != atual)
                {
                    resultado.Append(atual);
                }
            }
            else
            {
                resultado.Append(atual);
            }
        }

        Console.WriteLine("Texto normalizado:");
        Console.WriteLine(resultado.ToString());
    }
}
