double a, b, c;
string oper, result = "";

Console.Write("введите число a: ");
a = Convert.ToDouble(Console.ReadLine());
Console.Write("введите операцию (+, -, *, /, ^, sqrt, %, квад): ");
oper = Console.ReadLine();

if (oper == "квад")
{
    Console.Write("введите коэффициент b: ");
    b = Convert.ToDouble(Console.ReadLine());
    Console.Write("введите коэффициент c: ");
    c = Convert.ToDouble(Console.ReadLine());

    if (a == 0)
    {
        if (b == 0)
            result = c == 0 ? "бесконечные решения" : "нет решений";
        else
            result = $"корень линейного уравнения: x = {-c / b}";
    }
    else
    {
        double d = b * b - 4 * a * c;
        if (d > 0)
        {
            double x1 = (-b + Math.Sqrt(d)) / (2 * a);
            double x2 = (-b - Math.Sqrt(d)) / (2 * a);
            result = $"два корня: x1 = {x1}, x2 = {x2}";
        }
        else if (d == 0)
            result = $"один корень: x = {-b / (2 * a)}";
        else
            result = "нет действительных корней";
    }
}
else if (oper == "sqrt")
{
    if (a < 0)
        result = "корень из отрицательного числа не существует";
    else
        result = $" sqrt({a}) = {Math.Sqrt(a)}";
}
else
{
    Console.Write("введите второе число b: ");
    b = Convert.ToDouble(Console.ReadLine());
    result = "Ошибка";
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
            result = b != 0 ? $" {a} / {b} = {a / b}" : "на 0 нельзя делить";
            break;
        case "^":
            result = $" {a} ^ {b} = {Math.Pow(a, b)}";
            break;
        case "%":
            result = b != 0 ? $" {a} % {b} = {a % b}" : "на 0 нельзя делить";
            break;
        default:
            result = "операции не существует";
            break;
    }
}

Console.WriteLine(result);