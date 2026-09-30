// задание 1 разбить строку по символу

Console.Write("введите строку: ");
string str = Console.ReadLine();

Console.Write("введите символ: ");
char letter = Convert.ToChar(Console.ReadLine());

string part = "";
int parts = 1;

Console.WriteLine("строка разбита на части:");

for (int i = 0; i < str.Length; i++)
{
    if (str[i] == letter)
    {
        Console.WriteLine(part);
        part = "";
        parts++;
    }
    else
    {
        part = part + str[i];
    }
}

Console.WriteLine(part);
Console.WriteLine("всего частей: " + parts);

// задание 2 посчитать сколько раз встречается символ и поднять его вверх

Console.Write("введите строку: ");
string str2 = Console.ReadLine();

Console.Write("введите символ: ");
char letter2 = Convert.ToChar(Console.ReadLine());

int count = 0;
int pos = str2.IndexOf(letter2);

while (pos > -1)
{
    count++;
    pos = str2.IndexOf(letter2, pos + 1);
}

Console.WriteLine("исходная строка: " + str2);
Console.WriteLine("символ '" + letter2 + "' встречается " + count + " раз(а)");

char[] mass = str2.ToCharArray();

for (int i = 0; i < mass.Length; i++)
{
    if (mass[i] == letter2)
        mass[i] = char.ToUpper(mass[i]);
}

Console.WriteLine("строка с заглавными: " + new string(mass));

// задание 3 шифратор и дешифратор цезаря

const string ALPHABET = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

int size = ALPHABET.Length;

Console.WriteLine("шифратор и дешифратор цезаря");
Console.WriteLine("букв в алфавите: " + size);

Console.Write("введите слово: ");
string word = Console.ReadLine();

Console.Write("введите сдвиг: ");
int shift = Convert.ToInt32(Console.ReadLine());

while (shift > size - 1)
    shift = shift - size;

while (shift < 0)
    shift = shift + size;

string coded = "";

for (int i = 0; i < word.Length; i++)
{
    int number = ALPHABET.IndexOf(char.ToLower(word[i]));

    if (number == -1)
        coded = coded + word[i];
    else
    {
        number = number + shift;

        if (number > size - 1)
            number = number - size;

        if (char.IsUpper(word[i]))
            coded = coded + char.ToUpper(ALPHABET[number]);
        else
            coded = coded + ALPHABET[number];
    }
}

Console.WriteLine("слово: " + word);
Console.WriteLine("зашифровано со сдвигом " + shift + ": " + coded);

string decoded = "";

for (int i = 0; i < coded.Length; i++)
{
    int number = ALPHABET.IndexOf(char.ToLower(coded[i]));

    if (number == -1)
        decoded = decoded + coded[i];
    else
    {
        number = number - shift;

        if (number < 0)
            number = number + size;

        if (char.IsUpper(coded[i]))
            decoded = decoded + char.ToUpper(ALPHABET[number]);
        else
            decoded = decoded + ALPHABET[number];
    }
}

Console.WriteLine("расшифровано: " + decoded);
