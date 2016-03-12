using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLSpriteTest.Engine
{
    public enum DEBUG_LOG_TYPE
    {
        MESSAGE = 0,
        WARNING = 1,
        ERROR = 2
    }

    public class Debug
    {


        public static void Print( string _message, DEBUG_LOG_TYPE _logType = DEBUG_LOG_TYPE.MESSAGE, bool _multiline = false )
        {
            ConsoleColor _messageColor;

            switch ( _logType )
            {
                case DEBUG_LOG_TYPE.MESSAGE:
                    _messageColor = ConsoleColor.White;
                    break;
                case DEBUG_LOG_TYPE.WARNING:
                    _messageColor = ConsoleColor.Yellow;
                    break;
                case DEBUG_LOG_TYPE.ERROR:
                    _messageColor = ConsoleColor.Red;
                    break;

                default:
                    _messageColor = ConsoleColor.White;
                    break;
            }

            Console.ForegroundColor = _messageColor;

            if ( !_multiline )
                Console.WriteLine("System: " + _message );
            else
                Console.Write( "System: " + _message );

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
