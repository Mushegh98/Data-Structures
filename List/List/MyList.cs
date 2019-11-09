using System;
using System.Collections;
using System.Collections.Generic;


namespace List
{
    /// <summary>
    /// Строго типизированный список обьектов, который имеет много функцией для работы с ними
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyList<T> : IEnumerable<T>
    {
        T[] mylist;
        int capacity;
        private int count;
        /// <summary>
        /// Инициализирует коллекцию , который является пустым и имеет начальную емкость по умолчанию
        /// </summary>
        public MyList()
        {
            capacity = 4;
            count = 0;
            mylist = new T[capacity];
        }
        /// <summary>
        /// Инициализирует коллекцию , который является пустым и имеет начальную емкость по предаваемую аргументу
        /// </summary>
        /// <param name="capacity"></param>
        public MyList(int capacity)
        {
            this.capacity = capacity;
            count = 0;
            mylist = new T[capacity];
        }
        /// <summary>
        /// Возвращает количевства обьектов коллекции
        /// </summary>
        public int Count { get { return count; } }
        /// <summary>
        /// Можно задавать или получить емкость коллекции
        /// </summary>
        public int Capacity { get { return capacity; } set { capacity = value; } }
        /// <summary>
        /// Добавляет элемент в конец коллекции
        /// </summary>
        /// <param name="element"></param>
        public void Add(T element)
        {
            
            if(count<capacity)
            {
                mylist[count] = element;
                count++;
            }
            else
            {
                capacity *= 2;
                T[] newmylist = new T[capacity];
                mylist.CopyTo(newmylist, 0);
                mylist = new T[capacity];
                newmylist.CopyTo(mylist, 0);
                Add(element);
            }
        }
        /// <summary>
        /// Добовлят элемент в коллекцию по передаваемую индексу
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        public void Insert(int index,T element)
        {
            if(index>count-1)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                int copysize = count - index;
                T[] newarray = new T[copysize];

               for(int i=index,j=0;i<count;i++,j++)
                {
                   
                   newarray[j] = mylist[i];
                    
                }
                mylist[index] = element;
               
                for (int i = index + 1, j = 0; i <= count; i++, j++)
                {
                    link:
                    if (count < capacity)
                    {
                        mylist[i] = newarray[j];
                        
                    }
                    else
                    {
                        capacity *= 2;
                        T[] newmylist = new T[capacity];
                        mylist.CopyTo(newmylist, 0);
                        mylist = new T[capacity];
                        newmylist.CopyTo(mylist, 0);
                        
                        goto link;
                    }

                }
            }
            count++;

        }
       
        /// <summary>
        /// Очищает Коллекцию
        /// </summary>
        public void Clear()
        {
            count = 0;
            capacity = 4;
            mylist = new T[capacity];
        }
        
        /// <summary>
        /// Ищет элемент из коллекции
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool Contains(T element)
        {
            foreach (var item in mylist)
            {
                if(item.Equals(element))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Копирует коллекцию на массив передаваемую по аргументу
        /// </summary>
        /// <param name="array"></param>
        public void CopyTo(T[] array)
        {
            for(int i = 0, j = 0; i < count; i++, j++)
            {
                array[j] = mylist[i];
            }

        }
        /// <summary>
        /// Ищет элемент из колекции и возвращает его индекс
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public int IndexOf(T element)
        {
            for(int i=0;i<mylist.Length;i++)
            {
                if(mylist[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Удаляет элемент из коллекции передаваемую по аргумента
        /// </summary>
        /// <param name="element"></param>
        public void Remove(T element)
        {
           int index= IndexOf(element);
            if(index==-1)
            {
                return;
            }
            for(int i=index,j=index+1;j<=count;i++,j++)
            {
                mylist[i] = mylist[j];
            }
            count--;
            if(count==capacity/2)
            {
                capacity = count;
                T[] newarray = new T[capacity];
                for(int i=0,j=0;i<count;i++,j++)
                {
                    newarray[j] = mylist[i];
                }
                mylist = new T[capacity];
                newarray.CopyTo(mylist, 0);
            }
        }
     
        /// <summary>
        /// Изменяет порядок элементов коллекции на обратный
        /// </summary>
        public void Reverse()
        {
            T[] array = new T[count];
            for(int i=0,j=0;i<count;i++,j++)
            {
                array[j] = mylist[i];
            }
            mylist = new T[capacity];
            for(int i=array.Length-1,j=0;i>=0;i--,j++)
            {
                mylist[j] = array[i];
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < count)
                {
                    return mylist[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index < count)
                {
                    mylist[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }



        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return mylist[i];
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return mylist[i];
            }
        }
    }
}
