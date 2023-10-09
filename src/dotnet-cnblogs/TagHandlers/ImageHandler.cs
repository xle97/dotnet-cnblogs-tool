using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Dotnetcnblog.TagHandlers
{
    /// <summary>
    /// 图片标签处理程序
    /// </summary>
    public class ImageHandler : ITagHandler
    {
        private const string MatchRule = @"!\[.*?\]\((.*?)\)";

        private const string MatchHtmlRule = @"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>";

        public List<string> Process(string content)
        {
            var result = new List<string>();

            var matchResult = Regex.Matches(content, MatchRule, RegexOptions.IgnoreCase | RegexOptions.RightToLeft);

            foreach (Match match in matchResult) result.Add(match.Groups[1].Value);
            
            matchResult = Regex.Matches(content, MatchHtmlRule, RegexOptions.IgnoreCase);

            foreach (Match match in matchResult) result.Add(match.Groups[1].Value);

            return result;
        }
    }
}