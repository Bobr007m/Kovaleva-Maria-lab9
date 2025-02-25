using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб9
{
    //Часть 3
    public class CarArray
    {
        private Car[] arr;
        private static int collectionCount = 0;

        // Конструктор без параметров
        public CarArray()
        {
            arr = new Car[0];
            collectionCount++;
        }

        // Конструктор с параметрами
        public CarArray(int size, double minFuelFlow, double maxFuelFlow, double minFuelVolume, double maxFuelVolume)
        {
            arr = new Car[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                double fuelFlow = minFuelFlow + rand.NextDouble() * (maxFuelFlow - minFuelFlow);
                double fuelVolume = minFuelVolume + rand.NextDouble() * (maxFuelVolume - minFuelVolume);
                arr[i] = new Car(fuelFlow, fuelVolume);
            }
            collectionCount++;
        }

        public int Length
        {
            get { return arr.Length; }
        }

        // Конструктор копирования
        public CarArray(CarArray other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            arr = new Car[other.arr.Length];
            for (int i = 0; i < other.arr.Length; i++)
            {
                arr[i] = new Car(other.arr[i].FuelFlow, other.arr[i].FuelVolume);
            }
            collectionCount++;
        }

        // Метод для просмотра элементов массива
        public void Display()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Автомобиль {i + 1}:");
                arr[i].Display();
            }
        }

        // Индексатор
        public Car this[int index]
        {
            get
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException("Индекс выходит за пределы массива.");
                return arr[index];
            }
            set
            {
                if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException("Индекс выходит за пределы массива.");
                arr[index] = value;
            }
        }

        // Статическая функция для подсчета количества созданных коллекций
        public static int GetCollectionCount()
        {
            return collectionCount;
        }

        // Метод для поиска автомобиля с минимальным запасом хода
        public Car FindCarWithMinRange()
        {
            if (arr.Length == 0)
                return null;

            Car minRangeCar = arr[0];
            double minRange = minRangeCar.CalculateRemainingRange();

            for (int i = 1; i < arr.Length; i++)
            {
                double currentRange = arr[i].CalculateRemainingRange();
                if (currentRange < minRange)
                {
                    minRange = currentRange;
                    minRangeCar = arr[i];
                }
            }

            return minRangeCar;
        }
    }
}