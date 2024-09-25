using ShootAbby.Model;

namespace ShootAbbyTest
{
    [TestClass]
    public class WitchTest
    {
        [TestMethod]
        public void Test_witch_cannot_be_instanciated_outside_play_area()
        {
            // Arrange
            // Rien

            // Act
            // Rien

            // Assert
            Assert.ThrowsException<Exception>(() => { Witch bad = new Witch(599, 100); });
        }

        [TestMethod]
        public void Test_witch_location_after_create()
        {
            // Arrange
            Witch w = new Witch(123, 321);

            // Act

            // Assert
            Assert.AreEqual(123,w.X);
            Assert.AreEqual(321, w.Y);
        }
    }
}