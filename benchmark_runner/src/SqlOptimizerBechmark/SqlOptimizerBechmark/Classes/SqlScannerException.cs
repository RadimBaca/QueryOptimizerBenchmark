using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Classes
{
    public class SqlScannerException : SqlException
    {
        public const int CODE_UNTERMINATED_STRING = 1;
        public const int CODE_INVALID_NUMERIC_SYMBOL = 2;
        public const int CODE_INVALID_IDENTIFIER_SYMBOL = 3;
        public const int CODE_INVALID_SYMBOL = 4;

        public SqlScannerException(int code, string message, int startCharIndex, int endCharIndex)
            : base(code, message, startCharIndex, endCharIndex)
        {
        }
    }
}
