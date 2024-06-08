using Microsoft.VisualBasic;

namespace СhiffresRomains
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string [] matchArrayRom = new string [7] { "I", "V", "X", "L", "C", "D", "M" };
            int[] matchArrayInd = new int[7] { 1, 5, 10, 50, 100, 500, 1000 };
            Console.Write("Enter the Roman numeral using I , V, X, L, C, D, M :");
            string enteredString = Console.ReadLine();
            int enteredStringLenght = enteredString.Length ;
            int[] matchArrayIndEnterd = new int[enteredStringLenght];
            int[] valuesInNumbers = new int[enteredStringLenght];
            
            for (int i = 0; i < enteredStringLenght; i++)
            {
                string leftChar = enteredString.Substring(i, 1);
                int index = Array.IndexOf(matchArrayRom, leftChar);
                valuesInNumbers[i] = matchArrayInd[index];
            }
            int[] valuesForAdding = new int[enteredStringLenght];

            for (int i = 0; i < enteredStringLenght; i++)
            {
                if (i != enteredStringLenght - 1 && valuesInNumbers[i] < valuesInNumbers[i + 1] && valuesInNumbers[i] != 0 )
                {
                    valuesForAdding[i] = valuesInNumbers[i + 1] - valuesInNumbers[i];
                    valuesInNumbers[i + 1] = 0;
                }
                else
                {
                    valuesForAdding[i] = valuesInNumbers[i];
                }
            }

            int resultatInd = 0;
                for (int i = 0; i < enteredStringLenght; i++) 
                {
                    Console.Write(valuesForAdding[i] + "\n");
                    resultatInd = resultatInd + valuesForAdding[i];
                }
            Console.WriteLine(resultatInd);


        }
    }
}
