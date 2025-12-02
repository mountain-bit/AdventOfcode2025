namespace ADoC2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //czytanie z pliku
            
            using(StreamReader sr = new StreamReader("dane.txt"))
            {
                String line;
                line = sr.ReadToEnd();

                string[] zakresy = line.Split(',');
                long wynik = 0;
                foreach (string zakres in zakresy)
                {
                    string[] liczby = zakres.Split('-');
                    long  start = long.Parse(liczby[0]);
                    long  end = long.Parse(liczby[1]);
                    //sprawdzenie czy jeden zakres zawiera drugi
                    //brute force
                    for (; start <= end; start++)
                    {
                        int dlugosc_liczby = start.ToString().Length;
                        if(dlugosc_liczby % 2 == 1)
                        {
                            continue;
                        }
                        else if (dlugosc_liczby == 0 || dlugosc_liczby == 1)
                        {
                            continue;
                        }
                        long liczba_1 = Int64.Parse(start.ToString().Substring(0, dlugosc_liczby / 2));
                        long liczba_2 = Int64.Parse(start.ToString().Substring(dlugosc_liczby / 2, dlugosc_liczby - dlugosc_liczby / 2));
                      
                        if (liczba_1 == liczba_2)
                        {
                            Console.WriteLine($"Sprawdzana liczba: {liczba_1}, {liczba_2}");
                            Console.WriteLine($"konie: {end}");
                            Console.WriteLine($"Znaleziono: {start}");
                            wynik+=start;
                        }
                    }
                    
                }
                Console.WriteLine(wynik);
            }

        }
    }
}
