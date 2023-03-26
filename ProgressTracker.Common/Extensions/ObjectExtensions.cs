using System.Reflection;

namespace ProgressTracker.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static bool TrySetProperty(this object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(obj, value, null);
                return true;
            }
            return false;
        }
    }
}