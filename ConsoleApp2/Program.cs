using System.Globalization;

namespace ConsoleApp2;

internal class Program
{
    public static void Main(string[] args)
    {
        try
        {
            int selection;
            var rnd = new Random();
            const int Min = 0;
            const int Max = 100;
            do
            {
                Console.WriteLine("Выберите программу\n[1]Есть ли число в массиве случайных чисел\n[2]Вывод минимальных значений матрицы\n[3]Калькулятор");
                selection = int.Parse(Console.ReadLine());
            } while (selection is < 0 or > 3);

            switch (selection)
            {
                case 1:
                    Console.WriteLine("Введите длину массива: ");
                    var ml = int.Parse(Console.ReadLine());

                    Console.WriteLine($"Генерация массива длинной {ml}...");
                    var numbers = Enumerable.Repeat(rnd.Next(Min, Max), ml).ToArray();
                    Console.WriteLine("Генерация завершена");
                    Console.WriteLine($"Готовый массив:\n ({string.Join(",", numbers)})");
                    
                    Console.WriteLine("Введите число: ");
                    var num = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Число {num} {(numbers.Contains(num) ? "есть" : "отсутствует")} в массиве", num);
                    break;
                case 2:
                    Console.WriteLine("Введите длину массива:");
                    var m = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите высоту массива: ");
                    var n = int.Parse(Console.ReadLine());

                    Console.WriteLine("Генерация многомерного массива [{0}][{1}]...", m, n);
                    var randomArray = new int[m, n];
                    for (int i = 0; i < m; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            randomArray[i, j] = rnd.Next(Min, Max);
                            //Console.Write(randomArray[i,j]+"\t");
                        }
                        //Console.WriteLine("\n");
                    }

                    Console.WriteLine("Выбираем минимальные значения и сортируем...");
                    var minArray = Enumerable.Range(0, m)
                        .Select(i => Enumerable.Range(0, randomArray.GetLength(1)).Select(x => randomArray[i, x]).Min())
                        .OrderByDescending(c => c).ToArray();

                    Console.WriteLine($"Готовый массив минимальных значений по убыванию: {string.Join(", ", minArray)}");
                    break;
                case 3:
                    
                    Console.WriteLine("Калькулятор\r");
                    Console.WriteLine("------------------------\n");
                    
                    Console.WriteLine("Введите первое число");
                    var num1 = float.Parse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture);

                    Console.WriteLine("Выберите операцию:");
                    Console.WriteLine("\t+ - Сложение");
                    Console.WriteLine("\t- - Вычитание");
                    Console.WriteLine("\t* - Умножение");
                    Console.WriteLine("\t/ - Деление");
                    var operation = Console.ReadLine();

                    Console.WriteLine("Введите второе число");
                    var num2 = float.Parse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture);

                    var result = operation switch
                    {
                        "+" => num1 + num2,
                        "-" => num1 - num2,
                        "*" => num1 * num2,
                        "/" when num2 != 0 => num1 / num2,
                        "/" when num2 == 0 => float.NaN,
                        _ => throw new Exception("Неизвестная операция"),
                    };
                    Console.WriteLine($"Результат: {result:0.##}");
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