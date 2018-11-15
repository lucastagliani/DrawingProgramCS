using DrawingProgramCS.Model;
using DrawingProgramCS.Model.Exception;
using DrawingProgramCS.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DrawingProgramCS.Test.Model
{
    [TestClass]
    public class CanvasTest
    {
        [TestMethod]
        public void CanvasConstructor_ZeroWidth_ThrowsShapeException()
        {
            Action actual = () => new Canvas(0, 4);

            Exception ex = Assert.ThrowsException<ShapeException>(actual);
            Assert.AreEqual(ExceptionMessages.CANVAS_WIDTH_AND_HEIGHT_MUST_BE_POSITIVE, ex.Message);
        }

        [TestMethod]
        public void CanvasConstructor_NegativeHeight_ThrowsShapeException()
        {
            Action actual = () => new Canvas(15, -4);

            Exception ex = Assert.ThrowsException<ShapeException>(actual);
            Assert.AreEqual(ExceptionMessages.CANVAS_WIDTH_AND_HEIGHT_MUST_BE_POSITIVE, ex.Message);
        }

        [TestMethod]
        public void CanvasConstructor_WidthGreaterThanMax_ThrowsShapeException()
        {
            Action actual = () => new Canvas(1001, 7);

            Exception ex = Assert.ThrowsException<ShapeException>(actual);
            Assert.AreEqual(ExceptionMessages.CANVAS_MAX_WIDTH_OR_HEIGHT_REACHED, ex.Message);
        }

        [TestMethod]
        public void DrawCanvas_PositiveValues_Success()
        {
            string[] expected = new string[]
            {
                "----------------------",
                "|                    |",
                "|                    |",
                "|                    |",
                "|                    |",
                "----------------------"
            };

            Canvas canvas = new Canvas(20, 4);

            CollectionAssert.AreEqual(expected, canvas.Drawing);
        }
    }
}
