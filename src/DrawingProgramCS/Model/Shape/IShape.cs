namespace DrawingProgramCS.Model.Shape
{
    public interface IShape
    {
        void Validate(Canvas canvas);

        string[] Draw(Canvas canvas);
    }
}
