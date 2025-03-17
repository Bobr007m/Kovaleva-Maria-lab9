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
            // Пример использования
            // Подсчет количества созданных объектов
            Console.WriteLine($"Количество созданных автомобилей: {Car.GetCount()}"); // 3
            // Создание объектов класса Car
            Car car1 = new Car();
            Car car2 = new Car(8.5, 50);
            Car car3 = new Car(8); // Третий конструктор (с объемом топлива по умолчанию)
                                   // Установка некорректных значений через свойства
            car3.FuelFlow = -5; // Расход топлива не может быть отрицательным. Установлено значение 0.
            car3.FuelVolume = -10; // Объем топлива не может быть отрицательным. Установлено значение 0.
            car3.Display(); // Расход топлива: 0 л/100 км, Объем топлива: 0 л

            // Вывод информации о созданных объектах
            car1.Display();
            car2.Display();
            car3.Display(); // Расход топлива: 8 л/100 км, Объем топлива: 50 л

            // Демонстрация работы статической и нестатической функций
            Console.WriteLine($"Запас хода car1: {car1.CalculateRemainingRange()} км");
            Console.WriteLine($"Запас хода car2 (статический метод): {Car.CalculateRemainingRange(car2)} км");

            // Подсчет количества созданных объектов
            Console.WriteLine($"Количество созданных объектов: {Car.GetCount()}");
            //Часть 2
            // Создание объектов
            Car car4 = new Car(8.5, 50);
            Car car5 = new Car(8.5, 50);

            // Демонстрация перегруженных операций
            car4++;
            car5--;

            Console.WriteLine($"car3 после ++: Расход топлива: {car4.FuelFlow} л/100 км");
            Console.WriteLine($"car4 после --: Объем топлива: {car5.FuelVolume} л");

            // Операции приведения типа
            bool canReachGasStation = (bool)car4;
            double hundredsOfKm = (double)car4;

            Console.WriteLine($"Может ли car4 доехать до заправки: {canReachGasStation}");
            Console.WriteLine($"Сотни км до заправки для car4: {hundredsOfKm}");

            // Бинарные операции
            car4 = car4 + 10;
            car5 = 0.5 + car5;

            Console.WriteLine($"car5 после добавления топлива: Объем топлива: {car4.FuelVolume} л");
            Console.WriteLine($"car6 после уменьшения расхода: Расход топлива: {car5.FuelFlow} л/100 км");

            // Сравнение объектов
            Console.WriteLine($"car1 == car2: {car4 == car5}");
            Console.WriteLine($"car1 != car2: {car4 != car5}");
            //Часть 3
            // Создание массива вручную
            try
            {
                // Запрашиваем у пользователя количество автомобилей
                Console.Write("Введите количество автомобилей: ");
                int count = int.Parse(Console.ReadLine());

                // Создаем массив автомобилей
                CarArray manualArray = new CarArray(count);

                // Заполняем массив вручную
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine($"\nВведите данные для автомобиля {i + 1}:");

                    double fuelFlow, fuelVolume;

                    // Ввод расхода топлива
                    while (true)
                    {
                        Console.Write("Введите расход топлива (л/100 км): ");
                        if (double.TryParse(Console.ReadLine(), out fuelFlow) && fuelFlow > 0)
                            break;
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
                    }

                    // Ввод объема топлива
                    while (true)
                    {
                        Console.Write("Введите объем топлива (л): ");
                        if (double.TryParse(Console.ReadLine(), out fuelVolume) && fuelVolume > 0)
                            break;
                        Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное число.");
                    }

                    // Создаем объект Car и добавляем его в массив
                    manualArray[i] = new Car(fuelFlow, fuelVolume);
                }

                // Демонстрация обращения к индексатору по метке set
                Console.WriteLine("\nДемонстрация изменения элемента массива через индексатор:");
                manualArray[1] = new Car(8, 70); // Изменяем второй элемент массива
                Console.WriteLine("Элемент массива изменен.");

                // Демонстрация использования функции FindCarWithMinRange
                Console.WriteLine("\nПоиск автомобиля с минимальным запасом хода:");
                Car carWithMinRange = manualArray.FindCarWithMinRange();
                if (carWithMinRange != null)
                {
                    Console.WriteLine("Автомобиль с минимальным запасом хода:");
                    carWithMinRange.Display();
                }
                else
                {
                    Console.WriteLine("Массив пуст.");
                }

                // Вывод всех автомобилей
                Console.WriteLine("\nСписок всех автомобилей:");
                manualArray.Display();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}


