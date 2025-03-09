using Microsoft.VisualStudio.TestTools.UnitTesting;
using ���9;

namespace CarArrayTests
{
    [TestClass]
    public class CarArrayTests
    {
        // ����� ��� ������ CarArray

       

        [TestMethod]
        public void TestParameterizedConstructor()
        {
            // Arrange & Act
            CarArray carArray = new CarArray(3, 5, 10, 40, 60);

            // Assert
            Assert.AreEqual(3, carArray.Length); // ��������� ������ �� 3 ���������
        }

        [TestMethod]
        public void TestCopyConstructor()
        {
            // Arrange
            CarArray originalArray = new CarArray(3, 5, 10, 40, 60);

            // Act
            CarArray copiedArray = new CarArray(originalArray);

            // Assert
            Assert.AreEqual(originalArray.Length, copiedArray.Length); // ���������, ��� ������� �����
        }

        [TestMethod]
        public void TestIndexer_ValidIndex()
        {
            // Arrange
            CarArray carArray = new CarArray(3, 5, 10, 40, 60);

            // Act & Assert
            Assert.IsNotNull(carArray[0]); // ���������, ��� ������� ����������
        }

        [TestMethod]
        public void TestIndexer_InvalidIndex_Get()
        {
            // Arrange
            CarArray carArray = new CarArray(3, 5, 10, 40, 60);

            // Act & Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => carArray[10]); // ��������� ����������
        }

        [TestMethod]
        public void TestIndexer_InvalidIndex_Set()
        {
            // Arrange
            CarArray carArray = new CarArray(3, 5, 10, 40, 60);
            Car newCar = new Car(8.5, 50);

            // Act & Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => carArray[10] = newCar); // ��������� ����������
        }

        [TestMethod]
        public void TestParameterizedConstructor_ZeroSize()
        {
            // Arrange & Act
            CarArray carArray = new CarArray(0, 5, 10, 40, 60);

            // Assert
            Assert.AreEqual(0, carArray.Length); // ���������, ��� ������ ����� ������ ��� ������� �������
        }

        [TestMethod]
        public void TestParameterizedConstructor_InvalidRange()
        {
            // Arrange & Act
            CarArray carArray = new CarArray(3, 10, 5, 60, 40); // min > max

            // Assert
            Assert.AreEqual(3, carArray.Length); // ���������, ��� ������ ����� ������, �� �������� ����� ���� �������������
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
            Assert.AreEqual(newCar, carArray[0]); // ���������, ��� �������� �� ������� 0 ����������
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
            Assert.AreEqual(newCar, carArray[1]); // ���������, ��� �������� �� ������� 1 ����������
        }
    }
}
