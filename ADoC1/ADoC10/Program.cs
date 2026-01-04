namespace ADoC10
{
    internal class Program
    {
        public static Dictionary<string, string[]> slownik = new Dictionary<string, string[]>();
        static int wynik = 0;
        public static List<Thread> threads = new List<Thread>();

        static void szukanie(string poczatek)
        {
            string[] strings = slownik[poczatek];
            foreach (var s in strings)
            {
                Console.WriteLine(s);

                if (s.Equals("out"))
                {
                    wynik++;

                }
                else
                {
                    szukanie(s);
                }
            }
        }


        static void Main(string[] args)
        {
            // słownik
            using (StreamReader sr = new StreamReader("slownik.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    string[] znaki = parts[1].Split(' ');
                    slownik[parts[0]] = znaki;
                }
            }

            szukanie("you");

            Console.WriteLine(wynik);
        }
    }
}
