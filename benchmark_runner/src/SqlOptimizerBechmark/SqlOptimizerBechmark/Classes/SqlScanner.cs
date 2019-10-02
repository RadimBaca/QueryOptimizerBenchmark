using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlOptimizerBechmark.Classes
{
    public class SqlScanner
    {
        private static char[] splitters = { ' ', '\t', '\r', '\n', ')', '(', ')', '+', '-', '*', '/', '.', ',', '=', '>', '<', '!', '%' };
        private static char[] whiteChars = { ' ', '\t', '\r', '\n' };
        private static char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static char[] identifierChars = { '_', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'á', 'ä', 'č', 'ď', 'é', 'ě', 'í', 'ĺ', 'ľ', 'ň', 'ó', 'ô', 'ŕ', 'ř', 'š', 'ť', 'ú', 'ů', 'ý', 'ž',
            'Á', 'Ä', 'Č', 'Ď', 'É', 'Ě', 'Í', 'Ĺ', 'Ľ', 'Ň', 'Ó', 'Ô', 'Ŕ', 'Ř', 'Š', 'Ť', 'Ú', 'Ů', 'Ý', 'Ž'};
        private static char[] firstIdentifierChars = { '_',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'á', 'ä', 'č', 'ď', 'é', 'ě', 'í', 'ĺ', 'ľ', 'ň', 'ó', 'ô', 'ŕ', 'ř', 'š', 'ť', 'ú', 'ů', 'ý', 'ž',
            'Á', 'Ä', 'Č', 'Ď', 'É', 'Ě', 'Í', 'Ĺ', 'Ľ', 'Ň', 'Ó', 'Ô', 'Ŕ', 'Ř', 'Š', 'Ť', 'Ú', 'Ů', 'Ý', 'Ž'};

        private static char decimalSeparator = '.';
        private static char stringChar = '\'';
        private static char identifierChar1 = '\"';
        private static char identifierStartChar2 = '[';
        private static char identifierEndChar2 = ']';
        private static char sqlBenchParamChar = '$';

        private string querySql;
        private SqlToken[] tokens;

        public string QuerySql
        {
            get { return querySql; }
            set { querySql = value; }
        }

        public SqlToken[] Tokens
        {
            get { return tokens; }
        }

        private bool IsInArray(char c, char[] array)
        {
            foreach (char c1 in array)
                if (c1 == c) return true;
            return false;
        }

        private bool IsSplitter(char c) { return IsInArray(c, splitters); }
        private bool IsWhiteChar(char c) { return IsInArray(c, whiteChars); }
        private bool IsDigit(char c) { return IsInArray(c, digits); }
        private bool IsIdentifierChar(char c) { return IsInArray(c, identifierChars); }
        private bool IsFirstIdentifierChar(char c) { return IsInArray(c, firstIdentifierChars); }

        private SqlToken CreateToken(string strSymbol, int startCharIndex, int endCharIndex)
        {

            switch (strSymbol)
            {
                case "(": return new SqlToken(SqlTokenType.LEFT_BRACKET, "(", startCharIndex, endCharIndex);
                case ")": return new SqlToken(SqlTokenType.RIGHT_BRACKET, ")", startCharIndex, endCharIndex);
                case ".": return new SqlToken(SqlTokenType.DOT, ".", startCharIndex, endCharIndex);
                case ",": return new SqlToken(SqlTokenType.COMMA, ",", startCharIndex, endCharIndex);
                case "+": return new SqlToken(SqlTokenType.PLUS, "+", startCharIndex, endCharIndex);
                case "-": return new SqlToken(SqlTokenType.MINUS, "-", startCharIndex, endCharIndex);
                case "*": return new SqlToken(SqlTokenType.ASTERISK, "*", startCharIndex, endCharIndex);
                case "/": return new SqlToken(SqlTokenType.SLASH, "/", startCharIndex, endCharIndex);
                case "%": return new SqlToken(SqlTokenType.PERCENT, "%", startCharIndex, endCharIndex);
                case "=": return new SqlToken(SqlTokenType.EQUAL, "=", startCharIndex, endCharIndex);
                case ">": return new SqlToken(SqlTokenType.MORE_THAN, ">", startCharIndex, endCharIndex);
                case "<": return new SqlToken(SqlTokenType.LESS_THAN, "<", startCharIndex, endCharIndex);
                case ">=": return new SqlToken(SqlTokenType.MORE_OR_EQUALS, ">=", startCharIndex, endCharIndex);
                case "<=": return new SqlToken(SqlTokenType.LESS_OR_EQUALS, "<=", startCharIndex, endCharIndex);
                case "<>": return new SqlToken(SqlTokenType.NOT_EQUAL, "<>", startCharIndex, endCharIndex);
                case "!=": return new SqlToken(SqlTokenType.NOT_EQUAL, "!=", startCharIndex, endCharIndex);
                default:
                    if (strSymbol[0] == sqlBenchParamChar)
                        return new SqlToken(SqlTokenType.SQL_BENCH_PARAMETER_SYMBOL, strSymbol, startCharIndex, endCharIndex);

                    if (strSymbol[0] == stringChar)
                        return new SqlToken(SqlTokenType.STRING_CONSTANT, strSymbol.Substring(1, strSymbol.Length - 2).Replace("''", "'"), startCharIndex, endCharIndex);

                    //strSymbol = strSymbol.ToUpper();

                    if (IsDigit(strSymbol[0]) || (strSymbol[0] == decimalSeparator))
                    {
                        foreach (char c in strSymbol)
                            if (!IsDigit(c) && (c != decimalSeparator))
                                throw new SqlScannerException(SqlScannerException.CODE_INVALID_NUMERIC_SYMBOL, "Invalid numeric symbol '" + strSymbol + "'", startCharIndex, endCharIndex);
                        return new SqlToken(SqlTokenType.NUMERIC_CONSTANT, strSymbol, startCharIndex, endCharIndex);
                    }

                    if (strSymbol[0] == identifierChar1)
                        return new SqlToken(SqlTokenType.IDENTIFIER_OR_KEYWORD, strSymbol.Substring(1, strSymbol.Length - 2).Replace("\"\"", "\""), startCharIndex, endCharIndex);

                    if (strSymbol[0] == identifierStartChar2)
                        return new SqlToken(SqlTokenType.IDENTIFIER_OR_KEYWORD, strSymbol.Substring(1, strSymbol.Length - 2).Replace("]]", "]"), startCharIndex, endCharIndex);

                    if (IsFirstIdentifierChar(strSymbol[0]))
                    {
                        foreach (char c in strSymbol)
                            if (!IsIdentifierChar(c))
                                throw new SqlScannerException(SqlScannerException.CODE_INVALID_IDENTIFIER_SYMBOL, "Invalid identifier symbol '" + strSymbol + "'", startCharIndex, endCharIndex);

                        // Specialni test... nektera klicova slova mohou byt taky funkce (LEFT, RIGHT)
                        bool functionFollows = false;
                        int index = endCharIndex + 1;
                        while (index < querySql.Length && IsWhiteChar(querySql[index]))
                        {
                            index++;
                        }
                        if (index < querySql.Length && querySql[index] == '(')
                        {
                            functionFollows = true;
                        }

                        return new SqlToken(SqlTokenType.IDENTIFIER_OR_KEYWORD, strSymbol, startCharIndex, endCharIndex);
                    }

                    throw new SqlScannerException(SqlScannerException.CODE_INVALID_SYMBOL, "Invalid symbol '" + strSymbol + "'", startCharIndex, endCharIndex);
            }
        }

        private List<SqlToken> Tokenize()
        {
            List<SqlToken> result = new List<SqlToken>();

            string token = string.Empty;
            bool readingString = false;         // Priznak - cte se string
            bool readingIdentifier1 = false;    // Priznak - cte se identifikator v uvozovkach
            bool readingIdentifier2 = false;    // Priznak - cte se identifikator v hranatych zavorkach
            bool readingComment1 = false;       // Priznak - cte se jednoradkovy komentar uvozeny --
            bool readingComment2 = false;       // Priznak - cte se viceradkovy komentar mezi /*  */
            char nextChar;
            char currChar;
            int startCharIndex = 0;
            int index = 0;

            while (index < querySql.Length)
            {
                currChar = querySql[index];

                if (index + 1 < querySql.Length)
                    nextChar = querySql[index + 1];
                else
                    nextChar = (char)0;

                // Zacatek unikodoveho textoveho retezce
                if (currChar == 'N' && nextChar == stringChar && !readingString && !readingIdentifier1 && !readingIdentifier2 && !readingComment1 && !readingComment2)
                {
                    if (token != string.Empty) result.Add(CreateToken(token, startCharIndex, index - 1));
                    readingString = true;
                    index++;
                }
                // Textove retezce
                else if (currChar == stringChar && !readingIdentifier1 && !readingIdentifier2 && !readingComment1 && !readingComment2)
                {
                    if (readingString)
                    {
                        if (nextChar == stringChar)
                        {
                            index++;
                            token += stringChar.ToString() + stringChar.ToString();
                        }
                        else
                        {
                            result.Add(CreateToken(stringChar.ToString() + token + stringChar.ToString(), startCharIndex, index));
                            readingString = false;
                            token = string.Empty;
                        }
                    }
                    else
                    {
                        if (token != string.Empty) result.Add(CreateToken(token, startCharIndex, index - 1));
                        readingString = true;
                    }
                }
                // Identifikatory v uvozovkach "..."
                else if (currChar == identifierChar1 && !readingString && !readingIdentifier2 && !readingComment1 && !readingComment2)
                {
                    if (readingIdentifier1)
                    {
                        if (nextChar == identifierChar1)
                        {
                            index++;
                            token += identifierChar1.ToString() + identifierChar1.ToString();
                        }
                        else
                        {
                            SqlToken sqlToken = CreateToken(identifierChar1.ToString() + token + identifierChar1.ToString(), startCharIndex, index);
                            sqlToken.Quoted = true;
                            result.Add(sqlToken);

                            readingIdentifier1 = false;
                            token = string.Empty;
                        }
                    }
                    else
                    {
                        if (token != string.Empty) result.Add(CreateToken(token, startCharIndex, index - 1));
                        readingIdentifier1 = true;
                    }
                }
                // Identifikatory v hranatych zavorkach [...]
                else if (currChar == identifierStartChar2 && !readingString && !readingIdentifier1 && !readingIdentifier2 && !readingComment1 && !readingComment2)
                {
                    if (token != string.Empty) result.Add(CreateToken(token, startCharIndex, index - 1));
                    readingIdentifier2 = true;
                }
                else if (currChar == identifierEndChar2 && readingIdentifier2)
                {
                    if (nextChar == identifierEndChar2)
                    {
                        index++;
                        token += identifierEndChar2.ToString() + identifierEndChar2.ToString();
                    }
                    else
                    {
                        SqlToken sqlToken = CreateToken(identifierStartChar2.ToString() + token + identifierEndChar2.ToString(), startCharIndex, index);
                        sqlToken.Quoted = true;
                        result.Add(sqlToken);

                        readingIdentifier2 = false;
                        token = string.Empty;
                    }
                }
                // Jedoradkovy komentar
                else if (currChar == '-' && nextChar == '-' && !readingString && !readingIdentifier1 && !readingIdentifier2 && !readingComment1 && !readingComment2)
                {
                    if (token != string.Empty) result.Add(CreateToken(token, startCharIndex, index - 1));
                    readingComment1 = true;
                }
                else if (currChar == '\n' && readingComment1)
                {
                    readingComment1 = false;
                    token = string.Empty;
                }
                // Viceradkovy komentar
                else if (currChar == '/' && nextChar == '*' && !readingString && !readingIdentifier1 && !readingIdentifier2 && !readingComment1 && !readingComment2)
                {
                    if (token != string.Empty) result.Add(CreateToken(token, startCharIndex, index - 1));
                    readingComment2 = true;
                }
                else if (currChar == '*' && nextChar == '/' && readingComment2)
                {
                    index++;
                    readingComment2 = false;
                    token = string.Empty;
                }
                else
                {
                    bool extendToken = false;

                    if (!readingString && !readingIdentifier1 && !readingIdentifier2 && !readingComment1 && !readingComment2)
                    {
                        if (IsSplitter(currChar) && !(currChar == decimalSeparator && IsDigit(nextChar) && (token == string.Empty || IsDigit(token[0]))))
                        {
                            if (token != string.Empty)
                                result.Add(CreateToken(token, startCharIndex, index - 1));

                            if (!IsWhiteChar(currChar))
                            {
                                if (currChar == '>' && nextChar == '=')
                                {
                                    result.Add(CreateToken(">=", index, index + 2));
                                    index++;
                                }
                                else if (currChar == '<' && nextChar == '=')
                                {
                                    result.Add(CreateToken("<=", index, index + 2));
                                    index++;
                                }
                                else if (currChar == '<' && nextChar == '>')
                                {
                                    result.Add(CreateToken("<>", index, index + 2));
                                    index++;
                                }
                                else if (currChar == '!' && nextChar == '=')
                                {
                                    result.Add(CreateToken("!=", index, index + 2));
                                    index++;
                                }
                                else
                                    result.Add(CreateToken(currChar.ToString(), index, index));

                            }

                            token = string.Empty;
                            startCharIndex = index + 1;
                        }
                        else
                        {
                            extendToken = true;
                        }
                    }
                    else
                    {
                        extendToken = true;
                    }

                    if (extendToken)
                    {
                        token += currChar;
                    }
                }
                index++;
            }

            if (readingString)
                throw new SqlScannerException(SqlScannerException.CODE_UNTERMINATED_STRING, "Unterminated string", startCharIndex, index);
            if (token != string.Empty) result.Add(CreateToken(token, startCharIndex, index - 1));

            result.Add(new SqlToken(SqlTokenType.EOF, string.Empty, startCharIndex, index));
            return result;
        }

        public void Scan()
        {
            tokens = Tokenize().ToArray();
        }

        public SqlScanner(string querySql)
        {
            this.querySql = querySql;
        }
    }
}
