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
            } else if (_botType == 3) {
                bot = new TwoStepBot(_horizontalSize, _verticalSize);
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
                    do {
                        bot.make_move(numStep, field);
                        x = bot.Cell[0];
                        y = bot.Cell[1];
                    } while (field.CheckSymbol(x - 1, y - 1, false));
                } else {
                    do {
                        Console.WriteLine("Введите координату Х ");
                        while (!int.TryParse(Console.ReadLine(), out x)) { Console.WriteLine("Wrong input! Enter натуральное число!"); }
                        Console.WriteLine("Введите координату Y ");
                        while (!int.TryParse(Console.ReadLine(), out y)) { Console.WriteLine("Wrong input! Enter натуральное число!"); }
                    } while (field.CheckSymbol(x - 1, y - 1, true));
                }

                field.SetSymbol(x - 1, y - 1, symbol);
                field.printField();
                numStep++;
            } while (!field.checkWin() && numStep < _horizontalSize * _verticalSize);

            if (field.checkWin()) {
                Console.WriteLine(string.Format("{0} побеждает!", symbol));
            } else {
                Console.WriteLine("Ничья!");
            }
        }
    }
}