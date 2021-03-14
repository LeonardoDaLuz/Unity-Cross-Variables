
public static class NullExtensionMethods
{
    public static void Safe<T>(this T obj, GenericMethod2<T> dl)
    {
        if (obj != null)
            dl(obj);
        //expr.Compile();
    }

    public delegate void GenericMethod2<T>(T n);
}