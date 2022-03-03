using System.Globalization;

namespace ConsoleApp2;

internal class Program
{
    public static void Main(string[] args)
    {
        try
        {
            int selection;
            Random rnd = new Random();
            int Min = 0;
            int Max = 100;
            do
            {
                Console.WriteLine("Выберите программу\n[1]Вывод массива случайных чисел\n[2]Вывод минимальных значений матрицы\n[3]Калькулятор");
                selection = int.Parse(Console.ReadLine());
            } while (selection < 0 || selection > 3);

            switch (selection)
            {
                case 1:
                    int ml;

                    Console.WriteLine("Введите длину массива: ");
                    ml = int.Parse(Console.ReadLine());

                    Console.WriteLine("Генерация массива длинной {0}...", ml);
                    int[] numbers;
                    numbers = Enumerable.Repeat(0, ml).Select(i => rnd.Next(Min, Max)).ToArray();
                    var stringArray = string.Join(",", numbers);
                    Console.WriteLine("Генерация завершена");
                    Console.WriteLine("Готовый массив:\n ({0})", stringArray);
                    
                    Console.WriteLine("Введите число: ");
                    int num = int.Parse(Console.ReadLine());
                    if (numbers.Contains(num))
                    {
                        Console.WriteLine("Число {0} есть в массиве", num);
                    }
                    else
                    {
                        Console.WriteLine("Число {0} отсутствует в массиве", num);
                    }
                    break;
                case 2:
                    int m, n;

                    Console.WriteLine("Введите длину массива:");
                    m = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите высоту массива: ");
                    n = int.Parse(Console.ReadLine());

                    Console.WriteLine("Генерация многомерного массива [{0}][{1}]...", m, n);
                    int[,] randomArray = new int[m, n];
                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            randomArray[i, j] = rnd.Next(Min, Max);
                            Console.Write(randomArray[i,j]+"\t");
                        }
                        Console.WriteLine("\n");
                    }

                    Console.WriteLine("Выбираем минимальные значения и сортируем...");
                    List<int> minArray = new List<int>();
                    for (int i = 0; i < m; i++)
                    {
                        int[] row = Enumerable.Range(0, randomArray.GetLength(1)).Select(x => randomArray[i, x]).ToArray();
                        minArray.Add(row.Min());
                    }
                    
                    var minArrayString = string.Join(", ", minArray.OrderByDescending(c => c).ToArray());

                    Console.WriteLine("Готовый массив минимальных значений по убыванию: {0}", minArrayString);
                    break;
                case 3:
                    float num1, num2, result;
                    
                    Console.WriteLine("Калькулятор\r");
                    Console.WriteLine("------------------------\n");
                    
                    Console.WriteLine("Введите первое число");
                    num1 = float.Parse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture);

                    Console.WriteLine("Введите второе число");
                    num2 = float.Parse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture);

                    Console.WriteLine("Выберите операцию:");
                    Console.WriteLine("\ta - Сложение");
                    Console.WriteLine("\ts - Вычитание");
                    Console.WriteLine("\tm - Умножение");
                    Console.WriteLine("\td - Деление");
                    
                    switch (Console.ReadLine())
                    {
                        case "a":
                            result = num1 + num2;
                            Console.WriteLine($"Результат: {result:0.##}");
                            break;
                        case "s":
                            result = num1 - num2;
                            Console.WriteLine($"Результат: {result:0.##}");
                            break;
                        case "m":
                            result = num1 * num2;
                            Console.WriteLine($"Результат: {result:0.##}");
                            break;
                        case "d":
                            while (num2 == 0)
                            {
                                Console.WriteLine("Деление на ноль невозможно. Введите другое число: ");
                                num2 = Convert.ToInt32(Console.ReadLine());
                            }

                            result = num1 / num2;
                            Console.WriteLine($"Результат: {result:0.##}");
                            break;
                    }
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка в аргументах");
            switch (e)
            {
                case FormatException _:
                    Console.WriteLine("Format Exception - разрешен только ввод чисел");
                    break;
                case OverflowException _:
                    Console.WriteLine("Overflow Exception - число слишком большое");
                    break;
                case IndexOutOfRangeException _:
                    Console.WriteLine("OutofRange exception - выбранное число вне доступа");
                    break;
                default:
                    Console.WriteLine("Unknown error - " + e.Message);
                    break;
            }
        }
        finally
        {
            Console.Write("Press any key to exit");
            Console.ReadKey();
        }
    }
}