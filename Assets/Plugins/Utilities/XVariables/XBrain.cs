using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;


public class XBrain : MonoBehaviour
{

    public Animator animator;
    public Rigidbody rigidbody;
    public Rigidbody2D rigidbody2D;
    public xBoolData[] xBoolList;
    public xfloatData[] xFloatList;
    public xintData[] xIntList;
    public bool LogRigidbody;
    public bool showVariablesOnScreen;


    [System.Serializable]
    public class xfloatData
    {
        public float value;
        public string varName;
        public bool sincronizeAnimatorParameter;
        public string variablePath;
        public MonoBehaviour script;
    }

    [System.Serializable]
    public class xintData
    {
        public int value;
        public string varName;
        public bool sincronizeAnimatorParameter;
        public string variablePath;
        public MonoBehaviour script;
    }
    public void Awake()
    {

    }
    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        RigidbodyIterationLogList = new List<RigidbodyIterationLog>();
        if (animator != null)
        {
            for (int i = 0; i < xBoolList.Length; i++)
                if (xBoolList[i].sincronizeAnimatorParameter)
                    animator.SetBool(xBoolList[i].varName, xBoolList[i].value);

            for (int i = 0; i < xFloatList.Length; i++)
                if (xFloatList[i].sincronizeAnimatorParameter)
                    animator.SetFloat(xFloatList[i].varName, xFloatList[i].value);

            for (int i = 0; i < xIntList.Length; i++)
                if (xIntList[i].sincronizeAnimatorParameter)
                    animator.SetInteger(xIntList[i].varName, xIntList[i].value);
        }
    }

    public void OnGUI()
    {
        if (!showVariablesOnScreen)
            return;


        var labelRect = new Rect(10f, 10f, 300f, 20f);
        GUI.Label(labelRect, gameObject.name);
        labelRect.y += labelRect.height;
        labelRect.height = 12f;
        var style = new GUIStyle(GUI.skin.toggle);
        style.fontSize = 9;
        style.normal.textColor = Color.green;
        for (int i = 0; xBoolList != null && i < xBoolList.Length; i++)
        {
            bool newVal = GUI.Toggle(labelRect, xBoolList[i].value, xBoolList[i].varName, style);
            if (newVal != xBoolList[i].value)
            {
                xBoolList[i].value = newVal;

                if (xBoolList[i].sincronizeAnimatorParameter)
                    animator.SetBool(xBoolList[i].varName, newVal);
            }
            labelRect.y += labelRect.height;
        }
        for (int i = 0; xFloatList != null && i < xFloatList.Length; i++)
        {
            GUI.Label(labelRect, xFloatList[i].varName + ": " + xFloatList[i].value, style);

            labelRect.y += labelRect.height;
        }
        for (int i = 0; xIntList != null && i < xIntList.Length; i++)
        {
            GUI.Label(labelRect, xIntList[i].varName + ": " + xIntList[i].value, style);

            labelRect.y += labelRect.height;
        }

    }

    #region Editor
#if UNITY_EDITOR
    public int GetXBoolIndex(int currentIndex, string varName)
    {
        if (xBoolList == null)
            xBoolList = new xBoolData[0];

        if (currentIndex >= xBoolList.Length)
            return -1;

        if (currentIndex > -1 && xBoolList[currentIndex].varName == varName)
            return currentIndex;

        for (int i = 0; xBoolList != null && i < xBoolList.Length; i++)
        {
            if (xBoolList[i].varName == varName)
                return i;
        }
        return -1;
    }
    public int GetXFloatIndex(int currentIndex, string varName)
    {
        if (xFloatList == null)
            xFloatList = new xfloatData[0];

        if (currentIndex >= xFloatList.Length)
            return -1;

        if (currentIndex > -1 && xFloatList[currentIndex].varName == varName)
            return currentIndex;

        for (int i = 0; xFloatList != null && i < xFloatList.Length; i++)
        {
            if (xFloatList[i].varName == varName)
                return i;
        }
        return -1;
    }
    public int GetXIntIndex(int currentIndex, string varName)
    {
        if (xIntList == null)
            xIntList = new xintData[0];

        if (currentIndex >= xIntList.Length)
            return -1;

        if (currentIndex > -1 && xIntList[currentIndex].varName == varName)
            return currentIndex;

        for (int i = 0; xIntList != null && i < xIntList.Length; i++)
        {
            if (xIntList[i].varName == varName)
                return i;
        }
        return -1;
    }
    public xBoolData CreateXBoolData(string _varName, bool sincronizeAnimatorParameter, string variablePath, MonoBehaviour script)
    {
        var newXBoolData = new xBoolData();
        newXBoolData.varName = _varName;
        newXBoolData.variablePath = variablePath;
        newXBoolData.script = script;
        newXBoolData.sincronizeAnimatorParameter = sincronizeAnimatorParameter;
        xBoolList = xBoolList.Add(newXBoolData);
#if UNITY_EDITOR
        Debug.Log("New xbool created " + _varName + " animatorPrameter: " + sincronizeAnimatorParameter + " path: " + variablePath);
#endif
        ResolveAnimatorBoolParameter(xBoolList.Length - 1, sincronizeAnimatorParameter, true);
        return newXBoolData;
    }
    public xfloatData CreateXFloatData(string _varName, bool sincronizeAnimatorParameter, string variablePath, MonoBehaviour script)
    {
        var newXFloatData = new xfloatData();
        newXFloatData.varName = _varName;
        newXFloatData.variablePath = variablePath;
        newXFloatData.script = script;
        newXFloatData.sincronizeAnimatorParameter = sincronizeAnimatorParameter;
        xFloatList = xFloatList.Add(newXFloatData);
#if UNITY_EDITOR
        Debug.Log("New xfloat created " + _varName + " animatorPrameter: " + sincronizeAnimatorParameter + " path: " + variablePath);
#endif
        ResolveAnimatorFloatParameter(xFloatList.Length - 1, sincronizeAnimatorParameter, true);
        return newXFloatData;
    }
    public xintData CreateXIntData(string _varName, bool sincronizeAnimatorParameter, string variablePath, MonoBehaviour script)
    {
        var newXIntData = new xintData();
        newXIntData.varName = _varName;
        newXIntData.variablePath = variablePath;
        newXIntData.script = script;
        newXIntData.sincronizeAnimatorParameter = sincronizeAnimatorParameter;
        xIntList = xIntList.Add(newXIntData);
#if UNITY_EDITOR
        UnityEngine.Debug.Log("New xfloat created " + _varName + " animatorPrameter: " + sincronizeAnimatorParameter + " path: " + variablePath);
#endif
        ResolveAnimatorIntParameter(xIntList.Length - 1, sincronizeAnimatorParameter, true);
        return newXIntData;
    }
    public void ResolveAnimatorBoolParameter(int index, bool _sincronizeAnimatorParameter, bool force = false)
    {
        if (!force && _sincronizeAnimatorParameter == xBoolList[index].sincronizeAnimatorParameter)
            return;

        xBoolList[index].sincronizeAnimatorParameter = _sincronizeAnimatorParameter;

        var animator = GetComponent<Animator>();
        if (animator == null)
            return;

        if (_sincronizeAnimatorParameter)
            AddUniqueParameter(animator, xBoolList[index].varName, AnimatorControllerParameterType.Bool);
        else
            RemoveParameter(animator, xBoolList[index].varName, AnimatorControllerParameterType.Bool);

        Debug.Log("Animator parameter resolved");
    }
    public void ResolveAnimatorFloatParameter(int index, bool _sincronizeAnimatorParameter, bool force = false)
    {
        if (!force && _sincronizeAnimatorParameter == xFloatList[index].sincronizeAnimatorParameter)
            return;

        xFloatList[index].sincronizeAnimatorParameter = _sincronizeAnimatorParameter;

        var animator = GetComponent<Animator>();
        if (animator == null)
            return;

        if (_sincronizeAnimatorParameter)
            AddUniqueParameter(animator, xFloatList[index].varName, AnimatorControllerParameterType.Float);
        else
            RemoveParameter(animator, xFloatList[index].varName, AnimatorControllerParameterType.Float);

    }
    public void ResolveAnimatorIntParameter(int index, bool _sincronizeAnimatorParameter, bool force = false)
    {
        if (!force && _sincronizeAnimatorParameter == xIntList[index].sincronizeAnimatorParameter)
            return;

        xIntList[index].sincronizeAnimatorParameter = _sincronizeAnimatorParameter;

        var animator = GetComponent<Animator>();
        if (animator == null)
            return;

        if (_sincronizeAnimatorParameter)
            AddUniqueParameter(animator, xIntList[index].varName, AnimatorControllerParameterType.Int);
        else
            RemoveParameter(animator, xIntList[index].varName, AnimatorControllerParameterType.Int);

        Debug.Log("Animator parameter resolved");
    }
    public void AddUniqueParameter(Animator animator, string parameterName, AnimatorControllerParameterType type)
    {
        if (!HasParameter(animator, parameterName, type) && animator.runtimeAnimatorController != null)
        {
            UnityEditor.Animations.AnimatorController animatorInternal = (UnityEditor.Animations.AnimatorController)animator.runtimeAnimatorController;
            if (!HasParameter(animatorInternal, parameterName, type))
            {
                Debug.Log("Adding the parameter " + parameterName);
                animatorInternal.AddParameter(parameterName, type);

                animator.runtimeAnimatorController = animatorInternal;
            }
        }
    }
    public void RemoveParameter(Animator animator, string parameterName, AnimatorControllerParameterType type)
    {
        if (HasParameter(animator, parameterName, type) && animator.runtimeAnimatorController != null)
        {
            UnityEditor.Animations.AnimatorController animatorInternal = (UnityEditor.Animations.AnimatorController)animator.runtimeAnimatorController;
            if (HasParameter(animatorInternal, parameterName, type))
            {
                Debug.Log("Removing the parameter: " + parameterName);
                RemoveParameter(animatorInternal, parameterName, type);
                animator.runtimeAnimatorController = animatorInternal;
            }
        }
    }
    public bool HasParameter(Animator animator, string paramName, AnimatorControllerParameterType type)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName && param.type == type)
                return true;
        }
        return false;
    }
    public bool RemoveParameter(UnityEditor.Animations.AnimatorController animator, string paramName, AnimatorControllerParameterType type)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName && param.type == type)
            {
                animator.RemoveParameter(param);
                return true;
            }
        }
        return false;
    }
    public bool HasParameter(UnityEditor.Animations.AnimatorController animator, string paramName, AnimatorControllerParameterType type)
    {
        foreach (AnimatorControllerParameter param in animator.parameters)
        {
            if (param.name == paramName && param.type == type)
                return true;
        }
        return false;
    }
    public void CleanUpUnusedVariables()
    {
        for (int i = 0; i < xBoolList.Length; i++)
        {
            object analyzedObj = xBoolList[i].script;
            string[] allfields = xBoolList[i].variablePath.Split('.');

            for (int ib = 0; ib < allfields.Length; ib++)
            {
                var field = analyzedObj.GetType().GetField(allfields[ib]);
                if (field != null)
                {
                    if (ib == allfields.Length - 1)
                    {
                        //Significa que o campo ainda existe, portanto esta variavel prevalecerá
                        break;
                    }
                    var obj = field.GetValue(analyzedObj); //obtem objeto pra procurar o proximo campo.
                    if (obj != null)
                    {
                        analyzedObj = obj; //Encontrou o objeto para fazer a próxima analise
                    }
                    else
                    {
                        //O objeto especificado nao foi encontrado
                    }
                }
                else
                {
                    //Não encontrou este campo no objeto analizado, significa que este campo deve ser 
                    // removido da lista de xBools/xInt/xFloat
                    var _xBoolList = ArrayUtility.ArrayToList(xBoolList);
                    _xBoolList.RemoveAt(i);
                    xBoolList = _xBoolList.ToArray();
                    i--;
                    break;
                }
            }
        }
    }
    public void UpdateAnimatorDefaultParameters()
    {
        for (int i = 0; i < xBoolList.Length; i++)
        {
            ResolveAnimatorBoolParameter(i, xBoolList[i].sincronizeAnimatorParameter, true);
        }
    }
    public string[] getXboolList()
    {
        if (xBoolList == null)
        {
            xBoolList = new xBoolData[0];
        }
        string[] list = new string[xBoolList.Length];
        for (int i = 0; i < list.Length; i++)
        {
            list[i] = xBoolList[i].varName;
        }
        return list;
    }
    void InitializeLists()
    {
        xBoolList = new xBoolData[0];
        xFloatList = new xfloatData[0];
        xIntList = new xintData[0];
    }
    public object[] getXPrimitivesList()
    {
        if (xBoolList == null)
            InitializeLists();


        string[] nameList = new string[xBoolList.Length + xFloatList.Length + xIntList.Length];
        XPrimitivesRequireds.XPrimitiveRequired.valueType[] typeList = new XPrimitivesRequireds.XPrimitiveRequired.valueType[nameList.Length];
        int[] xIndexList = new int[nameList.Length];
        for (int i = 0; i < xBoolList.Length; i++)
        {
            nameList[i] = xBoolList[i].varName;
            typeList[i] = XPrimitivesRequireds.XPrimitiveRequired.valueType._bool;
            xIndexList[i] = i;
        }
        for (int i = xBoolList.Length; i < xBoolList.Length + xIntList.Length; i++)
        {
            nameList[i] = xIntList[i - xBoolList.Length].varName;
            typeList[i] = XPrimitivesRequireds.XPrimitiveRequired.valueType._int;
            xIndexList[i] = i - xBoolList.Length;
        }
        for (int i = xBoolList.Length + xIntList.Length; i < xBoolList.Length + xIntList.Length + xFloatList.Length; i++)
        {
            nameList[i] = xFloatList[i - xBoolList.Length - xIntList.Length].varName;
            typeList[i] = XPrimitivesRequireds.XPrimitiveRequired.valueType._float;
            xIndexList[i] = i - xBoolList.Length - xIntList.Length;
        }
        return new object[] { nameList, typeList, xIndexList };
    }
#endif
    #endregion

    #region Rigidbody Intermediator
    public Vector2 velocity2D
    {
        get
        {
            return rigidbody2D.velocity;
        }
        set
        {
            if (LogRigidbody)
            {
                if (RigidbodyIterationLogList.Count > 1000)
                {
                    RigidbodyIterationLogList.RemoveRange(0, 100);
                }

                RigidbodyIterationLogList.Add(new RigidbodyIterationLog("velocity = " + value));
            }

            rigidbody2D.velocity = value;
        }
    }
    [System.NonSerialized]
    public List<RigidbodyIterationLog> RigidbodyIterationLogList;

    public class RigidbodyIterationLog
    {
        public string _description;
        public System.Diagnostics.StackTrace stackTrace;

        public RigidbodyIterationLog(string description)
        {
            stackTrace = new System.Diagnostics.StackTrace(true);
            this._description = description + " ["+ stackTrace.GetFrame(2).GetFileLineNumber()+"]";
        }

        public override string ToString()
        {
            string txt = "";
            var frames = stackTrace.GetFrames();
            for (int i = 2; i < frames.Length; i++)
            {
                string[] fileName = frames[i].GetFileName().Split('\\');
                txt += "\n<b><color=blue>" + fileName[fileName.Length - 1] + "</color></b>->" + frames[i].GetMethod().Name + "() [<color=lime>" + frames[i].GetFileLineNumber() + "</color>]";
            }
            return txt;
        }
    }
    #endregion
}
