namespace Jklm
{

    public class Jklm
    {

        static void Main()
        {
            Console.Clear();
            var frase = "   /\\_/\\  \n  / o o \\ \n (   \"   ) \n  \\~(*)~/ \n   \\~|~/\n    | |\n   /| |\\";

            for (int i = 0; i < frase.Length; i++)
            {
                Console.Write(frase[i]);

                Thread.Sleep(2);
            }
            Console.WriteLine("");
            Console.WriteLine("Auxilio para \n    JKLM");
            Console.WriteLine("|===========|");
            Menu();
        }

        static string? letras = "";
        // static string[] palavras = { "Girassol", "Rapsol", "Abacaxi", "Espectro", "Aquarela", "Tramontana", "Elixir" };
        // static string [] palavrasLowerCase = palavras.Select(s => s.ToLower()).ToArray();

        static void Menu()
        {
            Console.Write("Digite parte da palavra: ");
            letras = Console.ReadLine();
            letras?.ToLower();
            Pesquisa();
        }


        public static void Pesquisa()
        {
            string arquivo = "lista.txt";
            string[] palavrasLowerCase = new string[0];

            if (File.Exists(arquivo))
            {
                List<string> listaDeStrings = new List<string>(File.ReadAllLines(arquivo));
                palavrasLowerCase = listaDeStrings.Select(s => s.ToLower()).ToArray();
            }
            else
            {
                Console.WriteLine("Arquivo nao encontrado, fechando o programa em 5 segundos");
                Thread.Sleep(5000);
                Environment.Exit(1);
            }

            List<string> palavrasEncontradas = new List<string>();

            Console.WriteLine("|===========|");
            foreach (var palavra in palavrasLowerCase)
            {
                if (palavra.Contains(letras))
                {
                    palavrasEncontradas.Add(palavra);
                }
            }

            if (palavrasEncontradas.Count == 0) {
                Console.WriteLine("Nao encontramos nenhuma palavra");
            } else {
                Console.WriteLine("Palavras encontradas");
                foreach (var item in palavrasEncontradas)
                {
                    Console.WriteLine(item);
                }
            }

            Console.ReadKey();
            Console.Clear();
            Menu();
        }
    }
}