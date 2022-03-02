//float.Parse("3.14", NumberStyles.Any, CultureInfo.InvariantCulture, out float result);
namespace ConsoleApp2;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            int selection;
            do
            {
                Console.WriteLine("Выберите программу\n[1].Вывод массива случайных чисел\n[2]Вывод минимальных значений матрицы\n[3]Калькулятор");
                selection = int.Parse(Console.ReadLine());
            } while (selection < 0 || selection > 3);

            switch (selection)
            {
                case 1:
                    int ml;
                    int Min = 0;
                    int Max = 100;

                    Console.WriteLine("Введите длину массива: ");
                    ml = int.Parse(Console.ReadLine());

                    Console.WriteLine("Генерация массива длинной {0}...", ml);
                    int[] numbers;
                    Random rnd = new Random();
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
                    break;
                case 3:
                    int num1; int num2;
                    
                    Console.WriteLine("Console Calculator in C#\r");
                    Console.WriteLine("------------------------\n");
                    
                    Console.WriteLine("Type a number, and then press Enter");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine("Type another number, and then press Enter");
                    num2 = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine("Choose an option from the following list:");
                    Console.WriteLine("\ta - Add");
                    Console.WriteLine("\ts - Subtract");
                    Console.WriteLine("\tm - Multiply");
                    Console.WriteLine("\td - Divide");
                    Console.Write("Your option? ");
                    
                    switch (Console.ReadLine())
                    {
                        case "a":
                            Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
                            break;
                        case "s":
                            Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
                            break;
                        case "m":
                            Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
                            break;
                        case "d":
                            while (num2 == 0)
                            {
                                Console.WriteLine("Enter a non-zero divisor: ");
                                num2 = Convert.ToInt32(Console.ReadLine());
                            }
                            Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
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
    }
}