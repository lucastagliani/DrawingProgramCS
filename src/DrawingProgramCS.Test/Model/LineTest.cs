using DrawingProgramCS.Model;
using DrawingProgramCS.Model.Exception;
using DrawingProgramCS.Model.Shape;
using DrawingProgramCS.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DrawingProgramCS.Test.Model
{
    [TestClass]
    public class LineTest
    {
        [TestMethod]
        public void LineConstructor_Diagonal_ThrowsShapeException()
        {
            Action actual = () => new Line(7, 9, 8, 10);

            Exception ex = Assert.ThrowsException<ShapeException>(actual);
            Assert.AreEqual(ExceptionMessages.LINE_MUST_BE_HORIZONTAL_OR_VERTICAL, ex.Message);
        }

        [TestMethod]
        public void DrawLine_WithoutCanvas_ThrowsDrawingException()
        {
            Line line = new Line(1, 2, 6, 2);
            Action actual = () => line.Draw(null);

            Exception ex = Assert.ThrowsException<DrawingException>(actual);
            Assert.AreEqual(ExceptionMessages.CREATE_CANVAS_FIRST, ex.Message);
        }

        [TestMethod]
        public void DrawLine_OverlapsWidth_ThrowsDrawingException()
        {
            Line line = new Line(4, 3, 21, 3);

            Canvas canvas = this.CreateAndDrawBasicCanvas();

            Action actual = () => line.Draw(canvas);

            Exception ex = Assert.ThrowsException<DrawingException>(actual);
            Assert.AreEqual(ExceptionMessages.SHAPE_MUST_BE_DRAWN_INSIDE_CANVAS, ex.Message);
        }
        
        [TestMethod]
        public void DrawLine_OverlapsHeight_ThrowsDrawingException()
        {
            Line line = new Line(6, 3, 6, 5);

            Canvas canvas = this.CreateAndDrawBasicCanvas();

            Action actual = () => line.Draw(canvas);

            Exception ex = Assert.ThrowsException<DrawingException>(actual);
            Assert.AreEqual(ExceptionMessages.SHAPE_MUST_BE_DRAWN_INSIDE_CANVAS, ex.Message);
        }

        [TestMethod]
        public void DrawLine_Horizontal_Success()
        {
            string[] expected = new string[]
            {
                "----------------------",
                "|                    |",
                "|xxxxxx              |",
                "|                    |",
                "|                    |",
                "----------------------"
            };

            Canvas canvas = this.CreateAndDrawBasicCanvas();

            Line line = new Line(1, 2, 6, 2);
            string[] actual = line.Draw(canvas);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DrawLine_HorizontalWithReverseCoordinates_Success()
        {
            string[] expected = new string[]
            {
                "----------------------",
                "|                    |",
                "|xxxxxx              |",
                "|                    |",
                "|                    |",
                "----------------------"
            };

            Canvas canvas = this.CreateAndDrawBasicCanvas();

            Line line = new Line(6, 2, 1, 2);
            string[] actual = line.Draw(canvas);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DrawLine_Vertical_Success()
        {
            string[] expected = new string[]
            {
                "----------------------",
                "|                    |",
                "|                    |",
                "|     x              |",
                "|     x              |",
                "----------------------"
            };

            Canvas canvas = this.CreateAndDrawBasicCanvas();

            Line line = new Line(6, 3, 6, 4);
            string[] actual = line.Draw(canvas);

            CollectionAssert.AreEqual(expected, actual);
        }

        private Canvas CreateAndDrawBasicCanvas()
        {
            Canvas canvas = new Canvas(20, 4);
            canvas.Draw();
            return canvas;
        }
    }
}
