using DrawingProgramCS.Model.Exception;
using DrawingProgramCS.Model.Shape;
using DrawingProgramCS.Utils;
using System.Collections.Generic;

namespace DrawingProgramCS.Model
{
    public class Canvas
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<IShape> Shapes { get; private set; }
        public string[] Drawing { get; internal set; } // TODO: Need refactoring to be PRIVATE SET. Main reason is at BucketFill.cs:67

        public Canvas(string width, string height)
        {
            if (!Util.IsInteger(width) || !Util.IsInteger(height))
            {
                throw new ShapeException(ExceptionMessages.CANVAS_WIDTH_AND_HEIGHT_MUST_HAVE_INTEGER_VALUES);
            }

            SetCanvas(int.Parse(width), int.Parse(height));
        }

        public Canvas(int width, int height)
        {
            SetCanvas(width, height);
        }

        public string[] Draw()
        {
            DrawCanvas();
            DrawShapes();

            return this.Drawing;
        }

        public char[] GetLine(int index)
        {
            if (index > this.Drawing.Length)
            {
                throw new ShapeException(ExceptionMessages.CANVAS_HAS_NO_ITEM_ON_THIS_POSITION);
            }

            return this.Drawing[index].ToCharArray();
        }

        public char GetPoint(int x, int y)
        {
            if (y > this.Drawing.Length)
            {
                throw new ShapeException(ExceptionMessages.CANVAS_HAS_NO_ITEM_ON_THIS_POSITION);
            }

            char[] line = this.Drawing[y].ToCharArray();

            if (x > line.Length)
            {
                throw new ShapeException(ExceptionMessages.CANVAS_HAS_NO_ITEM_ON_THIS_POSITION);
            }

            return line[x];
        }

        private void SetCanvas(int width, int height)
        {
            if (Util.IsZeroOrNegative(width) || Util.IsZeroOrNegative(height))
            {
                throw new ShapeException(ExceptionMessages.CANVAS_WIDTH_AND_HEIGHT_MUST_BE_POSITIVE);
            }

            if (width > ConfigConstants.CANVAS_MAXIMUM_WIDTH || height > ConfigConstants.CANVAS_MAXIMUM_HEIGHT)
            {
                throw new ShapeException(ExceptionMessages.CANVAS_MAX_WIDTH_OR_HEIGHT_REACHED);
            }

            this.Width = width;
            this.Height = height;
            this.Shapes = new List<IShape>();

            this.DrawCanvas();
        }

        private void DrawCanvas()
        {
            this.Drawing = new string[this.Height + 2];

            for (int i = 0; i <= this.Height + 1; i++)
            {
                string line = string.Empty;

                for (int j = 0; j <= this.Width + 1; j++)
                {
                    if (IsFirstOrLastRow(i))
                    {
                        line += ConfigConstants.CANVAS_HORIZONTAL_DELIMITER_CHAR;
                    }
                    else
                    {
                        if (IsFirstOrLastColumn(j))
                        {
                            line += ConfigConstants.CANVAS_VERTICAL_DELIMITER_CHAR;
                        }
                        else
                        {
                            line += ConfigConstants.CANVAS_EMPTY_SPACE_CHAR;
                        }
                    }
                }

                this.Drawing[i] = line;
            }
        }

        private void DrawShapes()
        {
            foreach (var shape in this.Shapes)
            {
                shape.Draw(this);
            }
        }

        private bool IsFirstOrLastColumn(int position)
        {
            return position == 0 || position == this.Width + 1;
        }

        private bool IsFirstOrLastRow(int position)
        {
            return position == 0 || position == this.Height + 1;
        }
    }
}
