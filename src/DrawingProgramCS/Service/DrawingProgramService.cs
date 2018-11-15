using DrawingProgramCS.Model;
using DrawingProgramCS.Model.Exception;
using DrawingProgramCS.Model.Shape;
using DrawingProgramCS.Utils;
using System;

namespace DrawingProgramCS.Service
{
    public class DrawingProgramService
    {
        public void Process()
        {
            CommandLineInterface.Write(CLIMessages.WELLCOME_TO_DRAWING_PROGRAM);

            UserCommand userCommand = null;
            Canvas canvas = null;

            do
            {
                try
                {
                    CommandLineInterface.Write(CLIMessages.STANDARD_SEPARATOR);
                    userCommand = CommandLineInterface.WaitForUserCommand("Type your command: ");
                    CommandLineInterface.Write(this.GetDrawingProgramAnswerForUserCommand(userCommand, ref canvas));
                }
                catch (DrawingException ex)
                {
                    CommandLineInterface.Write($"Drawing exception: {ex.Message}");
                }
                catch (ShapeException ex)
                {
                    CommandLineInterface.Write($"Shape exception: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    CommandLineInterface.Write($"Argument exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    CommandLineInterface.Write($"Exception: {ex.Message}");
                }

            } while (userCommand != null && userCommand.Command != EnumCommand.Q);

            Console.ReadKey();
        }

        public string[] GetDrawingProgramAnswerForUserCommand(UserCommand userCommand, ref Canvas canvas)
        {
            if (userCommand == null)
            {
                throw new ArgumentException(ExceptionMessages.COMMAND_CANNOT_BE_NULL);
            }

            if (userCommand.IsCanvasNeededToContinue && canvas == null)
            {
                throw new ShapeException(ExceptionMessages.CREATE_CANVAS_FIRST);
            }

            switch (userCommand.Command)
            {
                case EnumCommand.C:
                    canvas = new Canvas(userCommand.FirstArgument, userCommand.SecondArgument);
                    break;
                case EnumCommand.L:
                    Line line = new Line(userCommand.FirstCoordinate, userCommand.SecondCoordinate);
                    canvas.Shapes.Add(line);
                    break;
                case EnumCommand.R:
                    Rectangle rectangle = new Rectangle(userCommand.FirstCoordinate, userCommand.SecondCoordinate);
                    canvas.Shapes.Add(rectangle);
                    break;
                case EnumCommand.B:
                    BucketFill bucketFill = new BucketFill(userCommand.FirstCoordinate, userCommand.ThirdArgument);
                    canvas.Shapes.Add(bucketFill);
                    break;
                case EnumCommand.Q:
                    break;
                case EnumCommand.HELP:
                    return CLIMessages.DOCUMENTATION;
                case EnumCommand.NOT_RECOGNIZED:
                default:
                    return new string[] { CLIMessages.NOT_RECOGNIZED_COMMAND };
            }

            if (userCommand.IsCanvasCommand)
            {
                return canvas.Draw();
            }

            return new string[0];
        }
    }

}
