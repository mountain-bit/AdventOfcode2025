namespace ADoC4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[][] cells;
            int wynik = 0;
            List<int[]> dousuniecia = new List<int[]>();
            using (StreamReader sr = new StreamReader("dane.txt"))
            {
                List<bool[]> rows = new List<bool[]>();
                while (!sr.EndOfStream)
                {
                    String line = sr.ReadLine();
                    bool[] row = line.Select(c => c == '@').ToArray();
                    rows.Add(row);
                }
                cells = rows.ToArray();
            }

            for (int i = 0; i < cells.Length; i++)
            {
                for (int j = 0; j < cells[i].Length; j++)
                {
                    Console.Write(cells[i][j] ? '@' : '.');
                }
                Console.WriteLine();
            }

            Console.WriteLine("------------------------");
            bool czywyniksiezmienia = false;
            do {
                czywyniksiezmienia = false;
                Console.WriteLine("Nowa iteracja");
                for (int i = 0; i < cells.Length; i++)
                 {

                for (int j = 0; j < cells[i].Length; j++)
                {
                    //czy jest otoczone
                    int count = 0;
                    if (cells[i][j] == false)
                    {
                        //Console.Write('.');
                        continue;
                    }
                    for (int k = i - 1; k <= i + 1; k++)
                    {

                        for (int l = j - 1; l <= j + 1; l++)
                        {
                            if (k < 0 || k >= cells.Length) continue;
                            if (l < 0 || l >= cells[i].Length) continue;
                            if (cells[k][l])
                            {
                                count++;
                                //star 2

                            }
                        }

                    }
                    //Console.WriteLine($"{count} {i},{j}");

                    //Console.Write(cells[i][j] ? count<4?"X":"@" : '.');
                    if (count <= 4)
                    {
                        wynik++;
                            dousuniecia.Add(new int[] { i, j });
                            czywyniksiezmienia = true;
                    }
                    count = 0;
                }
               // Console.WriteLine();
            }
                //usun zaznaczone
                foreach (var item in dousuniecia)
                {
                   // Console.WriteLine($"Usuwam {item[0]},{item[1]}");
                    cells[item[0]][item[1]] = false;
                }
                dousuniecia.Clear();
                //wyswietl
                //for (int i = 0; i < cells.Length; i++)
                //{
                //    for (int j = 0; j < cells[i].Length; j++)
                //    {
                //        Console.Write(cells[i][j] ? '@' : '.');
                //    }
                //    Console.WriteLine();
                //}
            } while (czywyniksiezmienia);

            Console.WriteLine($"Wynik: {wynik}");



        }
    }
}
