using DrawingProgramCS.Model.Exception;
using DrawingProgramCS.Utils;

namespace DrawingProgramCS.Model.Shape
{
    public class Rectangle : IShape
    {
        private Coordinate coordinateStart;
        private Coordinate coordinateEnd;

        public Rectangle(Coordinate coordinate1, Coordinate coordinate2)
        {
            this.coordinateStart = coordinate1;
            this.coordinateEnd = coordinate2;
        }

        public Rectangle(int x1, int y1, int x2, int y2) : this(new Coordinate(x1, y1), new Coordinate(x2, y2)) { }

        public string[] Draw(Canvas canvas)
        {
            this.Validate(canvas);

            Line topHorizontalLine = new Line(this.coordinateStart, new Coordinate(this.coordinateEnd.X, this.coordinateStart.Y));
            topHorizontalLine.Draw(canvas);

            Line bottomHorizontalLine = new Line(new Coordinate(this.coordinateStart.X, this.coordinateEnd.Y), this.coordinateEnd);
            bottomHorizontalLine.Draw(canvas);

            Line leftVerticalLine = new Line(this.coordinateStart, new Coordinate(this.coordinateStart.X, this.coordinateEnd.Y));
            leftVerticalLine.Draw(canvas);

            Line rightVerticalLine = new Line(new Coordinate(this.coordinateEnd.X, this.coordinateStart.Y), this.coordinateEnd);
            rightVerticalLine.Draw(canvas);

            return canvas.Drawing;
        }

        public void Validate(Canvas canvas)
        {
            if (canvas == null)
            {
                throw new DrawingException(ExceptionMessages.CREATE_CANVAS_FIRST);
            }
        }
    }
}
