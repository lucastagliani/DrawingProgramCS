namespace DrawingProgramCS.Utils
{
    public static class CLIMessages
    {
        public static readonly string NOT_RECOGNIZED_COMMAND = "Sorry, I didn't understand your command, let's try again.";
        public static readonly string STANDARD_SEPARATOR = "--------------------------------------------------";

        public static readonly string[] DOCUMENTATION = new string[]
        {
            "Command        Description",
            "C w h          Should create a new canvas of width w and height h.",
            "L x1 y1 x2 y2  Should create a new line from (x1,y1) to (x2,y2). Currently only",
            "               horizontal or vertical lines are supported. Horizontal and vertical lines",
            "               will be drawn using the 'x' character.",
            "R x1 y1 x2 y2  Should create a new rectangle, whose upper left corner is (x1,y1) and",
            "               lower right corner is (x2,y2). Horizontal and vertical lines will be drawn",
            "               using the 'x' character",
            "B x y c        Should fill the entire area connected to (x,y) with \"colour\" c. The",
            "               behaviour of this is the same as that of the \"bucket fill\" tool in paint",
            "               programs.",
            "Q              Should quit the program."
        };

        public static readonly string[] WELLCOME_TO_DRAWING_PROGRAM = new string[]
        {
            "Hi, I am a Drawing Assistent =)",
            "Right now I can do only this steps",
            "1. Create a new canvas",
            "2. Start drawing on the canvas by issuing various commands",
            "3. Quit",
            "If you need some help, type 'HELP' anytime"
        };

    }
}
