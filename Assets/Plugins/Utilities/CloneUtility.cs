using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class CloneUtility
{

    public static object Clone<T>(T toClone)
    {
        T newObj = (T)Activator.CreateInstance(toClone.GetType());
        var Properties = toClone.GetType().GetProperties();

        for (int i = 0; i < Properties.Length; i++)
        {
            var value = Properties[0].GetValue(toClone, null);
            if (Properties[i].PropertyType.IsArray)
            {
                Array newArray = null;
                Array.Copy((Array)value, newArray, ((Array)value).Length);
                Properties[i].SetValue(newObj, newArray, null);
            }
            else
            {
                Properties[i].SetValue(newObj, value, null);
            }

        }
        return newObj;
    }
}
