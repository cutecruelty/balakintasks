Console.WriteLine(@"
  |\__/,|   (`\
 |_ _  |.--.) )
 ( T   )     /
(((^_(((/(((_/
");

// task 1 разбить строку по символу

Console.Write("введите строку: ");
string str = Console.ReadLine();

Console.Write("введите символ-разделитель: ");
char sep = Convert.ToChar(Console.ReadLine());

string[] parts = str.Split(sep);

Console.WriteLine($"строка разбита на {parts.Length} частей:");

for (int i = 0; i < parts.Length; i++)
    Console.WriteLine($"{i + 1}) {parts[i]}");

// task 2 сколько раз встречается символ и поднять его в верхний регистр

Console.Write("введите строку: ");
string str2 = Console.ReadLine();

Console.Write("введите символ: ");
char letter = Convert.ToChar(Console.ReadLine());

int count = 0;

foreach (char c in str2)
{
    if (c == letter)
        count++;
}

Console.WriteLine($"исходная строка: {str2}");
Console.WriteLine($"символ '{letter}' встречается {count} раз(а)");

string upper = "";

foreach (char c in str2)
{
    if (c == letter)
        upper = upper + char.ToUpper(c);
    else
        upper = upper + c;
}

Console.WriteLine($"строка с заглавными: {upper}");

// task 3 шифратор и дешифратор цезаря

const string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

Console.WriteLine("шифратор и дешифратор цезаря");
Console.WriteLine($"в русском алфавите с учётом ё букв: {alphabet.Length}");

Console.Write("введите слово: ");
string word = Console.ReadLine();

Console.Write("введите сдвиг: ");
int shift = Convert.ToInt32(Console.ReadLine());

shift = shift % alphabet.Length;

if (shift < 0)
    shift = shift + alphabet.Length;

string coded = "";

for (int i = 0; i < word.Length; i++)
{
    char letter2 = word[i];
    int pos = alphabet.IndexOf(char.ToLower(letter2));

    if (pos < 0)
        coded = coded + letter2;
    else if (char.IsUpper(letter2))
        coded = coded + char.ToUpper(alphabet[(pos + shift) % alphabet.Length]);
    else
        coded = coded + alphabet[(pos + shift) % alphabet.Length];
}

Console.WriteLine($"слово: {word}");
Console.WriteLine($"зашифровано со сдвигом {shift}: {coded}");

string decoded = "";

for (int i = 0; i < coded.Length; i++)
{
    char letter3 = coded[i];
    int pos = alphabet.IndexOf(char.ToLower(letter3));
    int newPos = (pos - shift + alphabet.Length) % alphabet.Length;

    if (pos < 0)
        decoded = decoded + letter3;
    else if (char.IsUpper(letter3))
        decoded = decoded + char.ToUpper(alphabet[newPos]);
    else
        decoded = decoded + alphabet[newPos];
}

Console.WriteLine($"расшифровано: {decoded}");
