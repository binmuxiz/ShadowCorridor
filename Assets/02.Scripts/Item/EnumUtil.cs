using System;

public static class EnumUtil<T>
{
    public static T StringToEnum(string str)
    {
        return (T)Enum.Parse(typeof(T), str);
    }
}
