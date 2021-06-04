

namespace Gof.Design.Patterns.Winforms.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsRequired(this object obj)
        {
            if (obj == null) return true;
            return obj.ToString().Trim().Length == 0;
        }
    }
}
