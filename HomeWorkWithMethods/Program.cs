using System.Reflection.Metadata.Ecma335;

namespace HomeWorkWithMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = GetUserData();
            PrintUserData(user);
        }

        static (string, string, int, bool, int,
            string[], int, string[]) GetUserData()
        {
            var questionColor = ConsoleColor.Green;
            (string fitstName, string lastName, int age, bool hasPet, int countPet,
            string[] namePet, int countColor, string[] favColor) user;

            PrintTextWithChangeColor("Ведите ваше имя: ", questionColor);
            user.fitstName = Console.ReadLine();

            PrintTextWithChangeColor("Введите вашу фамилию: ", questionColor);
            user.lastName = Console.ReadLine();

            PrintTextWithChangeColor("Введите ваш возраст: ", questionColor);
            user.age = InputNumber();

            PrintTextWithChangeColor("Есть ли у вас питомцы? Да\\Нет ", questionColor);
            user.hasPet = InputBool();

            if (user.hasPet)
            {
                PrintTextWithChangeColor("Cколько у вас питомцев:", questionColor);
                user.countPet = InputNumber();
                PrintTextWithChangeColor("Введите их имена: \n", questionColor);
                user.namePet = new string[user.countPet];
                InputStringInArray(user.namePet);
            }
            else
            {
                user.namePet = new string[0];
                user.countPet = 0;
            }

            PrintTextWithChangeColor("Eсть ли у вас любимые цвета? Да\\Нет:", questionColor);
            var hasColor = InputBool();

            if (hasColor)
            {
                PrintTextWithChangeColor("Сколько у вас любимых цветов:", questionColor);
                user.countColor = InputNumber();
                user.favColor = new string[user.countColor];
                InputStringInArray(user.favColor);
            }
            else
            {
                user.countColor = 0;
                user.favColor = new string[0];
            }
            return user;
        }

        static void PrintTextWithChangeColor(string text, ConsoleColor color)
        {
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = defaultColor;
        }

        static int InputNumber()
        {
            var input = Console.ReadLine();
            int inputInt;
            var parse = int.TryParse(input, out inputInt);
            if (!parse)
            {
                PrintTextWithChangeColor("Не корректный ввод. Должно быть число", ConsoleColor.Red);
                inputInt = InputNumber();
            }
            else if (inputInt <= 0)
            {
                PrintTextWithChangeColor("Ввод должен быть больше нуля.", ConsoleColor.Red);
                inputInt = InputNumber();
            }
            return inputInt;
        }

        static bool InputBool()
        {
            var input = Console.ReadLine();
            while (true)
            {
                switch (input.ToLower())
                {
                    case "да":
                        return true;
                    case "нет":
                        return false;
                    default:
                        PrintTextWithChangeColor("Не корректный ввод.", ConsoleColor.Red);
                        break;
                }
            }
        }

        static void InputStringInArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                while (true)
                {
                    Console.Write(i + ": ");
                    var input = Console.ReadLine();
                    if (input == "" || input == " ")
                    {
                        PrintTextWithChangeColor("Не корректный ввод!", ConsoleColor.Red);
                    }
                    else
                    {
                        arr[i] = input;
                        break;
                    }
                }
            }
        }

        static void PrintUserData((string fitstName, string lastName, int age, bool hasPet, int countPet,
            string[] namePet, int countColor, string[] favColor) user)
        {
            Console.WriteLine("Ваше имя: {0}.", user.fitstName);
            Console.WriteLine("Ваша фамилия: {0}.", user.lastName);
            Console.WriteLine("Вам {0} лет.", user.age);
            if (user.hasPet)
            {
                Console.WriteLine("У вас {0} петомцев, вот их имена:", user.countPet);
                foreach (var item in user.namePet)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine("У вас нет питомцев.");
            if (user.countColor != 0)
            {
                Console.WriteLine("У вас {0} любимых цветов, вот их названия:", user.countColor);
                foreach (var item in user.favColor)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine("У вас нет любимых цветов.");
        }
    }
}
