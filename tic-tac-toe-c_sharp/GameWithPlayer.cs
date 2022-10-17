using System;

namespace TicTacToe {
    public class GameWithPlayer {
        private readonly int _horizontalSize;
        private readonly int _verticalSize;

        public GameWithPlayer(int horizontalSizeField, int verticalSizeField) {
            _horizontalSize = horizontalSizeField;
            _verticalSize = verticalSizeField;
        }

        public void Game() {
            Console.WriteLine("\nNew game!");
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

                do {
                    Console.WriteLine("Введите координату Х ");
                    x = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите координату Y ");
                    y = int.Parse(Console.ReadLine());
                } while (field.CheckSymbol(x - 1, y - 1, true));
                
                field.SetSymbol(x - 1, y - 1, symbol);
                numStep++;
            } while (!field.checkWin() && numStep < _horizontalSize * _verticalSize);
            
            Console.WriteLine($"{symbol} побеждает!");
        }
    }
}