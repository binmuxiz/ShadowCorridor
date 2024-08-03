using System;

public static class EnumUtil<T>
{
    public static T Parse(string str)
    {
        return (T)Enum.Parse(typeof(T), str);
    }
}
