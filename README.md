### How to run:

1. Open ~\src\DrawingProgramCS.sln file in Visual Studio.
2. Check if DrawingProgramCS is setted as StartUp Project (if don't, set it up).
3. Menu "Build" -> Click "Build Solution".
4. Double click at ~\src\DrawingProgramCS\bin\Debug\DrawingProgramCS.exe

### Assumptions: 

* Canvas has a maximum width and height predefined.
* If user types command a little bit wrong (extra spaces or lower case, for example) the program will try to get a valid command.
* When creating shapes (line or rectangle),  the order of the coordinates does not matter. For example "R 18 3 14 1" will draw the rectangle correctly.
* If a canvas is already drawn and the user types a command to create canvas, the old will be replaced.
* If user bucket fill over another bucket fill, the old will NOT be replaced.
