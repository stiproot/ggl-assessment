using System.Text.RegularExpressions;

namespace Ggl.Slst.Db.Extensions;

public static partial class StringExtensions
{
    public static string ToSnakeCase(this string @this)
        => Regex.Replace(@this, "[A-Z]", "_$0")
            .ToLower()
            .Remove(0, 1);

    public static string ToPostgresParameter(this string @this)
        => $"p_{@this.ToSnakeCase()}";
}
