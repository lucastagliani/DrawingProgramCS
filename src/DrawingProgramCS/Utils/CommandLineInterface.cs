using DrawingProgramCS.Model;
using System;

namespace DrawingProgramCS.Utils
{
    public static class CommandLineInterface
    {
        public static UserCommand WaitForUserCommand(string inlineMessageBeforeUserCommand = "")
        {
            if (!string.IsNullOrWhiteSpace(inlineMessageBeforeUserCommand))
            {
                Console.Write(inlineMessageBeforeUserCommand);
            }

            return new UserCommand(Console.ReadLine());
        }

        public static void Write(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine(message);
            }
        }

        public static void Write(string[] messages)
        {
            if (messages != null && messages.Length > 0)
            {
                for (int i = 0; i < messages.Length; i++)
                {
                    Console.WriteLine(messages[i]);
                }
            }
        }
    }
}
