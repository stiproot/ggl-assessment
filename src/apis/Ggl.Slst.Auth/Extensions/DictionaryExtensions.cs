namespace Ggl.Slst.Auth.Extensions;

public static class DictionaryExtensions
{
    public static FormUrlEncodedContent ToFormUrlEncodedContent(this IDictionary<string, string>  @this) 
        => new(@this);
}