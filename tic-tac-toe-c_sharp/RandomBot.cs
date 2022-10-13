using System;

namespace TicTacToe {
    public class RandomBot {
        private readonly int _horizontalSize;
        private readonly int _verticalSize;
        private Random _rnd;
        public int[] cell;

        public RandomBot(int horizontalSizeField, int verticalSizeField) {
            _horizontalSize = horizontalSizeField;
            _verticalSize = verticalSizeField;
            cell = new int[2];
            _rnd = new Random();
        }
        
        public void make_move() {
            cell[0] = _rnd.Next(1, _horizontalSize+1);
            cell[1] = _rnd.Next(1, _verticalSize+1);
        }
    }
}