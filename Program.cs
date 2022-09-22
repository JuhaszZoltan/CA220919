using System.Diagnostics;

char[,] palya = new char[24, 79];
Console.CursorVisible = false;
Console.SetWindowSize(79, 25);

Random rnd = new();
Stopwatch sw = new();

//a palya beolvasasa
using StreamReader sr = new(@"..\..\..\res\lab.txt");

int si = 0;
while (!sr.EndOfStream)
{
    string ts = sr.ReadLine();
    for (int oi = 0; oi < ts.Length; oi++)
    {
        palya[si, oi] = ts[oi];
    }
    si++;
}

//a palya kirajzolasa a matrixbol
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
Console.ForegroundColor = ConsoleColor.Red;
Console.BackgroundColor = ConsoleColor.White;

int top = 0;
int left = 0;
while (palya[top, left] != 'O')
{
    var ck = Console.ReadKey().Key;
    if (!sw.IsRunning) sw.Start();
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
    Console.Write('@');
}

sw.Stop();
Console.Clear();

Console.BackgroundColor = ConsoleColor.White;
Console.ForegroundColor = ConsoleColor.Black;

Console.SetCursorPosition(
    Console.WindowWidth / 2 - 4,
    Console.WindowHeight / 2);
Console.WriteLine("győztél!");
Console.SetCursorPosition(
    Console.WindowWidth / 2 - 8,
    Console.WindowHeight / 2 + 1);

Console.WriteLine($"idő: {sw.Elapsed.TotalSeconds:0.000} sec.");

while (Console.ReadKey().Key != ConsoleKey.Escape);
