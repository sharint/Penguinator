# Penguinator
# Документация к проекту
<br> Работа с файлом map.json ("Assets/Json/map.json"):
<br> В файле находится 6 перменных:
1) width - ширина (число - ширина поля).
2) height - высота (число - высота поля).
3) walls - обозначение боковых стен, их количество равно width*height, в каждой из них сожердится 4 перменных (top,bot,left,right), которые обозночают положение боковой стены относительно конкретной ячейки поля, то есть в примере файла, у первого wall, bot и left равны true, это значит, что у первой ячейки боковые стены будут снизу и слева, а свехру и справа - нет. Порядковый номер боковых стен равен порядковому номеру позиции сектора.
4) playerPosition - позиция игрока (число - порядковый номер сектора).
5) blocksPositions - позиции блоков, которые нужно перетаскивать (число - порядковые номера секторов).
6) finishPositions - позиции финишных точек в которые нужно перетаскивать (число - порядковые номера секторов).

<br> На рисунке ниже представлено обозначение порядковых номеров позиций секторов(Снизу вверх и слева направо)

![Иллюстрация к проекту](https://github.com/sharint/Penguinator/blob/master/sectorsPositions.png)
