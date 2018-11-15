using DrawingProgramCS.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingProgramCS.Test.Model
{
    [TestClass]
    public class UserCommandTest
    {
        [TestMethod]
        public void UserCommandConstructor_CanvasCorrectSyntax_Success()
        {
            string userCommandLine = "C 20 4";

            UserCommand userCommand = new UserCommand(userCommandLine);

            Assert.AreEqual(userCommandLine, userCommand.UserOriginalCommandLine);
            Assert.AreEqual(EnumCommand.C, userCommand.Command);
            Assert.AreEqual("20", userCommand.FirstArgument);
            Assert.AreEqual("4", userCommand.SecondArgument);
        }

        [TestMethod]
        public void UserCommandConstructor_LineCorrectSyntax_Success()
        {
            string userCommandLine = "L 1 2 6 2";

            UserCommand userCommand = new UserCommand(userCommandLine);

            Coordinate[] expectedCoordinates = new Coordinate[] { new Coordinate("1", "2"), new Coordinate("6", "2") };

            Assert.AreEqual(userCommandLine, userCommand.UserOriginalCommandLine);
            Assert.AreEqual(EnumCommand.L, userCommand.Command);
            Assert.AreEqual(expectedCoordinates[0], userCommand.FirstCoordinate);
            Assert.AreEqual(expectedCoordinates[1], userCommand.SecondCoordinate);
        }

        [TestMethod]
        public void UserCommandConstructor_RectangleCorrectSyntax_Success()
        {
            string userCommandLine = "R 14 1 18 3";

            UserCommand userCommand = new UserCommand(userCommandLine);

            Coordinate[] expectedCoordinates = new Coordinate[] { new Coordinate("14", "1"), new Coordinate("18", "3") };

            Assert.AreEqual(userCommandLine, userCommand.UserOriginalCommandLine);
            Assert.AreEqual(EnumCommand.R, userCommand.Command);
            Assert.AreEqual(expectedCoordinates[0], userCommand.FirstCoordinate);
            Assert.AreEqual(expectedCoordinates[1], userCommand.SecondCoordinate);
        }

        [TestMethod]
        public void UserCommandConstructor_BucketFillCorrectSyntax_success()
        {
            string userCommandLine = "B 10 3 o";

            UserCommand userCommand = new UserCommand(userCommandLine);

            Coordinate[] expectedCoordinates = new Coordinate[] { new Coordinate("10", "3") };

            Assert.AreEqual(userCommandLine, userCommand.UserOriginalCommandLine);
            Assert.AreEqual(EnumCommand.B, userCommand.Command);
            Assert.AreEqual("o", userCommand.ThirdArgument);
            Assert.AreEqual(expectedCoordinates[0], userCommand.FirstCoordinate);
        }

        [TestMethod]
        public void UserCommandConstructor_Q_success()
        {
            string userCommandLine = "Q";

            UserCommand userCommand = new UserCommand(userCommandLine);

            Assert.AreEqual(userCommandLine, userCommand.UserOriginalCommandLine);
            Assert.AreEqual(EnumCommand.Q, userCommand.Command);
        }

        [TestMethod]
        public void UserCommandConstructor_X_NotRecognized()
        {
            string userCommandLine = "X";

            UserCommand userCommand = new UserCommand(userCommandLine);

            Assert.AreEqual(userCommandLine, userCommand.UserOriginalCommandLine);
            Assert.AreEqual(EnumCommand.NOT_RECOGNIZED, userCommand.Command);
        }

        [TestMethod]
        public void UserCommandConstructor_CanvasLowercaseWithExtraSpaces_fixed()
        {
            string userCommandLine = " c  40   8 ";

            UserCommand userCommand = new UserCommand(userCommandLine);

            string CONSIDERED_COMMAND_LINE = "C 40 8";

            Assert.AreEqual(userCommandLine, userCommand.UserOriginalCommandLine);
            Assert.AreEqual(CONSIDERED_COMMAND_LINE, userCommand.UserValidCommandLine);
            Assert.AreEqual(EnumCommand.C, userCommand.Command);
            Assert.AreEqual("40", userCommand.FirstArgument);
            Assert.AreEqual("8", userCommand.SecondArgument);
        }
    }
}
