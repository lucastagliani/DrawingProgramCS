namespace DrawingProgramCS.Utils
{
    public static class ExceptionMessages
    {
        public static readonly string BUCKET_FILL_MUST_BE_CREATED_ON_EMPTY_POINT = "Bucket fill must be created on empty point";
        public static readonly string BUCKET_FILL_COLOUR_CANNOT_BE_EMPTY = "Bucket fill colour can not be empty";
        public static readonly string BUCKET_FILL_COLOUR_MUST_BE_SINGULAR_CHAR = "Bucket fill colour must be a singular char";
        public static readonly string BUCKET_FILL_COLOUR_ALREADY_IN_USE_CHAR = "Bucket fill colour invalid. Char already in use by another shape or separator";
        public static readonly string CANVAS_HAS_NO_ITEM_ON_THIS_POSITION = "Canvas has no item on this position.";
        public static readonly string CANVAS_MAX_WIDTH_OR_HEIGHT_REACHED = "Canvas max width or height reached";
        public static readonly string CANVAS_POINT_ALREADY_CONTAINS_ANOTHER_SHAPE = "Canvas point already contains another shape drawn";
        public static readonly string CANVAS_WIDTH_AND_HEIGHT_MUST_BE_POSITIVE = "Canvas width and height must have positive values";
        public static readonly string CANVAS_WIDTH_AND_HEIGHT_MUST_HAVE_INTEGER_VALUES = "Canvas width and height must have integer values";
        public static readonly string COMMAND_CANNOT_BE_NULL = "User command can not be null";
        public static readonly string COORDINATE_X_AND_Y_MUST_BE_POSITIVE_VALUES = "Coordinate X and Y must have positive values";
        public static readonly string COORDINATE_X_AND_Y_MUST_HAVE_INTEGER_VALUES = "Coordinate X and Y must have integer values";
        public static readonly string CREATE_CANVAS_FIRST = "Create a canvas before draw a shape";
        public static readonly string LINE_MUST_BE_HORIZONTAL_OR_VERTICAL = "Line must be horizontal or vertical";
        public static readonly string SHAPE_MUST_BE_DRAWN_INSIDE_CANVAS = "Shape must be drawn inside canvas and can not conflict with its border";
    }
}
