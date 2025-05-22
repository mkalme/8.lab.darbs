//221RDB411 Miķelis Kalme-Danenbaums
using System.Text;
using TextCopy;

namespace _8.lab.darbs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] array = CreateArrayFromClipboard(30);
            array = RotateArary(array);

            StringBuilder builder = new StringBuilder();

            for (int y = 0; y < array.GetLength(0); y++)
            {
                for (int x = 0; x < array.GetLength(0); x++)
                {
                    builder.Append(array[y, x] + "\t");
                }
                builder.Append("\n");
            }

            new Clipboard().SetText(builder.ToString());

            Console.WriteLine(builder.ToString());
            Console.ReadLine();
        }

        private static string[,] CreateArrayFromClipboard(int n)
        {
            string? s = new Clipboard().GetText();

            string[] lines = s.Split("\n");

            string[,] output = new string[n, n];
            for (int y = 0; y < n; y++)
            {
                string[] cells = lines[y].Split("\t");
                for (int x = 0; x < n; x++)
                {
                    output[y, x] = cells[x];
                }
            }
            

            return output;
        }
        private static string[,] RotateArary(string[,] array)
        {
            string[,] output = new string[array.GetLength(0), array.GetLength(0)];

            for (int y = 0; y < array.GetLength(0); y++) {
                for (int x = 0; x < array.GetLength(0); x++) {
                    output[y, x] = array[array.GetLength(0) - x - 1, y];
                }
            }

            return output;
        }

        private static ISet<int> FetchNumbers() { 
            ISet<int> output = new HashSet<int>();

            while (true) {
                int n = int.Parse(Console.ReadLine());
                output.Add(n);

                if (n == 0) break;
            }

            return output;
        }
    }
}