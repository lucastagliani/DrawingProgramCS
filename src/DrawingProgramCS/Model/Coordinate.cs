using DrawingProgramCS.Utils;
using System;

namespace DrawingProgramCS.Model
{
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate(string x, string y)
        {
            if (!Util.IsInteger(x) || !Util.IsInteger(y))
            {
                throw new ArgumentException(ExceptionMessages.COORDINATE_X_AND_Y_MUST_HAVE_INTEGER_VALUES);
            }

            SetCoordinate(int.Parse(x), int.Parse(y));
        }

        public Coordinate(int x, int y)
        {
            SetCoordinate(x, y);
        }

        private void SetCoordinate(int x, int y)
        {
            if (!Util.IsPositive(x) || !Util.IsPositive(y))
            {
                throw new ArgumentException(ExceptionMessages.COORDINATE_X_AND_Y_MUST_BE_POSITIVE_VALUES);
            }

            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Coordinate;

            if (item == null)
            {
                return false;
            }

            return this.X.Equals(item.X) && this.Y.Equals(item.Y);
        }
    }
}
