namespace ADoC1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pozycja = 50;
            int max = 100;
            int wynik = 0;
            string line;
            char kierunek;
            int odleglosc;
            using (StreamReader sr = new StreamReader("dane.txt"))
            {
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    kierunek = line[0];
                    odleglosc = int.Parse(line.Substring(1));

                    Console.WriteLine($"Pozycja: {pozycja}");

                    Console.WriteLine($"kierunek:{kierunek} odległosc:{odleglosc}");
                    //if (kierunek == 'L')
                    //{

                    //    pozycja -= odleglosc;
                    //    while (pozycja < 0)
                    //    {
                    //        pozycja = pozycja + max;
                    //        //if (pozycja != 0)
                    //        //{
                    //        //    wynik++;
                    //        //}

                    //    }
                    //}
                    //else if (kierunek == 'R')
                    //{
                    //    pozycja += odleglosc;
                    //    while (pozycja >= max)
                    //    {
                    //        pozycja = pozycja - max;
                    //        //if (pozycja != 0)
                    //        //{
                    //        //    wynik++;
                    //        //}
                    //    }
                    //}
                    //if (pozycja == 0 )
                    //{
                    //    wynik++;
                    //}

                    //XD
                    for (int i = 0; i < odleglosc; i++)
                    {
                        pozycja += (kierunek == 'L') ? -1 : 1;
                        if (pozycja == 0 || pozycja==100)
                        {
                            wynik++;
                        }
                        if (pozycja < 0)
                        {
                            pozycja = max - 1;
                        }
                        else if (pozycja == max)
                        {
                            pozycja = 0;
                        }

                    }
                }


            }
            Console.WriteLine($"Pozycja: {pozycja}");

      
           
            

            Console.WriteLine(wynik);

        }
    }
}
