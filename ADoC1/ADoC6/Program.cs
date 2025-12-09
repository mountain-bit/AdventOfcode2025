namespace ADoC6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<long>> list = new List<List<long>>();
            List<char> znak = new List<char>();

            using (StreamReader sr = new StreamReader("dane.txt"))
            {
                while (!sr.EndOfStream)
                {
                    String line = sr.ReadLine();
                    Console.WriteLine(line);
                    Console.WriteLine("-----");
                    if (line == null)
                    {
                        break;
                    }

                    int liczba = 0;
                    
                    List<long> row = new List<long>();
                    for (int i = 0; i < line.Length; i ++)
                    {
                        if (line[i] == ' ' || line[i] == '\r' || line[i]=='\n')
                        {
                            if(liczba != 0)
                            {
                                row.Add(liczba);
                                liczba = 0;
                            }
                            continue;
                        }else if(line[i] == '+')
                        {
                            znak.Add('+');
                            continue;
                        }
                        else if (line[i] == '*')
                        {
                            znak.Add('*');
                            continue;
                        }

                        liczba = liczba * 10 + Int32.Parse(line[i].ToString());

                       
                    }
                    list.Add(row);
                }
            }

            long wynik = 0;

             int n = list.Count;
            int m = list[0].Count;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(list[i].Count);
            }
            Console.WriteLine("-----");  
            Console.WriteLine(znak.Count);

            long[] wyniki = new long[m];
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0)
                    {
                        wyniki[j] = list[i][j];
                    }
                    else
                    if (znak[j] == '+')
                    {
                        wyniki[j] += list[i][j];
                    }
                    else if (znak[j] == '*')
                    {
                        wyniki[j] *= list[i][j];
                    }
                }
            }

            for (int j = 0; j < m; j++)
            {  wynik += wyniki[j];}

                Console.WriteLine($"Wynik: {wynik}");
        }
    }
}
