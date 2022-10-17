using System;

namespace TicTacToe {
    public class GameWithBot {
        private readonly int _horizontalSize;
        private readonly int _verticalSize;
        private readonly int _botType;

        public GameWithBot(int horizontalSizeField, int verticalSizeField, int botType) {
            _horizontalSize = horizontalSizeField;
            _verticalSize = verticalSizeField;
            _botType = botType;
        }

        public void Game() {
            Console.WriteLine("\nNew game!");
            Bot bot = new RandomBot(_horizontalSize, _verticalSize);
            if (_botType == 2) {
                bot = new OneStepBot(_horizontalSize, _verticalSize);
            }

            var field = new Field(_horizontalSize, _verticalSize);
            int x;
            int y;
            var numStep = 0;
            char symbol;
            do {
                Console.WriteLine("\nNext Step.");
                if (numStep % 2 == 0) {
                    Console.WriteLine("X move now.\n");
                    symbol = 'X';
                } else {
                    Console.WriteLine("O move now.\n");
                    symbol = 'O';
                }

                if (numStep % 2 != 0) {
                    
                    bot.make_move(numStep, field);
                    x = bot.Cell[0] + 1;
                    y = bot.Cell[1] + 1;
                    Console.WriteLine("Я застрял!!!");
                    
                } else {
                    do {
                        Console.WriteLine("Введите координату Х ");
                        x = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите координату Y ");
                        y = int.Parse(Console.ReadLine());
                    } while (field.CheckSymbol(x - 1, y - 1, true));
                }

                field.SetSymbol(x - 1, y - 1, symbol);
                field.printField();
                numStep++;
            } while (!field.checkWin() && numStep < _horizontalSize * _verticalSize);
            
            Console.WriteLine($"{symbol} побеждает!");
        }
    }
}