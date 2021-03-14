/// Template de testes de performance
/// 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class nestedClass3
{
    public bool bool1;
}
[System.Serializable]
public class nestedClass2
{
    public bool bool1;
    public nestedClass3 NestedClass3;

}
[System.Serializable]
public class nestedClass
{
    public bool bool1;
    public nestedClass2 NestedClass2;

}

/// <summary>

/// </summary>
public static class StopwatchExtensions
{
    public static long RunTest(this Stopwatch stopwatch, PerformanceTests.TestCode testFunction)
    {
        stopwatch.Reset();
        stopwatch.Start();
        testFunction();
        return stopwatch.ElapsedMilliseconds;
    }
    public static long RunPrintTest(this Stopwatch stopwatch, PerformanceTests.TestCode testFunction)
    {
        stopwatch.Reset();
        stopwatch.Start();
        testFunction();
        return stopwatch.ElapsedMilliseconds;
    }
}

public class TestClass
{
    public int IntField;
    public int IntProperty { get; set; }
    public void VoidMethod() { }
    public bool field;
}

public class PerformanceTest
{
    public static void TestMethod(PerformanceTests.TestCode testFunction)
    {
        Stopwatch sw = new Stopwatch();
        float time = sw.RunTest(testFunction);
        UnityEngine.Debug.Log("Time Elapsed " + time + " miliseconds");
    }
}
public class PerformanceTests : MonoBehaviour
{
    public xbool specialBool;
    public xTbool specialXTBool;
    public xBoolData xboolData;
    public nestedClass NestedClass;
    public int StartIterationsPerFrame = 100000;
    [ReadOnly]
    public int CurrentIterationsPerFrame = 100000;
    public float TestDuration = 5f;
    public bool InstabilityCorrection = true;
    public float Looseness = 1f;
    [ReadOnlyInPlayMode]
    public bool started;
    [ReadOnlyInPlayMode]
    public float StartTime;
    public delegate void TestCode();

    [ReadOnlyInPlayMode]
    public TestBlock currentTestBlock;
    [ReadOnlyInPlayMode]
    public TestCode CurrentCode;
    [ReadOnlyInPlayMode]
    public List<TestBlock> codes;
    Stopwatch stopwatch;
    bool bool1;
    float float1;
    bool[] array1 = new bool[20] { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, };
    List<bool> List1 = new List<bool>() { true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, };
    LayerMask layermask1 = 1 << 8;


    void Start()
    {
        stopwatch = new Stopwatch();
        codes = new List<TestBlock>();

        codes.Add(new TestBlock("Empty for loop", 1, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
            }
        }));

        codes.Add(new TestBlock("bool1 = true", 1, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                bool1 = true;
            }
        }));

        codes.Add(new TestBlock("bool1 = true 20x per loop", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                bool1 = true;
                bool1 = true;
                bool1 = true;
                bool1 = true;
                bool1 = true;
                bool1 = true;
                bool1 = true;
                bool1 = true;
                bool1 = true;
                bool1 = true;

                bool1 = true;
                bool1 = true;
                bool1 = true;
                bool1 = true;
                bool1 = true;
                bool1 = true;
                bool1 = true;
                bool1 = true;
                bool1 = true;
                bool1 = true;
            }
        }));
        codes.Add(new TestBlock("NestedClass.bool1  = true 20x per loop", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                NestedClass.bool1 = true;
                NestedClass.bool1 = true;
                NestedClass.bool1 = true;
                NestedClass.bool1 = true;
                NestedClass.bool1 = true;

                NestedClass.bool1 = true;
                NestedClass.bool1 = true;
                NestedClass.bool1 = true;
                NestedClass.bool1 = true;
                NestedClass.bool1 = true;

                NestedClass.bool1 = true;
                NestedClass.bool1 = true;
                NestedClass.bool1 = true;
                NestedClass.bool1 = true;
                NestedClass.bool1 = true;

                NestedClass.bool1 = true;
                NestedClass.bool1 = true;
                NestedClass.bool1 = true;
                NestedClass.bool1 = true;
                NestedClass.bool1 = true;
            }
        }));
        codes.Add(new TestBlock("NestedClass.NestedClass2.bool1  = true 20x per loop", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;

                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;

                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;

                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;
                NestedClass.NestedClass2.bool1 = true;
            }
        }));
        codes.Add(new TestBlock("NestedClass.NestedClass2.NestedClass3.bool1  = true 20x per loop", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;

                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;

                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;

                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;
                NestedClass.NestedClass2.NestedClass3.bool1 = true;
            }
        }));
        codes.Add(new TestBlock("(xbool)specialbool.val = true 20x per loop", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                specialBool.val = true;
                specialBool.val = true;
                specialBool.val = true;
                specialBool.val = true;
                specialBool.val = true;

                specialBool.val = true;
                specialBool.val = true;
                specialBool.val = true;
                specialBool.val = true;
                specialBool.val = true;

                specialBool.val = true;
                specialBool.val = true;
                specialBool.val = true;
                specialBool.val = true;
                specialBool.val = true;

                specialBool.val = true;
                specialBool.val = true;
                specialBool.val = true;
                specialBool.val = true;
                specialBool.val = true;
            }
        }));
        codes.Add(new TestBlock("(xbool)specialBool.Set(true); = true 20x per loop", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);

                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);

                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);

                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
            }
        }));

        codes.Add(new TestBlock("(xbool)specialBool.x.value = true 20x per loop", 20, () =>
        {
            specialBool.Optimize();
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                specialBool.x.value = true;
                specialBool.x.value = true;
                specialBool.x.value = true;
                specialBool.x.value = true;
                specialBool.x.value = true;

                specialBool.x.value = true;
                specialBool.x.value = true;
                specialBool.x.value = true;
                specialBool.x.value = true;
                specialBool.x.value = true;

                specialBool.x.value = true;
                specialBool.x.value = true;
                specialBool.x.value = true;
                specialBool.x.value = true;
                specialBool.x.value = true;

                specialBool.x.value = true;
                specialBool.x.value = true;
                specialBool.x.value = true;
                specialBool.x.value = true;
                specialBool.x.value = true;
            }
        }));
        codes.Add(new TestBlock("(xTbool)specialXTBool.val = true 20x per loop", 20, () =>
        {
            specialXTBool.xboolData = new xBoolData();
            specialXTBool.optimized = true;
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                specialXTBool.val = true;
                specialXTBool.val = true;
                specialXTBool.val = true;
                specialXTBool.val = true;
                specialXTBool.val = true;

                specialXTBool.val = true;
                specialXTBool.val = true;
                specialXTBool.val = true;
                specialXTBool.val = true;
                specialXTBool.val = true;

                specialXTBool.val = true;
                specialXTBool.val = true;
                specialXTBool.val = true;
                specialXTBool.val = true;
                specialXTBool.val = true;

                specialXTBool.val = true;
                specialXTBool.val = true;
                specialXTBool.val = true;
                specialXTBool.val = true;
                specialXTBool.val = true;
            }
        }));
        codes.Add(new TestBlock("(xTbool)  specialXTBool.Set(true) 20x per loop", 20, () =>
        {
            specialXTBool.xBrain = GetComponent<XBrain>();
            specialXTBool.xIndex = 0;
            specialXTBool.xboolData = GetComponent<XBrain>().xBoolList[0];
            specialXTBool.optimized = true;
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                specialXTBool.Set(true);
                specialXTBool.Set(true);
                specialXTBool.Set(true);
                specialXTBool.Set(true);
                specialXTBool.Set(true);

                specialXTBool.Set(true);
                specialXTBool.Set(true);
                specialXTBool.Set(true);
                specialXTBool.Set(true);
                specialXTBool.Set(true);

                specialXTBool.Set(true);
                specialXTBool.Set(true);
                specialXTBool.Set(true);
                specialXTBool.Set(true);
                specialXTBool.Set(true);

                specialXTBool.Set(true);
                specialXTBool.Set(true);
                specialXTBool.Set(true);
                specialXTBool.Set(true);
                specialXTBool.Set(true);
            }
        }));
        codes.Add(new TestBlock("(xTbool)specialXTBool.xboolData.value = true; 20x per loop", 20, () =>
        {
            specialXTBool.xBrain = GetComponent<XBrain>();
            specialXTBool.xIndex = 0;
            specialXTBool.xboolData = GetComponent<XBrain>().xBoolList[0];
            specialXTBool.optimized = true;
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;

                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
                specialXTBool.xboolData.value = true;
            }
        }));
        codes.Add(new TestBlock("xboolData.value = true; 20x per loop", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                xboolData.value = true;
                xboolData.value = true;
                xboolData.value = true;
                xboolData.value = true;
                xboolData.value = true;

                xboolData.value = true;
                xboolData.value = true;
                xboolData.value = true;
                xboolData.value = true;
                xboolData.value = true;

                xboolData.value = true;
                xboolData.value = true;
                xboolData.value = true;
                xboolData.value = true;
                xboolData.value = true;

                xboolData.value = true;
                xboolData.value = true;
                xboolData.value = true;
                xboolData.value = true;
                xboolData.value = true;
            }
        }));
        codes.Add(new TestBlock("(xbool) specialBool.Set(true); 20x per loop", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);

                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);

                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);

                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
                specialBool.Set(true);
            }
        }));
        codes.Add(new TestBlock("bool1 = true 100x", 100, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true;
                bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true;
                bool1 = true; bool1 = true; bool1 = true; bool1 = true;

                bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true;
                bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true;
                bool1 = true; bool1 = true; bool1 = true; bool1 = true;

                bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true;
                bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true;
                bool1 = true; bool1 = true; bool1 = true; bool1 = true;

                bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true;
                bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true;
                bool1 = true; bool1 = true; bool1 = true; bool1 = true;

                bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true;
                bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true; bool1 = true;
                bool1 = true; bool1 = true; bool1 = true; bool1 = true;
            }
        }));


        codes.Add(new TestBlock("ArrayLength = array1.Length\n .. \nfor (int ib = 0; ib < ArrayLength; ib++)\n{\n \tarray1[i] = true;\n} 20x loops (Array)", 20, () =>
        {
            int ArrayLength = array1.Length;
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                for (int ib = 0; ib < ArrayLength; ib++)
                {
                    array1[ib] = true;
                }
            }
        }));


        codes.Add(new TestBlock("ArrayLength = array1.Length\nfor (int ib = 0; ib < ArrayLength; ib++)\n{\n \tarray1[i] = true;\n} 20x loops (Array)", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                int ArrayLength = array1.Length;
                for (int ib = 0; ib < ArrayLength; ib++)
                {
                    array1[ib] = true;
                }
            }
        }));

        codes.Add(new TestBlock("for (int ib = 0; ib < array1.Length; ib++)\n{\n \tarray1[ib] = true;\n} 20x loops loops (Array)", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                for (int ib = 0; ib < array1.Length; ib++)
                {
                    array1[ib] = true;
                }
            }
        }));


        codes.Add(new TestBlock("for (int ib = 0; ib < array1.Length; ib++)\n{\n \tbool1 = true;\n} 20x loops (Array)", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                for (int ib = 0; ib < array1.Length; ib++)
                {
                    bool1 = true;
                }
            }
        }));
        codes.Add(new TestBlock("for (int ib = 0; ib < array1.Length; ib++)\n{\n \tbool bool3 = true;\n} 20x loops (Array)", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                for (int ib = 0; ib < array1.Length; ib++)
                {
                    bool bool3 = true;
                }
            }
        }));
        codes.Add(new TestBlock("for (int ib = 0; ib < List1.Count; ib++)\n{\n \tList1[ib] = true;\n} 20x loops (list)", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                for (int ib = 0; ib < List1.Count; ib++)
                {
                    List1[ib] = true;
                }
            }
        }));
        codes.Add(new TestBlock("ListCount = List1.Count\n for (int ib = 0; ib < listCount; ib++)\n{\n \tList1[ib] = true;\n} 20x loops (list)", 20, () =>
        {
            int listCount = List1.Count;
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                for (int ib = 0; ib < listCount; ib++)
                {
                    List1[ib] = true;
                }
            }
        }));
        codes.Add(new TestBlock("for (int ib = 0; ib < List1.Count; ib++)\n{\n \t bool1 = true;\n} 20x loops (list)", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                for (int ib = 0; ib < List1.Count; ib++)
                {
                    bool1 = true;
                }
            }
        }));


        codes.Add(new TestBlock("ListCount = List1.Count\nfor (int ib = 0; ib < ListCount; ib++)\n{\n \t bool1 = true;\n} 20x loops (list)", 20, () =>
        {
            var listCount = List1.Count;
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                for (int ib = 0; ib < listCount; ib++)
                {
                    bool1 = true;
                }
            }
        }));

        codes.Add(new TestBlock("Array.ForEach(array1, n => n = true) 20x loops (Array)", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                System.Array.ForEach(array1, n => n = true);
            }
        }));

        codes.Add(new TestBlock("Array.ForEach(array1, n => bool1 = true) 20x loops (Array)", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                System.Array.ForEach(array1, n => bool1 = true);
            }
        }));


        codes.Add(new TestBlock("List1.ForEach(n => n = true) 20x lopps (list)", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                List1.ForEach(n => n = true);
            }
        }));

        codes.Add(new TestBlock("List1.ForEach(n => bool1 = true) 20x loops (list)", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                List1.ForEach(n => bool1 = true);
            }
        }));

        codes.Add(new TestBlock("foreach (bool booln in array1)\n{\n \t bool1 = booln;\n} 20x loops (Array)", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                foreach (bool booln in array1)
                {
                    bool1 = booln;
                }
            }
        }));

        codes.Add(new TestBlock("foreach (bool booln in List1)\n{\n \t bool1 = booln;\n} 20x loops (List)", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                foreach (bool booln in List1)
                {
                    bool1 = booln;
                }
            }
        }));

        codes.Add(new TestBlock("Physics2D.Raycast(Vector2.zero, Vector2.right, 3f) 20x per loop", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f);
            }
        }));

        codes.Add(new TestBlock("Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1) 20x per loop", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1); Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1); Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
                Physics2D.Raycast(Vector2.zero, Vector2.right, 3f, layermask1);
            }
        }));

        codes.Add(new TestBlock("Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1) 20x per loop", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
                Physics2D.OverlapArea(Vector2.zero, Vector2.right, layermask1);
            }
        }));

        codes.Add(new TestBlock("Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1) 20x per loop", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
                Physics2D.OverlapCircle(Vector2.zero, 1f, layermask1);
            }
        }));

        codes.Add(new TestBlock("GetComponent<PerformanceTests>(); 20x per loop", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();
                GetComponent<PerformanceTests>();

            }
        }));
        GameObject GameObj = new GameObject();
        //  GameObj.AddComponent<SpriteRenderer>();
        codes.Add(new TestBlock("GameObj.SetActive(true); 20x per loop", 20, () =>
    {

        for (long i = 0; i < CurrentIterationsPerFrame; ++i)
        {
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);
            GameObj.SetActive(true);

        }
    }));
        codes.Add(new TestBlock("GameObj.SetActive(false); 20x per loop", 20, () =>
        {

            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);
                GameObj.SetActive(false);

            }
        }));
        codes.Add(new TestBlock("GameObj.SetActive(false) Consecutive to GameObj.SetActive(true) 20x per loop", 20, () =>
        {

            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                GameObj.SetActive(false);
                GameObj.SetActive(true);
                GameObj.SetActive(false);
                GameObj.SetActive(true);
                GameObj.SetActive(false);
                GameObj.SetActive(true);
                GameObj.SetActive(false);
                GameObj.SetActive(true);
                GameObj.SetActive(false);
                GameObj.SetActive(true);
                GameObj.SetActive(false);
                GameObj.SetActive(true);
                GameObj.SetActive(false);
                GameObj.SetActive(true);
                GameObj.SetActive(false);
                GameObj.SetActive(true);
                GameObj.SetActive(false);
                GameObj.SetActive(true);
                GameObj.SetActive(false);
                GameObj.SetActive(true);
            }
        }));

        codes.Add(new TestBlock("Instantiate(GameObj); 1 per loop", 1, () =>
        {

            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                Instantiate(GameObj);
            }
        }));
        codes.Add(new TestBlock("Physics2D.OverlapPoint(Vector2.zero, layermask1) 20x per loop", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
                Physics2D.OverlapPoint(Vector2.zero, layermask1);
            }
        }));
        codes.Add(new TestBlock("sendMessage(testMethod)", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");
                SendMessage("testMethod");

            }
        }));
        codes.Add(new TestBlock(" text.SetPixel() 150x100", 1, () =>
        {
            Texture2D text = new Texture2D(150, 100);
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                for (int y = 0; y < 100; y++)
                {
                    for (int x = 0; x < 150; x++)
                    {
                        Color color = new Color();
                        text.SetPixel(x, y, color);
                    }
                }
            }


        }));

        Animator animator = GetComponent<Animator>();
        codes.Add(new TestBlock("animator.GetBool(grounded) x 20", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
                animator.GetBool("grounded");
            }


        }));
        codes.Add(new TestBlock("animator.GetFloat(hor) x 20", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
                animator.GetFloat("hor");
            }


        }));

        bool[] boolsMatrix = new bool[20];
        codes.Add(new TestBlock("bool test = boolsMatrix[15] x 20", 20, () =>
        {
            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                bool test = boolsMatrix[15];
                test = boolsMatrix[15];
                test = boolsMatrix[13];
                test = boolsMatrix[14];
                test = boolsMatrix[15];
                test = boolsMatrix[12];
                test = boolsMatrix[15];
                test = boolsMatrix[15];
                test = boolsMatrix[14];
                test = boolsMatrix[15];
                test = boolsMatrix[15];
                test = boolsMatrix[10];
                test = boolsMatrix[11];
                test = boolsMatrix[15];
                test = boolsMatrix[15];
                test = boolsMatrix[15];
                test = boolsMatrix[15];
                test = boolsMatrix[15];
                test = boolsMatrix[15];
                test = boolsMatrix[15];
            }


        }));

        codes.Add(new TestBlock("For X(150) inner For Y(100) => matrixBool[x, y] = true;", 1, () =>
        {
            bool[,] matrixBool = new bool[150, 100];

            for (long i = 0; i < CurrentIterationsPerFrame; ++i)
            {
                for (int y = 0; y < 100; y++)
                {
                    for (int x = 0; x < 150; x++)
                    {
                        matrixBool[x, y] = true;
                    }
                }
            }


        }));

    }

    void testMethod()
    {

    }

    public class TestBlock
    {
        public string name;
        public int IterationsMultiplier;

        public float Time;
        public int ResultIterationsPerFrame;
        public TestCode code;
        public int iterationsCount;
        public float instability;
        public float frameRate;
        public int FrameCount;

        public TestBlock(string name, int EffetiveIterationsPerFrame, TestCode code)
        {
            this.name = name;
            this.IterationsMultiplier = EffetiveIterationsPerFrame;
            this.code = code;
        }
        public void Reset()
        {
            iterationsCount = 0;
            instability = 0f;
            FrameCount = 0;
            frameRate = 0f;
        }

        public void Close()
        {
            iterationsCount = iterationsCount / FrameCount;
            instability = instability / FrameCount;
            frameRate = frameRate / FrameCount;
        }
    }

    bool testingAll;
    public float TestAllStartTime;
    public IEnumerator TestAll()
    {
        testingAll = true;
        TestAllStartTime = Time.time;
        for (int i = 0; i < codes.Count; i++)
        {
            while (started)
            {
                yield return new WaitForEndOfFrame();
            }
            started = true;
            StartTime = Time.time;
            currentTestBlock = codes[i];
            currentTestBlock.Reset();
            CurrentIterationsPerFrame = StartIterationsPerFrame;
            CurrentCode = codes[i].code;
        }
        testingAll = false;
    }

    void Update()
    {
        if (started)
        {
            var speed = stopwatch.RunTest(CurrentCode);

            float targetDeltaTime = QualitySettings.vSyncCount == 1 ? 0.0166666666f : QualitySettings.vSyncCount == 2 ? 0.033333333333f : Application.targetFrameRate > 1 ? 1f / Application.targetFrameRate : 0.016666f;
            instability = targetDeltaTime / Time.deltaTime;

            if (speed != 0f)
            {
                CurrentIterationsPerFrame = (int)((float)CurrentIterationsPerFrame / (speed / ((targetDeltaTime * 1000f) / Looseness)));
                // print("instability " + instability);
                if (InstabilityCorrection)
                {
                    CurrentIterationsPerFrame = (int)((float)CurrentIterationsPerFrame * instability);
                }
            }
            else
            {
                CurrentIterationsPerFrame *= 8;
            }




            if (instability > 1f)
                instability -= 1f;
            else
                instability = 1f - instability;

            currentTestBlock.instability += instability;

            currentTestBlock.iterationsCount += CurrentIterationsPerFrame * currentTestBlock.IterationsMultiplier;

            currentTestBlock.frameRate += (1f / Time.deltaTime);

            currentTestBlock.FrameCount++;




            // print(speed);
        }
    }

    public Vector2 sp;
    float instability;

    void OnGUI()
    {
        if (started && Time.time > StartTime + TestDuration)
        {
            currentTestBlock.Close();
            started = false;
        }

        GUILayout.BeginArea(new Rect(10, 10, Screen.width, Screen.width));
        var richTextLabel = new GUIStyle();
        richTextLabel.richText = true;
        richTextLabel.normal.textColor = Color.cyan;
        richTextLabel.fontStyle = FontStyle.Bold;
        GUILayout.Label("Fps: " + (1f / Time.deltaTime).ToString("0.0") + " DeltaTime: " + Time.deltaTime.ToString("0.000") + " Instability: " + (instability * 100f).ToString("0.000") + "% code iterations: " + (currentTestBlock != null ? (CurrentIterationsPerFrame * currentTestBlock.IterationsMultiplier) : CurrentIterationsPerFrame));
        sp = GUILayout.BeginScrollView(sp, false, true, GUILayout.Width(Screen.width - 60f), GUILayout.Height(Screen.height - 60f));
        GUILayout.BeginHorizontal(GUI.skin.box);

        InstabilityCorrection = GUILayout.Toggle(InstabilityCorrection, "Instability Corretion");
        GUILayout.Label("Looseness: " + Looseness.ToString("0.00"));
        Looseness = GUILayout.HorizontalSlider(Looseness, 0.1f, 50f);
        if (GUILayout.Button("Exit"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelector");
        }
        GUILayout.EndHorizontal();
        if (!started && !testingAll && GUILayout.Button("Test All"))
        {
            StartCoroutine(TestAll());
        }
        if (testingAll)
        {
            GUILayout.Label("<color=lime>" + (((Time.time - TestAllStartTime) / (codes.Count * TestDuration)) * 100f).ToString("0.0") + "%</color>");
            if (GUILayout.Button("Stop All"))
            {
                started = false;
                testingAll = false;
                currentTestBlock.Reset();
                StopAllCoroutines();
            }
        }


        for (int i = 0; i < codes.Count; i++)
        {
            GUILayout.BeginHorizontal(GUI.skin.box);
            GUILayout.BeginVertical(GUI.skin.box);

            GUILayout.Label(codes[i].name, richTextLabel);
            if (currentTestBlock != codes[i] || !started)
            {
                GUILayout.Label("   Average Framerate: " + codes[i].frameRate.ToString("0.00"));
                GUILayout.Label("   Average Instability: " + (codes[i].instability * 100f).ToString("0.00") + "%");
                GUILayout.Label("   Average Iterations Per Frame: <color=lime>" + Mathf.Abs(codes[i].iterationsCount).ToString("0,000.") + "</color>");
            }
            else
            {
                GUILayout.Space(16f);
                GUILayout.Label(" <color=lime>Running</color>");
                GUILayout.Space(16f);
            }
            GUILayout.EndVertical();
            if (started)
                GUI.enabled = false;
            if (GUILayout.Button("Go"))
            {
                started = true;
                StartTime = Time.time;
                currentTestBlock = codes[i];
                currentTestBlock.Reset();
                CurrentIterationsPerFrame = StartIterationsPerFrame;
                CurrentCode = codes[i].code;
            }
            GUI.enabled = true;
            GUILayout.EndHorizontal();

        }
        GUILayout.EndScrollView();

        GUILayout.EndArea();
    }

}