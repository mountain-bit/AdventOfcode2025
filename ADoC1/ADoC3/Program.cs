namespace ADoC3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long wynik = 0;
            //read file
            using (StreamReader sr = new StreamReader("dane.txt"))
            {
                while (!sr.EndOfStream)
                {
                    String line;
                    line = sr.ReadLine();
                    int n = line.Length;
                    int[] liczby = new int[n];
                    for (int i = 0; i < n; i++)
                    {
                        liczby[i] = line[i] - 48;
                    }
                    //znajdz największą liczbę razem z indeksem
                    //int max = liczby[0];
                    //int index = 0;
                    //for (int i = 1; i < n - 1; i++)
                    //{
                    //    if (liczby[i] > max)
                    //    {
                    //        max = liczby[i];
                    //        index = i;
                    //    }
                    //}
                    //Console.WriteLine($"Największa liczba: {max}, indeks: {index}");
                    ////druga najwieksza po pierwszej
                    //int max2 = liczby[index + 1];
                    //for (int i = index + 1; i < n; i++)
                    //{
                    //    if (liczby[i] > max2)
                    //    {
                    //        max2 = liczby[i];
                    //    }
                    //}
                    //Console.WriteLine($"Druga największa liczba: {max2}");

                    //wynik += max * 10 + max2;


                    int[] najwieksze = new int[12];
                    int[] indexs = new int[12];
                    int max = liczby[0];
                    int index = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        Console.WriteLine($"Szukam {i + 1} największej liczby {index}");

                        for (int j = index+1; j < n - 11 + i; j++)
                        {
                            if (liczby[j] > max && !indexs.Contains(j))
                            {
                                Console.WriteLine($"Sprawdzana liczba: {liczby[j]} na indeksie {j}");
                                max = liczby[j];
                                index = j;
                            }
                        }

                        najwieksze[i] = max;
                        indexs[i] = index;
                        max = -1;
                    }
                    for (int i = 0; i < 12; i++)
                    {
                        Console.WriteLine($"Największa liczba {i + 1}: {najwieksze[i]}, indeks: {indexs[i]}");
                    }
                    long w = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        w = w * 10 + najwieksze[i];
                        Console.WriteLine($"Wartość w trakcie tworzenia liczby: {w}");
                    }
                    wynik += w;
                }
               
            }
            Console.WriteLine(wynik);
        }
    }
}
