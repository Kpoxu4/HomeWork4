using HomeWork4;
using System.Reflection.Metadata.Ecma335;

int row = 0;
int col = 0;
string numOperation;

Console.WriteLine("Программа работы с матрицами");
Console.WriteLine("Нужно ввести размер матрицы через пробел\n" +
    "пример: 3 3 ");

#region Проверка входных данных
while (true)
{
    try
    {
        int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if (array.Length == 2 && array[0] > 0 && array[1] > 0)
        {
            row = array[0];
            col = array[1];
            break;
        }
        else
        {
            Console.WriteLine("Ввели не верные значения");
        }
    }
    catch
    {
        Console.WriteLine("Ввели не верные значения");
    }
}
#endregion

int[,] matrix = MyArray.СreateArray(row, col);
Continue:
Console.WriteLine(MyArray.ShowArray(matrix)); 
MyArray.InfoOperation();

#region проверка номера операции
while (true)
{
    numOperation = Console.ReadLine();
    if (MyArray.CheckOperation(numOperation))
    {
        break;
    }
    else
        Console.WriteLine("Неверно. Повторите попытку");
}
#endregion

if (numOperation == "6")
    Environment.Exit(0);

Console.Clear();
Console.WriteLine(MyArray.ShowArray(matrix));
Console.WriteLine(MyArray.OperationHandler(numOperation,matrix));
Console.WriteLine("Для продолжения работы над матрицей нажмите любую кнопку\n" +
                 "Выйти нажмите ESC");
if (Console.ReadKey().Key == ConsoleKey.Escape)
    Environment.Exit(0);
else 
{
    Console.Clear();
    goto Continue;
}
