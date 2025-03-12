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
