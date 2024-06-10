using Microsoft.VisualBasic;

namespace СhiffresRomains
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] matchArrayRom = new char[7] { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int[] matchArrayInd = new int[7] { 1, 5, 10, 50, 100, 500, 1000 };
            Console.Write("Enter the Roman numeral using I , V, X, L, C, D, M :");
            string enteredString = Console.ReadLine();
            int enteredStringLenght = enteredString.Length;
            int[] matchArrayIndEnterd = new int[enteredStringLenght];
            int[] valuesInNumbers = new int[enteredStringLenght];

            for (int i = 0; i < enteredStringLenght; i++)
            {
                char leftChar = enteredString[i];

                int index = Array.IndexOf(matchArrayRom, leftChar);
                valuesInNumbers[i] = matchArrayInd[index];
            }
            int[] valuesForAdding = new int[enteredStringLenght];

            for (int i = 0; i < enteredStringLenght; i++)
            {
                if (i != enteredStringLenght - 1 && valuesInNumbers[i] < valuesInNumbers[i + 1] && valuesInNumbers[i] != 0)
                {
                    int differanceWithFolowing = valuesInNumbers[i + 1] - valuesInNumbers[i];
                    if (differanceWithFolowing % 4 ==0 || differanceWithFolowing % 9==0)
                    {
                        valuesForAdding[i] = differanceWithFolowing;
                        valuesInNumbers[i + 1] = 0;
                    }
                    else
                    {
                        valuesForAdding[i] = valuesInNumbers[i];
                    }
                    
                }
                else
                {
                    valuesForAdding[i] = valuesInNumbers[i];
                }
            }

            bool isTheResultatsCorrect = veifierResultatsAreCorrect(valuesForAdding);
            Console.Write(isTheResultatsCorrect);

            int resultatInd = 0;

            for (int i = 0; i < enteredStringLenght; i++)
            {
                Console.Write(valuesForAdding[i] + "\n");
                resultatInd = resultatInd + valuesForAdding[i];
            }
            if (isTheResultatsCorrect)
            {
                Console.Write("Result is correct and equal: ");
                Console.WriteLine(resultatInd);
            }
               
            else
            {
                Console.Write("Result isn't correct!");
            }


        }

        static bool veifierResultatsAreCorrect(int[] arrayForVerification)
        {
            bool verificationResultat = true;
            int enteredStringLenght = arrayForVerification.Length;
            for (int i = 0; i < enteredStringLenght; i++)
            {
                int courrantValue = arrayForVerification[i];

                for (int j= i+1; j < enteredStringLenght ; j++)
                {
                    
                    if (courrantValue < arrayForVerification[j] && arrayForVerification[j] % 5 != 0 && courrantValue != 0)
                    {
                        verificationResultat = false;
                    }
                }

                
            }

            for (int i = 0; i < enteredStringLenght; i++)
            {
                int numberOfRepetitions = 1;

                if (i < enteredStringLenght - 3)
                {
                    for (int j = i; j < i + 3; j++)
                    {
                        if (arrayForVerification[j] == arrayForVerification[j + 1])
                            numberOfRepetitions++;

                    }
                    if (numberOfRepetitions > 3)
                    {
                        verificationResultat = false;
                    }
                    

                }
            }
            return verificationResultat;
        }
    }
}



