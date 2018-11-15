using DrawingProgramCS.Service;

namespace DrawingProgramCS
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawingProgramService service = new DrawingProgramService();
            service.Process();
        }
    }
}
