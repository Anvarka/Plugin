using System.Collections.Generic;

namespace Parser
{
    public class PascalLexer
    {
        public List<Token> listOfTokens = new();
        public bool isMultiLineComment = false;
        public string multiLineComment = "";
        public string typeMultiLineComment = "";


        public List<Token> getToken(string line)
        {
            while (line != "")
            {
                if (isMultiLineComment)
                {
                    var eof = new Pattern(@"\s*(\*\)|\})\s*", TokenType.EofSymbol);
                    var matchEof = eof.getRegex().Match(line);
                    if (!matchEof.Success || matchEof.Value != typeMultiLineComment)
                    {
                        multiLineComment += line + "\n";
                        break;
                    }

                    var index = matchEof.Index;
                    multiLineComment += line.Substring(index);
                    if (typeMultiLineComment == "*)")
                    {
                        multiLineComment = "(*" + multiLineComment;
                    }
                    else
                    {
                        multiLineComment = "{" + multiLineComment;
                    }

                    listOfTokens.Add(new Token(TokenType.MultiLineComment, multiLineComment));
                    multiLineComment = "";
                    line = line.Substring(index + typeMultiLineComment.Length);
                    isMultiLineComment = false;
                    typeMultiLineComment = "";
                }

                foreach (var curPattern in Pattern.getAllPatterns())
                {
                    var match = curPattern.getRegex().Match(line);
                    if (!match.Success)
                    {
                        continue;
                    }

                    if (curPattern.getType() == TokenType.ProgramSymbol)
                    {
                        if (match.Value == "(*")
                        {
                            typeMultiLineComment = "*)";
                            isMultiLineComment = true;
                        }
                        else if (match.Value == "{")
                        {
                            typeMultiLineComment = "}";
                            isMultiLineComment = true;
                        }
                    }

                    if (!isMultiLineComment)
                    {
                        listOfTokens.Add(new Token(curPattern.getType(), match.Value.Trim()));
                    }

                    line = line.Substring(match.Value.Length);

                    break;
                }
            }

            return listOfTokens;
        }
    }
}
