using System;

namespace DrawingProgramCS.Model
{
    public class UserCommand
    {
        private EnumCommand command;
        private string userOriginalCommandLine;
        private string[] arguments;
        private Coordinate[] coordinates;

        public UserCommand(string userOriginalCommandLine)
        {
            this.userOriginalCommandLine = userOriginalCommandLine;

            string[] userCommandLineSeparatedBySpate = this.UserValidCommandLine.Split(' ');

            this.SetCommand(userCommandLineSeparatedBySpate[0]);
            this.SetArguments(userCommandLineSeparatedBySpate);
            this.SetCoordinates();
        }

        public EnumCommand Command { get { return command; } }
        public string UserOriginalCommandLine { get { return this.userOriginalCommandLine; } }
        public string UserValidCommandLine { get { return ClearCommandLine(UserOriginalCommandLine); } }
        public string FirstArgument { get { return GetItemFromArray(arguments, 0) as string; } }
        public string SecondArgument { get { return GetItemFromArray(arguments, 1) as string; } }
        public string ThirdArgument { get { return GetItemFromArray(arguments, 2) as string; } }
        public Coordinate FirstCoordinate { get { return GetItemFromArray(coordinates, 0) as Coordinate; } }
        public Coordinate SecondCoordinate { get { return GetItemFromArray(coordinates, 1) as Coordinate; } }

        public bool IsCanvasCommand {
            get
            {
                return this.command == EnumCommand.C || this.command == EnumCommand.L || this.command == EnumCommand.R || this.command == EnumCommand.B;
            }
        }

        public bool IsCanvasNeededToContinue
        {
            get
            {
                return this.command == EnumCommand.L || this.command == EnumCommand.R || this.command == EnumCommand.B;
            }
        }

        private void SetCommand(string userCommand)
        {
            this.command = EnumCommand.NOT_RECOGNIZED;
            Enum.TryParse(userCommand, out EnumCommand command);
            this.command = command;
        }

        private void SetArguments(string[] userCommandLineSeparatedBySpace)
        {
            this.arguments = new string[userCommandLineSeparatedBySpace.Length - 1];
            Array.Copy(userCommandLineSeparatedBySpace, 1, this.arguments, 0, userCommandLineSeparatedBySpace.Length - 1);
        }

        private void SetCoordinates()
        {
            if (this.arguments.Length >= 2)
            {
                this.coordinates = new Coordinate[this.arguments.Length / 2];

                Coordinate firstCoordinate = new Coordinate(this.arguments[0], this.arguments[1]);
                this.coordinates[0] = firstCoordinate;

                if (this.arguments.Length >= 4)
                {
                    Coordinate secondCoordinate = new Coordinate(this.arguments[2], this.arguments[3]);
                    this.coordinates[1] = secondCoordinate;
                }
            }
        }
        
        private string ClearCommandLine(string userOriginalCommandLine)
        {
            if (!string.IsNullOrWhiteSpace(userOriginalCommandLine))
            {
                // Remove extra spaces
                while (userOriginalCommandLine.Contains("  "))
                    userOriginalCommandLine = userOriginalCommandLine.Replace("  ", " ");

                userOriginalCommandLine = userOriginalCommandLine.Trim();

                return userOriginalCommandLine[0].ToString().ToUpper() + userOriginalCommandLine.Substring(1);
            }

            return string.Empty;
        }

        private Object GetItemFromArray(Array array, int position)
        {
            if (array != null && array.Length >= position + 1)
            {
                return array.GetValue(position);
            }

            return null;
        }
    }
}
