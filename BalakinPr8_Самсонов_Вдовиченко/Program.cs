// Практическая работа № 8. Задания 1-3. Авторы: Самсонов А. Ю., Вдовиченко С. А.

// Задание 1. Анализ надёжности пароля
Console.WriteLine("Задание 1. Анализ надёжности пароля");
Console.Write("введите пароль: ");
string pass = Console.ReadLine();

bool cif = false;
bool reg = false;
bool spec = false;

for (int i = 0; i < pass.Length; i++)
{
    char ch = pass[i];

    if (char.IsDigit(ch))
        cif = true;
    else if (char.IsUpper(ch))
        reg = true;
    else if (!char.IsLetter(ch) && !char.IsDigit(ch))
        spec = true;
}

bool good = pass.Length >= 8 && cif && reg && spec;

Console.WriteLine("длина пароля: " + pass.Length + " (нужно не менее 8)");
Console.WriteLine("цифра: " + (cif ? "есть" : "нет"));
Console.WriteLine("заглавная буква: " + (reg ? "есть" : "нет"));
Console.WriteLine("специальный символ: " + (spec ? "есть" : "нет"));
Console.WriteLine("вывод: пароль " + (good ? "надёжный" : "ненадёжный"));

// Задание 2. Построение числового ромба
Console.WriteLine();
Console.WriteLine("Задание 2. Построение числового ромба");
Console.Write("введите нечётное число (количество строк): ");
int n = Convert.ToInt32(Console.ReadLine());

if (n < 3 || n % 2 == 0)
{
    Console.WriteLine("нужно нечётное число больше 1");
}
else
{
    int mid = n / 2 + 1;

    for (int i = 1; i <= n; i++)
    {
        int row = i <= mid ? i : n - i + 1;
        string line = "";

        for (int s = 0; s < mid - row; s++)
            line += " ";

        for (int s = 0; s < 2 * row - 1; s++)
            line += "*";

        Console.WriteLine(line);
    }
}

// Задание 3. Игра «больше / меньше»
Console.WriteLine();
Console.WriteLine("Задание 3. Игра «больше / меньше»");

string ans = "yes";

while (ans == "yes")
{
    int zag = new Random().Next(1, 101);
    int pop = 0;

    Console.WriteLine("загадано число от 1 до 100");

    while (true)
    {
        Console.Write("введите число: ");
        int x = Convert.ToInt32(Console.ReadLine());

        if (x < 1 || x > 100)
        {
            Console.WriteLine("число должно быть от 1 до 100, попытка не засчитана");
            continue;
        }

        pop++;

        if (x == zag)
        {
            Console.WriteLine("угадал!");
            Console.WriteLine("загаданное число: " + zag);
            Console.WriteLine("попыток: " + pop);
            break;
        }

        if (x < zag)
            Console.WriteLine("меньше");
        else
            Console.WriteLine("больше");
    }

    Console.Write("сыграть ещё раз? (yes/no): ");
    ans = Console.ReadLine();
}
