using System.Text;

namespace Ovn4_Collections.Extensions;

public static class StringBuilderExtensions
{
    public static StringBuilder PrependLine(this StringBuilder sb, string content)
    {
        return sb.Insert(0, $"{content}{Environment.NewLine}");
    }
}
