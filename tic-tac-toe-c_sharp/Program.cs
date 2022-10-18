using System;

namespace TicTacToe {
    internal static class Program {
        public static void Main(string[] args) {
            int horizontalSize;
            int verticalSize;
            while (!int.TryParse(Console.ReadLine(), out horizontalSize)) { Console.WriteLine("Wrong input! Enter натуральное число!"); }
            while (!int.TryParse(Console.ReadLine(), out verticalSize)) { Console.WriteLine("Wrong input! Enter натуральное число!"); }
            
            Console.WriteLine("Сыграть с ботом? true/false");
            bool botFlag;
            while (!bool.TryParse(Console.ReadLine(), out botFlag)) { Console.WriteLine("Wrong input! Enter \"true\" or \"false\"!"); }

            if (botFlag) {
                Console.WriteLine("Тип бота:");
                Console.WriteLine("1) Random bot");
                Console.WriteLine("2) OneStep bot");
                Console.WriteLine("3) TwoStep bot");
                int typeBot;
                while (!int.TryParse(Console.ReadLine(), out typeBot) && !(typeBot == 1 || typeBot == 2 || typeBot == 3)) { Console.WriteLine("Wrong input! Enter 1 or 2!"); }

                var game = new GameWithBot(horizontalSize, verticalSize, typeBot);
                game.Game();
            } else {
                var game = new GameWithPlayer(horizontalSize, verticalSize);
                game.Game();
            }
        }
    }
    
}