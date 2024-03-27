namespace HomeWork4
{
    public class MyArray
    {
        public static void InfoOperation()
        {
            Console.WriteLine("Операции над матрицей:\n" +
                  "1.Найти количество положительных элементов.\n" +
                  "2.Найти количество отрицательных элементов.\n" +
                  "3.Сортировка элементов с лева на права.\n" +
                  "4.Сортировка элементов с права на лева.\n" +
                  "5.Инверсия элементов матрицы построчно.\n" +
                  "6.Выход из программы.\n" +
                  "Введите номер операции:");
        }
        public static int[,] СreateArray(int row, int column)
        {
            int[,] array = new int[row, column];

            Random rnd = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = rnd.Next(-50, 50);

            return array;
        }
        public static string  ShowArray(int[,] array)
        {
            string result = "";

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    result = result + array[i, j] + "\t";
                }
                result += "\n";
                result += "\n";
            }
            return result;
        }
        public static bool CheckOperation(string operation)
        {
            var checkOperation = true;
            if (operation != null)
            {
                if (int.TryParse(operation, out int result) && result > 0 && result <= 6)
                    checkOperation = true;
                else
                    checkOperation = false;
            }
            else { checkOperation = false; }

            return checkOperation;
        }
        public static string OperationHandler(string operation, int[,] matrix)
        {
            string result = null;
            switch (operation) 
            {
                case "1":
                    result =NumberOfPositiveElements(matrix);
                    break;
                case "2":
                    result = NumberOfNegativeElements(matrix);
                    break;
                case "3":
                    result = ShowArray(SortingElements(matrix));
                    break;
                case "4":
                    result = ShowArray(InversionSortingElements(matrix));
                    break;
                case "5":
                    result = ShowArray(InversionOfElements(matrix));
                    break;
            }
            return result;
        }


        private static string NumberOfPositiveElements(int[,] matrix)
        {
            string result = "Количество положительных элементов:";
            int count = 0;  
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        count++;
                    else
                        continue;
                }    
            }
            return $"{result} {count}";
        }
        private static string NumberOfNegativeElements(int[,] matrix) 
        {
            string result = "Количество отрицательных элементов:";
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                        count++;
                    else
                        continue;
                }
            }
            return $"{result} {count}";
        }
        private static int[,] SortingElements(int[,] matrix)
        {
            int temp;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    for (int k = j + 1; k < matrix.GetLength(1); k++)
                    {
                        if (matrix[i,j] > matrix[i,k])
                        {
                            temp = matrix[i,j];
                            matrix[i,j] = matrix[i,k];
                            matrix[i,k] = temp;
                        }
                    }
                }
            }
            return matrix;
        }
        private static int[,] InversionSortingElements(int[,] matrix)
        {
            matrix = SortingElements(matrix);
            return InversionOfElements(matrix);
        }
        private static int[,] InversionOfElements(int[,] matrix)
        {
            int n = matrix.GetLength(1); 
            int k = n / 2;          
            int temp;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < k; j++)
                {
                    temp = matrix[i, j];
                    matrix[i, j] = matrix[i, n - j - 1];
                    matrix[i,n - j - 1] = temp;
                }
            }
            return matrix;
        }
    }
}


