using System.Text;

Console.WriteLine(@"
            _                                    
           .'\   /`.
         .'.-.`-'.-.`.
    ..._:   .-. .-.   :_...
  .'    '-.(o ) (o ).-'    `.
 :  _    _ _`~(_)~`_ _    _  :
:  /:   ' .-=_   _=-. `   ;\  :
:   :|-.._  '     `  _..-|:   :
 :   `:| |`:-:-.-:-:'| |:'   :
  `.   `.| | | | | | |.'   .'
    `.   `-:_| | |_:-'   .'
      `-._   ````    _.-'
          ``-------''

");

Console.Write("enter string: ");

string input = Console.ReadLine();

StringBuilder result = new StringBuilder();

for (int i = 0; i < input.Length; i++)
{
    if (i % 2 == 0)
    {
        result.Append(char.ToUpper(input[i]));
    }
    else
    {
        result.Append(input[i]);
    }
}

Console.WriteLine($"result: {result.ToString()}");

Console.Write("enter a number from 0 to 1k: ");

int numInput = Convert.ToInt32(Console.ReadLine());

if (numInput < 0 || numInput > 1000)
{
    Console.WriteLine("wrong range");
}
else
{
    for (int i = 0; i <= numInput; i++)
    {
        Console.WriteLine(i);
    }
}

Console.WriteLine("array of 5 elements:");

string[] arr = new string[5];

for (int i = 0; i < arr.Length; i++)
{
    arr[i] = (i + 1).ToString();
}

Console.Write("input: ");

for (int i = 0; i < arr.Length; i++)
{
    Console.Write(arr[i] + " ");
}

Console.WriteLine("\noutput:");

Array.Reverse(arr);

for (int i = 0; i < arr.Length; i++)
{
    Console.Write(arr[i] + " ");
}

Console.WriteLine();
