using DrawingProgramCS.Model;
using DrawingProgramCS.Model.Exception;
using DrawingProgramCS.Model.Shape;
using DrawingProgramCS.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DrawingProgramCS.Test.Model
{
    [TestClass]
    public class RectangleTest
    {
        [TestMethod]
        public void DrawRectangle_WithoutCanvas_ThrowsDrawingException()
        {
            Rectangle rectangle = new Rectangle(14, 1, 18, 3);
            Action actual = () => rectangle.Draw(null);

            Exception ex = Assert.ThrowsException<DrawingException>(actual);
            Assert.AreEqual(ExceptionMessages.CREATE_CANVAS_FIRST, ex.Message);
        }

        [TestMethod]
        public void DrawRectangle_BottomLineOverlapsCanvasHeight_ThrowsDrawingException()
        {
            Canvas canvas = this.CreateAndDrawBasicCanvas();

            Rectangle rectangle = new Rectangle(14, 1, 21, 3);
            Action actual = () => rectangle.Draw(canvas);

            Exception ex = Assert.ThrowsException<DrawingException>(actual);
            Assert.AreEqual(ExceptionMessages.SHAPE_MUST_BE_DRAWN_INSIDE_CANVAS, ex.Message);
        }

        [TestMethod]
        public void DrawRectangle_RightLineOverlapsCanvasWidth_ThrowsDrawingException()
        {
            Canvas canvas = this.CreateAndDrawBasicCanvas();

            Rectangle rectangle = new Rectangle(14, 1, 18, 5);
            Action actual = () => rectangle.Draw(canvas);

            Exception ex = Assert.ThrowsException<DrawingException>(actual);
            Assert.AreEqual(ExceptionMessages.SHAPE_MUST_BE_DRAWN_INSIDE_CANVAS, ex.Message);
        }

        [TestMethod]
        public void DrawRectangle_CoordinatesTopLefAndBottomRight_Success()
        {
            string[] expected = new string[]
            {
                "----------------------",
                "|             xxxxx  |",
                "|             x   x  |",
                "|             xxxxx  |",
                "|                    |",
                "----------------------"
            };

            Canvas canvas = this.CreateAndDrawBasicCanvas();

            Rectangle rectangle = new Rectangle(new Coordinate(14, 1), new Coordinate(18, 3));
            string[] actual = rectangle.Draw(canvas);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DrawRectangle_CoordinatesBottomRightAndTopLeft_Success()
        {
            string[] expected = new string[]
            {
                "----------------------",
                "|             xxxxx  |",
                "|             x   x  |",
                "|             xxxxx  |",
                "|                    |",
                "----------------------"
            };

            Canvas canvas = this.CreateAndDrawBasicCanvas();

            Rectangle rectangle = new Rectangle(new Coordinate(18, 3), new Coordinate(14, 1));
            string[] actual = rectangle.Draw(canvas);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DrawRectangle_CoordinatesBottomLeftAndTopRight_Success()
        {
            string[] expected = new string[]
            {
                "----------------------",
                "|             xxxxx  |",
                "|             x   x  |",
                "|             xxxxx  |",
                "|                    |",
                "----------------------"
            };

            Canvas canvas = this.CreateAndDrawBasicCanvas();

            Rectangle rectangle = new Rectangle(new Coordinate(14, 3), new Coordinate(18, 1));
            string[] actual = rectangle.Draw(canvas);

            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void DrawRectangle_CoordinatesTopRightAndBottomLeft_Success()
        {
            string[] expected = new string[]
            {
                "----------------------",
                "|             xxxxx  |",
                "|             x   x  |",
                "|             xxxxx  |",
                "|                    |",
                "----------------------"
            };

            Canvas canvas = this.CreateAndDrawBasicCanvas();

            Rectangle rectangle = new Rectangle(new Coordinate(18, 1), new Coordinate(14, 3));
            string[] actual = rectangle.Draw(canvas);

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
