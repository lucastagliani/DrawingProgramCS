using DrawingProgramCS.Model;
using DrawingProgramCS.Model.Exception;
using DrawingProgramCS.Model.Shape;
using DrawingProgramCS.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DrawingProgramCS.Test.Model
{
    [TestClass]
    public class BucketFillTest
    {
        [TestMethod]
        public void BucketFillConstructor_EmptyColour_ThrowsShapeException()
        {
            Action actual = () => new BucketFill(4, 2, " ");
            
            Exception ex = Assert.ThrowsException<ShapeException>(actual);
            Assert.AreEqual(ExceptionMessages.BUCKET_FILL_COLOUR_CANNOT_BE_EMPTY, ex.Message);
        }

        [TestMethod]
        public void BucketFillConstructor_DoubleCharColour_ThrowsShapeException()
        {
            Action actual = () => new BucketFill(4, 2, "cc");
            
            Exception ex = Assert.ThrowsException<ShapeException>(actual);
            Assert.AreEqual(ExceptionMessages.BUCKET_FILL_COLOUR_MUST_BE_SINGULAR_CHAR, ex.Message);
        }

        [TestMethod]
        public void BucketFillConstructor_ColourAsSeparatorChar_ThrowsShapeException()
        {
            Action actual = () => new BucketFill(4, 2, "-");

            Exception ex = Assert.ThrowsException<ShapeException>(actual);
            Assert.AreEqual(ExceptionMessages.BUCKET_FILL_COLOUR_ALREADY_IN_USE_CHAR, ex.Message);
        }

        [TestMethod]
        public void DrawBucketFill_OutsideCanvas_ThrowsDrawException()
        {
            Canvas canvas = new Canvas(20, 5);
            canvas.Draw();

            BucketFill bucketFillOutsideRectangle = new BucketFill(30, 2, "c");
            Action actual = () => bucketFillOutsideRectangle.Draw(canvas);

            Exception ex = Assert.ThrowsException<DrawingException>(actual);
            Assert.AreEqual(ExceptionMessages.SHAPE_MUST_BE_DRAWN_INSIDE_CANVAS, ex.Message);
        }

        [TestMethod]
        public void DrawBucketFill_OnAlreadyExistentLine_ThrowsDrawException()
        {
            Canvas canvas = new Canvas(20, 5);
            Line line = new Line(2, 2, 5, 2);
            canvas.Shapes.Add(line);
            canvas.Draw();

            BucketFill bucketFillOutsideRectangle = new BucketFill(3, 2, "c");
            Action actual = () => bucketFillOutsideRectangle.Draw(canvas);

            Exception ex = Assert.ThrowsException<DrawingException>(actual);
            Assert.AreEqual(ExceptionMessages.BUCKET_FILL_MUST_BE_CREATED_ON_EMPTY_POINT, ex.Message);
        }

        [TestMethod]
        public void DrawBucketFill_EmptyCanvas_CanvasFilled()
        {
            string[] expected = new string[]
            {
                "----------------------",
                "|cccccccccccccccccccc|",
                "|cccccccccccccccccccc|",
                "|cccccccccccccccccccc|",
                "|cccccccccccccccccccc|",
                "----------------------"
            };

            Canvas canvas = new Canvas(20, 4);
            canvas.Draw();

            BucketFill bucketFillAllCanvas = new BucketFill(10, 2, "c");
            string[] actual = bucketFillAllCanvas.Draw(canvas);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DrawBucketFill_LeftOnCanvasWithVerticalLine_LeftSideCanvasFilled()
        {
            string[] expected = new string[]
            {
                "----------------------",
                "|cccccccccx          |",
                "|cccccccccx          |",
                "|cccccccccx          |",
                "|cccccccccx          |",
                "----------------------"
            };

            Canvas canvas = new Canvas(20, 4);
            Line verticalLine = new Line(10, 1, 10, 4);
            canvas.Shapes.Add(verticalLine);
            canvas.Draw();

            BucketFill bucketFillLeftSide = new BucketFill(5, 3, "c");
            string[] actual = bucketFillLeftSide.Draw(canvas);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DrawBucketFill_BottomOnCanvasWithHorizontalLine_BottomSideCanvasFilled()
        {
            string[] expected = new string[]
            {
                "----------------------",
                "|                    |",
                "|                    |",
                "|xxxxxxxxxxxxxxxxxxxx|",
                "|cccccccccccccccccccc|",
                "|cccccccccccccccccccc|",
                "----------------------"
            };

            Canvas canvas = new Canvas(20, 5);
            Line horizontalLine = new Line(1, 3, 20, 3);
            canvas.Shapes.Add(horizontalLine);
            canvas.Draw();

            BucketFill bucketFillBottomCanvas = new BucketFill(5, 4, "c");
            string[] actual = bucketFillBottomCanvas.Draw(canvas);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DrawBucketFill_InsideRectangle_RectangleFilled()
        {
            string[] expected = new string[]
            {
                "----------------------",
                "|                    |",
                "|  xxxxx             |",
                "|  xcccx             |",
                "|  xcccx             |",
                "|  xxxxx             |",
                "----------------------"
            };

            Canvas canvas = new Canvas(20, 5);
            Rectangle rectangle = new Rectangle(3, 2, 7, 5);
            canvas.Shapes.Add(rectangle);
            canvas.Draw();

            BucketFill bucketFillInsideRectangle = new BucketFill(5, 3, "c");
            string[] actual = bucketFillInsideRectangle.Draw(canvas);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DrawBucketFill_OutsideRectangle_RectangleFilled()
        {
            string[] expected = new string[]
            {
                "----------------------",
                "|cccccccccccccccccccc|",
                "|ccxxxxxccccccccccccc|",
                "|ccx   xccccccccccccc|",
                "|ccx   xccccccccccccc|",
                "|ccxxxxxccccccccccccc|",
                "----------------------"
            };

            Canvas canvas = new Canvas(20, 5);
            Rectangle rectangle = new Rectangle(3, 2, 7, 5);
            canvas.Shapes.Add(rectangle);
            canvas.Draw();

            BucketFill bucketFillOutsideRectangle = new BucketFill(10, 4, "c");
            string[] actual = bucketFillOutsideRectangle.Draw(canvas);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
