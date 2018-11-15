using DrawingProgramCS.Model;
using DrawingProgramCS.Model.Exception;
using DrawingProgramCS.Service;
using DrawingProgramCS.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DrawingProgramCS.Test.Service
{
    [TestClass]
    public class DrawingProgramServiceTest
    {
        [TestMethod]
        public void GetDrawingProgramAnswerForUserCommand_NullCommand_ThrowsCommandException()
        {
            DrawingProgramService drawingProgramService = new DrawingProgramService();
            Canvas canvas = null;

            Action actual = () => drawingProgramService.GetDrawingProgramAnswerForUserCommand(null, ref canvas);

            Exception ex = Assert.ThrowsException<ArgumentException>(actual);
            Assert.AreEqual(ExceptionMessages.COMMAND_CANNOT_BE_NULL, ex.Message);
        }

        [TestMethod]
        public void GetDrawingProgramAnswerForUserCommand_CreateLineBeforeCanvas_ThrowsShapeException()
        {
            DrawingProgramService drawingProgramService = new DrawingProgramService();
            Canvas canvas = null;

            Action actual = () => drawingProgramService.GetDrawingProgramAnswerForUserCommand(new UserCommand("L 2 4 7 4"), ref canvas);

            Exception ex = Assert.ThrowsException<ShapeException>(actual);
            Assert.AreEqual(ExceptionMessages.CREATE_CANVAS_FIRST, ex.Message);
        }

        [TestMethod]
        public void GetDrawingProgramAnswerForUserCommand_CreateCanvasWithBillionWidth_ThrowsShapeException()
        {
            DrawingProgramService drawingProgramService = new DrawingProgramService();
            Canvas canvas = null;

            Action actual = () => drawingProgramService.GetDrawingProgramAnswerForUserCommand(new UserCommand("C 9111222333 4"), ref canvas);

            Exception ex = Assert.ThrowsException<ArgumentException>(actual);
            Assert.AreEqual(ExceptionMessages.COORDINATE_X_AND_Y_MUST_HAVE_INTEGER_VALUES, ex.Message);
        }

        [TestMethod]
        public void GetDrawingProgramAnswerForUserCommand_SampleIO_DrawnCanvas()
        {
            string[] expected = new string[]
            {
                "----------------------",
                "|oooooooooooooxxxxxoo|",
                "|xxxxxxooooooox   xoo|",
                "|     xoooooooxxxxxoo|",
                "|     xoooooooooooooo|",
                "----------------------"
            };

            DrawingProgramService drawingProgramService = new DrawingProgramService();
            Canvas canvas = null;

            drawingProgramService.GetDrawingProgramAnswerForUserCommand(new UserCommand("C 20 4"), ref canvas);
            drawingProgramService.GetDrawingProgramAnswerForUserCommand(new UserCommand("L 1 2 6 2"), ref canvas);
            drawingProgramService.GetDrawingProgramAnswerForUserCommand(new UserCommand("L 6 3 6 4"), ref canvas);
            drawingProgramService.GetDrawingProgramAnswerForUserCommand(new UserCommand("R 14 1 18 3"), ref canvas);
            drawingProgramService.GetDrawingProgramAnswerForUserCommand(new UserCommand("R 14 1 18 3"), ref canvas);
            drawingProgramService.GetDrawingProgramAnswerForUserCommand(new UserCommand("B 10 3 o"), ref canvas);

            CollectionAssert.AreEqual(expected, canvas.Drawing);
        }

        [TestMethod]
        public void GetDrawingProgramAnswerForUserCommand_HelpCommand_Documentation()
        {
            string[] expected = CLIMessages.DOCUMENTATION;

            DrawingProgramService drawingProgramService = new DrawingProgramService();
            Canvas canvas = null;

            string[] actual = drawingProgramService.GetDrawingProgramAnswerForUserCommand(new UserCommand("HELP"), ref canvas);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
