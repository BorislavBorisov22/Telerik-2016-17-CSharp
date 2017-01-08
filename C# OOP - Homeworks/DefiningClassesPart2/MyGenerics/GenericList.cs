namespace MyGenerics
{
    using System;
    using System.Text;

    public class GenericList<T> where T : IComparable
    {
        private T[] genericList;
        private int elementsCount;

        public GenericList(int capacity)
        {
            this.genericList = new T[capacity];
            this.ElementsCount = 0;
        }

        public int ElementsCount
        {
            get
            {
                return this.elementsCount;
            }

            private set
            {
                this.elementsCount = value;
            }
        }

        public int Capacity
        {
            get { return this.genericList.Length; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.ElementsCount)
                {
                    throw new IndexOutOfRangeException("Index was outside the list boundaries");
                }

                return this.genericList[index];
            }

            set
            {
                if (index < 0 || index >= this.ElementsCount)
                {
                    throw new IndexOutOfRangeException("Index was outside the list boundaries");
                }

                this.genericList[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.ElementsCount >= this.genericList.Length)
            {
                this.ResizeList();
            }

            this.genericList[this.ElementsCount] = element;
            this.ElementsCount++;
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index > this.elementsCount)
            {
                throw new ArgumentOutOfRangeException("Index must be within the bounds of the list");
            }

            if (this.ElementsCount >= this.genericList.Length)
            {
                this.ResizeList();
            }

            var tempList = new T[this.genericList.Length];
            for (int i = 0; i <= this.ElementsCount; i++)
            {
                if (i < index)
                {
                    tempList[i] = this.genericList[i];
                }
                else if (i == index)
                {
                    tempList[i] = element;
                }
                else
                {
                    tempList[i] = this.genericList[i - 1];
                }
            }

            this.genericList = tempList;
            this.ElementsCount++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.ElementsCount)
            {
                throw new IndexOutOfRangeException("Index must be non-negative and less than the size of the list");
            }

            var tempList = new T[this.genericList.Length];

            for (int i = 0; i < this.ElementsCount; i++)
            {
                if (i != index)
                {
                    if (i < index)
                    {
                        tempList[i] = this.genericList[i];
                    }
                    else
                    {
                        tempList[i - 1] = this.genericList[i];
                    }
                }
            }

            this.genericList = tempList;
            this.ElementsCount--;
        }

        public int GetElementIndex(T searchedElement)
        {
            // iterate through all elements of the generic list
            for (int i = 0; i < this.ElementsCount; i++)
            {
                // if element is found return index
                if (this.genericList[i].CompareTo(searchedElement) == 0)
                {
                    return i;
                }
            }

            // if element is not found return -1
            return -1;
        }

        public T Max()
        {
            if (this.ElementsCount == 0)
            {
                throw new ArgumentException("List is empty. Cannot use max on an empty sequence");
            }

            T max = this.genericList[0];

            for (int i = 1; i < this.ElementsCount; i++)
            {
                if (max.CompareTo(this.genericList[i]) < 0)
                {
                    max = this.genericList[i];
                }
            }

            return max;
        }

        public T Min()
        {
            if (this.ElementsCount == 0)
            {
                throw new ArgumentException("List is empty. Cannot use max on an empty sequence");
            }

            T min = this.genericList[0];

            for (int i = 1; i < this.ElementsCount; i++)
            {
                if (min.CompareTo(this.genericList[i]) > 0)
                {
                    min = this.genericList[i];
                }
            }

            return min;
        }

        public void Clear()
        {
            this.genericList = new T[this.genericList.Length];
            this.ElementsCount = 0;
        }

        public void ResizeList()
        {
            var tempList = new T[this.genericList.Length * 2];

            for (int i = 0; i < this.genericList.Length; i++)
            {
                tempList[i] = this.genericList[i];
            }

            this.genericList = tempList;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            for (int i = 0; i < this.ElementsCount; i++)
            {
                output.AppendFormat("{0} ", this.genericList[i]);
            }

            return output.ToString().Trim();
        }
    }
}
