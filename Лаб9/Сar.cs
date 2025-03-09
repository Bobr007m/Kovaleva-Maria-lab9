using System;

namespace Лаб9
{
    public class Car
    {
        // Часть 1
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
            FuelFlow = fuelFlow; // Используем свойство для установки значения
            FuelVolume = fuelVolume; // Используем свойство для установки значения
            count++;
        }

        // Третий конструктор (с значением по умолчанию для fuelVolume)
        public Car(double fuelFlow) : this(fuelFlow, 50) // Объем топлива по умолчанию 50 литров
        {
        }

        // Свойства для доступа к закрытым атрибутам
        public double FuelFlow
        {
            get { return fuelFlow; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Расход топлива не может быть отрицательным. Установлено значение 0.");
                    fuelFlow = 0;
                }
                else
                {
                    fuelFlow = value;
                }
            }
        }

        public double FuelVolume
        {
            get { return fuelVolume; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Объем топлива не может быть отрицательным. Установлено значение 0.");
                    fuelVolume = 0;
                }
                else
                {
                    fuelVolume = value;
                }
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
            if (car == null)
                throw new ArgumentNullException(nameof(car));

            return car.CalculateRemainingRange();
        }

        // Часть 2
        // Унарные операции
        public static Car operator ++(Car car)
        {
            car.FuelVolume += 1; // Увеличиваем объем топлива на 1 литр (заправка)
            return car;
        }

        public static Car operator --(Car car)
        {
            car.FuelVolume = Math.Max(0, car.FuelVolume - 1); // Уменьшаем объем топлива на 1 литр (расход)
            return car;
        }

        // Операции приведения типа
        public static explicit operator bool(Car car)
        {
            return car.CalculateRemainingRange() > 0; // Автомобиль может продолжать движение, если запас хода больше 0
        }

        public static implicit operator double(Car car)
        {
            return car.CalculateRemainingRange(); // Возвращаем запас хода
        }

        // Бинарные операции
        public static Car operator +(Car car, double fuel)
        {
            car.FuelVolume += fuel; // Добавляем топливо
            return car;
        }

        public static Car operator +(double fuel, Car car)
        {
            car.FuelVolume += fuel; // Добавляем топливо (коммутативность)
            return car;
        }

        public static bool operator ==(Car c1, Car c2)
        {
            if (ReferenceEquals(c1, c2))
                return true;
            if (c1 is null || c2 is null)
                return false;

            return c1.FuelFlow == c2.FuelFlow && c1.FuelVolume == c2.FuelVolume;
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
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + fuelFlow.GetHashCode();
                hash = hash * 23 + fuelVolume.GetHashCode();
                return hash;
            }
        }
    }
}