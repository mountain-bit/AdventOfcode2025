namespace ADoC8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iloscObiektow = 1000;
            int[][] obiekty = new int[iloscObiektow][];
            for (int i = 0; i < iloscObiektow; i++)
            {
                obiekty[i] = new int[3];
            }
            bool[] czypolaczony = new bool[iloscObiektow];

            int iloscPolaczen = iloscObiektow * (iloscObiektow - 1) / 2;

            int[][] polaczenia = new int[iloscPolaczen][];
            for (int i = 0; i < iloscPolaczen; i++)
            {
                polaczenia[i] = new int[3];
            }

            using (StreamReader sr = new StreamReader("dane.txt"))
            {
                for (int i = 0; i < iloscObiektow; i++)
                {
                    string line = sr.ReadLine();
                    string[] parts = line.Split(',');
                    obiekty[i][0] = int.Parse(parts[0]);
                    obiekty[i][1] = int.Parse(parts[1]);
                    obiekty[i][2] = int.Parse(parts[2]);
                }
            }

            //wszystkie możliwe polaczenia
            int index = 0;
            for (int i = 0; i < iloscObiektow; i++)
            {
                for (int j = i + 1; j < iloscObiektow; j++)
                {
                    polaczenia[index][0] = i;
                    polaczenia[index][1] = j;
                    double dx = obiekty[i][0] - obiekty[j][0];
                    double dy = obiekty[i][1] - obiekty[j][1];
                    double dz = obiekty[i][2] - obiekty[j][2];
                    double distance = Math.Sqrt(dx * dx + dy * dy + dz * dz);
                    polaczenia[index][2] = (int)distance;
                    index++;
                }
            }

            List<List<int>> polaczone = new List<List<int>>();

            //szukanie najlepszych polaczen

            Array.Sort(polaczenia, static (a, b) => a[2].CompareTo(b[2]));

            //wyswietl polaczenia
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Polaczenie: {polaczenia[i][0]} - {polaczenia[i][1]} : {polaczenia[i][2]}");
            }


            int countPolaczen = 0;
            foreach (var polaczenie in polaczenia)
            {
                if (countPolaczen >= 1000)
                {
                    break;
                }
                if (czypolaczony[polaczenie[0]] && czypolaczony[polaczenie[1]])
                {
                    continue;
                }
                else if (czypolaczony[polaczenie[1]])
                {
                    foreach (var item in polaczone)
                    {
                        if (item.Find(x => polaczenie[1] == x) != -1)
                        {
                            item.Add(polaczenie[0]);
                            czypolaczony[polaczenie[0]] = true;
                            break;
                        }
                    }
                }
                else
                {
                    List<int> list = new List<int>();
                    list.Add(polaczenie[0]);
                    list.Add(polaczenie[1]);
                    czypolaczony[polaczenie[1]] = true;
                    czypolaczony[polaczenie[0]] = true;
                    polaczone.Add(list);
                }

                countPolaczen++;

            }
            int wynik = 1;
            long wynik2 = 1;
            //wynik
            Console.WriteLine("Wynik:");
            foreach (var item in polaczone)
            {
                Console.WriteLine("Grupa:" + item.Count);
                if (item.Count > 0)
                {
                    wynik = wynik + item.Count;
                    wynik2 = wynik2 *(long) item.Count;
                }
                Console.WriteLine(wynik); Console.WriteLine(wynik2);

                //foreach (var obj in item)
                //{
                //    Console.WriteLine($"Obiekt {obj} - ({obiekty[obj][0]}, {obiekty[obj][1]}, {obiekty[obj][2]})");
                //}
            }

            Console.WriteLine(wynik);
        }
    }
}
