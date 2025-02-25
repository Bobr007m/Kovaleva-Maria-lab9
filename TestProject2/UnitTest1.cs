using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ћаб9;

namespace CarArrayTests
{
    [TestClass]
    public class CarArrayTests
    {
        // “есты дл€ класса CarArray

        [TestMethod]
        public void TestDefaultConstructor()
        {
            // Arrange & Act
            CarArray carArray = new CarArray();

            // Assert
            Assert.AreEqual(0, carArray.Length); // ќжидаетс€ пустой массив
        }

        [TestMethod]
        public void TestParameterizedConstructor()
        {
            // Arrange & Act
            CarArray carArray = new CarArray(3, 5, 10, 40, 60);

            // Assert
            Assert.AreEqual(3, carArray.Length); // ќжидаетс€ массив из 3 элементов
        }

        [TestMethod]
        public void TestCopyConstructor()
        {
            // Arrange
            CarArray originalArray = new CarArray(3, 5, 10, 40, 60);

            // Act
            CarArray copiedArray = new CarArray(originalArray);

            // Assert
            Assert.AreEqual(originalArray.Length, copiedArray.Length); // ќжидаетс€, что массивы равны
        }

        [TestMethod]
        public void TestIndexer_ValidIndex()
        {
            // Arrange
            CarArray carArray = new CarArray(3, 5, 10, 40, 60);

            // Act & Assert
            Assert.IsNotNull(carArray[0]); // ќжидаетс€, что элемент существует
        }

        [TestMethod]
        public void TestIndexer_InvalidIndex_Get()
        {
            // Arrange
            CarArray carArray = new CarArray(3, 5, 10, 40, 60);

            // Act & Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => carArray[10]); // ќжидаетс€ исключение
        }

        [TestMethod]
        public void TestIndexer_InvalidIndex_Set()
        {
            // Arrange
            CarArray carArray = new CarArray(3, 5, 10, 40, 60);
            Car newCar = new Car(8.5, 50);

            // Act & Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => carArray[10] = newCar); // ќжидаетс€ исключение
        }

        [TestMethod]
        public void TestParameterizedConstructor_ZeroSize()
        {
            // Arrange & Act
            CarArray carArray = new CarArray(0, 5, 10, 40, 60);

            // Assert
            Assert.AreEqual(0, carArray.Length); // ќжидаетс€, что массив будет пустым при нулевом размере
        }

        [TestMethod]
        public void TestParameterizedConstructor_InvalidRange()
        {
            // Arrange & Act
            CarArray carArray = new CarArray(3, 10, 5, 60, 40); // min > max

            // Assert
            Assert.AreEqual(3, carArray.Length); // ќжидаетс€, что массив будет создан, но значени€ могут быть некорректными
        }

        [TestMethod]
        public void TestCopyConstructor_EmptyArray()
        {
            // Arrange
            CarArray originalArray = new CarArray();

            // Act
            CarArray copiedArray = new CarArray(originalArray);

            // Assert
            Assert.AreEqual(0, copiedArray.Length); // ќжидаетс€, что скопированный массив будет пустым
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
            Assert.AreEqual(newCar, carArray[0]); // ќжидаетс€, что значение по индексу 0 изменилось
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
            Assert.AreEqual(newCar, carArray[1]); // ќжидаетс€, что значение по индексу 1 изменилось
        }
    }
}
