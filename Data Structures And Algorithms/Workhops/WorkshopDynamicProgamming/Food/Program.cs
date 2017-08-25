using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food
{
    public class Program
    {
        public static void Main()
        {
            int kolyoStomachCapacity = int.Parse(Console.ReadLine());
            int foodsCount = int.Parse(Console.ReadLine());

            var queue = new PriorityQueue<Food>();

            var foods = new Food[foodsCount];
            for (int i = 0; i < foodsCount; i++)
            {
                var line = Console.ReadLine().Split(' ');
                foods[i] = new Food(line[0], int.Parse(line[1]), int.Parse(line[2]));
                queue.Enqueue(foods[i]);
            }

            var sum = 0;
            int freeSpace = kolyoStomachCapacity;
            var result = new StringBuilder();
            while (!queue.IsEmpty)
            {
                var current = queue.Dequeue();
                while (!queue.IsEmpty && freeSpace - current.Weight < 0)
                {
                    current = queue.Dequeue();
                }

                if (queue.IsEmpty && freeSpace - current.Weight < 0)
                {
                    break;
                }

                for (int i = foods.Length - 1; i >= 0; i--)
                {
                    if (foods[i].Name == current.Name)
                    {
                        result.AppendLine(foods[i].Name);
                        break;
                    }
                }

                sum += current.Taste;
                freeSpace -= current.Weight;
            }

            Console.WriteLine(sum);
            Console.WriteLine(result.ToString().Trim());
        }
    }

    public class PriorityQueue<T>
        where T : IComparable<T>
    {
        private List<T> heap;
        private Func<T, T, bool> compare;

        public PriorityQueue()
        {
            this.heap = new List<T>
            {
                default(T)
            };

            this.compare = (x, y) => x.CompareTo(y) < 0;
        }

        public T Top => heap[1];
        public int Count => heap.Count - 1;
        public bool IsEmpty => Count == 0;

        public void Enqueue(T value)
        {
            var index = heap.Count; // index where inserted
            heap.Add(value);

            while (index > 1 && compare(value, heap[index / 2]))
            {
                heap[index] = heap[index / 2];
                index /= 2;
            }

            heap[index] = value;
        }

        public T Dequeue()
        {
            var toReturn = heap[1];
            var value = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            if (!this.IsEmpty)
            {
                this.HeapifyDown(1, value);
            }

            return toReturn;
        }

        private void HeapifyDown(int index, T value)
        {
            while (index * 2 + 1 < heap.Count)
            {
                var smallerKidIndex = compare(heap[index * 2], heap[index * 2 + 1])
                    ? index * 2
                    : index * 2 + 1;
                if (compare(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
                else
                {
                    break;
                }
            }

            if (index * 2 < heap.Count)
            {
                var smallerKidIndex = index * 2;
                if (compare(heap[smallerKidIndex], value))
                {
                    heap[index] = heap[smallerKidIndex];
                    index = smallerKidIndex;
                }
            }

            heap[index] = value;
        }
    }

    public class Food : IComparable<Food>
    {
        public Food(string name, int weight, int taste)
        {
            this.Name = name;
            this.Weight = weight;
            this.Taste = taste;
        }

        public int Weight { get; set; }

        public int Taste { get; set; }

        public string Name { get; set; }

        public int CompareTo(Food other)
        {
            return other.Taste.CompareTo(this.Taste);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
