using System;

namespace TicTacToe {
    internal static class Program {
        public static void Main(string[] args) {
            int horizontalSize;
            int verticalSize;
            while (!int.TryParse(Console.ReadLine(), out horizontalSize)) { Console.WriteLine("Wrong input! Enter натуральное число!"); }
            while (!int.TryParse(Console.ReadLine(), out verticalSize)) { Console.WriteLine("Wrong input! Enter натуральное число!"); }
            var field = new Field(horizontalSize, verticalSize);
            
            Console.WriteLine("Сыграть с ботом? true/false");
            bool botFlag;
            while (!bool.TryParse(Console.ReadLine(), out botFlag)) { Console.WriteLine("Wrong input! Enter \"true\" or \"false\"!"); }

            Console.WriteLine("\nNew game!");
            int x;
            int y;
            var numStep = 0;
            char symbol;
            var bot = new RandomBot(horizontalSize, verticalSize);
            do {
                Console.WriteLine("\nNext Step.");
                if (numStep % 2 == 0) {
                    Console.WriteLine("X move now.\n");
                    symbol = 'X';
                }
                else {
                    Console.WriteLine("O move now.\n");
                    symbol = 'O';
                }

                if (botFlag && numStep % 2 != 0) {
                    do {
                        bot.make_move();
                        x = bot.cell[0];
                        y = bot.cell[1];
                    } while (field.CheckSymbol(x - 1, y - 1));
                } else {
                    do {
                        Console.WriteLine("Введите координату Х ");
                        x = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите координату Y ");
                        y = int.Parse(Console.ReadLine());
                    } while (field.CheckSymbol(x - 1, y - 1));
                }

                field.SetSymbol(x - 1, y - 1, symbol);
                numStep++;
            } while (!field.checkWin());
            
            Console.WriteLine($"{symbol} побеждает!");
        }
    }
    
}