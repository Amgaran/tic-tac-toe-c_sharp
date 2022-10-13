using System;

namespace TicTacToe {
    public class Field {
        private readonly int _horizontalSize;
        private readonly int _verticalSize;
        private char[, ] _cells;

        public Field(int horizontalSize, int verticalSize) {
            _horizontalSize = horizontalSize;
            _verticalSize = verticalSize;
            _cells = new char[_horizontalSize, _verticalSize];
            for (var i = 0; i < _horizontalSize; i++) {
                for (var j = 0; j < _verticalSize; j++) {
                    _cells[i, j] = ' ';
                }
            }
            printField();
        }

        public void SetSymbol(int x, int y, char symbol) {
            _cells[x, y] = symbol;
            printField();
        }

        public bool CheckSymbol(int x, int y) {
            if (x < 0 || x > _horizontalSize-1 || y < 0 || y > _verticalSize-1) {
                Console.WriteLine("Такой точки нет на поле. Введите другие координаты.");
                return true;
            } 
            var flag = _cells[x, y] != ' ';
            if (flag) {
                Console.WriteLine("В данной клетке уже стоит другой символ. Введите другие координаты.");
            }
            return flag;
        }

        private bool CheckRow(int x, int y) {
            return (_cells[x - 1, y] == _cells[x, y]) && (_cells[x, y] == _cells[x + 1, y]);
        }

        private bool CheckColumn(int x, int y) {
            return (_cells[x, y-1] == _cells[x, y]) && (_cells[x, y] == _cells[x, y+1]);
        }

        private bool CheckDiags(int x, int y) {
            var top = (_cells[x - 1, y - 1] == _cells[x, y]) && (_cells[x, y] == _cells[x + 1, y + 1]);
            var bottom = (_cells[x - 1, y + 1] == _cells[x, y]) && (_cells[x, y] == _cells[x + 1, y - 1]);
            return top || bottom;
        }

        public bool checkWin() {
            var flag = false;

            for (var i = 1; i < _horizontalSize-1; i++) {
                if (_cells[i, 0] == ' ') {
                    continue;
                }
                flag = CheckRow(i, 0);
                if (flag) {
                    return flag;
                }
            }
            
            for (var i = 1; i < _horizontalSize-1; i++) {
                if (_cells[i, _verticalSize-1] == ' ') {
                    continue;
                }
                flag = CheckRow(i, _verticalSize-1);
                if (flag) {
                    return flag;
                }
            }
            
            for (var i = 1; i < _verticalSize-1; i++) {
                if (_cells[0, i] == ' ') {
                    continue;
                }
                flag = CheckColumn(0, i);
                if (flag) {
                    return flag;
                }
            }
            
            for (var i = 1; i < _verticalSize-1; i++) {
                if (_cells[_horizontalSize-1, i] == ' ') {
                    continue;
                }
                flag = CheckColumn(_horizontalSize-1, i);
                if (flag) {
                    return flag;
                }
            }
            
            for (var i = 1; i < _horizontalSize-1; i++) {
                for (var j = 1; j < _verticalSize-1; j++) {
                    if (_cells[i, j] == ' ') {
                        continue;
                    }
                    var flagRow = CheckRow(i,j);
                    var flagColumn = CheckColumn(i,j);
                    var flagDiags = CheckDiags(i, j);
                    flag = flagRow || flagColumn || flagDiags;
                    if (flag) {
                        return flag;
                    }
                }
            }

            return flag;
        }

        private void printField() {
            for (var j = 0; j < _verticalSize; j++) {
                for (var i = 0; i < _horizontalSize; i++) {
                    Console.Write(_cells[i, j]);
                    Console.Write('|');
                }
                Console.Write('\n');
                for (var i = 0; i < _horizontalSize; i++) {
                    Console.Write('-');
                    Console.Write('-');
                }
                Console.Write('\n');
            }
        }
    }
}