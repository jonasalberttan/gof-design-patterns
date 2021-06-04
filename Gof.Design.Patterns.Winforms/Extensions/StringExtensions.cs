
namespace Gof.Design.Patterns.Winforms.Extensions
{
    public static class StringExtensions
    {
        public static bool IsRequired(this string value)
        {
            return value.Trim().Length == 0;
        }
    }
}
