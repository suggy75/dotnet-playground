using System;
using DiServices;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using Unity;
using Xunit;

namespace DiTests
{
    public class CalculatorTests
    {
        private Mock<IAdder> _mockAdder;
        private Mock<ISubtractor> _mockSubtractor;

        [Fact]
        public void Constructor_WithNullAdder_ThrowsArgumentNullException()
        {
            // Act
            var action = new Action(() => new Calculator(null, new Mock<ISubtractor>().Object));
            
            // Assert
            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("adder");
        }

        [Fact]
        public void Constructor_WithNullSubtractor_ThrowsArgumentNullException()
        {
            // Act
            var action = new Action(() => new Calculator(new Mock<IAdder>().Object, null));
            
            // Assert
            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("subtractor");
        }

        [Fact]
        public void Add_ReturnsCorrectValue()
        {
            // Arrange
            var calculator = ConfigureCalculator();

            _mockAdder.Setup(x => x.Add(It.IsAny<int>(),It.IsAny<int>())).Returns(2000);
            
            // Act
            calculator.Add(1, 1);

            // Assert
            _mockAdder.Verify(x => x.Add(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Subtract_HandsOffToISubtractor_()
        {
            // Arrange
            var calculator = ConfigureCalculator();

            _mockSubtractor.Setup(x => x.Subtract(It.IsAny<int>(), It.IsAny<int>())).Returns(It.IsAny<int>());
            
            // Act
            calculator.Subtract(1000, 2000);

            // Assert
            _mockSubtractor.Verify(x => x.Subtract(1000, 2000), Times.Once);
        }

        private Calculator ConfigureCalculator()
        {
            _mockAdder = new Mock<IAdder>();
            _mockSubtractor = new Mock<ISubtractor>();
            
            var result = new Calculator(_mockAdder.Object, _mockSubtractor.Object);

            return result;
        }
    }
}