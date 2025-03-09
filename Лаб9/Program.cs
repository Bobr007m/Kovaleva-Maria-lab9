// Нестатическая функция: Это метод объекта, который работает с конкретным экземпляром класса. Он имеет доступ к атрибутам объекта через ключевое слово this.
// //Статическая функция: Это метод класса, который не привязан к конкретному экземпляру. Он может быть вызван без создания объекта и не имеет доступа к нестатическим атрибутам класса.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Лаб9.Car;

namespace Лаб9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Часть 1
            // Создание объектов класса Car
            Car car1 = new Car();
            Car car2 = new Car(8.5, 50);

            // Вывод информации о созданных объектах
            car1.Display();
            car2.Display();

            // Демонстрация работы статической и нестатической функций
            Console.WriteLine($"Запас хода car1: {car1.CalculateRemainingRange()} км");
            Console.WriteLine($"Запас хода car2 (статический метод): {Car.CalculateRemainingRange(car2)} км");

            // Подсчет количества созданных объектов
            Console.WriteLine($"Количество созданных объектов: {Car.GetCount()}");
            //Часть 2
            // Создание объектов
            Car car3 = new Car(8.5, 50);
            Car car4 = new Car(8.5, 50);

            // Демонстрация перегруженных операций
            car1++;
            car2--;

            Console.WriteLine($"car3 после ++: Расход топлива: {car3.FuelFlow} л/100 км");
            Console.WriteLine($"car4 после --: Объем топлива: {car4.FuelVolume} л");

            // Операции приведения типа
            bool canReachGasStation = (bool)car1;
            double hundredsOfKm = (double)car1;

            Console.WriteLine($"Может ли car1 доехать до заправки: {canReachGasStation}");
            Console.WriteLine($"Сотни км до заправки для car1: {hundredsOfKm}");

            // Бинарные операции
            Car car5 = car3 + 10;
            Car car6 = 0.5 + car4;

            Console.WriteLine($"car5 после добавления топлива: Объем топлива: {car5.FuelVolume} л");
            Console.WriteLine($"car6 после уменьшения расхода: Расход топлива: {car6.FuelFlow} л/100 км");

            // Сравнение объектов
            Console.WriteLine($"car3 == car4: {car3 == car4}");
            Console.WriteLine($"car3 != car4: {car3 != car4}");
            //Часть 3
            // Создание массива вручную
            CarArray manualArray = new CarArray(3);
            manualArray[0] = new Car(5, 40);
            manualArray[1] = new Car(6, 50);
            manualArray[2] = new Car(7, 60);

            // Демонстрация обращения к индексатору по метке set
            manualArray[1] = new Car(8, 70); // Использование индексатора для установки значения

            // Демонстрация использования функции FindCarWithMinRange
            Car carWithMinRange = manualArray.FindCarWithMinRange();
            if (carWithMinRange != null)
            {
                Console.WriteLine("Автомобиль с минимальным запасом хода:");
                carWithMinRange.Display();
            }

            // Вывод всех автомобилей
            manualArray.Display();
            
            // Подсчет количества созданных объектов и коллекций
            Console.WriteLine($"Количество созданных объектов: {Car.GetCount()}");
           
        Console.ReadLine();
        }

        // Функция для поиска автомобиля с наименьшим запасом хода
        static Car FindCarWithMinRange(CarArray carArray)
        {
            Car minRangeCar = null;
            double minRange = double.MaxValue;

            for (int i = 0; i < carArray.Length; i++)
            {
                double range = carArray[i].CalculateRemainingRange();
                if (range < minRange)
                {
                    minRange = range;
                    minRangeCar = carArray[i];
                }
            }

            return minRangeCar;
        }

    }
}

