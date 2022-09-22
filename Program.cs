using System.Diagnostics;

char[,] palya = new char[24, 79];
Random rnd = new();

Stopwatch sw = new Stopwatch();


//a palya beolvasasa
using StreamReader sr = new(@"..\..\..\res\lab.txt");
int sorIndex = 0;

sw.Start();
while (!sr.EndOfStream)
{
    string teljesSor = sr.ReadLine();
    for (int oszlopIndex = 0; oszlopIndex < teljesSor.Length; oszlopIndex++)
    {
        palya[sorIndex, oszlopIndex] = teljesSor[oszlopIndex];
    }
    sorIndex++;
}

//a palya kirajzolasa a matrixbol
Console.CursorVisible = false;
Console.SetWindowSize(79, 25);
for (int s = 0; s < palya.GetLength(0); s++)
{
    for (int o = 0; o < palya.GetLength(1); o++)
    {
        if (palya[s, o] == '#')
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
        }
        Console.Write(palya[s, o]);
    }
    Console.Write("\n");
}

int top = 0;
int left = 0;

Console.ForegroundColor = ConsoleColor.Red;
Console.BackgroundColor = ConsoleColor.White;

while (palya[top, left] != 'O')
{
    var ck = Console.ReadKey().Key;

    switch (ck)
    {
        case ConsoleKey.UpArrow:
            if (top != 0 && palya[top - 1, left] != '#')
            {
                top--;
                Console.SetCursorPosition(left, top + 1);
                Console.Write(' ');
            }
            break;
        case ConsoleKey.DownArrow:
            if (top != palya.GetLength(0) - 1 && palya[top + 1, left] != '#')
            {
                top++;
                Console.SetCursorPosition(left, top - 1);
                Console.Write(' ');
            }
            break;
        case ConsoleKey.LeftArrow:
            if (left != 0 && palya[top, left - 1] != '#')
            {
                left--;
                Console.SetCursorPosition(left + 1, top);
                Console.Write(' ');
            }
            break;
        case ConsoleKey.RightArrow:
            if (left != palya.GetLength(1) - 1 && palya[top, left + 1] != '#')
            {
                left++;
                Console.SetCursorPosition(left - 1, top);
                Console.Write(' ');
            }
            break;
    }
    Console.SetCursorPosition(left, top);

    Console.ForegroundColor = (ConsoleColor)rnd.Next(15);

    Console.Write('@');
}

sw.Stop();
Console.Clear();
Console.WriteLine("győztél ge!");
Console.WriteLine($"idő: {sw.Elapsed}");

while (Console.ReadKey().Key != ConsoleKey.Escape);
