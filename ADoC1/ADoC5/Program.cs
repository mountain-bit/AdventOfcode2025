namespace ADoC5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<long[]> zakresy = new List<long[]>();
            List<long> id = new List<long>();
            using (StreamReader sr = new StreamReader("dane.txt"))
            {
                
                while (!sr.EndOfStream)
                {
                    String line = sr.ReadLine();
                    if (line == null || line.Equals("")) break;

                    //int64
                    long[] zakres  = line.Split('-').Select(x => Int64.Parse(x)).ToArray();
                    zakresy.Add(zakres);
                }
               
                while(!sr.EndOfStream)
                {
                    String line = sr.ReadLine();
                    if (line == null || line.Equals("")) break;
                    id.Add(Int64.Parse(line));
                }
            }
            int wynik = 0;

            //wyświetlanie
            foreach (var z in zakresy)
            {
                Console.WriteLine($"{z[0]} - {z[1]}");
            }
            Console.WriteLine("-----");
            foreach (var i in id)
            {
                Console.WriteLine(i);
                foreach (var z in zakresy)
                {
                   if(i >= z[0] && i <= z[1])
                    {
                        wynik++;
                        break;
                    }
                }
            }

            Console.WriteLine($"Wynik: {wynik}");


        }
    }
}
