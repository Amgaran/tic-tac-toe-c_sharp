using System;

namespace TicTacToe {
    public class TwoStepBot : Bot {
        private readonly int _horizontalSize;
        private readonly int _verticalSize;
        private Random _rnd;

        public TwoStepBot(int horizontalSizeField, int verticalSizeField) {
            _horizontalSize = horizontalSizeField;
            _verticalSize = verticalSizeField;
            _rnd = new Random();
        }

        public override void make_move(int numStep, Field field) {
            var symbol = numStep % 2 == 0 ? 'X' : 'O';
            var symbolEmeny = symbol == 'X' ? 'O' : 'X';
            var iter = 0;
            var coords = new int[_horizontalSize * _verticalSize, 2];
            for (var i = 0; i < _horizontalSize; i++) {
                for (var j = 0; j < _verticalSize; j++) {
                    var newField = field.Copy();
                    if (newField.CheckSymbol(i, j, false)) {
                        continue;
                    }

                    newField.SetSymbol(i, j, symbol);
                    if (newField.checkWin()) {
                        Cell[0] = i+1;
                        Cell[1] = j+1;
                        return;
                    }
                    
                    for (var i2 = 0; i2 < _horizontalSize; i2++) {
                        for (var j2 = 0; j2 < _verticalSize; j2++) {
                            var newField2 = newField.Copy();
                            if (newField2.CheckSymbol(i2, j2, false)) {
                                continue;
                            }

                            newField2.SetSymbol(i2, j2, symbolEmeny);
                            if (newField2.checkWin()) {
                                Cell[0] = i2+1;
                                Cell[1] = j2+1;
                                return;
                            }
                        }
                    }
                    
                    iter++;
                    coords[iter, 0] = i+1;
                    coords[iter, 1] = j+1;
                }
            }
            
            Cell[0] = coords[_rnd.Next(coords.Length/2), 0];
            Cell[1] = coords[_rnd.Next(coords.Length/2), 1];
        }
    }
}