using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;


public class ScreenLog : MonoBehaviour {

    public bool disableAllLogs = false;
    public static bool enableCurrentLog = true;
    public GUIStyle style;
    public static ScreenLog instance;
    public int numberOfLineColors = 300;
    List<LogElement> logBuffer;
	[HideInInspector]
    public Color[] LineColors;

    private class LogElement
    {
        public string text;
        public float ExpireTime;
        public Color textColor;

        public LogElement(string _text, float duration, Color _textColor)
        {
            text = _text;
            ExpireTime = Time.time + duration;
            textColor = _textColor;
        }
    }

    // Use this for initialization
    void OnEnable () {
        instance = this;
        logBuffer = new List<LogElement>();


    }

    void OnDrawGizmosSelected()
    {
        if (LineColors==null || LineColors.Length < 1000)
        {
            GenerateRandomColors();
        }
    }

    void GenerateRandomColors()
    {
        LineColors = new Color[1000];
        for (int i = 0; i < LineColors.Length; i++)
        {
            Vector3 vectorColor = new Vector3(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f)).normalized;
            LineColors[i] = new Color(vectorColor.x, vectorColor.y, vectorColor.z, 1f);
        }
    }
	// Update is called once per frame
    public static void Log(string txt="", float duration = 0.0016f)
    {
        if (instance == null)
        {
            GameObject prefab = (GameObject)FileUtility.LoadFile("ScreenLogPrefab");
            GameObject obj = (GameObject)Instantiate(prefab);
            instance = obj.GetComponent<ScreenLog>();
            instance.logBuffer = new List<LogElement>();
        }

        if (instance.disableAllLogs || !enableCurrentLog)
            return;
        // Get call stack
        StackTrace stackTrace = new StackTrace(true);

        // Get calling method name
        var frame = stackTrace.GetFrame(1);
        var frame2 = stackTrace.GetFrame(2);
        int lineNumber = frame.GetFileLineNumber();
        txt =   frame2.GetMethod().Name+"()."+ frame.GetMethod().Name + "() " + lineNumber + " " + txt;
        
        if(instance.LineColors!=null && instance.LineColors.Length > 999)
            instance.logBuffer.Add(new LogElement(txt, duration, GetColorBasedOnLineNumber(lineNumber+ frame2.GetFileLineNumber())));
        else
            instance.logBuffer.Add(new LogElement(txt, duration, Color.white));
    }

    private static Color GetColorBasedOnLineNumber(int number)
    {
        while (number > 1000)
            number = number - 1000;

        return instance.LineColors[number];
    }

    public void FixedUpdate()
    {
		#if UNITY_ANDROID || UNITY_IPHONE
		if(UnityEngine.Input.touchCount >= 4){
			disableAllLogs = !disableAllLogs;
		}
		#endif

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            disableAllLogs = !disableAllLogs;
        }
        for (int i = 0; i < logBuffer.Count; i++)
        {
            if (Time.time > logBuffer[i].ExpireTime)
            {
                logBuffer.RemoveAt(i);
                i--;
            }
        }


    }


    public static void Log(string txt, Color color, float duration = 0.001f, int layer = 0)
    {
        if (instance.disableAllLogs || !enableCurrentLog)
            return;

        if (instance == null)
        {
            GameObject prefab = (GameObject)FileUtility.LoadFile("ScreenLogPrefab");
            GameObject obj = (GameObject)Instantiate(prefab);
            instance = obj.GetComponent<ScreenLog>();
            instance.logBuffer = new List<LogElement>();
        }

        instance.logBuffer.Add(new LogElement(txt, duration, color));
    }

    void OnGUI()
    {

        if (disableAllLogs)
            return;

        GUILayout.BeginArea(new Rect(10, Screen.height-32f, 300, 25f));
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("1fps"))
        {
            Application.targetFrameRate = 15;
            //        Time.fixedDeltaTime = 1f / 7f;
            Time.timeScale = 1f / 60f;
            QualitySettings.vSyncCount = 0;
        }
        if (GUILayout.Button("3fps"))
        {
            Application.targetFrameRate = 15;
            //        Time.fixedDeltaTime = 1f / 7f;
            Time.timeScale = 3f / 60f;
            QualitySettings.vSyncCount = 0;
        }

        if (GUILayout.Button("7fps"))
        {
            Application.targetFrameRate = 15;
    //        Time.fixedDeltaTime = 1f / 7f;
            Time.timeScale = 7f / 60f;
            QualitySettings.vSyncCount = 0;
        }
        if (GUILayout.Button("15fps"))
        {
            Application.targetFrameRate = 15;
    //        Time.fixedDeltaTime = 1f / 15f;
            Time.timeScale = 15f / 60f;
            QualitySettings.vSyncCount = 0;
        }
        if (GUILayout.Button("30fps"))
        {
            Application.targetFrameRate = 30;
   //         Time.fixedDeltaTime = 1f / 30f;
            Time.timeScale = 30f / 60f;
            QualitySettings.vSyncCount = 2;
        }
        if (GUILayout.Button("60fps"))
        {
            Application.targetFrameRate = 60;
      //      Time.fixedDeltaTime = 1f / 60f;
            Time.timeScale = 1f;
            QualitySettings.vSyncCount = 1;
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();


            GUILayout.BeginArea(new Rect(10, 10f, Screen.width * 0.55f, Screen.height - 52f));
            for (int i = 0; i < logBuffer.Count; i++)
            {
                style.normal.textColor = logBuffer[i].textColor*1.5f;

               // GUILayout.Label(logBuffer[i].text, style);
                DrawOutline(logBuffer[i].text, 1, style);
            }
            GUILayout.EndArea();
        
    }

    void DrawOutline(string t, int strength, GUIStyle style)
    {
        GUIContent content = new GUIContent(t);
        Rect r = GUILayoutUtility.GetRect(content, style);

        GUI.color = style.normal.textColor*0.333f ;
        int i;
        for (i = -strength; i <= strength; i++)
        {
            GUI.Label(new Rect(r.x - strength, r.y + i, r.width, r.height), t, style);
            GUI.Label(new Rect(r.x + strength, r.y + i, r.width, r.height), t, style);
        }
        for (i = -strength + 1; i <= strength - 1; i++)
        {
            GUI.Label(new Rect(r.x + i, r.y - strength, r.width, r.height), t, style);
            GUI.Label(new Rect(r.x + i, r.y + strength, r.width, r.height), t, style);
        }
        GUI.color = new Color(1, 1, 1, 1);

        GUI.Label(r, t, style);
    }
}
