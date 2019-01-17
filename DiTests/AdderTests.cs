using DiServices;
using FluentAssertions;
using Xunit;

namespace DiTests
{
    public class AdderTests
    {
        [Fact]
        public void Add_ReturnsCorrectValue()
        {
            // Arrange
            const int a  = 10;
            const int b = 5;
            var expected = a + b;
            var adder = new Adder();
            
            // Act
            var result = adder.Add(a, b);

            // Assert
            result.Should().Be(expected);
        }
    }
}