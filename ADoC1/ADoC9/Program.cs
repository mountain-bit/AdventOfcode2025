namespace ADoC9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int[]> indeksy = new List<int[]>();
            long najwiekszyX = 0;
            long najwiekszyY = 0;

            using (StreamReader sr = new StreamReader("wyniki.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    int[] para = new int[2];
                    para[0] = int.Parse(parts[0]);
                    para[1] = int.Parse(parts[1]);
                    if (para[0] > najwiekszyX) najwiekszyX = para[0];
                    if (para[1] > najwiekszyY) najwiekszyY = para[1];

                    indeksy.Add(para);
                }
            }

            //bool[,] tablica = new bool[najwiekszyX + 1, najwiekszyY + 1];

            //foreach (var para in indeksy)
            //{
            //    tablica[para[0], para[1]] = true;
            //}
            Console.WriteLine("Wczytano dane.");
            long maxpole = 0;

            foreach (var para in indeksy)
            {
                Console.WriteLine($"Sprawdzam punkt {para[0]},{para[1]}");
                foreach (var drugaPara in indeksy)
                {
                    long szerokosc = Math.Abs(para[0] - drugaPara[0]) +1;
                    long wysokosc = Math.Abs(para[1] - drugaPara[1]) +1 ;
                    long pole = szerokosc * wysokosc;

                    if (pole > maxpole) maxpole = pole;
                }
            }
            Console.WriteLine(maxpole);




        }
    }
}
