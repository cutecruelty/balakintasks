double a, b, c, n;
string oper, result = "";

Console.Write("введите операцию (+, -, *, /, ^, %, корень, квад): ");
oper = Console.ReadLine();

Console.Write("введите число: ");
a = Convert.ToDouble(Console.ReadLine());

result = "ошибка ввода";

if (oper == "корень")
{
    Console.Write("введите степень корня: ");
    n = Convert.ToDouble(Console.ReadLine());

    if (n < 2)
        result = "степень корня должна быть не меньше 2";
    else if (a < 0 && n % 2 == 0)
        result = "корень чётной степени из отрицательного числа не существует";
    else
    {
        double r = Math.Round(Math.Pow(Math.Abs(a), 1.0 / n), 10);
        result = a < 0
            ? $" корень степени {n} из {a} = {-r}"
            : $" корень степени {n} из {a} = {r}";
    }
}
else if (oper == "квад")
{
    Console.Write("введите коэффициент b: ");
    b = Convert.ToDouble(Console.ReadLine());

    Console.Write("введите коэффициент c: ");
    c = Convert.ToDouble(Console.ReadLine());

    double d = b * b - 4 * a * c;

    if (a == 0)
    {
        result = b == 0
            ? c == 0 ? "бесконечные решения" : "нет решений"
            : $"корень линейного уравнения: x = {-c / b}";
    }
    else if (d > 0)
        result = $"два корня: x1 = {(-b + Math.Sqrt(d)) / (2 * a)}, " +
                 $"x2 = {(-b - Math.Sqrt(d)) / (2 * a)}";
    else if (d == 0)
        result = $"один корень: x = {-b / (2 * a)}";
    else
        result = "нет действительных корней";
}
else
{
    Console.Write("введите второе число: ");
    b = Convert.ToDouble(Console.ReadLine());

    switch (oper)
    {
        case "+":
            result = $" {a} + {b} = {a + b}";
            break;

        case "-":
            result = $" {a} - {b} = {a - b}";
            break;

        case "*":
            result = $" {a} * {b} = {a * b}";
            break;

        case "/":
            result = b == 0 ? "на 0 нельзя делить" : $" {a} / {b} = {a / b}";
            break;

        case "%":
            result = b == 0 ? "на 0 нельзя делить" : $" {a} % {b} = {a % b}";
            break;

        case "^":
            result = $" {a} ^ {b} = {Math.Pow(a, b)}";
            break;

        default:
            result = "операции не существует";
            break;
    }
}

Console.WriteLine(result);
