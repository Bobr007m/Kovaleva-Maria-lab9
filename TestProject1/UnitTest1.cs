using Microsoft.VisualStudio.TestTools.UnitTesting;
using Лаб9;

[TestClass]
public class CarTests
{
    [TestMethod]
    public void Constructor_Default_InitializesCorrectly()
    {
        var car = new Car();
        Assert.AreEqual(0, car.FuelFlow);
        Assert.AreEqual(0, car.FuelVolume);
    }

    [TestMethod]
    public void Constructor_WithParameters_InitializesCorrectly()
    {
        var car = new Car(10, 50);
        Assert.AreEqual(10, car.FuelFlow);
        Assert.AreEqual(50, car.FuelVolume);
    }

    [TestMethod]
    public void Constructor_WithDefaultFuelVolume_InitializesCorrectly()
    {
        var car = new Car(10);
        Assert.AreEqual(10, car.FuelFlow);
        Assert.AreEqual(50, car.FuelVolume); // По умолчанию 50 литров
    }
    [TestMethod]
    public void FuelFlow_SetNegativeValue_SetsToZero()
    {
        var car = new Car();
        car.FuelFlow = -10;
        Assert.AreEqual(0, car.FuelFlow);
    }

    [TestMethod]
    public void FuelVolume_SetNegativeValue_SetsToZero()
    {
        var car = new Car();
        car.FuelVolume = -20;
        Assert.AreEqual(0, car.FuelVolume);
    }
    [TestMethod]
    public void CalculateRemainingRange_WithZeroFuelFlow_ReturnsZero()
    {
        var car = new Car(0, 50);
        Assert.AreEqual(0, car.CalculateRemainingRange());
    }

    [TestMethod]
    public void CalculateRemainingRange_WithPositiveValues_ReturnsCorrectRange()
    {
        var car = new Car(10, 50);
        Assert.AreEqual(500, car.CalculateRemainingRange());
    }
    [TestMethod]
    public void OperatorIncrement_IncreasesFuelVolumeByOne()
    {
        var car = new Car(10, 50);
        car++;
        Assert.AreEqual(51, car.FuelVolume);
    }

    [TestMethod]
    public void OperatorDecrement_DecreasesFuelVolumeByOne()
    {
        var car = new Car(10, 50);
        car--;
        Assert.AreEqual(49, car.FuelVolume);
    }

    [TestMethod]
    public void OperatorDecrement_DoesNotDecreaseBelowZero()
    {
        var car = new Car(10, 0);
        car--;
        Assert.AreEqual(0, car.FuelVolume);
    }
    [TestMethod]
    public void ExplicitOperatorBool_WithPositiveRange_ReturnsTrue()
    {
        var car = new Car(10, 50);
        Assert.IsTrue((bool)car);
    }

    [TestMethod]
    public void ExplicitOperatorBool_WithZeroRange_ReturnsFalse()
    {
        var car = new Car(10, 0);
        Assert.IsFalse((bool)car);
    }

    [TestMethod]
    public void ImplicitOperatorDouble_ReturnsRemainingRange()
    {
        var car = new Car(10, 50);
        double range = car;
        Assert.AreEqual(500, range);
    }
    [TestMethod]
    public void OperatorPlus_AddsFuelVolume()
    {
        var car = new Car(10, 50);
        car = car + 10;
        Assert.AreEqual(60, car.FuelVolume);
    }

    [TestMethod]
    public void OperatorPlus_AddsFuelVolume_Commutative()
    {
        var car = new Car(10, 50);
        car = 10 + car;
        Assert.AreEqual(60, car.FuelVolume);
    }
}
[TestClass]
public class CarArrayTests
{
    // Тесты для класса CarArray
    [TestMethod]
    public void Constructor_Default_InitializesEmptyArray()
    {
        var carArray = new CarArray(0);
        Assert.AreEqual(0, carArray.Length);
    }

    [TestMethod]
    public void Constructor_WithParameters_InitializesArrayWithRandomValues()
    {
        var carArray = new CarArray(3, 5, 10, 40, 60);
        Assert.AreEqual(3, carArray.Length);
    }

    [TestMethod]
    public void Constructor_Copy_InitializesArrayWithSameValues()
    {
        var originalArray = new CarArray(2, 5, 10, 40, 60);
        var copiedArray = new CarArray(originalArray);
        Assert.AreEqual(originalArray.Length, copiedArray.Length);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Constructor_Copy_WithNull_ThrowsException()
    {
        var copiedArray = new CarArray(null);
    }
    [TestMethod]
    public void Indexer_GetAndSet_WorksCorrectly()
    {
        var carArray = new CarArray(2, 5, 10, 40, 60);
        var newCar = new Car(8, 70);
        carArray[1] = newCar;
        Assert.AreEqual(newCar, carArray[1]);
    }

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void Indexer_GetOutOfRange_ThrowsException()
    {
        var carArray = new CarArray(2, 5, 10, 40, 60);
        var car = carArray[3]; // Должно выбросить исключение
    }

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void Indexer_SetOutOfRange_ThrowsException()
    {
        var carArray = new CarArray(2, 5, 10, 40, 60);
        carArray[3] = new Car(8, 70); // Должно выбросить исключение
    }
    [TestMethod]
    public void Display_OutputsCorrectInformation()
    {
        var carArray = new CarArray(2, 5, 10, 40, 60);
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            carArray.Display();
            var result = sw.ToString().Trim();
            Assert.IsTrue(result.Contains("Автомобиль 1:"));
            Assert.IsTrue(result.Contains("Автомобиль 2:"));
        }
    }

    [TestMethod]
    public void FindCarWithMinRange_EmptyArray_ReturnsNull()
    {
        var carArray = new CarArray(0);
        var minRangeCar = carArray.FindCarWithMinRange();
        Assert.IsNull(minRangeCar);
    }
    [TestMethod]
    public void GetCollectionCount_ReturnsCorrectCount()
    {
        int initialCount = CarArray.GetCollectionCount();
        var carArray1 = new CarArray(2, 5, 10, 40, 60);
        var carArray2 = new CarArray(3, 5, 10, 40, 60);
        Assert.AreEqual(initialCount + 2, CarArray.GetCollectionCount());
    }
    [TestMethod]
    public void Constructor_WithParameters_CreatesArrayWithCorrectSize()
    {
        var carArray = new CarArray(5, 5, 10, 40, 60);
        Assert.AreEqual(5, carArray.Length);
    }
    [TestMethod]
    public void Constructor_Copy_CreatesDeepCopy()
    {
        var originalArray = new CarArray(2, 5, 10, 40, 60);
        var copiedArray = new CarArray(originalArray);

        // Изменяем элемент в оригинальном массиве
        originalArray[0] = new Car(15, 75);

        // Проверяем, что скопированный массив не изменился
        Assert.AreNotEqual(originalArray[0], copiedArray[0]);
    }

    [TestMethod]
    public void TestParameterizedConstructor()
    {
        // Arrange & Act
        CarArray carArray = new CarArray(3, 5, 10, 40, 60);

        // Assert
        Assert.AreEqual(3, carArray.Length); //  Ожидается массив из 3 элементов
    }

    [TestMethod]
    public void TestCopyConstructor()
    {
        // Arrange
        CarArray originalArray = new CarArray(3, 5, 10, 40, 60);

        // Act
        CarArray copiedArray = new CarArray(originalArray);

        // Assert
        Assert.AreEqual(originalArray.Length, copiedArray.Length); // Ожидается, что массивы равны
    }

    [TestMethod]
    public void TestIndexer_ValidIndex()
    {
        // Arrange
        CarArray carArray = new CarArray(3, 5, 10, 40, 60);

        // Act & Assert
        Assert.IsNotNull(carArray[0]); // Ожидается, что элемент существует
    }

    [TestMethod]
    public void TestIndexer_InvalidIndex_Get()
    {
        // Arrange
        CarArray carArray = new CarArray(3, 5, 10, 40, 60);

        // Act & Assert
        Assert.ThrowsException<IndexOutOfRangeException>(() => carArray[10]); //  Ожидается исключение
    }

    [TestMethod]
    public void TestIndexer_InvalidIndex_Set()
    {
        // Arrange
        CarArray carArray = new CarArray(3, 5, 10, 40, 60);
        Car newCar = new Car(8.5, 50);

        // Act & Assert
        Assert.ThrowsException<IndexOutOfRangeException>(() => carArray[10] = newCar); //  Ожидается исключение
    }

    [TestMethod]
    public void TestParameterizedConstructor_ZeroSize()
    {
        // Arrange & Act
        CarArray carArray = new CarArray(0, 5, 10, 40, 60);

        // Assert
        Assert.AreEqual(0, carArray.Length); //  Ожидается, что массив будет пустым при нулевом размере
    }

    [TestMethod]
    public void TestParameterizedConstructor_InvalidRange()
    {
        // Arrange & Act
        CarArray carArray = new CarArray(3, 10, 5, 60, 40); // min > max

        // Assert
        Assert.AreEqual(3, carArray.Length); // Ожидается, что массив будет создан, но значения могут быть некорректными
    }



    [TestMethod]
    public void TestIndexer_SetValidValue()
    {
        // Arrange
        CarArray carArray = new CarArray(3, 5, 10, 40, 60);
        Car newCar = new Car(8.5, 50);

        // Act
        carArray[0] = newCar;

        // Assert
        Assert.AreEqual(newCar, carArray[0]); // Ожидается, что значение по индексу 0 изменилось
    }

    [TestMethod]
    public void TestIndexer_GetAfterSet()
    {
        // Arrange
        CarArray carArray = new CarArray(3, 5, 10, 40, 60);
        Car newCar = new Car(8.5, 50);

        // Act
        carArray[1] = newCar;

        // Assert
        Assert.AreEqual(newCar, carArray[1]); // Ожидается, что значение по индексу 1 изменилось
    }
}
