namespace ADoC7
{
    internal class Program
    {
        public static int rowCount = 0;
        public static int columnCount = 0;
        public static int startcolumn = 0;
        public static char[,] mapa;
        public static int duplicateCount = 0;

        static void foton(int startR,int startC)
        {
            //fing first split point
            int firts_splitR = -1;

            firts_splitR= fotonGoDown(startR, startC);
            if (firts_splitR == -1)
                return;

            List<(int, int)> splitPoints = new List<(int, int)>();
            splitPoints.Add((firts_splitR, startC));

            while (splitPoints.Count > 0)
            {
                ////show current mapa
                //for (int r1 = 0; r1 < rowCount; r1++)
                //{
                //    for (int c2 = 0; c2 < columnCount; c2++)
                //    {
                //        Console.Write(mapa[r1, c2]);
                //    }
                //    Console.WriteLine();
                //}
                //Console.WriteLine($"Duplikacje:{duplicateCount}");
                //Console.WriteLine("--------------------------");


                var point = splitPoints[0];
                splitPoints.RemoveAt(0);
                int r = point.Item1;
                int c = point.Item2;
                bool leftClear = false;
                if (c - 1 >= 0)
                    leftClear = !(mapa[r, c-1] == '|');
                bool rightClear = false;
                if (c + 1 < columnCount)
                    rightClear = !(mapa[r, c+1] == '|');
                //if(leftClear || rightClear)
                //    duplicateCount++;
                int newPointRow = -1;
                if (rightClear)
                    newPointRow = fotonGoDown(r, c+1);
                if(newPointRow != -1)
                    splitPoints.Add((newPointRow, c + 1));
                newPointRow = -1;

                if (leftClear)
                    newPointRow = fotonGoDown(r, c-1);

                if (newPointRow != -1)
                    splitPoints.Add((newPointRow, c - 1));

              splitPoints.Sort((a, b) => a.Item1.CompareTo(b.Item1));

            }
        }

        private static int fotonGoDown(int r, int c)
        {
            for (int r1 = r; r1 < rowCount; r1++)
            {
                if (mapa[r1, c] == '^')
                {
                    duplicateCount++;
                    return r1;
                }
                mapa[r1, c] = '|';
            }
            return -1;
        }

        static void Main(string[] args)
        {


            using(StreamReader sr = new StreamReader("dane.txt"))
            {
                while (!sr.EndOfStream)
                {
                    String line = sr.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    rowCount++;
                    columnCount = line.Length;
                    if (line[columnCount/2] == 'S')
                    {
                        startcolumn = columnCount / 2;
                    }
                }
            }

            Console.WriteLine("Number of rows: " + rowCount);
            Console.WriteLine("Number of columns: " + columnCount);
            Console.WriteLine("Start column: " + startcolumn);


            mapa = new char[rowCount, columnCount];

            using(StreamReader sr = new StreamReader("dane.txt"))
            {
                int r = 0;
                while (!sr.EndOfStream)
                {
                    String line = sr.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    for (int c = 0; c < columnCount; c++)
                    {
                        mapa[r, c] = line[c];
                    }
                    r++;
                }
            }

            //print mapa
            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < columnCount; c++)
                {
                    Console.Write(mapa[r, c]);
                }
                Console.WriteLine();
            }


            foton( 0, startcolumn );

            Console.WriteLine("Duplicate count: " + duplicateCount);

            //print mapa
            for (int r = 0; r < rowCount; r++)
            {
                for (int c = 0; c < columnCount; c++)
                {
                    Console.Write(mapa[r, c]);
                }
                Console.WriteLine();
            }


            Console.WriteLine(duplicateCount);

        }
    }
}
