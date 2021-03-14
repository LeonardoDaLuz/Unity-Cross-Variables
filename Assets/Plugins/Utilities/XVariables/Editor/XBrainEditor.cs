using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(XBrain))]
public class XBrainEditor : Editor
{
    [System.NonSerialized]
    private bool afterCompile;
    [System.NonSerialized]
    private bool logPhysics2DIteration;
    bool flagsFold = true;
    bool xFloatsFold = true;
    bool xIntsFold = true;
    public float lastRenderTime;
    public Texture2D styleBox;
    public Vector2 scrollPosition;
    public List<System.Diagnostics.StackFrame> scriptAccessList;


    public override void OnInspectorGUI()
    {

        var inspected = (XBrain)target;
        //  LogRenderTime();

        //CleanUp variables
        if (!afterCompile)
        {
            Debug.Log("Checking unused variables");
            afterCompile = true;
            inspected.CleanUpUnusedVariables();
            inspected.UpdateAnimatorDefaultParameters();
        }

        //Obtain Components and initialize lists
        if (inspected.animator == null)
            inspected.animator = inspected.GetComponent<Animator>();

        if (inspected.xIntList == null)
            inspected.xIntList = new XBrain.xintData[0];

        if (inspected.xBoolList == null)
            inspected.xBoolList = new xBoolData[0];

        if (inspected.xFloatList == null)
            inspected.xFloatList = new XBrain.xfloatData[0];

        //Draw Xbools, XFloats and XInts
        if (Application.isPlaying)
        {
            GUIStyle bold = new GUIStyle(GUI.skin.label);
            bold.fontStyle = FontStyle.Bold;
            bold.fontSize = 12;
            if (inspected.xBoolList.Length > 0)
            {

                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUILayout.LabelField("X Bools", bold);
                for (int i = 0; i < inspected.xBoolList.Length; i++)
                {
                    var rect = EditorGUILayout.GetControlRect(true, 16f);
                    EditorGUI.LabelField(rect, i.ToString());
                    rect.x += 42f;
                    rect.width -= 42f;

                    EditorGUI.LabelField(rect, inspected.xBoolList[i].varName);
                    rect.x -= 16f;
                    rect.width = 16f;
                    bool newVal = EditorGUI.Toggle(rect, inspected.xBoolList[i].value);
                    if (newVal != inspected.xBoolList[i].value)
                    {
                        if (inspected.xBoolList[i].sincronizeAnimatorParameter && inspected.animator != null)
                            inspected.animator.SetBool(inspected.xBoolList[i].varName, newVal);

                        inspected.xBoolList[i].value = newVal;
                    }

                }
                EditorGUILayout.EndVertical();



            }
            if (inspected.xFloatList.Length > 0)
            {


                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUILayout.LabelField("X Floats", bold);
                for (int i = 0; i < inspected.xFloatList.Length; i++)
                {
                    var rect = EditorGUILayout.GetControlRect(true, 16f);
                    EditorGUI.LabelField(rect, i.ToString());
                    rect.x += 58;
                    rect.width -= 58;

                    EditorGUI.LabelField(rect, inspected.xFloatList[i].varName);
                    rect.x -= 32f;
                    rect.width = 28f;
                    var newVal = EditorGUI.FloatField(rect, inspected.xFloatList[i].value);
                    if (newVal != inspected.xFloatList[i].value)
                    {
                        if (inspected.xFloatList[i].sincronizeAnimatorParameter)
                            inspected.animator.SetFloat(inspected.xFloatList[i].varName, newVal);

                        inspected.xFloatList[i].value = newVal;
                    }
                }
                EditorGUILayout.EndVertical();

            }
            if (inspected.xIntList.Length > 0)
            {


                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUILayout.LabelField("X Ints", bold);
                for (int i = 0; i < inspected.xIntList.Length; i++)
                {
                    var rect = EditorGUILayout.GetControlRect(true, 16f);
                    EditorGUI.LabelField(rect, i.ToString());
                    rect.x += 58f;
                    rect.width -= 58f;

                    EditorGUI.LabelField(rect, inspected.xIntList[i].varName);
                    rect.x -= 32f;
                    rect.width = 28f;
                    var newVal = EditorGUI.IntField(rect, inspected.xIntList[i].value);
                    if (newVal != inspected.xIntList[i].value)
                    {
                        if (inspected.xIntList[i].sincronizeAnimatorParameter && inspected.animator != null)
                            inspected.animator.SetInteger(inspected.xIntList[i].varName, newVal);

                        inspected.xIntList[i].value = newVal;
                    }
                }
                EditorGUILayout.EndVertical();

            }

            //Log Physics iterations
            inspected.LogRigidbody = EditorGUILayout.ToggleLeft("Log Physics 2D Iteration", inspected.LogRigidbody);
            if (inspected.LogRigidbody)
            {
                if (inspected.RigidbodyIterationLogList == null)
                {
                    inspected.RigidbodyIterationLogList = new List<XBrain.RigidbodyIterationLog>();
                }
                EditorGUILayout.BeginVertical(GUI.skin.box);
                EditorGUILayout.LabelField("Physics2D Iterations", bold);

                scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUI.skin.scrollView, GUILayout.Height(300f));
                
                //Draw all iterations
                for (int i = 0; i < inspected.RigidbodyIterationLogList.Count; i++)
                {
                    if (GUILayout.Button(inspected.RigidbodyIterationLogList[i]._description))
                    {
                        Debug.Log(inspected.RigidbodyIterationLogList[i].ToString());
                        var frames = inspected.RigidbodyIterationLogList[i].stackTrace.GetFrames();
                        scriptAccessList = new List<System.Diagnostics.StackFrame>();
                        for (int ib = 2; ib < frames.Length; ib++)
                        {
                            scriptAccessList.Add(frames[ib]);
                        }
                    }
                }
                EditorGUILayout.EndScrollView();
                EditorGUILayout.BeginVertical(GUI.skin.box);
                //Draw access to iterator scritpts
                EditorGUILayout.LabelField("Iterator Scripts", bold);
                var scriptButtonStyle = new GUIStyle(GUI.skin.button);
                scriptButtonStyle.normal.textColor = Color.blue;
                for (int i = 0; scriptAccessList != null && i < scriptAccessList.Count; i++)
                {
                    string[] scriptName = scriptAccessList[i].GetFileName().Split('\\');
                    if (GUILayout.Button(scriptName[scriptName.Length-1], scriptButtonStyle))
                    {
                        //Open Scripts
                        UnityEditorInternal.InternalEditorUtility.OpenFileAtLineExternal(scriptAccessList[i].GetFileName(), scriptAccessList[i].GetFileLineNumber());

                    }
                }

                EditorGUILayout.EndVertical();
                EditorGUILayout.EndVertical();
            }
            inspected.showVariablesOnScreen = EditorGUILayout.ToggleLeft("Show Variables On Game View", inspected.showVariablesOnScreen);
        }

    }

    void LogRenderTime()
    {
        if (Event.current.type == EventType.Repaint)
        {
            var time = Time.realtimeSinceStartup - lastRenderTime;
            Debug.Log("XBrain Render time " + time);
            lastRenderTime = Time.realtimeSinceStartup;
        }
    }
}
