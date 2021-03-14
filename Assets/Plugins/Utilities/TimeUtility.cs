using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUtility
{

    public static string FormatSeconds(float elapsed)
    {
        int d = (int)(elapsed * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;
        return System.String.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public static string FormatSeconds2(float elapsed)
    {
        int d = (int)(elapsed * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;
        return System.String.Format("{0:00}\'{1:00}\"", minutes, seconds);
    }
}
