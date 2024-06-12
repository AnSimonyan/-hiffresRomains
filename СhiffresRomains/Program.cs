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

            //Getting an array valuesInNumbers with matches numbers of the entered data 
            for (int i = 0; i < enteredStringLenght; i++)
            {
                char leftChar = enteredString[i];
                int index = Array.IndexOf(matchArrayRom, leftChar);
                valuesInNumbers[i] = matchArrayInd[index];
            }
            //Applying the formula valuesInNumbers[i+1]-valuesInNumbers[i] if valuesInNumbers[i+1]>valuesInNumbers[i]
            int[] valuesForAdding = new int[enteredStringLenght];
            for (int i = 0; i < enteredStringLenght; i++)
            {
                if (i != enteredStringLenght - 1 && valuesInNumbers[i] < valuesInNumbers[i + 1] && valuesInNumbers[i] != 0)
                {
                    int differanceWithFolowing = valuesInNumbers[i + 1] - valuesInNumbers[i];
                    if (valuesInNumbers[i] != 5 && valuesInNumbers[i] != 50 && valuesInNumbers[i] != 500)
                    {
                        valuesForAdding[i] = differanceWithFolowing;
                        valuesInNumbers[i + 1] = 0;
                    }
                    else
                    {
                        valuesForAdding[i] = -1;
                    }
                }
                else
                {
                    valuesForAdding[i] = valuesInNumbers[i];
                }
            }
            //Сhecking the correctness of the array valuesForAdding
            bool isTheResultatsCorrect = veifierResultatsAreCorrect(valuesForAdding);
            Console.Write(isTheResultatsCorrect + "\n");
           
            //Results
            int resultsInd = 0;
            for (int i = 0; i < enteredStringLenght; i++)
            {
                Console.Write(valuesForAdding[i] + "\n");
                resultsInd = resultsInd + valuesForAdding[i];
            }
            if (isTheResultatsCorrect)
            {
                Console.Write("Result is correct and equal: ");
                Console.WriteLine(resultsInd);
            }
            else
            {
                Console.Write("Result isn't correct! \n ");
            }
        }

        static bool veifierResultatsAreCorrect(int[] arrayForVerification)
        {
            bool verificationResultat = true;
            int enteredStringLenght = arrayForVerification.Length;
            for (int i = 0; i < enteredStringLenght; i++)
            {
                int courrantValue = arrayForVerification[i];
                for (int j = i + 1; j < enteredStringLenght; j++)
                {
                    if (courrantValue == -1)
                    {
                        verificationResultat = false;
                    }
                    else if (courrantValue == 0 || arrayForVerification[j] == 0)
                    {
                        continue;
                    }
                    else if (courrantValue < arrayForVerification[j])
                    {
                        if (arrayForVerification[j] % 4 == 0 || arrayForVerification[j] % 9 == 0 || courrantValue % 4 == 0 || courrantValue % 9 == 0)
                        {
                            verificationResultat = false;
                        }
                        else if (courrantValue == 5 || courrantValue == 50 || courrantValue == 500)
                        {
                            verificationResultat = false;
                        }
                    }
                    else if (courrantValue > arrayForVerification[j])

                    {
                        if (courrantValue % 4 == 0 || courrantValue % 9 == 0 && gettingNumbersOfcharacters(courrantValue) == gettingNumbersOfcharacters(arrayForVerification[j]))
                        {
                            verificationResultat = false;
                        }

                    }
                    else if (courrantValue == arrayForVerification[j] && (courrantValue == 5 || courrantValue == 50 || courrantValue == 500))

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
        static int gettingNumbersOfcharacters(int number1)

        {
            int resultOfDivision = number1;
            int numberOfCharacters = 0;
            while (resultOfDivision > 0)
            {
                resultOfDivision = resultOfDivision / 10;
                numberOfCharacters++;
            }
            return numberOfCharacters;
        }
    }
}



