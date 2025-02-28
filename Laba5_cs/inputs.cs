using System.ComponentModel.Design;

class UserInput
{

    // Для ввода целых чисел
    public static int intInput(bool isPositive = false, string text = "Введите целое число: ")
    {
        string user_input = "";
        bool b = false;

        while (b != true)
        {
            Console.Write(text);
            user_input = Console.ReadLine();
            b = int.TryParse(user_input, out int result2);
            if (b && isPositive)
            {
                int i = int.Parse(user_input);
                if (i <= 0)
                {
                    b = false;
                    Console.WriteLine("Число должно быть положительным!");
                }
            }
            else if (!b) { Console.WriteLine("Введенное значение не является целым числом!"); }
        }
        return int.Parse(user_input);
    }
    public static string StringInput(string text = "Введите строку")
    {
        string? user_input = "";

        bool b = false;

        while (b != true)
        {
            Console.Write(text);
            user_input = Console.ReadLine();
            if (user_input == "" || user_input == null)
            {
                Console.WriteLine("Строка не дожна быть пустой!");
                b = false;
            }
            else
            {
                b = true;
            }

        }
        return user_input;
    }

    public static DateOnly dateInput(string text)
    {
        string dateString = UserInput.StringInput("введите дату в формате день.месяц.год");
        Console.WriteLine(dateString);
        DateOnly dateOnlyVal1 = new DateOnly();
        // Разбиваем строку на компоненты
        string[] dateParts = dateString.Split('.');
        Console.WriteLine(dateParts[0]);
        Console.WriteLine(dateParts[1]);
        Console.WriteLine(dateParts[2]);
        if (dateParts.Length == 3 &&
            int.TryParse(dateParts[0], out int d) &&
            int.TryParse(dateParts[1], out int m) &&
            int.TryParse(dateParts[2], out int y))
        {
            DateOnly dateOnlyVal = new DateOnly(d, m, y);
            return dateOnlyVal;
        }
        Console.WriteLine("некоректный ввод попробуйте еще раз");
        return dateOnlyVal1;
    }
        

    // Для ввода дробных чисел
    public static double doubleInput(bool isPositive = false, string text = "Введите рациональное число: ")
    {
        string user_input = "";
        bool b = false;

        while (b != true)
        {
            Console.Write(text);
            user_input = Console.ReadLine();
            b = double.TryParse(user_input, out double result2);
            if (b && isPositive)
            {
                double i = double.Parse(user_input);
                if (i < 0)
                {
                    b = false;
                    Console.WriteLine("Число должно быть положительным!");
                }
            }
            else if (!b) { Console.WriteLine("Введенное значение не является целым числом!"); }
        }
        return double.Parse(user_input);
    }


}