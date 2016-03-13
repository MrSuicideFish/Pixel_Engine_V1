using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEngine.Engine
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
            string _prefix = "System: ";

            switch ( _logType )
            {
                case DEBUG_LOG_TYPE.MESSAGE:
                    _messageColor = ConsoleColor.White;
                    break;
                case DEBUG_LOG_TYPE.WARNING:
                    _messageColor = ConsoleColor.Yellow;
                    _prefix = "WARNING: ";
                    break;
                case DEBUG_LOG_TYPE.ERROR:
                    _messageColor = ConsoleColor.Red;
                    _prefix = "ERROR: ";
                    break;

                default:
                    _messageColor = ConsoleColor.White;
                    _prefix = "System: ";
                    break;
            }

            Console.ForegroundColor = _messageColor;

            if ( !_multiline )
                Console.WriteLine( _prefix + _message );
            else
                Console.Write( _prefix + _message );

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}