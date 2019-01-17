using DiServices;
using FluentAssertions;
using Xunit;

namespace DiTests
{
    public class SubtractorTests
    {
        [Fact]
        public void Subtract_IsCorrect()
        {
            //Arrange
            var subtractor = new Subtractor();
            int a = 10;
            int b = 5;
            int expected = 5;
            
            //Assert
            subtractor.Subtract(a, b).Should().Be(expected);
        }
    }
}