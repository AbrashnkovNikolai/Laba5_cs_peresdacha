using System.ComponentModel.Design;

class UserInput
{

    // ��� ����� ����� �����
    public static int intInput(bool isPositive = false, string text = "������� ����� �����: ")
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
                    Console.WriteLine("����� ������ ���� �������������!");
                }
            }
            else if (!b) { Console.WriteLine("��������� �������� �� �������� ����� ������!"); }
        }
        return int.Parse(user_input);
    }
    public static string StringInput(string text = "������� ������")
    {
        string? user_input = "";

        bool b = false;

        while (b != true)
        {
            Console.Write(text);
            user_input = Console.ReadLine();
            if (user_input == "" || user_input == null)
            {
                Console.WriteLine("������ �� ����� ���� ������!");
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
        string dateString = UserInput.StringInput("������� ���� � ������� ����.�����.���");
        Console.WriteLine(dateString);
        DateOnly dateOnlyVal1 = new DateOnly();
        // ��������� ������ �� ����������
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
        Console.WriteLine("����������� ���� ���������� ��� ���");
        return dateOnlyVal1;
    }
        

    // ��� ����� ������� �����
    public static double doubleInput(bool isPositive = false, string text = "������� ������������ �����: ")
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
                    Console.WriteLine("����� ������ ���� �������������!");
                }
            }
            else if (!b) { Console.WriteLine("��������� �������� �� �������� ����� ������!"); }
        }
        return double.Parse(user_input);
    }


}