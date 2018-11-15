namespace DrawingProgramCS.Utils
{
    public static class Util
    {
        public static bool IsPositive(int number)
        {
            return number > 0;
        }

        public static bool IsNegative(int number)
        {
            return number < 0;
        }

        public static bool IsZeroOrNegative(int number)
        {
            return number == 0 || IsNegative(number);
        }

        public static bool IsInteger(string number)
        {
            return int.TryParse(number, out int value);
        }

        public static char[,] ConvertStringArrayToChar2DArray(string[] stringArray)
        {
            char[,] draft = new char[stringArray.Length, stringArray[0].Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                for (int j = 0; j < stringArray[i].Length; j++)
                {
                    draft[i, j] = stringArray[i][j];
                }
            }

            return draft;
        }

        public static string[] ConvertChar2DArrayToStringArray(char[,] char2DArray)
        {
            string[] stringArray = new string[char2DArray.GetLength(0)];

            for (int i = 0; i < char2DArray.GetLength(0); i++)
            {
                char[] chars = new char[char2DArray.GetLength(1)];
                
                for (int j = 0; j < char2DArray.GetLength(1); j++)
                {
                    chars[j] = char2DArray[i, j];
                }

                stringArray[i] = new string(chars);
            }

            return stringArray;
        }
    }
}
