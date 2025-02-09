using Microsoft.VisualStudio.TestTools.UnitTesting;
using Лаб9;

namespace CarTests
{
    [TestClass]
    public class CarTests
    {
        // Тесты для класса Car

        [TestMethod]
        public void TestDefaultConstructor()
        {
            // Arrange & Act
            Car car = new Car();

            // Assert
            Assert.AreEqual(0, car.FuelFlow);
            Assert.AreEqual(0, car.FuelVolume);
        }

        [TestMethod]
        public void TestParameterizedConstructor()
        {
            // Arrange & Act
            Car car = new Car(8.5, 50);

            // Assert
            Assert.AreEqual(8.5, car.FuelFlow);
            Assert.AreEqual(50, car.FuelVolume);
        }

        [TestMethod]
        public void TestParameterizedConstructor_NegativeValues()
        {
            // Arrange & Act
            Car car = new Car(-8.5, -50);

            // Assert
            Assert.AreEqual(0, car.FuelFlow); // Ожидается, что отрицательные значения будут заменены на 0
            Assert.AreEqual(0, car.FuelVolume);
        }

        [TestMethod]
        public void TestFuelFlowProperty()
        {
            // Arrange
            Car car = new Car();

            // Act
            car.FuelFlow = 10.5;

            // Assert
            Assert.AreEqual(10.5, car.FuelFlow);
        }

        [TestMethod]
        public void TestFuelFlowProperty_NegativeValue()
        {
            // Arrange
            Car car = new Car();

            // Act
            car.FuelFlow = -10.5;

            // Assert
            Assert.AreEqual(0, car.FuelFlow); // Ожидается, что отрицательное значение будет заменено на 0
        }

        [TestMethod]
        public void TestFuelVolumeProperty()
        {
            // Arrange
            Car car = new Car();

            // Act
            car.FuelVolume = 60;

            // Assert
            Assert.AreEqual(60, car.FuelVolume);
        }

        [TestMethod]
        public void TestFuelVolumeProperty_NegativeValue()
        {
            // Arrange
            Car car = new Car();

            // Act
            car.FuelVolume = -60;

            // Assert
            Assert.AreEqual(0, car.FuelVolume); // Ожидается, что отрицательное значение будет заменено на 0
        }

        [TestMethod]
        public void TestCalculateRemainingRange_ZeroFuelFlow()
        {
            // Arrange
            Car car = new Car(0, 50);

            // Act
            double range = car.CalculateRemainingRange();

            // Assert
            Assert.AreEqual(0, range); // Если расход топлива равен 0, запас хода должен быть 0
        }

        [TestMethod]
        public void TestCalculateRemainingRange_NormalCase()
        {
            // Arrange
            Car car = new Car(10, 50);

            // Act
            double range = car.CalculateRemainingRange();

            // Assert
            Assert.AreEqual(500, range); // 50 / 10 * 100 = 500 км
        }

        [TestMethod]
        public void TestIncrementOperator()
        {
            // Arrange
            Car car = new Car(8.5, 50);

            // Act
            car++;

            // Assert
            Assert.AreEqual(8.6, car.FuelFlow); // Расход топлива увеличивается на 0.1
        }

        [TestMethod]
        public void TestDecrementOperator()
        {
            // Arrange
            Car car = new Car(8.5, 50);

            // Act
            car--;

            // Assert
            Assert.AreEqual(49, car.FuelVolume); // Объем топлива уменьшается на 1
        }

        [TestMethod]
        public void TestAdditionOperator()
        {
            // Arrange
            Car car = new Car(8.5, 50);

            // Act
            Car newCar = car + 10;

            // Assert
            Assert.AreEqual(60, newCar.FuelVolume); // Объем топлива увеличивается на 10
        }

        [TestMethod]
        public void TestAdditionOperator_WithNegativeValue()
        {
            // Arrange
            Car car = new Car(8.5, 50);

            // Act
            Car newCar = car + (-10);

            // Assert
            Assert.AreEqual(40, newCar.FuelVolume); // Объем топлива уменьшается на 10
        }

        [TestMethod]
        public void TestEqualityOperator()
        {
            // Arrange
            Car car1 = new Car(8.5, 50);
            Car car2 = new Car(8.5, 50);

            // Act & Assert
            Assert.IsTrue(car1 == car2); // Ожидается, что объекты равны
        }

        [TestMethod]
        public void TestInequalityOperator()
        {
            // Arrange
            Car car1 = new Car(8.5, 50);
            Car car2 = new Car(9.0, 50);

            // Act & Assert
            Assert.IsTrue(car1 != car2); // Ожидается, что объекты не равны
        }

        [TestMethod]
        public void TestBoolConversion_True()
        {
            // Arrange
            Car car = new Car(8.5, 50);

            // Act
            bool canReach = (bool)car;

            // Assert
            Assert.IsTrue(canReach); // Ожидается, что автомобиль может доехать до заправки
        }

        [TestMethod]
        public void TestBoolConversion_False()
        {
            // Arrange
            Car car = new Car(8.5, 4); // Объем топлива меньше 5

            // Act
            bool canReach = (bool)car;

            // Assert
            Assert.IsFalse(canReach); // Ожидается, что автомобиль не может доехать до заправки
        }

        [TestMethod]
        public void TestDoubleConversion()
        {
            // Arrange
            Car car = new Car(8.5, 50);

            // Act
            double hundredsOfKm = (double)car;

            // Assert
            Assert.IsTrue(hundredsOfKm > 0); // Ожидается положительное значение
        }
    }

    [TestClass]
    public class CarArrayTests
    {
        // Тесты для класса CarArray

        [TestMethod]
        public void TestDefaultConstructor()
        {
            // Arrange & Act
            Car.CarArray carArray = new Car.CarArray();

            // Assert
            Assert.AreEqual(0, carArray.Length); // Ожидается пустой массив
        }

        [TestMethod]
        public void TestParameterizedConstructor()
        {
            // Arrange & Act
            Car.CarArray carArray = new Car.CarArray(3, 5, 10, 40, 60);

            // Assert
            Assert.AreEqual(3, carArray.Length); // Ожидается массив из 3 элементов
        }

        [TestMethod]
        public void TestCopyConstructor()
        {
            // Arrange
            Car.CarArray originalArray = new Car.CarArray(3, 5, 10, 40, 60);

            // Act
            Car.CarArray copiedArray = new Car.CarArray(originalArray);

            // Assert
            Assert.AreEqual(originalArray.Length, copiedArray.Length); // Ожидается, что массивы равны
        }

        [TestMethod]
        public void TestIndexer_ValidIndex()
        {
            // Arrange
            Car.CarArray carArray = new Car.CarArray(3, 5, 10, 40, 60);

            // Act & Assert
            Assert.IsNotNull(carArray[0]); // Ожидается, что элемент существует
        }

        [TestMethod]
        public void TestIndexer_InvalidIndex()
        {
            // Arrange
            Car.CarArray carArray = new Car.CarArray(3, 5, 10, 40, 60);

            // Act & Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => carArray[10]); // Ожидается исключение
        }
    }
}