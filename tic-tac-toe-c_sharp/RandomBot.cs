using System;

namespace TicTacToe {
    public class RandomBot : Bot {
        private readonly int _horizontalSize;
        private readonly int _verticalSize;
        private Random _rnd;

        public RandomBot(int horizontalSizeField, int verticalSizeField) {
            _horizontalSize = horizontalSizeField;
            _verticalSize = verticalSizeField;
            _rnd = new Random();
        }
        
        public override void make_move(int numStep, Field field) {
            Cell[0] = _rnd.Next(1, _horizontalSize+1);
            Cell[1] = _rnd.Next(1, _verticalSize+1);
        }
    }
}