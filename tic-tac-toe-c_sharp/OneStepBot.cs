using System;

namespace TicTacToe {

    public class OneStepBot : Bot {
    private readonly int _horizontalSize;
    private readonly int _verticalSize;
    private Random _rnd;

    public OneStepBot(int horizontalSizeField, int verticalSizeField) {
        _horizontalSize = horizontalSizeField;
        _verticalSize = verticalSizeField;
        _rnd = new Random();
    }

    public override void make_move(int numStep, Field field) {
        var newField = field.Copy();
        var symbol = numStep % 2 == 0 ? 'X' : 'O';
        for (var i = 0; i < _horizontalSize; i++) {
            for (var j = 0; j < _verticalSize; j++) {
                newField = field.Copy();
                if (newField.CheckSymbol(i, j, false)) {
                    continue;
                }

                newField.SetSymbol(i, j, symbol);
                if (newField.checkWin()) {
                    Cell[0] = i+1;
                    Cell[1] = j+1;
                    return;
                }
            }
        }

        Cell[0] = _rnd.Next(1, _horizontalSize + 1);
        Cell[1] = _rnd.Next(1, _verticalSize + 1);
    }
    }
}
