using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб9
{
    public class Car
    {
        //Часть 1
        private double fuelFlow; // Расход топлива в литрах на 100 км
        private double fuelVolume; // Объем топлива в баке в литрах
                                  
        private static int count = 0; // Статическая переменная для подсчета количества созданных объектов

        // Конструктор без параметров
        public Car()
        {
            fuelFlow = 0;
            fuelVolume = 0;
            count++;
        }

        // Конструктор с параметрами
        public Car(double fuelFlow, double fuelVolume)
        {
            if (fuelFlow < 0 || fuelVolume < 0)
                Console.WriteLine("Расход топлива и объем бака не могут быть отрицательными.");

            this.fuelFlow = fuelFlow;
            this.fuelVolume = fuelVolume;
            count++;
        }

        // Свойства для доступа к закрытым атрибутам
        public double FuelFlow
        {
            get { return fuelFlow; }
            set
            {
                if (value < 0)
                    Console.WriteLine ("Расход топлива не может быть отрицательным.");
                fuelFlow = value;
            }
        }
        public double FuelVolume
        {
            get { return fuelVolume; }
            set
            {
                if (value < 0)
                    Console.WriteLine ("Объем топлива не может быть отрицательным.");
                fuelVolume = value;
            }
        }
        // Метод для вывода атрибутов
        public void Display()
        {
            Console.WriteLine($"Расход топлива: {fuelFlow} л/100 км, Объем топлива: {fuelVolume} л");
        }

        // Статическая функция для подсчета количества созданных объектов
        public static int GetCount()
        {
            return count;
        }
        // Метод для вычисления оставшегося запаса хода
        public double CalculateRemainingRange()
        {
            if (fuelFlow == 0)
                return 0;

            return Math.Round((fuelVolume / fuelFlow) * 100, 3);
        }

        // Статическая функция для вычисления запаса хода
        public static double CalculateRemainingRange(Car car)
        {
            return car.CalculateRemainingRange();
        }
        //Часть 2
        // Унарные операции
        public static Car operator ++(Car car)
        {
            car.fuelFlow += 0.1;
            return car;
        }

        public static Car operator --(Car car)
        {
            car.fuelVolume = Math.Max(0, car.fuelVolume - 1);
            return car;
        }
        // Операции приведения типа
        public static explicit operator bool(Car car)
        {
            double range = car.CalculateRemainingRange();
            return range >= 100 && car.fuelVolume >= 5;
        }

        public static implicit operator double(Car car)
        {
            if (car.fuelVolume < 5)
                return -1;

            double requiredFuel = car.fuelFlow * 1; // 100 км
            double remainingFuel = car.fuelVolume - 5;
            return Math.Round(remainingFuel / requiredFuel, 3);
        }
        // Бинарные операции
        public static Car operator +(Car car, double fuel)
        {
            car.fuelVolume += fuel;
            return car;
        }

        public static Car operator +(double fuel, Car car)
        {
            car.fuelFlow -= fuel;
            return car;
        }

        public static bool operator ==(Car c1, Car c2)
        {
            return c1.fuelFlow == c2.fuelFlow && c1.fuelVolume == c2.fuelVolume;
        }

        public static bool operator !=(Car c1, Car c2)
        {
            return !(c1 == c2);
        }
        // Переопределение метода Equals
        public override bool Equals(object obj)
        {
            if (obj is Car car)
                return this == car;
            return false;
        }
        // Переопределение метода GetHashCode
        public override int GetHashCode()
        {
            unchecked // Позволяет избежать переполнения при вычислении хэш-кода
            {
                int hash = 17;
                hash = hash * 23 + fuelFlow.GetHashCode();
                hash = hash * 23 + fuelVolume.GetHashCode();
                return hash;
            }
        }
        //Часть 3
        public class CarArray
        {
            private Car[] arr;
            private static int collectionCount = 0;

            public int Length { get; set; }

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
            // Конструктор копирования
            public CarArray(CarArray other)
            {
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
        }
    }
}
