using DrawingProgramCS.Model.Exception;
using DrawingProgramCS.Utils;

namespace DrawingProgramCS.Model.Shape
{
    public class Line : IShape
    {
        private Coordinate coordinateStart;
        private Coordinate coordinateEnd;

        public Line(Coordinate coordinate1, Coordinate coordinate2)
        {
            if (coordinate1.X != coordinate2.X && coordinate1.Y != coordinate2.Y)
            {
                throw new ShapeException(ExceptionMessages.LINE_MUST_BE_HORIZONTAL_OR_VERTICAL);
            }

            // trick: if coordinate2 is "earlier" in cartesian, it becomes coordinateStart.
            if (coordinate1.X > coordinate2.X || coordinate1.Y > coordinate2.Y)
            {
                this.coordinateStart = coordinate2;
                this.coordinateEnd = coordinate1;
            }
            else
            {
                this.coordinateStart = coordinate1;
                this.coordinateEnd = coordinate2;
            }

        }

        public Line(int x1, int y1, int x2, int y2) : this(new Coordinate(x1, y1), new Coordinate(x2, y2)) { }

        public string[] Draw(Canvas canvas)
        {
            this.Validate(canvas);

            if (IsHorizontal())
            {
                char[] auxLine = canvas.GetLine(coordinateStart.Y);

                for (int i = coordinateStart.X; i <= coordinateEnd.X; i++)
                {
                    auxLine[i] = ConfigConstants.LINE_CHAR;
                }

                canvas.Drawing[coordinateStart.Y] = new string(auxLine);
            }
            else if (IsVertical())
            {
                char[] auxLine;

                for (int i = coordinateStart.Y; i <= coordinateEnd.Y; i++)
                {
                    auxLine = canvas.Drawing[i].ToCharArray();
                    auxLine[coordinateStart.X] = ConfigConstants.LINE_CHAR;
                    canvas.Drawing[i] = new string(auxLine);
                }
            }

            return canvas.Drawing;
        }

        public void Validate(Canvas canvas)
        {
            if (canvas == null)
            {
                throw new DrawingException(ExceptionMessages.CREATE_CANVAS_FIRST);
            }
            
            if (canvas.Width < this.coordinateEnd.X || canvas.Height < this.coordinateEnd.Y)
            {
                throw new DrawingException(ExceptionMessages.SHAPE_MUST_BE_DRAWN_INSIDE_CANVAS);
            }
        }

        private bool IsHorizontal()
        {
            return coordinateStart.Y == coordinateEnd.Y;
        }

        private bool IsVertical()
        {
            return coordinateStart.X == coordinateEnd.X;
        }
    }
}
