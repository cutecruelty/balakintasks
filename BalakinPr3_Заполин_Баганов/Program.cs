double a, b;
string oper;

Console.Write("введите число a: ");
a = Convert.ToDouble(Console.ReadLine());
Console.Write("введите операцию (+, -, *, /, ^, sqrt, %, квад): ");
oper = Console.ReadLine();

if (oper == "квад")
{
    Console.Write("введите коэффициент b: ");
    b = Convert.ToDouble(Console.ReadLine());
    Console.Write("введите коэффициент c: ");
    double c = Convert.ToDouble(Console.ReadLine());

    if (a == 0)
    {
        if (b == 0)
        {
            if (c == 0)
                Console.WriteLine("бесконечные решения");
            else
                Console.WriteLine("нет решений");
        }
        else
            Console.WriteLine("корень линейного уравнения: x = " + (-c / b));
    }
    else
    {
        double d = b * b - 4 * a * c;
        if (d > 0)
        {
            double x1 = (-b + Math.Sqrt(d)) / (2 * a);
            double x2 = (-b - Math.Sqrt(d)) / (2 * a);
            Console.WriteLine("два корня: x1 = " + x1 + ", x2 = " + x2);
        }
        else if (d == 0)
            Console.WriteLine("один корень: x = " + (-b / (2 * a)));
        else
            Console.WriteLine("нет действительных корней");
    }
}
else if (oper == "sqrt")
{
    if (a < 0)
        Console.WriteLine("корень из отрицательного числа не существует");
    else
        Console.WriteLine("sqrt(" + a + ") = " + Math.Sqrt(a));
}
else
{
    Console.Write("введите второе число b: ");
    b = Convert.ToDouble(Console.ReadLine());

    if (oper == "+")
        Console.WriteLine(" " + a + " + " + b + " = " + (a + b));
    else if (oper == "-")
        Console.WriteLine(" " + a + " - " + b + " = " + (a - b));
    else if (oper == "*")
        Console.WriteLine(" " + a + " * " + b + " = " + (a * b));
    else if (oper == "/")
    {
        if (b != 0)
            Console.WriteLine(" " + a + " / " + b + " = " + (a / b));
        else
            Console.WriteLine("на 0 нельзя делить");
    }
    else if (oper == "^")
        Console.WriteLine(" " + a + " ^ " + b + " = " + Math.Pow(a, b));
    else if (oper == "%")
    {
        if (b != 0)
            Console.WriteLine(" " + a + " % " + b + " = " + (a % b));
        else
            Console.WriteLine("на 0 нельзя делить");
    }
    else
        Console.WriteLine("операции не существует");
}