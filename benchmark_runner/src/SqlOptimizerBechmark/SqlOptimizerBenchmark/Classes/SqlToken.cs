using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBenchmark.Classes
{
    public enum SqlTokenType
    {
        IDENTIFIER_OR_KEYWORD,
        COMMA,
        DOT,
        LEFT_BRACKET,
        RIGHT_BRACKET,
        ASTERISK,
        PLUS,
        MINUS,
        SLASH,
        PERCENT,
        STRING_CONSTANT,
        NUMERIC_CONSTANT,
        NOT_EQUAL,
        EQUAL,
        MORE_THAN,
        LESS_THAN,
        MORE_OR_EQUALS,
        LESS_OR_EQUALS,
        EOF,
        SQL_BENCH_PARAMETER_SYMBOL,
        UNDEFINED
    }

    public class SqlToken
    {
        private SqlTokenType type;
        private string value;
        private int startCharIndex;
        private int endCharIndex;
        private bool quoted = false;

        public SqlTokenType Type
        {
            get { return type; }
        }

        public string Value
        {
            get { return value; }
        }

        public int StartCharIndex
        {
            get { return startCharIndex; }
            set { startCharIndex = value; }
        }

        public int EndCharIndex
        {
            get { return endCharIndex; }
            set { endCharIndex = value; }
        }

        public bool Quoted
        {
            get { return quoted; }
            set { quoted = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj is SqlToken)
                return (string.Compare(((SqlToken)obj).Value, this.Value, true) == 0 && ((SqlToken)obj).Type == this.Type);
            else
                return base.Equals(obj);
        }

        public bool Equals(SqlTokenType type, string value)
        {
            return string.Compare(this.Value, value, true) == 0 && this.type == type;
        }

        public override int GetHashCode()
        {
            return type.GetHashCode() ^ value.ToUpper().GetHashCode();
        }

        public SqlToken(SqlTokenType type, string value, int startCharIndex, int endCharIndex)
        {
            this.type = type;
            this.value = value;
            this.startCharIndex = startCharIndex;
            this.endCharIndex = endCharIndex;
        }

        public SqlToken(SqlTokenType type, string value)
        {
            this.type = type;
            this.value = value;
            startCharIndex = 0;
            endCharIndex = 0;
        }
    }

}
