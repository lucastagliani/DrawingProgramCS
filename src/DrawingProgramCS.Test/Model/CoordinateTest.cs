using DrawingProgramCS.Model;
using DrawingProgramCS.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DrawingProgramCS.Test.Model
{
    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        public void CoordinateConstructor_Letters_ThrowsArgumentException()
        {
            Action actual = () => new Coordinate("A", "B");

            Exception ex = Assert.ThrowsException<ArgumentException>(actual);
            Assert.AreEqual(ExceptionMessages.COORDINATE_X_AND_Y_MUST_HAVE_INTEGER_VALUES, ex.Message);
        }

        [TestMethod]
        public void CoordinateConstructor_OverIntValue_ThrowsArgumentException()
        {
            Action actual = () => new Coordinate("2147483648", "4");

            Exception ex = Assert.ThrowsException<ArgumentException>(actual);
            Assert.AreEqual(ExceptionMessages.COORDINATE_X_AND_Y_MUST_HAVE_INTEGER_VALUES, ex.Message);
        }

        [TestMethod]
        public void CoordinateConstructor_NegativeX_ThrowsArgumentException()
        {
            Action actual = () => new Coordinate("-7", "5");

            Exception ex = Assert.ThrowsException<ArgumentException>(actual);
            Assert.AreEqual(ExceptionMessages.COORDINATE_X_AND_Y_MUST_BE_POSITIVE_VALUES, ex.Message);
        }

        [TestMethod]
        public void CoordinateConstructor_StringPositiveValues_Success()
        {
            Coordinate actual = new Coordinate("4", "2");

            Assert.AreEqual(4, actual.X);
            Assert.AreEqual(2, actual.Y);
        }

        [TestMethod]
        public void CoordinateConstructor_PositiveValues_Success()
        {
            Coordinate actual = new Coordinate(8, 9);

            Assert.AreEqual(8, actual.X);
            Assert.AreEqual(9, actual.Y);
        }
    }
}
