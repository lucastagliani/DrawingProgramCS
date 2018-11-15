using DrawingProgramCS.Model.Exception;
using DrawingProgramCS.Utils;
using System.Collections.Generic;
using System.Linq;

namespace DrawingProgramCS.Model.Shape
{
    public class BucketFill : IShape
    {
        private readonly Coordinate coordinate;
        private char colour;

        public BucketFill(Coordinate coordinate, string colour)
        {
            this.coordinate = coordinate;
            this.SetColour(colour);
        }

        public BucketFill(int x, int y, string colour) : this(new Coordinate(x, y), colour) { }

        public string[] Draw(Canvas canvas)
        {
            this.Validate(canvas);

            char[,] draft = Util.ConvertStringArrayToChar2DArray(canvas.Drawing);

            Queue<Coordinate> coordinatesToFill = new Queue<Coordinate>();
            coordinatesToFill.Enqueue(this.coordinate);

            while (coordinatesToFill.Count != 0)
            {
                Coordinate c = coordinatesToFill.Dequeue();
                draft[c.Y, c.X] = this.colour;

                // Look above
                if (c.Y - 1 > 0 && draft[c.Y - 1, c.X] == ConfigConstants.CANVAS_EMPTY_SPACE_CHAR)
                {
                    coordinatesToFill.Enqueue(new Coordinate(c.X, c.Y - 1));
                }

                // Look below
                if (c.Y + 1 <= canvas.Height && draft[c.Y + 1, c.X] == ConfigConstants.CANVAS_EMPTY_SPACE_CHAR)
                {
                    coordinatesToFill.Enqueue(new Coordinate(c.X, c.Y + 1));
                }

                // Look left
                if (c.X - 1 > 0 && draft[c.Y, c.X - 1] == ConfigConstants.CANVAS_EMPTY_SPACE_CHAR)
                {
                    coordinatesToFill.Enqueue(new Coordinate(c.X - 1, c.Y));
                }

                // Look right
                if (c.X + 1 <= canvas.Width && draft[c.Y, c.X + 1] == ConfigConstants.CANVAS_EMPTY_SPACE_CHAR)
                {
                    coordinatesToFill.Enqueue(new Coordinate(c.X + 1, c.Y));
                }
            }

            canvas.Drawing = Util.ConvertChar2DArrayToStringArray(draft);

            return canvas.Drawing;
        }

        public void Validate(Canvas canvas)
        {
            if (canvas == null)
            {
                throw new DrawingException(ExceptionMessages.CREATE_CANVAS_FIRST);
            }

            if (canvas.Width < this.coordinate.X || canvas.Height < this.coordinate.Y)
            {
                throw new DrawingException(ExceptionMessages.SHAPE_MUST_BE_DRAWN_INSIDE_CANVAS);
            }

            if (canvas.GetPoint(this.coordinate.X, this.coordinate.Y) != ConfigConstants.CANVAS_EMPTY_SPACE_CHAR)
            {
                throw new DrawingException(ExceptionMessages.BUCKET_FILL_MUST_BE_CREATED_ON_EMPTY_POINT);
            }
        }

        private void SetColour(string colour)
        {
            if (string.IsNullOrWhiteSpace(colour))
            {
                throw new ShapeException(ExceptionMessages.BUCKET_FILL_COLOUR_CANNOT_BE_EMPTY);
            }

            colour = colour.Trim();

            if (colour.Length != 1)
            {
                throw new ShapeException(ExceptionMessages.BUCKET_FILL_COLOUR_MUST_BE_SINGULAR_CHAR);
            }

            char charColour = colour[0];

            char[] RESERVED_CHARACTERES = new char[]
            {
                ConfigConstants.CANVAS_HORIZONTAL_DELIMITER_CHAR,
                ConfigConstants.CANVAS_VERTICAL_DELIMITER_CHAR,
                ConfigConstants.LINE_CHAR
            };

            if (RESERVED_CHARACTERES.Contains(charColour))
            {
                throw new ShapeException(ExceptionMessages.BUCKET_FILL_COLOUR_ALREADY_IN_USE_CHAR);
            }

            this.colour = charColour;
        }
    }
}
