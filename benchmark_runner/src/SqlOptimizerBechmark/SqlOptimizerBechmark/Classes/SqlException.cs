using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Classes
{
    public class SqlException : Exception
    {
        private int code;
        private int startCharIndex;
        private int endCharIndex;

        public int Code
        {
            get { return code; }
        }

        public int StartCharIndex
        {
            get { return startCharIndex; }
        }

        public int EndCharIndex
        {
            get { return endCharIndex; }
        }

        public SqlException(int code, string message, int startCharIndex, int endCharIndex)
            : base(message)
        {
            this.code = code;
            this.startCharIndex = startCharIndex;
            this.endCharIndex = endCharIndex;
        }
    }

}
