using System.Globalization;

double a = ReadNumber("введите число a: ");
string? operation = ReadText(
    "введите операцию (+, -, *, /, ^, sqrt, корень, %, квад): ");

if (operation is null)
    Environment.Exit(0);

string answer = operation switch
{
    "квад" => SolveQuadratic(a,
        ReadNumber("введите коэффициент b: "),
        ReadNumber("введите коэффициент c: ")),
    "sqrt" => Root(a, 2),
    "корень" => Root(a, ReadDegree("введите степень корня: ")),
    _ => Apply(operation, a, ReadNumber("введите второе число b: "))
};

Console.WriteLine(answer);

static string? ReadText(string prompt)
{
    Console.Write(prompt);
    return Console.ReadLine()?.Trim();
}

static double ReadNumber(string prompt)
{
    while (true)
    {
        string? text = ReadText(prompt)?.Replace(',', '.');
        if (text is null)
            Environment.Exit(0);

        if (double.TryParse(text, NumberStyles.Float,
                CultureInfo.InvariantCulture, out double value))
            return value;

        Console.WriteLine("введено не число, повторите ввод");
    }
}

static int ReadDegree(string prompt)
{
    while (true)
    {
        string? text = ReadText(prompt);
        if (text is null)
            Environment.Exit(0);

        if (int.TryParse(text, out int degree) && degree >= 2)
            return degree;

        Console.WriteLine("степень корня - целое число не меньше 2");
    }
}

static string Format(double value) =>
    value.ToString("0.##########", CultureInfo.InvariantCulture);

static string Root(double value, int degree)
{
    bool negative = value < 0;

    if (negative && degree % 2 == 0)
        return "корень чётной степени из отрицательного числа не существует";

    double result = Math.Pow(Math.Abs(value), 1.0 / degree);

    return negative
        ? $" корень степени {degree} из {Format(value)} = {Format(-result)}"
        : $" корень степени {degree} из {Format(value)} = {Format(result)}";
}

static string Apply(string operation, double a, double b) => operation switch
{
    "+" => $" {Format(a)} + {Format(b)} = {Format(a + b)}",
    "-" => $" {Format(a)} - {Format(b)} = {Format(a - b)}",
    "*" => $" {Format(a)} * {Format(b)} = {Format(a * b)}",
    "/" => b == 0
        ? "на 0 нельзя делить"
        : $" {Format(a)} / {Format(b)} = {Format(a / b)}",
    "^" => $" {Format(a)} ^ {Format(b)} = {Format(Math.Pow(a, b))}",
    "%" => b == 0
        ? "на 0 нельзя делить"
        : $" {Format(a)} % {Format(b)} = {Format(a % b)}",
    _ => "операции не существует"
};

static string SolveQuadratic(double a, double b, double c)
{
    if (a == 0)
        return b == 0
            ? c == 0 ? "бесконечные решения" : "нет решений"
            : $"корень линейного уравнения: x = {Format(-c / b)}";

    double d = b * b - 4 * a * c;

    return d switch
    {
        > 0 => $"два корня: x1 = {Format((-b + Math.Sqrt(d)) / (2 * a))}, " +
               $"x2 = {Format((-b - Math.Sqrt(d)) / (2 * a))}",
        0 => $"один корень: x = {Format(-b / (2 * a))}",
        _ => "нет действительных корней"
    };
}
