using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ArrayExtentionMethods
{
    public static bool Contains<T>(this T[] array, T Element)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (!EqualityComparer<T>.Default.Equals(array[i], Element))
            {
                return true;
            }
        }
        return false;
    }
    public static bool Contains(this string[] array, string Element)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == Element)
            {
                return true;
            }
        }
        return false;
    }

    public static T[] Add<T>(this T[] array, T Element)
    {

        T[] newArray = new T[array.Length + 1];
        System.Array.Copy(array, newArray, array.Length);
        newArray[newArray.Length - 1] = Element;
        return newArray;
    }
}
