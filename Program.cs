namespace TypingSpeed
{
    internal class Program
    {
        static string text = "Он благополучно избегнул встречи с своею хозяйкой на лестнице. Каморка его приходилась под самою кровлей" +
            " высокого пятиэтажного дома и походила более на шкаф, чем на квартиру. Квартирная же хозяйка его, у которой он нанимал" +
            " эту каморку с обедом и прислугой, помещалась одною лестницей ниже, в отдельной квартире, и каждый раз, при выходе на улицу," +
            " ему непременно надо было проходить мимо хозяйкиной кухни, почти всегда настежь отворенной на лестницу. И каждый раз молодой человек," +
            " проходя мимо, чувствовал какое-то болезненное и трусливое ощущение, которого стыдился и от которого морщился. Он был должен кругом" +
            " хозяйке и боялся с нею встретиться.";

        static Table table = new Table();
        static int i = 0;
        static Record name = new Record();
        static bool isOn = true;
        static ConsoleKeyInfo key;

        static void Main()
        {
            do
            {
                Console.WriteLine("Введите ваше имя: ");
                name.Name = Console.ReadLine();
                WriteText();
                Console.SetCursorPosition(0, 0);
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.F1);
        }

        static void EndTime()
        {
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine("Имя: " + name.Name);
                        Console.WriteLine("Скорость в минуту: " + name.SymbolPerMinute);
                        Console.WriteLine("Скорость в секунду: " + name.SymbolPerSecond);

                        Console.WriteLine("-----------------");

                        table.WriteReccord();

                        table.AddItem(name.Name, name.SymbolPerMinute, name.SymbolPerSecond);
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("Чтобы вернуться обратно в меню, вернитесь через Escape");
                        Console.WriteLine("Чтобы закончить программу, нажмите F1");
                        break;
                    case ConsoleKey.Escape:
                        Main();
                        break;
                    case ConsoleKey.F1:
                        Environment.Exit(0);
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape && keyInfo.Key != ConsoleKey.F1);
        }

        static void Speed()
        {
            name.SymbolPerMinute = i;
            name.SymbolPerSecond = i / 60;
        }

        private static void Time()
        {
            Thread t = new Thread(_ =>
            {
                var dateTime = DateTime.Now;
                DateTime dt = dateTime.AddMinutes(-1);

                while (dateTime >= dt && isOn)
                {
                    Console.SetCursorPosition(0, 10);
                    if (i == text.Length)
                    {
                        isOn = false;
                    }
                    Console.SetCursorPosition(0, 10);
                    var ticks = (dateTime - dt).Ticks;
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine(new DateTime(ticks).ToString("mm:HH:ss"));
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(0, 10);
                    dt = dt.AddSeconds(1);
                    Console.SetCursorPosition(0, 10);
                }
                Console.Clear();

                Console.WriteLine("Стоп!");
                Speed();
                EndTime();
            });

            t.Start();
        }

        static void WriteYellowText(int dlina)
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < dlina; i++)
            {
                Console.Write(text[i]);
            }
            Console.SetCursorPosition(0, 0);
        }

        static void WriteText()
        {
            Console.Clear();

            Console.WriteLine("Нажмите Enter чтобы начать");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Time();

            while (isOn == true)
            {
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(text);
                    Console.SetCursorPosition(0, 0);

                    while (i < text.Length)
                    {
                        char c = Console.ReadKey(true).KeyChar;
                        if (c == text[i])
                        {
                            i++;
                            WriteYellowText(i);
                        }
                    }
                }
                keyInfo = Console.ReadKey();
            }
        }
    }
}