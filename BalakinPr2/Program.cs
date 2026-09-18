// task 1 Написать переводчик из двоичной системы в десятичную до восьми знаков (Ввод: строка, типа "11011100", Вывод: число 220)

string usrInput1 = Console.ReadLine() ?? "";

try
{
    if (usrInput1.Length <= 8)
    {
        int result1 = Convert.ToInt32(usrInput1, 2);
        Console.WriteLine($"резултьат первода: ${result1}");

    }
}
catch (FormatException)
{    
    Console.WriteLine("невалидная строка");
}

// task 2 Написать переводчик из десятичной в двоичную (Ввод: целочисленное число, Вывод: строка, типа "11011100")

string usrInput2 = Console.ReadLine() ?? "";

if (int.TryParse(usrInput2, out int mid2) && mid2 >= 0)
{
    string result2 = Convert.ToString(mid2, 2); 
    Console.WriteLine($"результат перевода в двоичную: {result2}");
}
else
{
    Console.WriteLine("число должно быть и целым и положительным");
}

// task 3 tldr


string usrInputN = Console.ReadLine() ?? "";
string usrInputM = Console.ReadLine() ?? "";
string usrInputT = Console.ReadLine() ?? "";

if (int.TryParse(usrInputN, out int hours) && 
    int.TryParse(usrInputM, out int minutes) && 
    long.TryParse(usrInputT, out long delivery))
{
    long totalMinutes = hours * 60L + minutes + delivery;
    
    long finalHours = (totalMinutes / 60) % 24;
    long finalMinutes = totalMinutes % 60;
    
    Console.WriteLine($"{finalHours:D2}:{finalMinutes:D2}");
}
