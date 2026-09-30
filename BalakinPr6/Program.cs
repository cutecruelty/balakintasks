Console.WriteLine(@"
  |\__/,|   (`\
 |_ _  |.--.) )
 ( T   )     /
(((^_(((/(((_/
");

// task 1 создать массив размера a (вводится в консоль) и заполнить его вводимыми данными

Console.Write("введите размер массива a: ");
int a = Convert.ToInt32(Console.ReadLine());

int[] arr = new int[a];

for (int i = 0; i < arr.Length; i++)
{
    Console.WriteLine($"введите arr[{i}]: ");
    arr[i] = Convert.ToInt32(Console.ReadLine());
}

Console.Write("массив: ");
Console.WriteLine(string.Join(" ", arr));

// task 2 заполнить массив из x ячеек в порядке: последний, первый, предпоследний, второй

Console.Write("введите количество ячеек x: ");
int x = Convert.ToInt32(Console.ReadLine());

int[] arr2 = new int[x];

int first = 0;
int last = x - 1;

while (first < last)
{
    Console.WriteLine($"введите arr2[{last}]: ");
    arr2[last--] = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine($"введите arr2[{first}]: ");
    arr2[first++] = Convert.ToInt32(Console.ReadLine());
}

if (first == last)
{
    Console.WriteLine($"введите arr2[{first}]: ");
    arr2[first] = Convert.ToInt32(Console.ReadLine());
}

Console.Write("заполнен в обратном с краёв порядке: ");
Console.WriteLine(string.Join(" ", arr2));

// task 3 двумерный массив 10*10, суммы строк, произведения столбцов и самые большие результаты

const int size = 10;

int[][] matrix = new int[size][];

for (int i = 0; i < size; i++)
    matrix[i] = new int[size];

Random rnd = new Random();

for (int i = 0; i < size; i++)
    for (int j = 0; j < size; j++)
        matrix[i][j] = rnd.Next(1, 10);

for (int i = 0; i < size; i++)
    Console.WriteLine(string.Join(" ", matrix[i]));

int[] sums = new int[size];
long[] products = new long[size];

for (int j = 0; j < size; j++)
    products[j] = 1;

for (int i = 0; i < size; i++)
    for (int j = 0; j < size; j++)
    {
        sums[i] += matrix[i][j];
        products[j] *= matrix[i][j];
    }

int maxSum = sums[0];
int maxSumRow = 0;

for (int i = 1; i < size; i++)
    if (sums[i] > maxSum)
    {
        maxSum = sums[i];
        maxSumRow = i;
    }

long maxProduct = products[0];
int maxProductCol = 0;

for (int j = 1; j < size; j++)
    if (products[j] > maxProduct)
    {
        maxProduct = products[j];
        maxProductCol = j;
    }

Console.Write("суммы строк: ");
Console.WriteLine(string.Join(" ", sums));

Console.WriteLine("произведения столбцов:");
for (int j = 0; j < size; j++)
    Console.WriteLine($"столбец {j + 1}: {products[j]}");

Console.WriteLine($"самая большая сумма: {maxSum} (строка {maxSumRow + 1})");
Console.WriteLine($"самое большое произведение: {maxProduct} (столбец {maxProductCol + 1})");
