namespace Jklm
{

    public class Jklm
    {

        static void Main()
        {
            Console.Clear();

            Console.WriteLine(" ╔═════════════════════╗ ");
            Console.WriteLine(" ║     JKLM-Finder     ║ ");
            Console.WriteLine(" ║ Github: JoaooowDev  ║ ");
            Console.WriteLine(" ║ Insta: @JoaooowDev  ║ ");
            Console.WriteLine(" ╚═════════════════════╝ ");

            // A frase é o que faz aparecer o Gato Foguete no inicio do script
            var frase = "          /\\_/\\  \n         / o o \\ \n        (   \"   ) \n         \\~(*)~/ \n          \\~|~/\n           | |\n          /| |\\";

            // Aqui faz com que o Gato-Foguete apareca caractere por caractere
            for (int i = 0; i < frase.Length; i++)
            {
                Console.Write(frase[i]);

                Thread.Sleep(2);
            }
            Console.WriteLine("");
            Console.WriteLine("      Auxilio para \n          JKLM");
            Console.WriteLine("|=======================|");
            Menu();
        }

        // Variavel para salvar as letras que vao conter nas palavras
        static string? letras = "";

        // Codigo antigo para testes
        // static string[] palavras = { "Girassol", "Rapsol", "Abacaxi", "Espectro", "Aquarela", "Tramontana", "Elixir" };
        // static string [] palavrasLowerCase = palavras.Select(s => s.ToLower()).ToArray();

        static void Menu()
        {
            Console.Write("Digite parte da palavra: ");
            // Ler a linha das letras e converte-las para minusculo
            letras = Console.ReadLine();
            letras?.ToLower();
            Pesquisa();
        }


        public static void Pesquisa()
        {
            // Nome do arquivo
            string arquivo = "lista.txt";

            // array para poder utilizar fora do if
            string[] palavrasLowerCase = new string[0];

            // Verificando a existencia do arquivo, se existir vai ler o arquivo e jogar dentro da array
            if (File.Exists(arquivo))
            {
                List<string> listaDeStrings = new List<string>(File.ReadAllLines(arquivo));
                palavrasLowerCase = listaDeStrings.Select(s => s.ToLower()).ToArray();
            }
            else
            {
                Console.WriteLine("Arquivo nao encontrado, crie um \"Lista.txt\"");
                Console.WriteLine("fechando o programa em 5 segundos");
                Thread.Sleep(5000);
                Environment.Exit(1);
            }

            // Array de palavras encontradas 
            List<string> palavrasEncontradas = new List<string>();

            Console.WriteLine("|===========|");

            // verifica cada palavra dentro da array de palavras
            foreach (var palavra in palavrasLowerCase)
            {
                if (palavra.Contains(letras))
                {
                    palavrasEncontradas.Add(palavra);
                }
            }

            // verifica se foram encontradas ou nao as palavras
            if (palavrasEncontradas.Count == 0)
            {
                Console.WriteLine("Nao encontramos nenhuma palavra");
            }
            else
            {
                Console.WriteLine("Palavras encontradas:");
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