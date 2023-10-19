using System;
using System.Data;

int[,] expArray = ArrayCreation(4, 5); /// Создание и заполнение массива с указанными размерами
ArrayOutPut(ArrayMirror(expArray)); /// Вывод отзеркаленного массива

int[,] ArrayMirror(int[,] array) /// Метод меняющий местами значения полученного массива, возвращающий отзеркаленную копию
{
    int[,] tempArr = array; ///Создание временного массива, что бы избежать деформации исходного
    int tempInt;

    for (int i = 0; i < tempArr.GetLength(0); i++) /// Цикл переберающий элементы массива
    {
        for (int j = 0; j < tempArr.GetLength(1) / 2; j++)
        {
            tempInt = tempArr[i, j]; /// Копирование элемента
            tempArr[i, j] = tempArr[i, tempArr.GetLength(1) - j - 1]; /// Перенос противоположного элемента на место первого
            tempArr[i, tempArr.GetLength(1) - j - 1] = tempInt; /// Замена перенесенного элемента созданной копией
        }

    }

    return tempArr; /// Возвращаем результат метода в виде массива
}
void ArrayOutPut(int[,] array) /// Метод вывода полученного массива в консоль. Ничего не возвращает.
{
    int arrRow = array.GetLength(0); /// Создание переменных размера строк и столбцов
    int arrColumn = array.GetLength(1);

    for (int i = 0; i < arrRow; i++) /// Цикл переберающий элементы массива
    {
        for (int j = 0; j < arrColumn; j++)
        {
            Console.Write(array[i, j] + " "); /// Вывод элемантов массива в консоль
        }
        Console.WriteLine();
    }
}
int[,] ArrayCreation(int rows, int columns) /// Метод создания и заполнения массива указанных размеров
{
    int arrRow = rows; int arrColumn = columns; /// Переменные размера строк и столбцов массива
    int[,] array = new int[arrRow, arrColumn]; /// Создание массива
    int tempInt; /// Временная переменная значения int

    for (int i = 0; i < arrRow; i++)
    {
        for (int j = 0; j < arrColumn; j++)
        {
            while (true) /// Цикл проверки полученных значений, повторяется до ввода корректного значения
            {
                Console.WriteLine($"Enter number [{i + 1},{j + 1}]: ");
                var input = Console.ReadLine();

                if (int.TryParse(input, out tempInt)) /// Проверка перевода полученного значения в int
                    break; /// Прерывается в случае удачного перевода
                else /// В случае неудачи выдает ошибку и повторяет с начала
                {
                    Console.WriteLine("[ERROR]: Invalid input");
                    Console.Write("Retry enter number: ");
                }
            }
            array[i, j] = tempInt; /// Присваивание элементу массива полученное значение
        }
        Console.Clear();
    }

    return array; /// Возвращаем итоговый массив
}