using System;
using System.IO;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        string textoCifrado = File.ReadAllText("provinhaBarbadinha.txt");
        string textoDecifrado = decifrar(textoCifrado);
        textoDecifrado = textoDecifrado.Replace("@", "\n");

        string[] palindromos = palindromo(textoDecifrado);

        Console.WriteLine("Conteúdo do texto cifrado: \n" + textoCifrado);
        Console.WriteLine("\nPalíndromos encontrados: ");

        foreach (var item in palindromos)
         {
            if (item.Length > 2)
            Console.WriteLine(item);
        }

        static string SubstituirPalindromos(string texto, string[] palindromos)
        {
            foreach (var palavra in palindromos)
            {
                if (palavra.Length > 2)
                {
                    string substituicao = "";
                    switch (palavra.ToLower())
                    {
                        case "arara":
                            substituicao = "gloriosa";
                            break;
                        case "ovo":
                            substituicao = "bondade";
                            break;
                        case "osso":
                            substituicao = "passam";
                            break;
                        // Add more cases for other palindromes if needed
                    }

                    texto = texto.Replace(palavra, substituicao);
                }
            }

            return texto;
        }
        
        textoDecifrado = SubstituirPalindromos(textoDecifrado, palindromos);
        Console.WriteLine("\nNúmero de caracteres do texto decifrado: " + textoDecifrado.Length);
        Console.WriteLine("\nQuantidade de palavras no texto decifrado: " + textoDecifrado.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length);
        Console.WriteLine("\nTexto decifrado em maiúsculas: \n" + textoDecifrado.ToUpper());
    }

    static string decifrar(string textoCifrado)
    {
        char[] caracteresCifrados = textoCifrado.ToCharArray();
        for (int i = 0; i < caracteresCifrados.Length; i++)
        {
            int chave = (i % 5 == 0) ? 8 : 16;
            caracteresCifrados[i] = (char)(caracteresCifrados[i] - chave);
        }
        return new string(caracteresCifrados);
    }
    static string[] palindromo(string texto)
    {
        return texto.Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Where(palavra =>
            {
                char[] caracteres = palavra.ToCharArray();
                Array.Reverse(caracteres);
                return palavra.Equals(new string(caracteres), StringComparison.OrdinalIgnoreCase);
            })
            .ToArray();
    }

}
//Johan Ricardo Masselai