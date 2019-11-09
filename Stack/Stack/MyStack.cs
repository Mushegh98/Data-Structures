using System;

namespace Stack
{
    /// <summary>
    /// Stack предстовляет коллекцию одинакого типа , и работает как LIFO(Last In First Out)
    /// </summary>
    class MyStack
    {
            object[] array;
            private static int size;
            private int count = 0;
            private int top = -1;
        
            /// <summary>
            /// Инициализирует новый экземпляр класса, который является пустым и имеет начальную емкость по умолчанию
            /// </summary>
            public MyStack()
            {
                size = 1000;
                array = new object[size];
            }
            
            /// <summary>
            /// Инициализирует новый экземпляр класса ,который является пустым и имеет начальную емкость по переданному аргументу
            /// </summary>
            /// <param name="SizeStack"></param>
            public MyStack(int SizeStack)
            {
                size = SizeStack;
                array = new object[size];
            }
            
            /// <summary>
            /// Количество элементов Стека
            /// </summary>
            public int Count
            {
                get { return count; }
            }
            /// <summary>
            /// Полностю очищает Стек
            /// </summary>
            public void Clear()
            {
                top = -1;
                count = 0;
            }
            /// <summary>
            /// Удаляет последный элемент Стека
            /// </summary>
            public void Pop()
            {
                if (top != -1)
                {
                    array[top--] = null;
                    count--;
                }
                else throw new IndexOutOfRangeException();
            }
            /// <summary>
            /// Добавляет element в Стек
            /// </summary>
            /// <param name="element"></param>
            public void Push(object element)
            {
                if (top != array.Length - 1)
                {
                    array[++top] = element;
                    count++;
                }
                else throw new IndexOutOfRangeException();
            }
            
            /// <summary>
            /// Возвращает последный элемент Стека
            /// </summary>
            /// <returns></returns>
            public object Top()
            {
                if (top >= 0)
                {
                    return array[top];
                }
                else throw new IndexOutOfRangeException();
            }
        
    }

}
