using System;

namespace TicTacToe {

    public class OneStepBot {
        private readonly int _horizontalSize;
        private readonly int _verticalSize;
        private readonly int field_size;
        private Random _rnd;
        public int[] cell;

        public OneStepBot(int horizontalSizeField, int verticalSizeField) {
            _horizontalSize = horizontalSizeField;
            _verticalSize = verticalSizeField;
            cell = new int[2];
            _rnd = new Random();
            field_size = _horizontalSize * _verticalSize;
        }

        public void make_move(int numStep, Field field) {
            var newField = field.Copy();
            var symbol = numStep % 2 == 0 ? 'X' : 'O';
            for (var i = 0; i < _horizontalSize; i++) {
                for (var j = 0; j < _verticalSize; j++) {
                    if (newField.CheckSymbol(i, j)) {
                        continue;
                    }
                    newField.SetSymbol(i, j, symbol);
                    if (newField.checkWin()) {
                        cell[0] = i;
                        cell[1] = j;
                        return;
                    }
                }
            }
            cell[0] = _rnd.Next(1, _horizontalSize + 1);
            cell[1] = _rnd.Next(1, _verticalSize + 1);
        }
    }
}
