using System;
using System.Reflection;

namespace UNetDump
{
    public static class Reflector
    {
        public static T Reflect<T>(this object instance, string name)
        {
            var t = instance.GetType();

            var f = t.GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if (f == null) throw new InvalidOperationException();

            if (f.IsStatic)
            {
                return (T)f.GetValue(null);
            }
            else
            {
                return (T)f.GetValue(instance);
            }
        }
    }
}