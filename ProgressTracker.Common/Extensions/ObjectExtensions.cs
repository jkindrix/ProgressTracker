using System.Net.NetworkInformation;
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

        public static object? TryGetProperty(this object obj, string property)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanRead)
            {
                return prop.GetValue(obj);
            }
            return null;
        }

        public static string? TryGetClassName(this object obj)
        {
            var name = obj.GetType().Name;
            if (name != null)
            {
                return name;
            }
            return null;
        }

        public static void TryInvokeMethod(this object obj, string method, params object[] args)
        {
            obj.GetType().GetMethod(method)?.Invoke(obj, args);
        }
    }
}